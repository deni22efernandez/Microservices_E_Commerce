using Catalog.Services.EventHandlers;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Tests.ContextConfig;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace Catalog.Tests
{
	[TestClass]
	public class ProductUpdateEventHandlerTest
	{
		private ILogger<ProductUpdateEventHandler> GetLogger
		{
			get
			{
				return new Mock<ILogger<ProductUpdateEventHandler>>().Object;
			}
			
		}
		[TestMethod]
		public void TryToSubstractStockWhenProductHasStock()
		{
			var context = ApplicationDbContextInMemory.Get();
			//creo un objeto de prueba
			context.Products.Add(new Domain.Product
			{
				Id = 1,
				Description = "description...",
				Name = "name...",
				Price = 50,
				Stock = 1
			});
			context.SaveChanges();

			var handler = new ProductUpdateEventHandler(context, GetLogger);

			handler.Handle(new ProductUpdateCommand {
				Items= new List<ProductUpdateItem>()
				{
					new ProductUpdateItem
					{
						 Action= Action.Substract,
						 Description="new description",
						 Id=1 
					}
				}
			}, new CancellationToken()).Wait();
		}

		//[TestMethod]
		//public void TryToSubstractStockWhenProductHasNotStock()
		//{
		//	var context = ApplicationDbContextInMemory.Get();
		//	//creo un objeto de prueba
		//	context.Products.Add(new Domain.Product
		//	{
		//		Id = 1,
		//		Description = "description...",
		//		Name = "name...",
		//		Price = 50,
		//		Stock = 1
		//	});
		//	context.SaveChanges();

		//	var handler = new ProductUpdateEventHandler(context, GetLogger);

		//	handler.Handle(new ProductUpdateCommand
		//	{
		//		Items = new List<ProductUpdateItem>()
		//		{
		//			new ProductUpdateItem
		//			{
		//				 Action = Action.Substract,
		//				 Stock = 2,
		//				 Description ="new description",
		//				 Id = 1
		//			}
		//		}
		//	}, new CancellationToken()).Wait();
		//}
	}
}
