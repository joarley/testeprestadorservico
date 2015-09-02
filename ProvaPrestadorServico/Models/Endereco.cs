using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaPrestadorServico.Models
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public Coordenadas Coordenadas { get; set; }

        public double CalcularDistanciaGeografica(Endereco endereco)
        {
            return CalcularDistanciaHaversine(
                this.Coordenadas.Latitude, this.Coordenadas.Longitude,
                endereco.Coordenadas.Latitude, endereco.Coordenadas.Longitude);
        }

        private double CalcularDistanciaHaversine(double lat1, double lon1, double lat2, double lon2)
        {
            //Fonte: http://rosettacode.org/wiki/Haversine_formula#C.23
            Func<double, double> toRadians = x => Math.PI * x / 180.0;

            var R = 6372.8; // In kilometers
            var dLat = toRadians(lat2 - lat1);
            var dLon = toRadians(lon2 - lon1);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return R * 2 * Math.Asin(Math.Sqrt(a));
        }
    }
}
