using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
	[Route("products")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductQuerieService _product;
		private readonly IMediator _mediator;
		public ProductController(IProductQuerieService product, IMediator mediator)
		{
			_product = product;
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<DataCollection<ProductDto>> GetAllAsync(int page=2, int take=3, string ids = null)
		{
			IEnumerable<int> prodId = null;
			if (!string.IsNullOrEmpty(ids))
			{
				 prodId = ids.Split(",").Select(x => Convert.ToInt32(x));
			}
			
			return await _product.GetAllAsync(page, take, prodId);
		}
		[HttpGet("{id}")]
		public async Task<ProductDto> GetAsync(int id)
		{
			return await _product.GetAsync(id);
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync(ProductCreateCommand command)
		{
			await _mediator.Publish(command);
			return Ok();
		} 
		[HttpPut]
		public async Task<IActionResult> Put(ProductUpdateCommand command)
		{
			await _mediator.Publish(command);
			return NoContent();
		}
	}
}
