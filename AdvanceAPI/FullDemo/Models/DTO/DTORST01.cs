using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for Restaurant
    /// </summary>
    public class DTORST01
    {
        /// <summary>
        /// Get or Set restaurant id
        /// </summary>
        [JsonProperty("R01101")]
        [Range(1, int.MaxValue, ErrorMessage = "Restaurant ID must be positive.")]
        public int R01F01 { get; set; }

        /// <summary>
        /// Get or Set restaurant name
        /// </summary>
        [JsonProperty("R01102")]
        [Required(ErrorMessage = "Restaurant name is required.")]
        [StringLength(30, ErrorMessage = "Restaurant name can't exceed 30 characters.")]
        public int R01F02 { get; set; }

        /// <summary>
        /// Get or Set restaurant email
        /// </summary>
        [JsonProperty("R01103")]
        [Required(ErrorMessage = "Restaurant email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public int R01F03 { get; set; }

        /// <summary>
        /// Get or Set restaurant password
        /// </summary>
        [JsonProperty("R01104")]
        [Required(ErrorMessage = "Restaurant password is required.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters.")]
        public int R01F04 { get; set; }


        /// <summary>
        /// Get or Set city of restaurant
        /// </summary>
        [JsonProperty("R01105")]
        [Required(ErrorMessage = "City is required.")]
        [StringLength(30, ErrorMessage = "City name cannot exceed 30 characters.")]
        public string R01F05 { get; set; }

        /// <summary>
        /// Get or Set restaurant start date
        /// </summary>
        [JsonProperty("R01106")]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime R01F06 { get; set; }
    }
}
