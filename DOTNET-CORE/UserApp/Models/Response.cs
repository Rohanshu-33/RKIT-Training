namespace UserApp.Models
{
    /// <summary>
    /// Represents a standard response structure for API operations.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or Sets the success status of the operation.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or Sets the message associated with the response.
        /// Typically used for error descriptions or success messages.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets the data associated with the response.
        /// Can hold any type of data related to the operation's result.
        /// </summary>
        public dynamic Data { get; set; }
    }
}
