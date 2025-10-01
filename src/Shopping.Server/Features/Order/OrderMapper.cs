namespace Shopping.Server.Features.Order;

public static class OrderMapper
{
	#region ToDto
	public static OrderDto ToDto(this Order order) =>
		new(
			order.Id,
			order.Name,
			order.Price);
	#endregion
	
	#region ToDomain
	public static Order ToDomain(this CreateOrderDto createOrderDto) =>
		new()
		{
			Name = createOrderDto.Name,
			Price = createOrderDto.Price
		};
	
	public static Order ToDomain(this UpdateOrderDto updateOrderDto, long id) =>
		new()
		{
				Id = id,
				Name = updateOrderDto.Name,
				Price = updateOrderDto.Price
		};
	#endregion
}