using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPrestadorServico.Models
{
    public interface IPrestadorRepository
    {
        void Adcionar(Prestador prestador);
        IEnumerable<Prestador> BuscaTodos();
        IEnumerable<Prestador> BuscarPorServicoPrestado(string servicoPrestado);
    }
}
