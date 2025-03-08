using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for Adding Item.
    /// </summary>
    public class DTOITH03
    {
        #region Add New Item

        /// <summary>
        /// Gets or Sets the User ID associated with the item.
        /// </summary>
        [JsonProperty("userId")]
        //[Required(ErrorMessage = "User ID is required.")]
        public int H03F02 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Name.
        /// </summary>
        [JsonProperty("itemName")]
        [Required(ErrorMessage = "Item Name is required.")]
        [StringLength(50, ErrorMessage = "Item Name cannot exceed 50 characters.")]
        public string H03F03 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Description.
        /// </summary>
        [JsonProperty("itemDescription")]
        [Required(ErrorMessage = "Item Description is required.")]
        [StringLength(100, ErrorMessage = "Item Description cannot exceed 100 characters.")]
        public string H03F04 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Price.
        /// </summary>
        [JsonProperty("itemPrice")]
        [Required(ErrorMessage = "Item Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Item Price must be a positive value.")]
        public float H03F05 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Security Deposit.
        /// </summary>
        [JsonProperty("itemSecurityDeposit")]
        [Required(ErrorMessage = "Item Security Deposit is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Security Deposit must be a positive value.")]
        public float H03F06 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Category.
        /// </summary>
        [JsonProperty("itemDescription")]
        [Required(ErrorMessage = "Item Category is required.")]
        [StringLength(50, ErrorMessage = "Item Category cannot exceed 50 characters.")]
        public string H03F07 { get; set; }

        /// <summary>
        /// Gets or Sets the Item Addition Date.
        /// </summary>
        [JsonProperty("itemAdditionDate")]
        [Required(ErrorMessage = "Item Addition Date is required.")]
        public DateTime H03F08 { get; set; }

        #endregion
    }
}
