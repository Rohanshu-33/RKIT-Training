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
        [Alias("R01F01")] // Maps this property to the column "R01F01"
        public int R01F01 { get; set; }

        /// <summary>
        /// Get or Set restaurant name
        /// </summary>
        [Required] // Ensures the value is not null
        [StringLength(30)] // Limits the length to 100 characters
        [Alias("R01F02")] // Maps this property to the column "R01F02"
        public string R01F02 { get; set; }

        /// <summary>
        /// Get or Set restaurant email
        /// </summary>
        [Required] // Ensures the value is not null
        [Alias("R01F03")] // Maps this property to the column "R01F03"
        public string R01F03 { get; set; }

        /// <summary>
        /// Get or Set restaurant password
        /// </summary>
        [Required] // Ensures the value is not null
        [Alias("R01F04")] // Maps this property to the column "R01F04"
        public string R01F04 { get; set; }

        /// <summary>
        /// Get or Set city of restaurant
        /// </summary>
        [Required] // Ensures the value is not null
        [StringLength(30)] // Limits the length to 50 characters
        [Alias("R01F05")] // Maps this property to the column "R01F05"
        public string R01F05 { get; set; }

        /// <summary>
        /// Get or Set restaurant start date
        /// </summary>
        [Required] // Ensures the value is not null
        [Alias("R01F06")] // Maps this property to the column "R01F06"
        public DateTime R01F06 { get; set; }
    }
}
