using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPrestadorServico.Models
{
    public interface IPesquisarEnderecoService
    {
        Coordenadas BuscarCoordenas(Endereco endereco);
        Distancia BuscarMenorDistancia(Endereco origem, IEnumerable<Endereco> destinos);
    }
}
