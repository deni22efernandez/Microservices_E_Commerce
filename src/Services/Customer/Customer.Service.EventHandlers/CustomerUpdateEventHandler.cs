using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
		private ILogger<CustomerUpdateEventHandler> _logger;
		public CustomerUpdateEventHandler(ApplicationDbContext db, ILogger<CustomerUpdateEventHandler> logger)
		{
			_db = db;
			_logger = logger;
		}
		// from HtttpPut
		public async Task Handle(CustomerUpdateCommand notification, CancellationToken cancellationToken)
		{
			_logger.LogInformation("Start update (HttpPut) customer...");
			var clientFromDb = await _db.Clients.FirstOrDefaultAsync(x => x.Id == notification.Id);
			_logger.LogInformation("Retrieve customer from database...");
			if (clientFromDb == null)//if client is null will create
			{
				_logger.LogInformation("Customer not found...create customer...");
				await _db.Clients.AddAsync(notification.MapTo<Client>());
			}
			//else update
			else
			{
				_logger.LogInformation("Update customer...");
				clientFromDb.Name = notification.Name;
				clientFromDb.LastName = notification.LastName;
				clientFromDb.Mobile = notification.Mobile;
				clientFromDb.Email = notification.Email;			
				_db.Update(clientFromDb);//ver
			}
			
			_logger.LogInformation("Save changes...");
			await _db.SaveChangesAsync();
		}
	}
}
