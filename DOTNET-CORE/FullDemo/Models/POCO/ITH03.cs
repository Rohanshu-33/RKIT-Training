using ServiceStack.DataAnnotations;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// ITH03 -> Item Images Table
    /// </summary>
    public class ITH03
    {
        #region Item Images table
        /// <summary>
        /// Gets or Sets Item ID (Foreign Key to ITH02).
        /// Gets or Sets Item ID (Foreign Key to ITH02).
        /// </summary>
        [Required]
        [Alias("H03F01")]
        [ForeignKey(typeof(ITH02))]
        public string H03F01 { get; set; }

        /// <summary>
        /// Gets or Sets Image File Path.
        /// </summary>
        [Required]
        [Alias("H03F02")]
        public string H03F02 { get; set; }
        #endregion
    }
}
