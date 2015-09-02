using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPrestadorServico.Models
{
    public class Prestador
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string ServicoPrestado { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
