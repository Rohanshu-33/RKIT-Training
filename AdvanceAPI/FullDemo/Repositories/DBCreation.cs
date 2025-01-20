using System;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using FullDemo.Models.POCO;

namespace FullDemo.Repositories
{
    public class DBCreation
    {
        private string _connectionString;
        private IDbConnectionFactory _dbFactory;

        public DBCreation()
        {
            _connectionString = "Server=localhost;Database=rbcollege;User=Admin;Password=gs@123;";
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        public void ConnectToMySQL()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.CreateTableIfNotExists(typeof(RST01), typeof(RST02));
                    Console.WriteLine("Database tables created successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }
        }
    }
}
