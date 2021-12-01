using Customer.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Tests.ContextConfig
{
	public class ApplicationDbContextInMemory
	{
		public static ApplicationDbContext Get()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase("Cutomer.DB")
				.Options;
			return new ApplicationDbContext(options);
		}
	}
}
