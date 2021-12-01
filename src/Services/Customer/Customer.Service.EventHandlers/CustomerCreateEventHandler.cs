using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using Service.Common.Mapping;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers
{
	public class CustomerCreateEventHandler:INotificationHandler<CustomerCreateCommand>
	{
		private readonly ApplicationDbContext _db;
		public CustomerCreateEventHandler(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task Handle(CustomerCreateCommand command, CancellationToken cancellationToken)
		{
			await _db.Clients.AddAsync(command.MapTo<Client>());//VER
			await _db.SaveChangesAsync();
		}
	}
}
