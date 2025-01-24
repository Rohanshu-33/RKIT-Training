using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreEmptyWebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("~/hello")]  // the base route setup of controller/action will not work now on this method.
        public string Get()
        {
            return "hi";
        }

        // Variables in routing
        [Route("{id}")]
        [HttpGet]
        public string Other(int id)
        {
            return "other "+id;
        }

        // Query string in routing
        //[Route("getall")]
        [HttpGet]
        public string GetAll(int id, string name, int aid, string aname)
        {
            return $"Id: {id} Name: {name} Aid: {aid} Aname: {aname}";
        }
    }
}
