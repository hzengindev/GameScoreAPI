using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZNGN.TTT.Api.Filter;

namespace ZNGN.TTT.Api.Controllers
{
    
    public class ValuesController : BaseApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authentication]
        public string Get(int id)
        {
            return this.CurrentSession.Name + this.CurrentSession.Surname;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
