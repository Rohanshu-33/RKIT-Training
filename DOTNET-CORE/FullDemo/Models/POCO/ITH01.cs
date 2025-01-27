using ServiceStack.DataAnnotations;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// ITH01 -> User Table
    /// </summary>
    public class ITH01
    {
        #region User Table

        /// <summary>
        /// Gets or Sets User ID.
        /// </summary>
        [PrimaryKey]
        [Alias("H01F01")]
        public string H01F01 { get; set; }

        /// <summary>
        /// Gets or Sets User Name.
        /// </summary>
        [Required]
        [Alias("H01F02")]
        public string H01F02 { get; set; }

        /// <summary>
        /// Gets or Sets Email Address.
        /// </summary>
        [Required]
        [Unique]
        [Alias("H01F03")]
        public string H01F03 { get; set; }

        /// <summary>
        /// Gets or Sets Password.
        /// </summary>
        [Required]
        [Alias("H01F04")]
        public string H01F04 { get; set; }

        /// <summary>
        /// Gets or Sets Contact Number.
        /// </summary>
        [Required]
        [Unique]
        [Alias("H01F05")]
        public string H01F05 { get; set; }

        /// <summary>
        /// Gets or Sets Date of Registration.
        /// </summary>
        [Required]
        [Alias("H01F06")]
        public DateTime H01F07 { get; set; }

        #endregion
    }
}
