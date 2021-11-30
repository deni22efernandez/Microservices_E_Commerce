using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Services.EventHandlers.Commands
{
	public class ProductCreateCommand:INotification
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public int Stock { get; set; }
	}
}
