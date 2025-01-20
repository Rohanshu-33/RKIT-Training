using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for Add Menu, Update Menu and View Menu from Restaurant perspective
    /// </summary>
    public class DTORST02
    {
        /// <summary>
        /// Get or Set menu id
        /// </summary>
        [JsonProperty("T02201")]
        public int? T02F01 { get; set; }

        /// <summary>
        /// Get or Set restaurant id
        /// </summary>
        [JsonProperty("T02202")]
        [Range(1, int.MaxValue, ErrorMessage = "Restaurant ID must be a positive value.")]
        [Required(ErrorMessage = "Restaurant ID is required.")]
        public int T02F02 { get; set; }

        /// <summary>
        /// Get or Set menu name
        /// </summary>
        [JsonProperty("T02203")]
        [Required(ErrorMessage = "Menu name is required.")]
        [StringLength(30, ErrorMessage = "Menu name cannot exceed 30 characters.")]
        public string T02F03 { get; set; }

        /// <summary>
        /// Get or Set menu price
        /// </summary>
        [JsonProperty("T02204")]
        [Required(ErrorMessage = "Menu price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public float T02F04 { get; set; }

        /// <summary>
        /// Get or Set menu price
        /// </summary>
        [JsonProperty("T02205")]
        [Required(ErrorMessage = "Menu cost price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost price must be a positive value.")]
        public float T02F05 { get; set; }

        /// <summary>
        /// Get or Set menu start date
        /// </summary>
        [JsonProperty("T02206")]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime T02F06 { get; set; }
    }
}