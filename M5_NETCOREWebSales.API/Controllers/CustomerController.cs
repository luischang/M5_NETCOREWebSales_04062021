using M5_NETCOREWEBSales.Core.Entities;
using M5_NETCOREWEBSales.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M5_NETCOREWebSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            var customers = await _customerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet]
        [Route("CustomerById/{id}")]
        public async Task<IActionResult> CustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        [Route("PostCustomer")]
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            await _customerRepository.InsertCustomer(customer);
            return Ok(customer);
        
        }

        [HttpPut]
        [Route("PutCustomer")]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
            return Ok(customer);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerRepository.DeleteCustomer(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
