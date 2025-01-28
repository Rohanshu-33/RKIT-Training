using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FullDemo.Models.DTO
{
    public class DTOITH05
    {
        #region Item Image DTO

        /// <summary>
        /// Gets or Sets the Item ID. This is the foreign key to the ITH02 (Item) table.
        /// </summary>
        [Required]
        [JsonProperty("itemId")]
        public int H05F01 { get; set; }

        /// <summary>
        /// Gets or Sets the Image File Path.
        /// </summary>
        [Required]
        [StringLength(500, ErrorMessage = "Image file path cannot exceed 255 characters.")]
        [JsonProperty("imageFilePath")]
        public string H05F02 { get; set; }

        #endregion
    }
}
