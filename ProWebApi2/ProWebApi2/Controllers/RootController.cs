using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProWebApi2.Controllers
{
    /// <summary>
    /// 基类ApiController
    /// ApiController方法是基于Http verbs
    /// </summary>
    public class RootController : ApiController
    {
        public string Get()
        {
            return string.Empty;
        }

    }
}
