﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HelloAspNet5.Web.Data;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloAspNet5.Web
{
    [Route("api/[controller]")]
    public class CustomersController : ApiController
    {
        private readonly NorthwindSlimContext _dbContext;

        public CustomersController(NorthwindSlimContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _dbContext.Customers
                .OrderBy(p => p.CustomerId)
                .ToListAsync();
            return Ok(products);
        }
    }
}
