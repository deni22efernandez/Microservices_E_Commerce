using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Persistence.Database.ProductConfiguration
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasIndex(x => x.Id);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Description).IsRequired().HasMaxLength(100);

			var products = new List<Product>();
			var rdm = new Random();
			for (int i = 1; i < 10; i++)
			{
				var p = new Product
				{
					Id = i,
					Name = $"Product {i}",
					Description = $"Product {i} description...",
					Price = rdm.Next(100, 1000),
					Stock = rdm.Next(0, 100)
				};
				products.Add(p);
			}
			
			builder.HasData(products);
		}
	}
}
