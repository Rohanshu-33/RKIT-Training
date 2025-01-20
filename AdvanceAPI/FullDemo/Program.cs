using System;
using FullDemo.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        //DBCreation db = new DBCreation();
        //db.ConnectToMySQL();

        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("\nMain Menu");
            Console.WriteLine("1. Restaurant Operations");
            Console.WriteLine("2. Menu Operations");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    RestaurantMenu();
                    break;

                case 2:
                    MenuOperationsMenu();
                    break;

                case 0:
                    Console.WriteLine("Exiting the application.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void RestaurantMenu()
    {
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("\nRestaurant Operations");
            Console.WriteLine("1. Get All Restaurants");
            Console.WriteLine("2. Get Restaurant by ID");
            Console.WriteLine("3. Add Restaurant");
            Console.WriteLine("4. Update Restaurant");
            Console.WriteLine("5. Delete Restaurant");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    RestaurantRepository.GetAllRestaurants();
                    break;

                case 2:
                    RestaurantRepository.GetRestaurantById();
                    break;

                case 3:
                    RestaurantRepository.AddRestaurant();
                    break;

                case 4:
                    RestaurantRepository.UpdateRestaurant();
                    break;

                case 5:
                    RestaurantRepository.DeleteRestaurant();
                    break;

                case 0:
                    Console.WriteLine("Returning to Main Menu.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void MenuOperationsMenu()
    {
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("\nMenu Operations");
            Console.WriteLine("1. Add Menu");
            Console.WriteLine("2. Update Menu");
            Console.WriteLine("3. Get Menus by Restaurant");
            Console.WriteLine("4. Store Menus by Restaurant in JSON File");
            Console.WriteLine("5. Delete Menu");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    MenuRepository.AddMenu();
                    break;

                case 2:
                    MenuRepository.UpdateMenu();
                    break;

                case 3:
                    MenuRepository.GetMenusByRestaurant();
                    break;

                case 4:
                    MenuRepository.StoreMenuByRestaurantInJSONFile();
                    break;

                case 5:
                    MenuRepository.DeleteMenu();
                    break;

                case 0:
                    Console.WriteLine("Returning to Main Menu.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}