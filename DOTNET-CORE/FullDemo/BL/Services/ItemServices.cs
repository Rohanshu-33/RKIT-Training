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
    public class ItemServices : IItemServices<DTOITH03>
    {
        private int _id;
        public EnmType Type { get; set; }
        private Response _objResponse; // Response
        private ITH02 _objITH02; // POCO
        private readonly IAppDBConnection _dbConnection;

        /// <summary>
        /// Item Services Constructor
        /// </summary
        public ItemServices(IAppDBConnection dbConnection)
        {
            _objResponse = new Response();
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Checks whether an item with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>True if the item exists, otherwise false</returns>
        private bool IsITH02Exists(int id)
        {
            //Console.WriteLine("id is : " + id);
            using (var db = _dbConnection.GetDbConnection())
            {
                return db.Exists<ITH02>(r => r.H02F01 == id);
            }
        }

        /// <summary>
        /// convert to poco for corresponding DTO.
        /// </summary>
        public void PreSave(DTOITH03 ITH)
        {
            _objITH02 = ITH.Convert<ITH02>();
        }

        /// <summary>
        /// convert to poco for corresponding DTO.
        /// </summary>
        public void PreSaveForUpdate(DTOITH04 ITH)
        {
            _objITH02 = ITH.Convert<ITH02>();
        }

        /// <summary>
        /// performs validation whether item exists or not before updating the data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public Response Validation()
        {
            _id = _objITH02.H02F01;
            Console.WriteLine(_id);
            if (Type == EnmType.E)
            {
                bool isITH02 = IsITH02Exists(_id);
                if (!isITH02)
                {
                    _objResponse.Success = false;
                    _objResponse.Message = "Item Not Found";
                }
            }
            return _objResponse;
        }


        /// <summary>
        /// Saves the item data (adding or updating a item) to the MySQL database.
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
                        db.Insert(_objITH02, true);
                        _objResponse.Message = "Item added successfully.";
                    }
                    if (Type == EnmType.E)
                    {
                        //db.UpdateOnlyFields(
                        //    _objITH02,
                        //    onlyFields: p => new { p.T01F02, p.T01F03, p.T01F05 },
                        //    where: p => p.T01F01 == _objITH02.T01F01);

                        _objResponse.Message = "Item data updated successfully.";
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
        /// Retrieves an item before deletion to validate its existence.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <returns>The item object if found.</returns>
        public ITH02 PreDelete(int id)
        {
            return Get(id);
        }

        /// <summary>
        /// Validates the item object before deletion.
        /// </summary>
        /// <param name="objITH02">The item object to validate.</param>
        /// <returns>A Response object indicating success or errors.</returns>
        public Response ValidationOnDelete(ITH02 objITH02)
        {
            if (objITH02 == null)
            {
                _objResponse.Success = false;
                _objResponse.Message = "Item Not Found";
            }
            return _objResponse;
        }


        /// <summary>
        /// Deletes an item by ID from the MySQL database.
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        public Response Delete(int id)
        {
            try
            {
                ITH02 objITH02 = PreDelete(id);
                Response objResponse = ValidationOnDelete(objITH02);

                if (objResponse.Success == true)
                {
                    using (var db = _dbConnection.GetDbConnection())
                    {
                        db.DeleteById<ITH02>(id);
                        _objResponse.Message = "Item deleted successfully.";
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
        /// Retrieves a item by ID from the database.
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>item with the specified ID</returns>
        public ITH02 Get(int id)
        {
            using (var db = _dbConnection.GetDbConnection())
            {
                return db.SingleById<ITH02>(id);
            }
        }

        /// <summary>
        /// Retrieves all items from the MySQL database.
        /// </summary>
        /// <returns>List of items</returns>
        public List<ITH02> GetAllItems()
        {
            throw new Exception("My exception.");
            using (var db = _dbConnection.GetDbConnection())
            {
                return db.Select<ITH02>();  // will return List of POCO Objects
            }
        }


        public List<ITH02> GetAllItemsByCategory(string category)
        {
            using (var db = _dbConnection.GetDbConnection())
            {
                return db.Select<ITH02>(i => i.H02F07 ==  category);  // will return List of POCO Objects
            }
        }
    }
}
