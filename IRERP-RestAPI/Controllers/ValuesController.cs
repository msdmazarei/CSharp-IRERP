using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IRERP_RestAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // POST api/values
        public void Post()
        {
        }

        // PUT api/values/5
        public void Put()
        {
        }

        // DELETE api/values/5
        public void Delete()
        {
        }

        public string test()
        {
            return "All thing is ok.";
        }

    }
}