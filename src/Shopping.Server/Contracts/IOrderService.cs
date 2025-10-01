using Shopping.Server.Features.Order;

namespace Shopping.Server.Contracts;

public interface IOrderService
{
	Task<OrderDto> Create(CreateOrderDto createOrderDto);
	Task<OrderDto> Update(long id, UpdateOrderDto updateOrderDto);
	Task<List<OrderDto>> GetAll();
	Task<OrderDto> Get(long id);
	Task Delete(long id);
}