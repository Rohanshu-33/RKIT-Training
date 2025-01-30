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

        // add item, jwt required
        [HttpPost]
        [Route("add")]
        //[JWTAuthorization]
        public ActionResult<Response> AddItem([FromBody] DTOITH03 itm)
        {
            _itmServices.PreSave(itm);
            _itmServices.Type = EnmType.A;
            _objResponse = _itmServices.Save();
            return Ok(_objResponse);
        }

        // get items
        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public ActionResult<Response> GetItems()
        {
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


        // get items by category
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


        // update item, jwt required
        [HttpPatch]
        [Route("update/{id}")]
        //[JWTAuthorization]
        public ActionResult<Response> UpdateItem([FromRoute] int id, [FromBody] DTOITH04 itm)
        {
            ITH02 itmObj = _itmServices.Get(id);

            if (itmObj == null)
            {
                _objResponse.Success = false;
                _objResponse.Message = "No such item.";
                return NotFound(_objResponse);
            }

            _itmServices.PreSaveForUpdate(itm);
            _itmServices.Type = EnmType.E;
            _objResponse = _itmServices.Validation();

            if (_objResponse.Success == false)
            {
                return BadRequest(_objResponse);
            }

            _objResponse = _itmServices.Save();
            return Ok(_objResponse);
        }

        // delete item, jwt required
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
