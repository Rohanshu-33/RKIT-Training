using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreEmptyWebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [Route("~/hello")]  // the base route setup of controller/action will not work now on this method.
        public string Get()
        {
            return "hi";
        }

        // Variables in routing
        [Route("{id}")]
        public string Other(int id)
        {
            return "other "+id;
        }

        // Query string in routing
        //[Route("getall")]
        public string GetAll(int id, string name, int aid, string aname)
        {
            return $"Id: {id} Name: {name} Aid: {aid} Aname: {aname}";
        }
    }
}
