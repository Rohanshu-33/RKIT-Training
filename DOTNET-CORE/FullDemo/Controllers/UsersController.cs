using FullDemo.BL.Interfaces;
using FullDemo.Models;
using FullDemo.Models.DTO;
using FullDemo.Models.ENUM;
using FullDemo.Models.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullDemo.Helpers.JWT;
using FullDemo.Helpers.Security;

namespace FullDemo.Controllers
{
    //[CustomExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices<DTOITH01> _usrServices;
        private Response _objResponse;
        private readonly ILogger _logger;

        public UsersController(IUserServices<DTOITH01> usrServices, ILogger<UsersController> logger)
        {
            Console.WriteLine("hi");
            _objResponse = new Response();
            _usrServices = usrServices;
            _logger = logger;
        }

        /// <summary>
        /// User signup
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        public ActionResult<Response> Signup([FromBody] DTOITH01 usr)
        {
            //throw new Exception("exce");
            usr.H01F04 = RjindaelEncryption.Encrypt(usr.H01F04);
            _usrServices.PreSave(usr, 0);
            _usrServices.Type = EnmType.A;

            _objResponse = _usrServices.Save();
            return Ok(_objResponse);
        }

        /// <summary>
        /// User login
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ActionResult<Response> Login([FromBody] DTOITH02 usr)
        {
            usr.H02F02 = RjindaelEncryption.Encrypt(usr.H02F02);
            bool isExists = _usrServices.CheckUserCredentials(usr);
            if (!isExists)
            {
                _objResponse.Success = false;
                _objResponse.Message = "No such user or invalid credentials.";
                return BadRequest(_objResponse);
            }
            // response should set JWT Token in cookie
            _objResponse.Success = true;
            _objResponse.Message = "Login successful.";
            _objResponse.Data = JWTHandler.GenerateToken(usr.H02F01);
            return Ok(_objResponse);
        }

        /// <summary>
        /// User update
        /// </summary> 
        [HttpPatch]
        [Route("update/{id}")]
        public ActionResult<Response> Update([FromRoute] int id, [FromBody] DTOITH01 usr)
        {
            ITH01 usrObj = _usrServices.Get(id);

            if (usrObj == null)
            {
                _objResponse.Success = false;
                _objResponse.Message = "No such user.";
                return NotFound(_objResponse);
            }

            _usrServices.Type = EnmType.E;
            _usrServices.PreSave(usr, usrObj.H01F01);
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
