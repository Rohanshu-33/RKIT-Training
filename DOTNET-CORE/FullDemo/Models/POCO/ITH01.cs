using ServiceStack.DataAnnotations;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// ITH01 -> User Table
    /// </summary>
    [Alias("ITH01")]
    public class ITH01
    {
        #region User Table

        /// <summary>
        /// Gets or Sets User ID.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        [Alias("H01F01")]
        public int H01F01 { get; set; }

        /// <summary>
        /// Gets or Sets User Name.
        /// </summary>
        [Required, StringLength(50, MinimumLength = 2)]
        [Alias("H01F02")]
        public string H01F02 { get; set; }

        /// <summary>
        /// Gets or Sets Email Address.
        /// </summary>
        [Required, StringLength(50), Unique]
        [Alias("H01F03")]
        public string H01F03 { get; set; }

        /// <summary>
        /// Gets or Sets Password.
        /// </summary>
        [Required, StringLength(100, MinimumLength = 8)]
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
        /// Gets or Sets User Address.
        /// </summary>
        [Required, Unique, StringLength(100)]
        [Alias("H01F06")]
        public string H01F06 { get; set; }

        /// <summary>
        /// Gets or Sets Date of Registration.
        /// </summary>
        [Required]
        [Alias("H01F07")]
        public DateTime H01F07 { get; set; }

        #endregion
    }
}
