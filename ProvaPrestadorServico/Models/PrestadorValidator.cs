using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPrestadorServico.Models
{
    class PrestadorValidator : AbstractValidator<Prestador>
    {
        public PrestadorValidator()
        {
            RuleFor(prestador => prestador.Id).NotEmpty().WithMessage("Id é obrigatório") ;
            RuleFor(prestador => prestador.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(prestador => prestador.Telefone).NotEmpty().WithMessage("Telefone é obrigatório");
            RuleFor(prestador => prestador.ServicoPrestado).NotEmpty().WithMessage("Serviço prestado é obrigatório");
            RuleFor(prestador => prestador.Endereco).NotNull().WithMessage("Endereço invalido").SetValidator(new EnderecoValidator());
        }
    }
}
