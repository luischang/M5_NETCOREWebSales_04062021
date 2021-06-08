using AutoMapper;
using M5_NETCOREWEBSales.Core.DTOs;
using M5_NETCOREWEBSales.Core.Entities;
using M5_NETCOREWEBSales.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M5_NETCOREWebSales.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;


        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        //[Authorize]
        [HttpGet]
        [Route("GetCustomer")]        
        public async Task<IActionResult> GetCustomer()
        {
            var customers = await _customerRepository.GetCustomers();
            //var customerList = new List<CustomerDTO>();
            //foreach (var item in customers)
            //{
            //    var customerDTO = new CustomerDTO()
            //    {
            //        Id = item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        City = item.City,
            //        Country = item.Country,
            //        Phone = item.Phone
            //    };
            //    customerList.Add(customerDTO);
            //}
            var customerList = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customerList);
        }

        [HttpGet]
        [Route("CustomerById/{id}")]
        public async Task<IActionResult> CustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpPost]
        [Route("PostCustomer")]
        //[AllowAnonymous]
        public async Task<IActionResult> PostCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);

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
