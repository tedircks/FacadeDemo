// See https://aka.ms/new-console-template for more information
using FacadePatternDemo;
using Microsoft.Extensions.DependencyInjection;

#region Configure DI
var services = new ServiceCollection();

services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IInventoryService, InventoryService>();
services.AddScoped<IDeliveryService, DeliveryService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IReviewService, ReviewService>();
services.AddTransient<IProductPageFacade, ProductPageFacade>();

var serviceProvider = services.BuildServiceProvider();
#endregion

var facade = serviceProvider.GetService<IProductPageFacade>();
facade.LoadPage(1);
facade.PlaceOrder(1, 10);

while (true) { }