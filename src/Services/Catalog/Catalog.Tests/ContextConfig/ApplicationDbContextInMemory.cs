using Catalog.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Tests.ContextConfig
{
	public class ApplicationDbContextInMemory
	{
		public static ApplicationDbContext Get()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
							.UseInMemoryDatabase("Catalog.DB")
							.Options;
			return new ApplicationDbContext(options);
		}
	}
}
