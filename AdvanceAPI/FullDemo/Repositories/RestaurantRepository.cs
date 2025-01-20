using System;
using FullDemo.BL.Services;
using FullDemo.Models.DTO;
using FullDemo.Models.POCO;
using FullDemo.Models.ENUM;
using FullDemo.Models;
using FullDemo.Helpers;
using System.Transactions;
using System.Diagnostics;

namespace FullDemo.Repositories
{
    public class RestaurantRepository
    {
        internal static RestaurantServices _objRestaurantServices = new RestaurantServices();

        // retrieve all restaurants
        internal static void GetAllRestaurants()
        {
            var restaurants = _objRestaurantServices.GetAll();
            if (restaurants.Count > 0)
            {
                foreach (var rest in restaurants)
                {
                    Console.WriteLine($"Name: {rest.T01F02}, Email: {rest.T01F03}, City: {rest.T01F05}");
                }
            }
            else
            {
                Console.WriteLine("No restaurants found.");
            }
        }

        // retrieve restaurant by id
        internal static void GetRestaurantById()
        {
            Console.Write("Enter restaurant id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var restaurant = _objRestaurantServices.Get(id);
            if (restaurant != null)
            {
                Console.WriteLine($"Name: {restaurant.T01F02}, Email: {restaurant.T01F03}, Password: {RjindaelEncryption.Decrypt(restaurant.T01F04)}, City: {restaurant.T01F05}, Start Date: {restaurant.T01F06}");
            }
            else
            {
                Console.WriteLine("No restaurant found.");
            }
        }

        // add restaurant (password hashing)
        internal static void AddRestaurant()
        {
            string nme = GetStringInput("Enter restaurant name: ");
            string email = GetStringInput("Enter email id: ");
            string pswd = RjindaelEncryption.Encrypt(GetStringInput("Enter password: "));
            string city = GetStringInput("Enter restaurant city: ");
            Debug.WriteLine("password is : " + pswd);
            DTORST01 restaurant = new DTORST01
            {
                T01F02 = nme,
                T01F03 = email,
                T01F04 = pswd,
                T01F05 = city,
                T01F06 = DateTime.Now
            };

            // validate dto before performing presave
            List<string> validationResults = DTOValidateHelper.ValidateDTO(restaurant);
            if (validationResults.Count > 0)
            {
                foreach (var error in validationResults)
                {
                    Console.WriteLine($"Validation Error: {error}");
                }
                return; // Exit the method if validation fails
            }

            _objRestaurantServices.PreSave(restaurant);
            _objRestaurantServices.Type = EnumType.A;
            Response response = _objRestaurantServices.Validation();
            if (response.IsError == true)
            {
                Console.WriteLine(response.Message);
                return;
            }
            response = _objRestaurantServices.Save();
            Console.WriteLine($"Success: {!response.IsError}\nMessage: {response.Message}");
        }

        // update restaurant
        internal static void UpdateRestaurant()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var restaurant = _objRestaurantServices.Get(id);
            if (restaurant != null)
            {
                var updatedRest = new DTORST01
                {
                    T01F01 = id,
                    T01F02 = GetStringInput("Enter new restaurant name: ", restaurant.T01F02),
                    T01F03 = GetStringInput("Enter new email id: ", restaurant.T01F03),
                    T01F05 = GetStringInput("Enter new restaurant city: ", restaurant.T01F05)
                };

                _objRestaurantServices.PreSave(updatedRest);
                _objRestaurantServices.Type = EnumType.E;

                Response response = _objRestaurantServices.Validation();
                if (response.IsError == true)
                {
                    Console.WriteLine(response.Message);
                    return;
                }
                response = _objRestaurantServices.Save();
                Console.WriteLine($"Success: {!response.IsError}\nMessage: {response.Message}");
            }
            else
            {
                Console.WriteLine("No such restaurant found.");
            }
        }

        // delete restaurant
        internal static void DeleteRestaurant()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Response response = _objRestaurantServices.Delete(id);
            Console.WriteLine($"Success: {!response.IsError}\nMessage: {response.Message}");
        }


        // Helper methods
        static string GetStringInput(string prompt, string defaultValue = "")
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
        }
    }
}
