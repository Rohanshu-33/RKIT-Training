using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalWebApplication.Configuration
{
    public static class MyConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes

            // 1) Attribute Routing
            // allows : [Route("routeName")]
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}