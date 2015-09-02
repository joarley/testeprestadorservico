using ProvaPrestadorServico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPrestadorServico.Infra
{
    class PrestadorRepositoryInMemory : IPrestadorRepository
    {
        private List<Prestador> prestadores = new List<Prestador>();

        public void Adcionar(Prestador prestador)
        {
            prestadores.Add(prestador);
        }

        public IEnumerable<Prestador> BuscaTodos()
        {
            return prestadores;
        }

        public IEnumerable<Prestador> BuscarPorServicoPrestado(string servicoPrestado)
        {
            return prestadores.Where(x => x.ServicoPrestado == servicoPrestado);
        }
    }
}
