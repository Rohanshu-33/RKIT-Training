using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DB_CRUD.Repositories;
using DB_CRUD.DTO;
using DB_CRUD.POCO_Model;

namespace DB_CRUD.Controllers
{
    public class UsersController : ApiController
    {
        private UserRepository usrRepo = new UserRepository();

        // Get api/users
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            List<UserDTO> users = usrRepo.GetUsers();
            return Ok(users);
        }


        // Get api/user/{id}
        [HttpGet]
        [Route("api/users/getuser")]
        public IHttpActionResult GetUserById(int id)
        {
            User user = usrRepo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };

            return Ok(userDTO);
        }

        // Post api/users
        [HttpPost]
        [Route("api/users/adduser")]
        public IHttpActionResult PostUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            // You might want to hash the password before storing it.
            usrRepo.AddUser(user);
            return Ok( new { user.Username, user.Email });  // Created status code
        }

        // PUT api/users/updateuser
        [HttpPut]
        [Route("api/users/updateuser")]
        public IHttpActionResult PutUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            var existingUser = usrRepo.GetUserById(user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            usrRepo.UpdateUser(user);
            return Ok($"User with id {user.Id} updated successfully.");
        }

        // DELETE api/users/deleteuser
        [HttpDelete]
        [Route("api/users/deleteuser")]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = usrRepo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            usrRepo.DeleteUser(id);
            return Ok($"User with id {user.Id} deleted successfully.");
        }
    }
}
