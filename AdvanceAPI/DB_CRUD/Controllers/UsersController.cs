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

        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>HTTP response with a list of UserDTO objects.</returns>
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            List<UserDTO> users = usrRepo.GetUsers();
            return Ok(users);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">User ID to fetch.</param>
        /// <returns>HTTP response with UserDTO if found, otherwise NotFound.</returns>
        [HttpGet]
        [Route("api/users/{id}")]
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

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">User object containing details.</param>
        /// <returns>HTTP response with created user details.</returns>
        [HttpPost]
        [Route("api/users/adduser")]
        public IHttpActionResult PostUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            usrRepo.AddUser(user);
            return Ok(new { user.Username, user.Email });
        }

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="user">User object containing updated details.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
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

        /// <summary>
        /// Deletes a user from the database by ID.
        /// </summary>
        /// <param name="id">User ID to be deleted.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
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