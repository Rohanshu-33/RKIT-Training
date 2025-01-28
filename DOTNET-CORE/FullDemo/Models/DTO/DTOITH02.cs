using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FullDemo.Models.DTO
{
    public class DTOITH02
    {
        #region User Login

        /// <summary>
        /// Gets or Sets the Email Address for User Login.
        /// </summary>
        [JsonProperty("email")]
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
        [StringLength(50, ErrorMessage = "Email Address should not exceed 50 characters.")]
        public string H02F01 { get; set; }

        /// <summary>
        /// Gets or Sets the Password for User Login.
        /// </summary>
        [JsonProperty("password")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 100 characters.")]
        public string H02F02 { get; set; }

        #endregion
    }
}
