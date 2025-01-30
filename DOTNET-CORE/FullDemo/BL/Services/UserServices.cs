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
        private readonly IAppDBConnection _dbConnection;

        /// <summary>
        /// UserServices Constructor
        /// </summary
        public UserServices(IAppDBConnection dbConnection)
        {
            _objResponse = new Response();
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Checks whether a user with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>True if the user exists, otherwise false</returns>
        private bool IsITH01Exists(int id)
        {
            //Console.WriteLine("id is : " + id);
            using (var db = _dbConnection.GetDbConnection())
            {
                return db.Exists<ITH01>(r => r.H01F01 == id);
            }
        }

        /// <summary>
        /// performs validation whether user exists or not before updating the data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public void PreSave(DTOITH01 ITH)
        {
            _objITH01 = ITH.Convert<ITH01>();
            Console.WriteLine($"{_objITH01.H01F01} {_objITH01.H01F02}");
        }

        /// <summary>
        /// performs validation whether user exists or not before updating the data.
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
        /// Saves the user data (adding or updating a user) to the MySQL database.
        /// </summary>
        /// <returns>Response object indicating success or failure of saving operation</returns>
        public Response Save()
        {
            try
            {
                using (var db = _dbConnection.GetDbConnection())
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
                _objResponse.Success = false;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a user before deletion to validate its existence.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>The User object if found.</returns>
        public ITH01 PreDelete(int id)
        {
            return Get(id);
        }

        /// <summary>
        /// Validates the user object before deletion.
        /// </summary>
        /// <param name="objITH01">The user object to validate.</param>
        /// <returns>A Response object indicating success or errors.</returns>
        public Response ValidationOnDelete(ITH01 objITH01)
        {
            if (objITH01 == null)
            {
                _objResponse.Success = false;
                _objResponse.Message = "User Not Found";
            }
            return _objResponse;
        }


        /// <summary>
        /// Deletes a user by ID from the MySQL database.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        public Response Delete(int id)
        {
            try
            {
                ITH01 objITH01 = PreDelete(id);
                Response objResponse = ValidationOnDelete(objITH01);

                if (objResponse.Success == true)
                {
                    using (var db = _dbConnection.GetDbConnection())
                    {
                        db.DeleteById<ITH01>(id);
                        _objResponse.Message = "User deleted successfully.";
                    }
                }
                return _objResponse;
            }
            catch (Exception ex)
            {
                _objResponse.Success = false;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a user by ID from the database.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User with the specified ID</returns>
        public ITH01 Get(int id)
        {
            using (var db =  _dbConnection.GetDbConnection())
            {
                return db.SingleById<ITH01>(id);
            }
        }

        /// <summary>
        /// Retrieves all users from the MySQL database.
        /// </summary>
        /// <returns>List of users</returns>
        public List<ITH01> GetAll()
        {
            using (var db =  _dbConnection.GetDbConnection())
            {
                return db.Select<ITH01>();  // will return List of POCO Objects
            }
        }

        /// <summary>
        /// Chcks for user match in the MySQL database.
        /// </summary>
        /// <returns>Boolean value</returns>
        public bool CheckUserCredentials(DTOITH02 usr)
        {
            using (var db =  _dbConnection.GetDbConnection())
            {
                return db.Exists<ITH01>(u => u.H01F03==usr.H02F01 && u.H01F04==usr.H02F02);
            }
        }
    }
}
