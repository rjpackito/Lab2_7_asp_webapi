using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using lab2_7_asp_webapi.Models;
   
namespace lab2_7_asp_webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );
        }
    }
}
