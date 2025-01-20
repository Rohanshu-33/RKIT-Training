using System;
using FullDemo.BL.Interfaces;
using FullDemo.Extensions;
using FullDemo.Models;
using FullDemo.Models.DTO;
using FullDemo.Models.ENUM;
using FullDemo.Models.POCO;
using Google.Protobuf.Compiler;
using Google.Protobuf.WellKnownTypes;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace FullDemo.BL.Services
{
    /// <summary>
    /// Business Logic class for handling CRUD operations on Restaurant data (RST01).
    /// Implements the IDataHandlerService interface for DTORST01.
    /// </summary>
    public class RestaurantServices : IDataHandlerServices<RST01, DTORST01>
    {
        private RST01 _objRST01;
        private int _id;
        private Response _objResponse;
        private string _connectionString;
        private IDbConnectionFactory _dbFactory;
        public EnumType Type { get; set; }

        /// <summary>
        /// RestaurantServices Constructor
        /// </summary
        public RestaurantServices()
        {
            _objResponse = new Response();
            _connectionString = "Server=localhost;Database=rbcollege;User=Admin;Password=gs@123;";
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }


        /// <summary>
        /// Checks whether a restaurant with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">Restaurant ID</param>
        /// <returns>True if the restaurant exists, otherwise false</returns>
        private bool IsRST01Exists(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<RST01>(r => r.T01F01 == id);
            }
        }

        /// <summary>
        /// performs validation whether restaurant exists or not before updating the data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public void PreSave(DTORST01 rst)
        {
            _objRST01 = rst.Convert<RST01>();
        }

        /// <summary>
        /// performs validation whether restaurant exists or not before updating the data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public Response Validation()
        {
            _id = _objRST01.T01F01;
            if (Type == EnumType.E)
            {
                bool isRST01 = IsRST01Exists(_id);
                if (!isRST01)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Restaurant Not Found";
                }
            }
            return _objResponse;
        }


        /// <summary>
        /// Saves the restaurant data (adding or updating a restaurant) to the MySQL database.
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
                        db.Insert(_objRST01);
                        _objResponse.Message = "Restaurant added successfully.";
                    }
                    if (Type == EnumType.E)
                    {
                        db.UpdateOnlyFields(
                            _objRST01,
                            onlyFields: p => new { p.T01F02, p.T01F03, p.T01F05 },
                            where: p => p.T01F01 == _objRST01.T01F01);

                        _objResponse.Message = "Restaurant data updated successfully.";
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
        /// Retrieves a Restaurant before deletion to validate its existence.
        /// </summary>
        /// <param name="id">The ID of the Restaurant to delete.</param>
        /// <returns>The Restaurant object if found.</returns>
        public RST01 PreDelete(int id)
        {
            return Get(id);
        }

        /// <summary>
        /// Validates the Restaurant object before deletion.
        /// </summary>
        /// <param name="objEMP01">The Restaurant object to validate.</param>
        /// <returns>A Response object indicating success or errors.</returns>
        public Response ValidationOnDelete(RST01 objRST01)
        {
            if (objRST01 == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Restaurant Not Found";
            }
            return _objResponse;
        }


        /// <summary>
        /// Deletes a restaurant by ID from the MySQL database.
        /// </summary>
        /// <param name="id">Restaurant ID</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        public Response Delete(int id)
        {
            try
            {
                RST01 objRST01 = PreDelete(id);
                Response objResponse = ValidationOnDelete(objRST01);

                if (objResponse.IsError == false)
                {
                    using (var db = _dbFactory.OpenDbConnection())
                    {
                        db.DeleteById<RST01>(id);
                        _objResponse.Message = "Restaurant deleted successfully.";
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
        /// Retrieves a restaurant by ID from the database.
        /// </summary>
        /// <param name="id">Restaurant ID</param>
        /// <returns>Restaurant with the specified ID</returns>
        public RST01 Get(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.SingleById<RST01>(id); // will return POCO Object
            }
        }

        /// <summary>
        /// Retrieves all restaurants from the MySQL database.
        /// </summary>
        /// <returns>List of restaurants</returns>
        public List<RST01> GetAll()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<RST01>();  // will return List of POCO Objects
            }
        }
    }
}
