using System.Collections.Generic;
using System.Web.Http;

namespace LearnWebApi2.Commons.Models
{
    /// <summary>
    /// Web api的Controller继承自ApiController,只能有Get/Post/Delete/Put(首字母大写)四种Action.
    /// 参数的个数可以不同
    /// GET PUT DELETE是幂等的，而POST不是。
    /// GET没有请求包体，PUT\DELETE\POST有
    /// 除了Url中的参数外，还可以指定包体中的参数和HttpRequestMessage类的参数
    /// 包体可以是json或者xml,框架自动解析为类。
    /// HttpRequestMessage提供了请求的所有信息
    /// 
    ///  
    /// </summary>
    public class BaseController : ApiController
    {
            /*
             * 常用的属性路由有Route, {}定义占位符，占位符的名字是有意义的
             * * 如：[Route("customers/{customerId}/orders")]
             * *[NonAction] 标志不是一个action
             *[ActionName] 覆盖action的名称
             *[HttpGet][HttpPost][HttpPut][HttpDelete]
             *[AcceptVerbs("GET", "HEAD")] 同时匹配多个method
             *
             */

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
