using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Queries.DTOs
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public int Stock { get; set; }
	}
}
