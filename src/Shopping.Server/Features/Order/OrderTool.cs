using System.ComponentModel;
using ModelContextProtocol.Server;
using Shopping.Server.Contracts;

namespace Shopping.Server.Features.Order;

[McpServerToolType]
public class OrderTool (IOrderService orderService)
{
	[McpServerTool, Description("Creates a new order and returns the created order.")]
	public async Task<OrderDto> CreateOrder(CreateOrderDto createOrderDto) 
		=> await orderService.Create(createOrderDto);

	[McpServerTool, Description("Updates an existing order.")]
	public async Task<OrderDto> UpdateOrder(long id, UpdateOrderDto updateOrderDto) 
		=> await orderService.Update(id, updateOrderDto);

	[McpServerTool, Description("Gets all orders.")]
	public async Task<List<OrderDto>> GetAllOrders() 
		=> await orderService.GetAll();

	[McpServerTool, Description("Gets an order by ID.")]
	public async Task<OrderDto> GetOrder(long id) 
		=> await orderService.Get(id);

	[McpServerTool, Description("Deletes an order by ID.")]
	public async Task DeleteOrder(long id) 
		=> await orderService.Delete(id);
}