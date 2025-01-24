//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CoreEmptyWebApplication1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ValueController : ControllerBase
//    {

//        // int, bool, datetime, double, float, min, max, minlength, maxlength, length, alpha, range(a, b) where a,b can be int, long, double
//        [Route("{id:int:max(10)}")]
//        [HttpGet]
//        public string GetById(int id)
//        {
//            return $" Small int value: {id}";
//        }

//        [Route("{id:maxlength(2)}")]
//        [HttpGet]
//        public string GetByString(string id)
//        {
//            return $"Small string value: {id}";
//        }

//        [Route("{id:minlength(10)}")]
//        [HttpGet]
//        public string GetByBigString(string id)
//        {
//            return $"Big string value: {id}";
//        }

//        [Route("{id:int:min(11)}")]
//        [HttpGet]
//        public string GetByBigId(int id)
//        {
//            return $"Big value: {id}";
//        }

//        [Route("{id:regex(abbbe(w|x))}")]
//        [HttpGet]
//        public string GetByRegEx(string id)
//        {
//            return $"Regex value: {id}";
//        }
//    }
//}
