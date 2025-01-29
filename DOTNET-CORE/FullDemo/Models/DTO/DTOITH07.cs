using FullDemo.Models.ENUM;
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for Bookings.
    /// </summary>
    public class DTOITH07
    {
        #region Bookings DTO

        /// <summary>
        /// Gets or Sets Renter ID (Foreign Key to User Table).
        /// </summary>
        [Required]
        [JsonProperty("renterId")]
        public string H07F01 { get; set; }

        /// <summary>
        /// Gets or Sets Seeker ID (Foreign Key to User Table).
        /// </summary>
        [Required]
        [JsonProperty("seekerId")]
        public string H07F02 { get; set; }

        /// <summary>
        /// Gets or Sets Item ID (Foreign Key to Item Table).
        /// </summary>
        [Required]
        [JsonProperty("itemId")]
        public string H07F03 { get; set; }

        /// <summary>
        /// Gets or Sets Total Price of the Booking.
        /// </summary>
        [Required]
        [JsonProperty("totalPrice")]
        public float H07F04 { get; set; }

        /// <summary>
        /// Gets or Sets Security Deposit of the Booking.
        /// </summary>
        [Required]
        [JsonProperty("securityDeposit")]
        public float H07F05 { get; set; }

        /// <summary>
        /// Gets or Sets Reservation Start Date.
        /// </summary>
        [Required]
        [JsonProperty("reservationStartDate")]
        public DateTime H07F06 { get; set; }

        /// <summary>
        /// Gets or Sets Reservation End Date.
        /// </summary>
        [Required]
        [JsonProperty("reservationEndDate")]
        public DateTime H07F07 { get; set; }

        /// <summary>
        /// Gets or Sets Booking Status.
        /// </summary>
        [Required]
        [JsonProperty("bookingStatus")]
        public EnmStatus H07F08 { get; set; }

        #endregion
    }
}
