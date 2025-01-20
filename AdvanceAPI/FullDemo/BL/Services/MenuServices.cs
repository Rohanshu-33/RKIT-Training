using System;
using FullDemo.BL.Interfaces;
using FullDemo.Extensions;
using FullDemo.Models;
using FullDemo.Models.DTO;
using FullDemo.Models.ENUM;
using FullDemo.Models.POCO;
using Google.Protobuf.WellKnownTypes;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace FullDemo.BL.Services
{
    /// <summary>
    /// Business Logic class for handling CRUD operations on Menu data (RST02).
    /// Implements the IDataHandlerService interface for DTORST02.
    /// </summary>
    public class MenuServices : IDataHandlerServices<RST02, DTORST02>
    {
        private RST02 _objRST02;
        private int _id;
        private Response _objResponse;
        private string _connectionString;
        private IDbConnectionFactory _dbFactory;
        public EnumType Type { get; set; }

        /// <summary>
        /// MenuServices Constructor
        /// </summary
        public MenuServices()
        {
            _objResponse = new Response();
            _connectionString = "Server=localhost;Database=rbcollege;User=Admin;Password=gs@123;";
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }


        /// <summary>
        /// Checks whether a menu item with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">Menu ID</param>
        /// <returns>True if the menu item exists, otherwise false</returns>
        private bool IsRST02Exists(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<RST02>(r => r.T02F01 == id);
            }
        }

        /// <summary>
        /// performs validation whether menu item exists or not before updating the data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public void PreSave(DTORST02 rst)
        {
            _objRST02 = rst.Convert<RST02>();
        }

        /// <summary>
        /// performs validation whether  menu item exists or not before updating the data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public Response Validation()
        {
            _id = _objRST02.T02F01;
            if (Type == EnumType.E)
            {
                bool isRST02 = IsRST02Exists(_id);
                if (!isRST02)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Menu Not Found";
                }
                else
                {
                    Console.WriteLine("Menu is present in db.");
                }
            }

            return _objResponse;
        }


        /// <summary>
        /// Saves the  menu item data (adding or updating a  menu item) to the MySQL database.
        /// </summary>
        /// <returns>Response object indicating success or failure of saving operation</returns>
        public Response Save()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    if (Type == EnumType.A)
                    {
                        db.Insert(_objRST02);
                        _objResponse.Message = "Menu added successfully.";
                    }
                    if (Type == EnumType.E)
                    {
                        db.Update(_objRST02);
                        db.UpdateOnlyFields(
                            _objRST02,
                            onlyFields: p => new { p.T02F03, p.T02F04, p.T02F05 },
                            where: p => p.T02F01 == _objRST02.T02F01);
                        _objResponse.Message = "Menu data updated successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a menu item before deletion to validate its existence.
        /// </summary>
        /// <param name="id">The ID of the menu item to delete.</param>
        /// <returns>The  menu item object if found.</returns>
        public RST02 PreDelete(int id)
        {
            return Get(id);
        }

        /// <summary>
        /// Validates the menu item object before deletion.
        /// </summary>
        /// <param name="objEMP01">The menu item object to validate.</param>
        /// <returns>A Response object indicating success or errors.</returns>
        public Response ValidationOnDelete(RST02 objRST02)
        {
            if (objRST02 == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Menu Not Found";
            }
            return _objResponse;
        }


        /// <summary>
        /// Deletes a menu item by ID from the MySQL database.
        /// </summary>
        /// <param name="id">Menu Item ID</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        public Response Delete(int id)
        {
            try
            {
                RST02 objRST02 = PreDelete(id);
                Response objResponse = ValidationOnDelete(objRST02);

                if (objResponse.IsError == false)
                {
                    using (var db = _dbFactory.OpenDbConnection())
                    {
                        db.DeleteById<RST02>(id);
                        _objResponse.Message = "Menu deleted successfully.";
                    }
                }
                return _objResponse;
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a menu item by ID from the database.
        /// </summary>
        /// <param name="id">Menu Item ID</param>
        /// <returns>Menu Item with the specified ID</returns>
        public RST02 Get(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.SingleById<RST02>(id); // will return POCO Object
            }
        }

        /// <summary>
        /// Retrieves all menu items from the MySQL database.
        /// </summary>
        /// <returns>List of menu items</returns>
        public List<RST02> GetAll()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<RST02>();  // will return List of POCO Objects
            }
        }

        /// <summary>
        /// Retrieves all menu items from the MySQL database.
        /// </summary>
        /// <returns>List of menu items</returns>
        public void GetMenuGroupByRestaurant()
        {
            //using (var db = _dbFactory.OpenDbConnection())
            //{
            //    var query = db.From<RST01>()
            //      .Join<RST02>((rest, menu) => rest.T01F01 == menu.T02F02)
            //      .Select<RST01, RST02>((rest, menu) => new
            //      {
            //          T01F02 = rest.T01F02,
            //          T02F03 = menu.T02F03,
            //          T02F04 = menu.T02F04
            //      })
            //      .OrderBy(rest => rest.T01F02);

            //    var result = db.Select(query);

            //    var ans = result.GroupBy(r => r.T01F02).ToList();

            //    foreach (var empGroup in ans)
            //    {
            //        Console.WriteLine($"Restaurant Name: {empGroup.Key}");
            //        foreach (var e in empGroup)
            //        {
            //            Console.WriteLine($"{e.T02F03}, {e.T02F04}");  // Print Menu details
            //        }
            //    }
            //}
        }
    }
}
