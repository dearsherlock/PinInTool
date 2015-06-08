using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PinInWeb.Controllers
{
    public class HelloController : ApiController
    {
        public IHttpActionResult GetProduct(int id)
        {
            //var product = products.FirstOrDefault((p) => p.Id == id);
            if (id == 0)
            {
                return NotFound();
            }
            return Ok("Hello World");
        }
        public IHttpActionResult GetProduct(int normal,int joke)
        {
            if (joke == 100)
            {
                return Ok("Hello World 100");
            }
            //var product = products.FirstOrDefault((p) => p.Id == id);
            if (normal == 0)
            {
                return NotFound();
            }
            return Ok("Hello World");
        }
    }
}
