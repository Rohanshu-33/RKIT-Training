using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1_NetFramework.Models;

namespace WebApplication1_NetFramework.Controllers
{
    public class ValueController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }

        public string Get(int id)
        {
            return "third param in url(after controller).";
        }

        [HttpGet]
        [Route("api/names/myname")]
        public string MyName()
        {
            return "Rohanshu Anil Banodha";
        }

        [Route("names")]
        [HttpGet]
        public IEnumerable<string> GetStudentNames()
        {
            return new string[] { "rohanshu", "navneet" };
        }

        [Route("")]
        [HttpGet]
        public string GreetUser()
        {
            return "Hello User";
        }

        [Route("httpresponse")]
        [HttpGet]
        public HttpResponseMessage GetResponse(int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"id is : {id}");   
        }

        [Route("iactionresult")]
        [HttpGet]
        public IHttpActionResult GetActionResult(string name)
        {
            if (name.Equals(null))
            {
                return NotFound();
            }
            return Ok($"Name : {name}");
        }

        [HttpPost]
        [Route("userdata")]
        public IHttpActionResult PostData([FromBody] ModelClass obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid object data.");
            }

            var responseObj = new
            {
                Message = "Data received successfully.",
                Id = obj.Id, 
                Name = obj.Name
            };

            return Ok(responseObj);
        }

    }
}
