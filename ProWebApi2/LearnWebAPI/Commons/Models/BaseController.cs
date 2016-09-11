using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnWebAPI.Commons.Models
{
    /// <summary>
    /// Web api的Controller继承自ApiController,只能有Get/Post/Delete/Put(首字母大写)四种Action.
    /// 参数的个数可以不同
    /// GET PUT DELETE是幂等的，而POST不是。
    /// GET没有请求包体，PUT\DELETE\POST有
    /// 除了Url中的参数外，还可以指定包体中的参数和HttpRequestMessage类的参数
    /// 包体可以是json或者xml,框架自动解析为类。
    /// HttpRequestMessage提供了请求的所有信息
    /// </summary>
    public class BaseController : ApiController
    {


        // GET: api/base
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/base/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/base
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/base/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/base/5
        public void Delete(int id)
        {
        }
    }
}
