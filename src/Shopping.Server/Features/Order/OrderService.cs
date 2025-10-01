using Shopping.Server.Contracts;

namespace Shopping.Server.Features.Order;

public class OrderService : IOrderService
{
	public static readonly List<Order> Orders = new()
	{
		new Order { Id = 1, Name = "Laptop", Price = 10.0m },
		new Order { Id = 2, Name = "Item 2", Price = 20.0m },
		new Order { Id = 3, Name = "Item 3", Price = 30.0m },
	};
	
	public Task<OrderDto> Create(CreateOrderDto createOrderDto)
	{
		var orderDomain = createOrderDto.ToDomain();
		orderDomain.Id = Orders.Max(o => o.Id) + 1;
		Orders.Add(orderDomain);
		return Task.FromResult(orderDomain.ToDto());
	}
	
	public Task Delete(long id)
	{
		var order = Orders.FirstOrDefault(o => o.Id == id);
		if (order != null)
		{
			Orders.Remove(order);
		}
		return Task.CompletedTask;
	}
	
	public Task<List<OrderDto>> GetAll()
	{
		var orderDtos = Orders.Select(o => o.ToDto()).ToList();
		return Task.FromResult(orderDtos);
	}
	
	public Task<OrderDto?> Get(long id)
	{
		var order = Orders.FirstOrDefault(o => o.Id == id);
		return Task.FromResult(order?.ToDto());
	}
	
	public Task<OrderDto> Update(long id, UpdateOrderDto updateOrderDto)
	{
		var orderIndex = Orders.FindIndex(o => o.Id == id);
		if (orderIndex != -1)
		{
			var updatedOrder = updateOrderDto.ToDomain(id);
			Orders[orderIndex] = updatedOrder;
		}
		return Task.FromResult(Orders[orderIndex].ToDto());
	}
}