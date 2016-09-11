using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LearnWebAPI.Commons.Utils
{
    /// <summary>
    /// ApiController帮助类
    /// </summary>
    public static class ApiControllerHelper
    {

        /// <summary>
        /// 获取HttpRequestMessage,它包含了所有的请求信息
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static HttpRequestMessage GetRequest(ApiController controller)
        {
            return controller.Request;
        }

    }
}