using Customer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Persistence.Database.ClientConfiguration
{
	public class ClientConfig : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.LastName).IsRequired();

			builder.HasData(
				new Client()
				{
					Id = 1,
					Name = "Miriam",
					LastName = "Lopez",
					Email = "miriLopez@gmail.com"
				},
				new Client()
				{
					Id = 2,
					Name = "Dana",
					LastName = "Fernandez",
					Email = "danaFer@gmail.com"
				},
				new Client()
				{
					Id = 3,
					Name = "Denisse",
					LastName = "Fer",
					Email = "Deni22e@gmail.com"
				});


		}
	}
}
