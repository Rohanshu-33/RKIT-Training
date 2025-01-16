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
        [Alias("M01F01")]
        public int M01F01 { get; set; }

        /// <summary>
        /// Get or Set restaurant id (IT IS FOREIGN KEY FROM RST01)
        /// </summary>
        [ForeignKey(typeof(RST01), OnDelete = "CASCADE")]
        [Required]
        [Alias("M01F02")]
        public int M01F02 { get; }

        /// <summary>
        /// Get or Set menu name
        /// </summary>
        [Required]
        [Alias("M01F03")]
        public string M01F03 { get; set; }

        /// <summary>
        /// Get or Set menu price
        /// </summary>
        [Required]
        [Alias("M01F04")]
        public float M01F04 { get; set; }

        /// <summary>
        /// Get or Set menu cost price
        /// </summary>
        [Required]
        [Alias("M01F05")]
        public float M01F05 { get; set; }

        /// <summary>
        /// Get or Set menu creation date
        /// </summary>
        [Required]
        [Alias("M01F06")]
        public DateTime M01F05 { get; set; }
    }
}
