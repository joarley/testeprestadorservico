using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaPrestadorServico.Models
{
    public class Distancia
    {
        public int Valor { get; private set; }
        public Endereco Origem { get; private set; }
        public Endereco Destino { get; private set; }

        public Distancia(Endereco origem, Endereco destino, int valor)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Valor = valor;
        }        
    }
}
