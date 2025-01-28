namespace FullDemo.Models.ENUM
{
    /// <summary>
    /// Represents the status of an item in the system.
    /// </summary>
    public enum EnmStatus
    {
        /// <summary>
        /// Indicates that the item is pending action.
        /// </summary>
        Pending,

        /// <summary>
        /// Indicates that the item has been collected.
        /// </summary>
        Collected,

        /// <summary>
        /// Indicates that the item has been returned.
        /// </summary>
        Returned
    }
}
