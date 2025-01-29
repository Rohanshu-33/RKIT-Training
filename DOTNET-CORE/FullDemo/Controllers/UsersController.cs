using FullDemo.BL.Interfaces;
using FullDemo.Models;
using FullDemo.Models.DTO;
using FullDemo.Models.ENUM;
using FullDemo.Models.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullDemo.Controllers
{
    //[CustomExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices<DTOITH01> _usrServices;
        private Response _objResponse;

        public UsersController(IUserServices<DTOITH01> usrServices)
        {
            _objResponse = new Response();
            _usrServices = usrServices;
        }

        /// <summary>
        /// User signup
        /// </summary>
        [HttpPost]
        [Route("signup")]
        public ActionResult<Response> Signup([FromBody] DTOITH01 usr)
        {
            _usrServices.PreSave(usr);
            _usrServices.Type = EnmType.A;

            _objResponse = _usrServices.Save();
            return Ok(_objResponse);
        }

        /// <summary>
        /// User login
        /// </summary>
        [HttpPost]
        [Route("login")]
        //[JWTGeneration]
        public ActionResult<Response> Login([FromBody] DTOITH02 usr)
        {
            bool isExists = _usrServices.CheckUserCredentials(usr);
            if (!isExists)
            {
                _objResponse.Success = false;
                _objResponse.Message = "No such user or invalid credentials.";
                return BadRequest(_objResponse);
            }
            // response should set JWT Token in cookie
            return Ok(_objResponse);
        }

        /// <summary>
        /// User update
        /// </summary> 
        [HttpPatch]
        [Route("update/{id}")]
        //[JWTAuthorization]
        public ActionResult<Response> Update([FromRoute] int id, [FromBody] DTOITH01 usr)
        {
            ITH01 usrObj = _usrServices.Get(id);

            if (usrObj == null)
            {
                _objResponse.Success = false;
                _objResponse.Message = "No such user.";
                return NotFound(_objResponse);
            }

            _usrServices.PreSave(usr);
            _usrServices.Type = EnmType.E;
            _objResponse = _usrServices.Validation();

            if (_objResponse.Success == false)
            {
                return BadRequest(_objResponse);
            }

            _objResponse = _usrServices.Save();
            return Ok(_objResponse);
        }
    }
}
