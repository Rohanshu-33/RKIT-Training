using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreEmptyWebApplication1.Filters;
using System.Diagnostics;

namespace CoreEmptyWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        [Route("GetDataWithApi")]
        //[ApiAuthorizationFilter()]
        [MyResourceFilter]
        [MyActionfilter]
        [MyResultFilter]
        [MyExceptionFilter]
        [HttpGet]
        public string GetAllData()
        {
            Debug.WriteLine("Start of action method.");
            int[] a = { 1,2,3};
            //return $"{a[3]}";
            return "All Data.";
        }
    }
}
