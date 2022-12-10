using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("{customerId}")]
        public IActionResult GetMyOrders(int customerId)
        {
            var result = _customerService.GetMyOrders(customerId);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("buyproduct/{customerId}/{piece}")]
        public IActionResult BuyProduct(Product product, int customerId, int piece)
        {

            var result = _customerService.BuyProduct(product, customerId, piece);
            if(result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
         
        }
    }
}