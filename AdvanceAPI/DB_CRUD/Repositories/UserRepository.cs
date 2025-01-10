using System;
using System.Collections.Generic;
using System.Configuration;
using DB_CRUD.POCO_Model;
using DB_CRUD.DTO;
using MySql.Data.MySqlClient;

namespace DB_CRUD.Repositories
{
    public class UserRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        // add a new user to database
        public void AddUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";  // at runtime, these @ values will be replaced
                MySqlCommand cmd = new MySqlCommand(query, conn);  // represents an sql query to be executed in mysql server.
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                conn.Open();  // establishes connection to sql server database
                cmd.ExecuteNonQuery();  // bcoz no data is returned from this query.
            }
        }

        // return list of users present in the database
        public List<UserDTO> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Id, Username, Email FROM Users";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserDTO user = new UserDTO   // Object Initialization Syntax
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Username = reader["Username"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                    users.Add(user);
                }
            }
            return users;
        }

        // update a user in the database
        public void UpdateUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Username = @Username, Email = @Email, Password = @Password WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // delete a user by it's id
        public void DeleteUser(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // get a particular user by it's id
        public User GetUserById(int id)
        {
            User usr = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Id, Username, Email, Password FROM Users WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usr = new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Username = reader["Username"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                }
            }
            return usr;
        }
    }
}