using FullDemo.BL.Interfaces;
using FullDemo.Models.DTO;
using FullDemo.Models.POCO;
using FullDemo.Models.ENUM;
using FullDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullDemo.BL.Services;
using Microsoft.AspNetCore.Authorization;

namespace FullDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices<DTOITH03> _itmServices;
        private Response _objResponse;
        private readonly ILogger _logger;

        public ItemsController(IItemServices<DTOITH03> itmServices, ILogger<ItemsController> logger)
        {
            _objResponse = new Response();
            _itmServices = itmServices;
            _logger = logger;
        }

        /// <summary>
        /// Adding new item. Requires jwt token
        /// <param name="item">Item DTO Object</param>
        /// </summary>
        [HttpPost]
        [Route("add")]
        public ActionResult<Response> AddItem([FromBody] DTOITH03 item)
        {
            _itmServices.PreSave(item);
            _itmServices.Type = EnmType.A;
            _objResponse = _itmServices.Save();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Get all items
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public ActionResult<Response> GetItems()
        {
            //throw new Exception("hi");
            List<ITH02> items = _itmServices.GetAllItems();
            if (items.Count == 0)
            {
                _objResponse.Success = false;
                _objResponse.Message = "Not Found";
                return NotFound(_objResponse);
            }
            _objResponse.Data = items;
            _objResponse.Success = true;
            _objResponse.Message = "Items";
             
            return Ok(_objResponse);
        }


        /// <summary>
        /// Get all items by category name
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [Route("{category}")]
        public ActionResult<Response> GetItems(string category)
        {
            _objResponse.Data = _itmServices.GetAllItemsByCategory(category);
            if (_objResponse.Data == null)
            {
                _objResponse.Success = false;
                _objResponse.Message = "Not Found";
                return NotFound(_objResponse);
            }
            _objResponse.Success = true;
            _objResponse.Message = "Items";
             
            return Ok(_objResponse);
        }



        /// <summary>
        /// Delete an item
        /// <param name="id"> Id of item to delete</param>
        /// </summary>
        [HttpDelete]
        [Route("delete/{id}")]
        //[JWTAuthorization]
        public ActionResult<Response> DeleteItem(int id)
        {
            _objResponse = _itmServices.Delete(id);
            return Ok(_objResponse);
        }
    }
}
