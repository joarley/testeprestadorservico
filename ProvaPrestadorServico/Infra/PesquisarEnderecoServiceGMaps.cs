using Google.Maps;
using Google.Maps.DistanceMatrix;
using Google.Maps.Geocoding;
using ProvaPrestadorServico.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaPrestadorServico.Infra
{
    public class PesquisarEnderecoServiceGMaps : IPesquisarEnderecoService
    {
        public Coordenadas BuscarCoordenas(Endereco endereco)
        {
            var gmapsRequest = new GeocodingRequest();

            gmapsRequest.Address = string.Format("{0}, {1}, {2} - {3}, {4}, {5}",
                    endereco.Logradouro,
                    endereco.Numero,
                    endereco.Bairro,
                    endereco.Cidade,
                    endereco.Estado,
                    endereco.Cep);
            gmapsRequest.Sensor = false;
            gmapsRequest.Language = "pt";

            var gmapsResponse = new GeocodingService().GetResponse(gmapsRequest);

            if (gmapsResponse.Status != ServiceResponseStatus.Ok)
                throw new Exception();

            return new Coordenadas()
            {
                Latitude = gmapsResponse.Results.First().Geometry.Location.Latitude,
                Longitude = gmapsResponse.Results.First().Geometry.Location.Longitude
            };
        }

        public Distancia BuscarMenorDistancia(Endereco origem, IEnumerable<Endereco> destinos)
        {
            var distanceMatrixRequest = new DistanceMatrixRequest()
            {
                Units = Units.metric,
                Mode = TravelMode.walking,
                Language = "pt",
                Sensor = false
            };

#pragma warning disable 0618

            distanceMatrixRequest.AddOrigin(new Waypoint((decimal)origem.Coordenadas.Latitude,
                (decimal)origem.Coordenadas.Longitude));

            var waypointDestinos = destinos.Select(
                    destino => new Waypoint(
                        (decimal)destino.Coordenadas.Latitude, (decimal)destino.Coordenadas.Longitude));

#pragma warning restore 0618

            foreach (var waypoint in waypointDestinos)
                distanceMatrixRequest.AddDestination(waypoint);

            var distanceMatrixResponse = new DistanceMatrixService().GetResponse(distanceMatrixRequest);

            if (distanceMatrixResponse.Status != ServiceResponseStatus.Ok)
                throw new Exception();

            var distancias = distanceMatrixResponse.Rows[0].Elements.
                Zip(destinos, (matrix, destino) =>
                    new Distancia(origem, destino, int.Parse(matrix.distance.Value)));

            return distancias.OrderBy(x => x.Valor).First();
        }
    }
}
