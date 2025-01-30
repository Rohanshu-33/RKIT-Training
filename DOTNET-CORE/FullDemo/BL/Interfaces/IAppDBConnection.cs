using System.Data;

namespace FullDemo.BL.Interfaces
{
    /// <summary>
    /// Interface for managing database connections.
    /// </summary>
    public interface IAppDBConnection
    {
        /// <summary>
        /// Gets a database connection for interacting with the database.
        /// </summary>
        /// <returns>An <see cref="IDbConnection"/> object that represents the database connection.</returns>
        IDbConnection GetDbConnection();
    }
}
