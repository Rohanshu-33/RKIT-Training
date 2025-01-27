using ServiceStack.DataAnnotations;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// ITH04 -> Item Calendar Table
    /// </summary>
    public class ITH04
    {
        #region Item Calendar
        /// <summary>
        /// Gets or Sets Item ID (Foreign Key to ITH02).
        /// </summary>
        [Required]
        [Alias("H04F01")]
        [ForeignKey(typeof(ITH02))]
        public string H04F01 { get; set; }

        /// <summary>
        /// Gets or Sets Booking Start Date.
        /// </summary>
        [Required]
        [Alias("H04F02")]
        public DateTime H04F02 { get; set; }

        /// <summary>
        /// Gets or Sets Booking End Date.
        /// </summary>
        [Required]
        [Alias("H04F03")]
        public DateTime H04F03 { get; set; }
        #endregion
    }
}
