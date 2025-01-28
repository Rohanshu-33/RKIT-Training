using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FullDemo.Models.ENUM;

namespace FullDemo.Models.DTO
{
    public class DTOITH08
    {
        #region Booking Status DTO

        /// <summary>
        /// Gets or Sets the Item ID. This is the foreign key to the ITH02 (Item) table.
        /// </summary>
        [Required]
        [JsonProperty("bookingId")]
        public int H08F01 { get; set; }

        /// <summary>
        /// Gets or Sets the Image File Path.
        /// </summary>
        [Required]
        [JsonProperty("bookingStatus")]
        public EnmStatus H08F02 { get; set; }

        #endregion
    }
}
