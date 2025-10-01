namespace Shopping.Server.Features.Order;

public record OrderDto(
	long Id,
	string Name,
	decimal Price);
	
public record CreateOrderDto(
	string Name,
	decimal Price);
	
public record UpdateOrderDto(
	string Name,
	decimal Price);
	