using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RadioPlayerLib.ViewModel
{
    public class FrequencyViewModel
    {
        [JsonProperty("program")]
        public string Program { get; set; }

        [JsonProperty("regional_program")]
        public string RegionalProgram { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

    }
}
