using ServiceStack.DataAnnotations;
using System;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// Menu Table
    /// </summary>
    [Alias("RST02")]
    sealed public class RST02
    {
        /// <summary>
        /// Get or Set menu id (AUTO-INCREMENT)
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        [Alias("T02F01")]
        public int T02F01 { get; set; }

        /// <summary>
        /// Get or Set restaurant id (IT IS FOREIGN KEY FROM RST01)
        /// </summary>
        [ForeignKey(typeof(RST01), OnDelete = "CASCADE")]
        [Required]
        [Alias("T02F02")]
        public int T02F02 { get; }

        /// <summary>
        /// Get or Set menu name
        /// </summary>
        [Required]
        [Alias("T02F03")]
        public string T02F03 { get; set; }

        /// <summary>
        /// Get or Set menu price
        /// </summary>
        [Required]
        [Alias("T02F04")]
        public float T02F04 { get; set; }

        /// <summary>
        /// Get or Set menu cost price
        /// </summary>
        [Required]
        [Alias("T02F05")]
        public float T02F05 { get; set; }

        /// <summary>
        /// Get or Set menu creation date
        /// </summary>
        [Required]
        [Alias("T02F06")]
        public DateTime T02F06 { get; set; }
    }
}
