using Newtonsoft.Json; 
using System.Collections.Generic; 
namespace wether{ 

    public class WeatherData    {
        [JsonProperty("lat")]
        public double Lat { get; set; } 

        [JsonProperty("lon")]
        public double Lon { get; set; } 

        [JsonProperty("timezone")]
        public string Timezone { get; set; } 

        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; } 

        [JsonProperty("current")]
        public Current Current { get; set; } 

        [JsonProperty("daily")]
        public List<Daily> Daily { get; set; }

        [JsonProperty("hourly")]
        public List<Hourly> Hourly { get; set; }

    }

}