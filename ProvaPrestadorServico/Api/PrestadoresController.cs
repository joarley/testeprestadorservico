using ProvaPrestadorServico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProvaPrestadorServico.Api
{
    [RoutePrefix("api/prestadores")]
    public class PrestadoresController : ApiController
    {
        private readonly IPrestadorRepository prestadorRepository;
        private readonly IPesquisarEnderecoService pesquisarEnderecoService;

        public PrestadoresController(IPrestadorRepository prestadorRepository,
            IPesquisarEnderecoService pesquisarEnderecoService)
        {
            this.prestadorRepository = prestadorRepository;
            this.pesquisarEnderecoService = pesquisarEnderecoService;
        }

        [Route("todos")]
        [HttpGet]
        public IEnumerable<Prestador> Todos()
        {
            return prestadorRepository.BuscaTodos();
        }

        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(Prestador prestador)
        {
            prestador.Id = Guid.NewGuid();

            var validator = new PrestadorValidator();
            var validatorResult = validator.Validate(prestador);

            if (!validatorResult.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                           string.Join("\n", validatorResult.Errors.Select(error => error.ErrorMessage)));

            try
            {
                prestador.Endereco.Coordenadas = pesquisarEnderecoService.BuscarCoordenas(prestador.Endereco);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Endereço Invalido");
            }

            prestadorRepository.Adcionar(prestador);

            return Request.CreateResponse(HttpStatusCode.Created, prestador);
        }

        [Route("buscar/{servicoPrestado}")]
        [HttpPost]
        public HttpResponseMessage BuscarPrestadorMaisProximo(string servicoPrestado, Endereco endereco)
        {
            try
            {
                endereco.Coordenadas = pesquisarEnderecoService.BuscarCoordenas(endereco);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Endereço Invalido");
            }


            var prestadoresPorProximidade = prestadorRepository.BuscarPorServicoPrestado(servicoPrestado).
                OrderBy(prestador => endereco.CalcularDistanciaGeografica(prestador.Endereco)).
                Take(3);

            if (!prestadoresPorProximidade.Any())
                    Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Nenhum prestador encontrado para o serviço");

            try
            {
                var menorDistancia = pesquisarEnderecoService.BuscarMenorDistancia(endereco,
                    prestadoresPorProximidade.Select(x => x.Endereco));

                var melhorPrestador = prestadoresPorProximidade.First(x => x.Endereco == menorDistancia.Destino);

                return Request.CreateResponse(new
                {
                    Distancia = menorDistancia.Valor,
                    Prestador = melhorPrestador
                });
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Erro ao buscar melhor prestador");
            }
        }
    }
}
