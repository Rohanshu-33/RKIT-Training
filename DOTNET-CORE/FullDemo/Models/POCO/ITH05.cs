using FullDemo.Models.ENUM;
using ServiceStack.DataAnnotations;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// ITH05 -> Bookings Table
    /// </summary>
    [Alias("ITH05")]
    public class ITH05
    {
        #region Bookings Table
        /// <summary>
        /// Gets or Sets Renter ID (Foreign Key to User Table).
        /// </summary>
        [Required]
        [Alias("H05F01")]
        [ForeignKey(typeof(ITH01))]
        public string H05F01 { get; set; }

        /// <summary>
        /// Gets or Sets Seeker ID (Foreign Key to User Table).
        /// </summary>
        [Required]
        [Alias("H05F02")]
        [ForeignKey(typeof(ITH01))]
        public string H05F02 { get; set; }

        /// <summary>
        /// Gets or Sets Item ID (Foreign Key to Item Table).
        /// </summary>
        [Required]
        [Alias("H05F03")]
        [References(typeof(ITH02))]
        public string H05F03 { get; set; }

        /// <summary>
        /// Gets or Sets Total Price of the Booking.
        /// </summary>
        [Required]
        [Alias("H05F04")]
        public float H05F04 { get; set; }

        /// <summary>
        /// Gets or Sets Security Deposit of the Booking.
        /// </summary>
        [Required]
        [Alias("H05F05")]
        public float H05F05 { get; set; }

        /// <summary>
        /// Gets or Sets Reservation Start Date.
        /// </summary>
        [Required]
        [Alias("H05F06")]
        public DateTime H05F06 { get; set; }

        /// <summary>
        /// Gets or Sets Reservation End Date.
        /// </summary>
        [Required]
        [Alias("H05F07")]
        public DateTime H05F07 { get; set; }

        /// <summary>
        /// Gets or Sets Booking Status.
        /// </summary>
        [Required]
        [Alias("H05F08")]
        public EnmStatus H05F08 { get; set; }
        #endregion
    }
}
