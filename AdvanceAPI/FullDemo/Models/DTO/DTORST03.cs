using System;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for menu format for restaurant menus json file query.
    /// </summary>
    public class DTORST03
    {
        [JsonProperty("Restaurant Name")]
        public string T03F01 { get; set; }

        [JsonProperty("Menu")]
        public List<DTORST04> T03F02 { get; set; }
        
    }
}
