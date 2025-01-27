using System;
using ServiceStack.DataAnnotations;

namespace FullDemo.Models.POCO
{
    /// <summary>
    /// Restaurant Table
    /// </summary>
    [Alias("RST01")] // Maps the class to the database table "RST01"
    sealed public class RST01
    {
        /// <summary>
        /// Get or Set restaurant id
        /// </summary>
        [PrimaryKey] // Marks this as the primary key
        [AutoIncrement] // Indicates this value is auto-incremented in the database
        [Alias("T01F01")] // Maps this property to the column "R01F01"
        public int T01F01 { get; set; }

        /// <summary>
        /// Get or Set restaurant name
        /// </summary>
        [Required] // Ensures the value is not null
        [StringLength(30)] // Limits the length to 30 characters
        [Alias("T01F02")] // Maps this property to the column "R01F02"
        public string T01F02 { get; set; }

        /// <summary>
        /// Get or Set restaurant email
        /// </summary>
        [Required] // Ensures the value is not null
        [Alias("T01F03")] // Maps this property to the column "R01F03"
        public string T01F03 { get; set; }

        /// <summary>
        /// Get or Set restaurant password
        /// </summary>
        [Required] // Ensures the value is not null
        [Alias("T01F04")] // Maps this property to the column "R01F04"
        public string T01F04 { get; set; }

        /// <summary>
        /// Get or Set city of restaurant
        /// </summary>
        [Required] // Ensures the value is not null
        [StringLength(30)] // Limits the length to 50 characters
        [Alias("T01F05")] // Maps this property to the column "R01F05"
        public string T01F05 { get; set; }

        /// <summary>
        /// Get or Set restaurant start date
        /// </summary>
        [Required] // Ensures the value is not null
        [Alias("T01F06")] // Maps this property to the column "R01F06"
        public DateTime T01F06 { get; set; }
    }
}
