using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for Menu
    /// </summary>
    public class DTORST02
    {
        /// <summary>
        /// Get or Set menu id
        /// </summary>
        [JsonProperty("M01101")]
        [Range(1, int.MaxValue, ErrorMessage = "Menu ID must be a positive value.")]
        public int M01F01 { get; set; }

        /// <summary>
        /// Get or Set restaurant id
        /// </summary>
        [JsonProperty("M01102")]
        [Range(1, int.MaxValue, ErrorMessage = "Restaurant ID must be a positive value.")]
        [Required(ErrorMessage = "Restaurant ID is required.")]
        public int M01F02 { get; }

        /// <summary>
        /// Get or Set menu name
        /// </summary>
        [JsonProperty("M01103")]
        [Required(ErrorMessage = "Menu name is required.")]
        [StringLength(30, ErrorMessage = "Menu name cannot exceed 30 characters.")]
        public string M01F03 { get; set; }

        /// <summary>
        /// Get or Set menu price
        /// </summary>
        [JsonProperty("M01104")]
        [Required(ErrorMessage = "Menu price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public float M01F04 { get; set; }

        /// <summary>
        /// Get or Set menu start date
        /// </summary>
        [JsonProperty("M01106")]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime M01F06 { get; set; }
    }
}