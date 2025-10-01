using Shopping.Server.Contracts;
using Shopping.Server.Features.Order;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSingleton<IOrderService, OrderService>();

builder.Services.AddMcpServer()
		.WithHttpTransport()
		.WithTools<OrderTool>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapMcp();
app.Run();
