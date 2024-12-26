using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1_NetFramework.Controllers
{
    public class HelloController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }

        public string Get(int id)
        {
            return "third param in url(after controller).";
        }

        //[HttpGet]
        //public string MyName()
        //{
        //    return "Rohanshu Banodha";
        //}

    }
}
