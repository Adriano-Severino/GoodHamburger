using AutoMapper;
using GH.Domain.Dto;
using GH.Domain.Entities;
using GH.Domain.Interfaces;
using GH.Infra.CrossCutting.Utils;
using GH.Service.Response;

namespace GH.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IBaseRepository<Order> baseRepository, IMapper mapper)
        {
            _orderRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ResultDto<Order>> GetOrders()
        {
            var result = await _orderRepository.SelectAsync<Order>(o => o.Sandwich, o => o.Extras);
            return Result.Response(result.ToList());
        }
        public async Task<ResultDto<Order>> GetOrderById(Guid id)
        {
            var resultDto = new List<Order>();
            var result = await _orderRepository.SelectAsync<Order>(id, o => o.Sandwich, o => o.Extras);
            if (result != null)
            {
                resultDto.Add(result);
                return Result.Response(resultDto);
            }
            return Result.Response(resultDto);
        }
        public async Task<ResultDto<Order>> CreateOrder(CreateOrderDto orderDto)
        {
            var resultDto = new List<Order>();
            try
            {
                var order = _mapper.Map<Order>(orderDto);
                order.Sandwich.Price = PriceProduct.GetPrice(order.Sandwich.EnumSandwichType.ToString());
                await _orderRepository.InsertAsync(order);
                if (order != null)
                {
                    resultDto.Add(order);
                    return Result.Response(resultDto, false, "Pedido criado com sucesso!", "Não foi possivel criar o pedido!");
                }
                return Result.Response(resultDto, false, "Pedido criado com sucesso!", "Não foi possivel criar o pedido!");
            }
            catch (Exception ex)
            {
                return Result.Response(resultDto, true, "Pedido criado com sucesso!", ex.Message);
            }
        }
        public async Task<ResultDto<Order>> UpdateOrder(UpdateOrderDto updateOrder)
        {
            var resultDto = new List<Order>();
            try
            {
                var existingOrder = await _orderRepository.SelectAsync<Order>(updateOrder.Id, o => o.Sandwich, o => o.Extras);

                if (existingOrder == null)
                {
                    return Result.Response(resultDto, false, "Pedido atualizado com sucesso!");
                }

                existingOrder.Sandwich.EnumSandwichType = updateOrder.Sandwich.EnumSandwichType;
                existingOrder.Sandwich.Price = PriceProduct.GetPrice(existingOrder.Sandwich.EnumSandwichType.ToString());

                // Limpar a lista de Extras existente
                existingOrder.Extras.Clear();

                // Mapear os novos Extras do DTO para a entidade
                foreach (var extraDto in updateOrder.Extras)
                {
                    var extra = _mapper.Map<Extra>(extraDto);
                    existingOrder.Extras.Add(extra);
                }

                await _orderRepository.UpdateAsync(existingOrder);
                resultDto.Add(existingOrder);
                return Result.Response(resultDto, false, "Pedido atualizado com sucesso!", "Não foi possivel atualizar o pedido!");

            }
            catch (Exception ex)
            {
                return Result.Response(resultDto, true, "Pedido criado com sucesso!", ex.Message);
            }
        }
        public async Task<ResultDto<Order>> DeleteOrder(Guid id)
        {
            var resultDto = new List<Order>();
            var order = await _orderRepository.SelectAsync<Order>(id, o => o.Sandwich, o => o.Extras);
            try
            {
                if (order != null)
                {
                    await _orderRepository.DeleteAsync(id);
                    resultDto.Add(order);
                }
                return Result.Response(resultDto, false, "Pedido deletado com sucesso!", "Não foi possivel deletar o pedido!");
            }
            catch (Exception ex)
            {
                return Result.Response(resultDto, true, "Pedido deletado com sucesso!", ex.Message);

            }
        }
        
    }
}
