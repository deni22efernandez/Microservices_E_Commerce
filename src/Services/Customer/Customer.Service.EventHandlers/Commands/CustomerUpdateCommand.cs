using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Service.EventHandlers.Commands
{
	public class CustomerUpdateCommand:INotification
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
	}
	
}
