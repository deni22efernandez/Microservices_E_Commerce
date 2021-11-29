using Catalog.Domain;
using Catalog.Persistence.Database.ProductConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Catalog.Persistence.Database
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.HasDefaultSchema("Catalog");
			builder.ApplyConfiguration(new ProductConfig());

		}
	}
}
