using ServiceStack.DataAnnotations;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// ITH02 -> Item Table
    /// </summary>
    public class ITH02
    {
        #region Item Table

        /// <summary>
        /// Gets or Sets Item ID.
        /// </summary>
        [PrimaryKey]
        [Alias("H02F01")]
        public string H02F01 { get; set; }

        /// <summary>
        /// Gets or Sets User ID associated with the item.
        /// </summary>
        [Required]
        [Alias("H02F02")]
        [ForeignKey(typeof(ITH01))]
        public string H02F02 { get; set; }
        
        /// <summary>
        /// Gets or Sets Item Name.
        /// </summary>
        [Required]
        [Alias("H02F03")]
        public string H02F03 { get; set; }

        /// <summary>
        /// Gets or Sets Item Description.
        /// </summary>
        [Alias("H02F04")]
        public string H02F04 { get; set; }

        /// <summary>
        /// Gets or Sets Item Price.
        /// </summary>
        [Required]
        [Alias("H02F05")]
        public float H02F05 { get; set; }

        /// <summary>
        /// Gets or Sets Item Security Deposit.
        /// </summary>
        [Required]
        [Alias("H02F05")]
        public float H02F06 { get; set; }

        /// <summary>
        /// Gets or Sets Item Addition Date.
        /// </summary>
        [Required]
        [Alias("H02F06")]
        public DateTime H02F07 { get; set; }

        #endregion
    }
}
