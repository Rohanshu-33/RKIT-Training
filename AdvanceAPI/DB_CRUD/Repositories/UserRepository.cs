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

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">User object containing details to be added.</param>
        public void AddUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Retrieves a list of all users from the database.
        /// </summary>
        /// <returns>List of UserDTO objects.</returns>
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
                    UserDTO user = new UserDTO
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

        /// <summary>
        /// Updates an existing user's information in the database.
        /// </summary>
        /// <param name="user">User object containing updated details.</param>
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

        /// <summary>
        /// Deletes a user from the database by their ID.
        /// </summary>
        /// <param name="id">User ID to be deleted.</param>
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

        /// <summary>
        /// Retrieves a user from the database by their ID.
        /// </summary>
        /// <param name="id">User ID to fetch the details for.</param>
        /// <returns>User object if found, otherwise null.</returns>
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
