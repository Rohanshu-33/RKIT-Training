using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApplication1_NetFramework.Configuration
{
    public static class HelloWebApiConfig
    {
        // Register - static method designed to configure a web api
        // Httpconfiguration as a parameter which holds settings related to web api
        // Register method configures 2 routing mechanisms:


        // This Register method is called in Global.asax file
        // during application startup which ensures that routing settings
        // are applied when application starts
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            // 1) Attribute Routing
            // allows : [Route("routeName")]
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
            name: "School",
            routeTemplate: "api/myvalue/{id}",
            defaults: new { controller = "value", id = RouteParameter.Optional },
            constraints: new { id = "/d+" }
            );


            // The MapHttpRoute() extension method internally
            // creates a new instance of IHttpRoute and adds it to an HttpRouteCollection.
            // default convention based route. it defines default route for api
            config.Routes.MapHttpRoute(
                name: "DefaultApi",  // name of route
                routeTemplate: "api/{controller}/{id}",
                // api is fixed prefix
                // controller is placeholder for controller name
                // id is optional parameter eg. api/products/5
                defaults: new { id = RouteParameter.Optional }
                // defaults specifies default values for route params.
                // here, id is made optional
            );
        }
    }
}