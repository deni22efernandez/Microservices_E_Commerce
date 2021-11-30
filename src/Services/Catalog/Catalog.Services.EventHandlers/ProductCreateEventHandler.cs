using Catalog.Persistence.Database;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Services.EventHandlers
{
	public class ProductCreateEventHandler:INotificationHandler<ProductCreateCommand>
	{
		private readonly ApplicationDbContext _db;
		public ProductCreateEventHandler(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
		{
			await _db.Products.AddAsync(new Domain.Product
			{
				Name = command.Name,
				Description = command.Description,
				Price = command.Price,
				Stock = command.Stock
			});
			await _db.SaveChangesAsync();
		}

	}
}
