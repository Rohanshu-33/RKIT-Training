using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    public class DTOITH04
    {
        #region Update Item

        /// <summary>
        /// Gets or Sets the Item ID.
        /// </summary>
        [JsonProperty("itemId")]
        [Required(ErrorMessage = "Item ID is required.")]
        public int H04F01 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Name.
        /// </summary>
        [JsonProperty("itemName")]
        [StringLength(50, ErrorMessage = "Item Name cannot exceed 50 characters.")]
        public string H04F02 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Description.
        /// </summary>
        [JsonProperty("itemDescription")]
        [StringLength(100, ErrorMessage = "Item Description cannot exceed 100 characters.")]
        public string H04F03 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Price.
        /// </summary>
        [JsonProperty("itemPrice")]
        [Range(0, double.MaxValue, ErrorMessage = "Item Price must be a positive value.")]
        public float H04F04 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Security Deposit.
        /// </summary>
        [JsonProperty("itemSecurityDeposit")]
        [Range(0, double.MaxValue, ErrorMessage = "Security Deposit must be a positive value.")]
        public float H04F05 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Addition/ Modification  Date.
        /// </summary>
        [JsonProperty("itemAdditionDate")]
        public DateTime H04F06 { get; set; }

        #endregion
    }
}
