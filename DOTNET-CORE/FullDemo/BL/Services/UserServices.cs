using System;
using FullDemo.BL.Interfaces;
using FullDemo.Extensions;
using FullDemo.Models;
using FullDemo.Models.DTO;
using FullDemo.Models.ENUM;
using FullDemo.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace FullDemo.BL.Services
{
    public class UserServices : IUserServices<DTOITH01>
    {
        private int _id;
        public EnmType Type { get; set; }
        private Response _objResponse; // Response
        private ITH01 _objITH01; // POCO
        private string _connectionString;
        private IDbConnectionFactory _dbFactory;

        /// <summary>
        /// UserServices Constructor
        /// </summary
        public UserServices()
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
        private bool IsITH01Exists(int id)
        {
            //Console.WriteLine("id is : " + id);
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<ITH01>(r => r.H01F01 == id);
            }
        }

        /// <summary>
        /// performs validation whether restaurant exists or not before updating the data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public void PreSave(DTOITH01 ITH)
        {
            _objITH01 = ITH.Convert<ITH01>();
            Console.WriteLine($"{_objITH01.H01F01} {_objITH01.H01F02}");
        }

        /// <summary>
        /// performs validation whether restaurant exists or not before updating the data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public Response Validation()
        {
            _id = _objITH01.H01F01;
            Console.WriteLine(_id);
            if (Type == EnmType.E)
            {
                bool isITH01 = IsITH01Exists(_id);
                if (!isITH01)
                {
                    _objResponse.Success = true;
                    _objResponse.Message = "User Not Found";
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
                    if (Type == EnmType.A)
                    {
                        db.Insert(_objITH01, true);
                        _objResponse.Message = "User added successfully.";
                    }
                    if (Type == EnmType.E)
                    {
                        //db.UpdateOnlyFields(
                        //    _objITH01,
                        //    onlyFields: p => new { p.T01F02, p.T01F03, p.T01F05 },
                        //    where: p => p.T01F01 == _objITH01.T01F01);

                        _objResponse.Message = "User data updated successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.Success = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a Restaurant before deletion to validate its existence.
        /// </summary>
        /// <param name="id">The ID of the Restaurant to delete.</param>
        /// <returns>The Restaurant object if found.</returns>
        public ITH01 PreDelete(int id)
        {
            return Get(id);
        }

        /// <summary>
        /// Validates the Restaurant object before deletion.
        /// </summary>
        /// <param name="objEMP01">The Restaurant object to validate.</param>
        /// <returns>A Response object indicating success or errors.</returns>
        public Response ValidationOnDelete(ITH01 objITH01)
        {
            if (objITH01 == null)
            {
                _objResponse.Success = true;
                _objResponse.Message = "User Not Found";
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
                ITH01 objITH01 = PreDelete(id);
                Response objResponse = ValidationOnDelete(objITH01);

                if (objResponse.Success == false)
                {
                    using (var db = _dbFactory.OpenDbConnection())
                    {
                        db.DeleteById<ITH01>(id);
                        _objResponse.Message = "User deleted successfully.";
                    }
                }
                return _objResponse;
            }
            catch (Exception ex)
            {
                _objResponse.Success = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a restaurant by ID from the database.
        /// </summary>
        /// <param name="id">Restaurant ID</param>
        /// <returns>Restaurant with the specified ID</returns>
        public ITH01 Get(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.SingleById<ITH01>(id);
            }
        }

        /// <summary>
        /// Retrieves all restaurants from the MySQL database.
        /// </summary>
        /// <returns>List of restaurants</returns>
        public List<ITH01> GetAll()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<ITH01>();  // will return List of POCO Objects
            }
        }
    }
}
