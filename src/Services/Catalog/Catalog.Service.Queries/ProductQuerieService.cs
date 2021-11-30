using Catalog.Domain;
using Catalog.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
	public class ProductQuerieService
	{
		private readonly ApplicationDbContext _db;
		public ProductQuerieService(ApplicationDbContext db)
		{
			_db = db;
		}
		
		public async Task<IEnumerable<Product>> GetAll(int page)
		{
			var products = await _db.Products.Skip((page - 1) * 10).Take(10).OrderBy(x => x.Name).ToListAsync();
			return products;
		}
	}
}
