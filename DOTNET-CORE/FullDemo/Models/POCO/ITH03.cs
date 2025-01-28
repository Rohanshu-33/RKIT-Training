using ServiceStack.DataAnnotations;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// ITH03 -> Item Images Table
    /// </summary>
    [CompositeKey(nameof(H03F01), nameof(H03F02))]
    [Alias("ITH03")]
    public class ITH03
    {
        #region Item Images table
        /// <summary>
        /// Gets or Sets Item ID (Foreign Key to ITH02).
        /// </summary>
        [Required]
        [Alias("H03F01")]
        [ForeignKey(typeof(ITH02))]
        public int H03F01 { get; set; }

        /// <summary>
        /// Gets or Sets Image File Path.
        /// </summary>
        [Required, StringLength(500)]
        [Alias("H03F02")]
        public string H03F02 { get; set; }
        #endregion
    }
}
