using Catalog.Persistence.Database;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Services.EventHandlers
{
	public class ProductUpdateEventHandler : INotificationHandler<ProductUpdateCommand>
	{
		private readonly ApplicationDbContext _db;
		private ILogger<ProductUpdateEventHandler> _logger;
		public ProductUpdateEventHandler(ApplicationDbContext db, ILogger<ProductUpdateEventHandler> logger)
		{
			_db = db;
			_logger = logger;
		}
		public async Task Handle(ProductUpdateCommand command, CancellationToken cancellationToken)
		{
			_logger.LogInformation("Start...");
			//var products = command.Items.Select(x => x.Id);
			//var stocks = _db.Products.Where(x => products.Contains(x.Id)).ToList();
			foreach (var item in command.Items)
			{
				var entry = await _db.Products.FirstOrDefaultAsync(x => x.Id == item.Id);

				if (item.Action == Catalog.Services.EventHandlers.Commands.Action.Substract)
				{
					if (entry == null || entry.Stock < item.Stock)
					{
						_logger.LogError("not enough stock...");
						throw new Exception("item doesnt have enough stock");
					}
					entry.Description = item.Description;
					entry.Name = item.Name;
					entry.Price = item.Price;
					entry.Stock -= item.Stock;
				}
				else
				{
					if (entry == null)
					{
						var prod = new ProductCreateCommand//ver si c crea
						{
							Description = item.Description,
							Name = item.Name,
							Stock = item.Stock,
							Price = item.Price
						};
					}
					else
					{
						entry.Description = item.Description;
						entry.Name = item.Name;
						entry.Price = item.Price;
						entry.Stock += item.Stock;
					}
				}				

			}
			_logger.LogInformation("end...");
			await _db.SaveChangesAsync();

		}
	}
}
