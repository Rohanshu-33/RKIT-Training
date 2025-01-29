using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for Item Calendar.
    /// </summary>
    public class DTOITH06
    {
        #region Item Calendar DTO

        /// <summary>
        /// Gets or Sets Item ID (Foreign Key to ITH02).
        /// </summary>
        [Required]
        [JsonProperty("itemId")]
        public string H06F01 { get; set; }

        /// <summary>
        /// Gets or Sets Booking Start Date.
        /// </summary>
        [Required]
        [JsonProperty("bookingStartDate")]
        public DateTime H06F02 { get; set; }

        /// <summary>
        /// Gets or Sets Booking End Date.
        /// </summary>
        [Required]
        [JsonProperty("bookingEndDate")]
        public DateTime H06F03 { get; set; }

        #endregion
    }
}
