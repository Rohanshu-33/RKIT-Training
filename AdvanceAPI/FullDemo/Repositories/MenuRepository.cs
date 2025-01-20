using FullDemo.BL.Services;
using FullDemo.Helpers;
using FullDemo.Models.DTO;
using FullDemo.Models.POCO;
using FullDemo.Models.ENUM;
using FullDemo.Models;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace FullDemo.Repositories
{
    internal class MenuRepository
    {
        internal static MenuServices _objMenuServices = new MenuServices();
        internal static RestaurantServices _objRestaurantServices = new RestaurantServices();

        // add menu
        internal static void AddMenu()
        {
            int restId = GetIntInput("Enter restaruant id: ");
            string nme = GetStringInput("Enter food item name: ");
            float sellPrice = GetFloatInput("Enter item price: ");
            float costPrice = GetFloatInput("Enter item cost price: ");

            DTORST02 menu = new DTORST02
            {
                T02F02 = restId,
                T02F03 = nme,
                T02F04 = sellPrice,
                T02F05 = costPrice,
                T02F06 = DateTime.Now
            };

            // validate dto before performing presave
            List<string> validationResults = DTOValidateHelper.ValidateDTO(menu);
            if (validationResults.Count > 0)
            {
                foreach (var error in validationResults)
                {
                    Console.WriteLine($"Validation Error: {error}");
                }
                return; // Exit the method if validation fails
            }

            _objMenuServices.PreSave(menu);
            _objMenuServices.Type = EnumType.A;

            Response response = _objMenuServices.Validation();

            if (response.IsError == true)
            {
                Console.WriteLine(response.Message);
                return;
            }
            response = _objMenuServices.Save();
            Console.WriteLine($"Success: {!response.IsError}\nMessage: {response.Message}");

        }

        // update menu
        internal static void UpdateMenu()
        {
            Console.Write("Enter Menu ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            RST02 menu = _objMenuServices.Get(id);

            if (menu != null)
            {
                var updatedMenu = new DTORST02
                {
                    T02F01 = id,
                    T02F02 = menu.T02F02,
                    T02F03 = GetStringInput("Enter new name of menu: ", menu.T02F03),
                    T02F04 = GetFloatInput("Enter menu new sell price: ", menu.T02F04),
                    T02F05 = GetFloatInput("Enter menu new cost price: ", menu.T02F05)
                };

                _objMenuServices.PreSave(updatedMenu);
                _objMenuServices.Type = EnumType.E;

                Response response = _objMenuServices.Validation();
                if (response.IsError == true)
                {
                    Console.WriteLine(response.Message);
                    return;
                }

                response = _objMenuServices.Save();
                Console.WriteLine($"Success: {!response.IsError}\nMessage: {response.Message}");
            }
            else
            {
                Console.WriteLine("No such menu found.");
            }
        }

        // fetch menu by restaurant (will use LINQ here)
        internal static void GetMenusByRestaurant()
        {
            Console.Write("Enter Restaurant ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            List<RST02> menuList = _objMenuServices.GetAll();

            // LINQ query for getting menu based on restaurant id
            var response = (from menu in menuList
                      where menu.T02F02 == id
                      select new
                      {
                          TO2F03 = menu.T02F03,
                          T02F04 = menu.T02F04
                      }).ToList();
            foreach (var menu in response)
            {
                Console.WriteLine($"Name: {menu.TO2F03}\tPrice:{menu.T02F04}");
            }
        }

        // store all menu grouped by their restaurant name and city in a file
        internal static void StoreMenuByRestaurantInJSONFile()
        {
            List<RST01> rstList = _objRestaurantServices.GetAll();
            List<RST02> menuList = _objMenuServices.GetAll();

            var result = (from rst in rstList
                         join menu in menuList
                         on rst.T01F01 equals menu.T02F02
                         into menuGroup
                         select new DTORST03
                         {
                             T03F01 = rst.T01F02,
                             T03F02 = menuGroup.Select(menu => new DTORST04
                             {
                                 T04F01 = menu.T02F03,
                                 T04F02 = menu.T02F04,
                                 T04F03 = menu.T02F05
                             }).ToList()
                         }).ToList();

            // Convert the result to JSON using Newtonsoft.Json
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);

            // Save the JSON to a file
            string filePath = "restaurants_menus.json";
            File.WriteAllText(filePath, json);

            Console.WriteLine($"File saved to {filePath}");

            //foreach (var entry in result)
            //{
            //    Console.WriteLine($"Restaurant: {entry.Restaurant}");
            //    foreach (var menu in entry.Menu)
            //    {
            //        Console.WriteLine($"  {menu.T02F03}: {menu.T02F04}");
            //    }
            //}
        }

        // delete a menu
        internal static void DeleteMenu()
        {
            Console.Write("Enter Menu ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Response response = _objMenuServices.Delete(id);
            Console.WriteLine($"Success: {!response.IsError}\nMessage: {response.Message}");
        }


        static string GetStringInput(string prompt, string defaultValue = "")
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
        }

        static int GetIntInput(string prompt, int defaultValue = 0)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return int.TryParse(input, out int result) ? result : defaultValue;
        }

        static float GetFloatInput(string prompt, float defaultValue = 0.0F)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return float.TryParse(input, out float result) ? result : defaultValue;
        }
    }
}
