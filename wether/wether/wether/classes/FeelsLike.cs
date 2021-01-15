using Newtonsoft.Json; 
namespace wether{ 

    public class FeelsLike    {
        [JsonProperty("day")]
        public double Day { get; set; } 

        [JsonProperty("night")]
        public double Night { get; set; } 

        [JsonProperty("eve")]
        public double Eve { get; set; } 

        [JsonProperty("morn")]
        public double Morn { get; set; } 
    }

}