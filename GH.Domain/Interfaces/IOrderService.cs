using GH.Domain.Dto;
using GH.Domain.Entities;

namespace GH.Domain.Interfaces
{
    public interface IOrderService
    {
        public Task<ResultDto<Order>> GetOrders();
        public Task<ResultDto<Order>> GetOrderById(Guid id);
        public Task<ResultDto<Order>> CreateOrder(CreateOrderDto orderDto);
        public Task<ResultDto<Order>> UpdateOrder(UpdateOrderDto updateOrder);
        public Task<ResultDto<Order>> DeleteOrder(Guid id);
        public Task<IEnumerable<ResultSandwichDto>> GetSandwiches();
        public Task<IEnumerable<ResultExtraDto>> GetExtras();
        public Task<ResultDto<Dictionary<string,object>>> GetSandwichesExtras();
    }
}
