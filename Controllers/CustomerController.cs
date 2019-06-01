using MISA.Mshopkeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MISA.Mshopkeeper.Controllers
{
    [RoutePrefix("customers")]
    public class CustomerController : ApiController
    {
        private List<Customer> _customers = Customer.ListCustomer();
        // GET: api/Customer
        [Route("")]
        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        // GET: api/Customer/5
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
