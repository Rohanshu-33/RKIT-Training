using System;
using ORMConsoleApp.BL.Service;
using ORMConsoleApp.Models.DTO;
using ORMConsoleApp.Models.ENUM;

namespace ORMConsoleApp.Controllers
{
    public class CRUDClass
    {
        internal static BLUser _objBLUser = new BLUser();

        /// <summary>
        /// Retrieves and displays all users from the database.
        /// </summary>
        internal static void GetAllUsers()
        {
            var users = _objBLUser.GetAll();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.P01F01}, Username: {user.P01F02}," +
                        $" Password: {user.P01F03}, Age: {user.P01F04}, Created At: {user.P01F05}");
                }
            }
            else
            {
                Console.WriteLine("No users found.");
            }
        }

        /// <summary>
        /// Retrieves and displays a user by their ID.
        /// </summary>
        internal static void GetUserById()
        {
            Console.Write("Enter User ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = _objBLUser.Get(id);
            if (user != null)
            {
                Console.WriteLine($"ID: {user.P01F01}, Username: {user.P01F02}," +
                        $" Password: {user.P01F03}, Age: {user.P01F04}, Created At: {user.P01F05}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        internal static void AddNewUser()
        {
            Console.Write("Enter User ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = new DTOUSR01
            {
                P01F01 = id,
                P01F02 = GetStringInput("Enter username: "),
                P01F03 = GetStringInput("Enter password: "),
                P01F04 = GetIntInput("Enter user age: "),
                P01F05 = DateTime.Now
            };

            var validationResults = DTOValidateHelper.ValidateDTO(user);
            if (validationResults.Count > 0)
            {
                foreach (var error in validationResults)
                {
                    Console.WriteLine($"Validation Error: {error}");
                }
                return;
            }

            _objBLUser.Type = EnmType.A;
            var response = _objBLUser.Validation(user);
            if (response.IsError)
            {
                Console.WriteLine(response.Message);
                return;
            }
            response = _objBLUser.Save();
            Console.WriteLine($"Error: {response.IsError} Message: {response.Message}");
        }

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        internal static void UpdateUser()
        {
            Console.Write("Enter User ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = _objBLUser.Get(id);

            if (user != null)
            {
                var updatedUser = new DTOUSR01
                {
                    P01F01 = id,
                    P01F02 = GetStringInput("Enter user's new name: ", user.P01F02),
                    P01F03 = GetStringInput("Enter user's new password: ", user.P01F03),
                    P01F04 = GetIntInput("Enter user's new age: ", user.P01F04),
                    P01F05 = user.P01F05
                };

                var validationResults = DTOValidateHelper.ValidateDTO(updatedUser);
                if (validationResults.Count > 0)
                {
                    foreach (var error in validationResults)
                    {
                        Console.WriteLine($"Validation Error: {error}");
                    }
                    return;
                }

                _objBLUser.Type = EnmType.E;
                var response = _objBLUser.Validation(updatedUser);
                if (response.IsError)
                {
                    Console.WriteLine(response.Message);
                    return;
                }

                response = _objBLUser.Save();
                Console.WriteLine($"Error: {response.IsError} Message: {response.Message}");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }

        /// <summary>
        /// Deletes a user from the database by ID.
        /// </summary>
        internal static void DeleteUser()
        {
            Console.Write("Enter User ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var response = _objBLUser.Delete(id);
            Console.WriteLine(response.Message);
        }

        /// <summary>
        /// Helper method to get a string input from the user.
        /// </summary>
        static string GetStringInput(string prompt, string defaultValue = "")
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
        }

        /// <summary>
        /// Helper method to get an integer input from the user.
        /// </summary>
        static int GetIntInput(string prompt, int defaultValue = 0)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return int.TryParse(input, out int result) ? result : defaultValue;
        }
    }
}
