using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web.Http;
using FinalWebApplication.Models;

namespace FinalWebApplication.Controllers
{
    public class UserController : ApiController
    {
        private static readonly List<User> Users = new List<User>();

        [HttpPost]
        [Route("api/user/signup")]
        public IHttpActionResult SignUp([FromBody] User user)
        {
            try
            {
                if (user == null) return BadRequest("Invalid Data.");

                if (!Regex.IsMatch(user.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    return BadRequest("Invalid email format.");
                }
                if (!Regex.IsMatch(user.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
                {
                    return BadRequest("Password didn't satisfied requirements.");
                }
                if (Users.Any(u => u.Email == user.Email))
                {
                    return BadRequest("User already exists.");
                }
                Users.Add(user);
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/user/login")]
        public IHttpActionResult Login([FromBody] User user)
        {
            try
            {
                if (user == null) return BadRequest("Invalid data.");

                User existingUser = Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if(existingUser == null)
                {
                    return NotFound();
                }
                var token = JWTHelper.GenerateToken(user.Email);
                return Ok(new { Token = token, Message = "Login Successful" });
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
