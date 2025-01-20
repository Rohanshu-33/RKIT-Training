using System;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for mapping restaurant name with menu name, cost price and sell price
    /// </summary>
    public class DTORST04
    {
        [JsonProperty("Name")]
        public string T04F01 { get; set; }

        [JsonProperty("SellPrice")]
        public float T04F02 { get; set; }

        [JsonProperty("CostPrice")]
        public float T04F03 { get; set; }
    }
}
