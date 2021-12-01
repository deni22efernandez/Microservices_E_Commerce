using Customer.Service.EventHandlers.Commands;
using Customer.Service.Queries;
using Customer.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
	[Route("customers")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerQuerieService _customerQuerieService;
		private readonly IMediator _mediator;
		public CustomerController(ICustomerQuerieService customerQuerieService, IMediator mediator)
		{
			_customerQuerieService = customerQuerieService;
			_mediator = mediator;
		}

		//get all customers
		[HttpGet]
		public async Task<DataCollection<CustomerDto>> GetAsync()
		{
			return await _customerQuerieService.GetAllAsync(1, 2);
		}
		//get one customer
		[HttpGet("{id}")]
		public async Task<CustomerDto> GetAsync(int id)
		{
			return await _customerQuerieService.Get(id);
		}
		[HttpPost]
		public async Task<IActionResult> PostAsync(CustomerCreateCommand command)
		{
			await _mediator.Publish(command);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> PutAsync(CustomerUpdateCommand command)
		{
			await _mediator.Publish(command);
			return Ok();
		}
	}
}
