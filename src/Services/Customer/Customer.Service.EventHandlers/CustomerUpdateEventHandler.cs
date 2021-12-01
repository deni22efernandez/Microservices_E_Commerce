using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Service.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers
{
	public class CustomerUpdateEventHandler : INotificationHandler<CustomerUpdateCommand>
	{
		private readonly ApplicationDbContext _db;
		public CustomerUpdateEventHandler(ApplicationDbContext db)
		{
			_db = db;
		}
		// from HtttpPut
		public async Task Handle(CustomerUpdateCommand notification, CancellationToken cancellationToken)
		{
			var clientFromDb = await _db.Clients.FirstOrDefaultAsync(x => x.Id == notification.Id);
			if (clientFromDb == null)//if client is null will create
			{
				await _db.Clients.AddAsync(notification.MapTo<Client>());
			}
			//else update
			_db.Update(notification.MapTo<Client>());//ver
			await _db.SaveChangesAsync();
		}
	}
}
