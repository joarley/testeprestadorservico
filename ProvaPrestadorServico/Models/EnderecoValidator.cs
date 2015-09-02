using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPrestadorServico.Models
{
    class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(endereco => endereco.Logradouro).NotEmpty().WithMessage("Logradouro é obrigatório");
            RuleFor(endereco => endereco.Bairro).NotEmpty().WithMessage("Bairro é obrigatório");
            RuleFor(endereco => endereco.Cidade).NotEmpty().WithMessage("Cidade é obrigatório");
            RuleFor(endereco => endereco.Estado).NotEmpty().WithMessage("Estado é obrigatório");
            RuleFor(endereco => endereco.Cep).NotEmpty().WithMessage("Cep é obrigatório");
        }
    }
}
