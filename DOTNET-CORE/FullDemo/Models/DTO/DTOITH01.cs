using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for User Signup.
    /// </summary>
    public class DTOITH01
    {
        #region User Signup
        /// <summary>
        /// Gets or Sets the User Name.
        /// </summary>
        [JsonProperty("userName")]
        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "User Name should be between 2 and 50 characters.")]
        public string H01F02 { get; set; }

        /// <summary>
        /// Gets or Sets the Email Address.
        /// </summary>
        [JsonProperty("email")]
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
        [StringLength(50, ErrorMessage = "Email Address should not exceed 50 characters.")]
        public string H01F03 { get; set; }

        /// <summary>
        /// Gets or Sets the Password.
        /// </summary>
        [JsonProperty("password")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters.")]
        public string H01F04 { get; set; }

        /// <summary>
        /// Gets or Sets the Contact Number.
        /// </summary>
        [JsonProperty("contactNumber")]
        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid Contact Number format.")]
        public string H01F05 { get; set; }

        /// <summary>
        /// Gets or Sets the User Address.
        /// </summary>
        [JsonProperty("address")]
        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Address must be between 2 and 100 characters.")]
        public string H01F06 { get; set; }

        /// <summary>
        /// Gets or Sets the User Registration Date.
        /// </summary>
        [JsonProperty("registeredDate")]
        [Required(ErrorMessage = "Registration date is required.")]
        public DateTime H01F07 { get; set; }
        #endregion
    }
}
