using FullDemo.BL.Interfaces;
using ServiceStack.OrmLite;
using System.Data;

namespace FullDemo.BL.Services
{
    public class AppDBConnectionService : IAppDBConnection
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbConnection"/> class.
        /// </summary>
        /// <param name="configuration">Configuration interface for retrieving connection strings.</param>
        public AppDBConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetDbConnection()
        {
            string connectionString = _configuration.GetConnectionString("DBConnection");
            OrmLiteConnectionFactory connectionFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);
            return connectionFactory.Open();
        }
    }
}
