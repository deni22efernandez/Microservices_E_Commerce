using Customer.Domain;
using Customer.Service.EventHandlers;
using Customer.Tests.ContextConfig;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Customer.Tests
{
	[TestClass]
	public class CustomerUpdateEventHandlerTest
	{
		private ILogger<CustomerUpdateEventHandler> Get
		{
			get
			{
				return new Mock<ILogger<CustomerUpdateEventHandler>>().Object;
			}
		}

		[TestMethod]
		public void TryToUpdateWhenCustomerExists()
		{
			var contxt = ApplicationDbContextInMemory.Get();
			contxt.Clients.Add(new Domain.Client
			{
				Id = 1,
				Email = "email@email.com",
				LastName = "test",
				Name = "test",
				Mobile = "222"
			});
			contxt.SaveChanges();
			var handler = new CustomerUpdateEventHandler(contxt, Get);
			handler.Handle(new Service.EventHandlers.Commands.CustomerUpdateCommand
			{
				Id = 1,
				Email = "newFakeEmail@gmail.com",
				LastName = "fake",
				Name = "fake",
				Mobile = "22"

			}, new System.Threading.CancellationToken()).Wait();
		}
		[TestMethod]
		public void TryToUpdateWhenCustomerDoesntExists()
		{
			var contxt = ApplicationDbContextInMemory.Get();
			contxt.Clients.Add(new Domain.Client
			{
				Id = 2,
				Email = "email@email.com",
				LastName = "test",
				Name = "test",
				Mobile = "222"
			});
			contxt.SaveChanges();
			var handler = new CustomerUpdateEventHandler(contxt, Get);
			handler.Handle(new Service.EventHandlers.Commands.CustomerUpdateCommand
			{
				Id = 3,
				Email = "newFakeEmail@gmail.com",
				LastName = "fake",
				Name = "fake",
				Mobile = "22"

			}, new System.Threading.CancellationToken()).Wait();
		}

	}
}
