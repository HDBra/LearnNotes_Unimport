using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LearnWebApi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            // 启用属性路由
            /*
             * 常用的属性路由有Route, {}定义占位符，占位符的名字是有意义的
             *  如：[Route("customers/{customerId}/orders")]
             *  [NonAction] 标志不是一个action
             *  [ActionName]覆盖action的名称
             *  [HttpGet][HttpPost][HttpPut][HttpDelete]
             *  [AcceptVerbs("GET", "HEAD")]同时匹配多个method
             *  
             */
            config.MapHttpAttributeRoutes();


            //公约路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
