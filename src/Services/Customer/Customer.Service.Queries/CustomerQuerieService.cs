using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.Queries
{
	public interface ICustomerQuerieService
	{
		Task<DataCollection<CustomerDto>> GetAllAsync(int page, int take, IEnumerable<int> clientIds = null);
		Task<CustomerDto> Get(int id);
	}
	public class CustomerQuerieService : ICustomerQuerieService
	{
		private readonly ApplicationDbContext _db;
		public CustomerQuerieService(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<DataCollection<CustomerDto>> GetAllAsync(int page, int take, IEnumerable<int> clientIds = null)
		{
			var clients = _db.Clients
								.OrderBy(x => x.LastName);
			var items = await clients.CountAsync();

			var collection = new DataCollection<Client>()
			{
				Items = await clients.Skip((page - 1) * take).Take(take).ToListAsync(),
				Page = page,
				TotalItems = items,
				TotalPages = (int)Math.Ceiling((decimal)items / take)
			};
			return clients.MapTo<DataCollection<CustomerDto>>();
		}
		public async Task<CustomerDto> Get(int id)
		{
			return (await _db.Clients.FirstOrDefaultAsync(x => x.Id == id)).MapTo<CustomerDto>();

		}
	}
}
