using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleClient2.Entities
{
    public class Clima
    {
        [JsonPropertyName("date")]
        public string Fecha { get; set; }
                           
        [JsonPropertyName("temperatureC")]
        public double Temperatura { get; set; }

        [JsonPropertyName("summary")]
        public string Descripcion { get; set; }

        [JsonPropertyName("location")]
        public string Ubicacion { get; set; }
    }
}
