using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Service.Queries.DTOs
{
	public class CustomerDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
	}
}
