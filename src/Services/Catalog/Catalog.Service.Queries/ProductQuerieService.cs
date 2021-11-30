using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
	public interface IProductQuerieService
	{
		Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> productIds = null);
		Task<ProductDto> GetAsync(int id);
	}
	public class ProductQuerieService : IProductQuerieService
	{
		private readonly ApplicationDbContext _db;
		public ProductQuerieService(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> productIds = null)
		{
			var collection = await _db.Products
									.Where(x => productIds == null || productIds.Contains(x.Id))
									.OrderBy(x => x.Id)
									.GetPagedAsync(page, take);
			//var prodList = _db.Products.OrderBy(x => x.Id);
			//var count = await prodList.CountAsync();
			//var collection = new DataCollection<Product>
			//{
			//	Items = await prodList.Skip((page - 1) * take).Take(take).ToListAsync(),
			//	Page = page,
			//	TotalItems = count,
			//	TotalPages = (int)Math.Ceiling((decimal)count / take)
			//};
			return collection.MapTo<DataCollection<ProductDto>>();
		}
		public async Task<ProductDto> GetAsync(int id)
		{
			return (await _db.Products.FirstOrDefaultAsync(x => x.Id == id)).MapTo<ProductDto>();
		}
	}

}
