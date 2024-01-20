using GH.Application.Helpers;
using GH.Domain.Dto;
using GH.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GH.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("get-orders")]
        public async Task<IActionResult> GetOrders()
        {
            return await ExecuteAsync(async () => await _orderService.GetOrders());
        }

        [HttpGet]
        [Route("get-order")]
        public async Task<IActionResult> GetOrderById([FromQuery] Guid id)
        {
            return await ExecuteAsync(async () => await _orderService.GetOrderById(id));
        }

        [HttpPost]
        [Route("create-order")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto order)
        {
            if (order == null)
                return NotFound();

            order.Validate();
            if (order.Invalid)
            {
                return NotFound(order);
            }

            var check = CheckRepeated.CheckCreate(order);
            if (!check.Success)
            {
                return NotFound(check);
            }
            return await ExecuteAsync(async () => await _orderService.CreateOrder(order));
        }

        [HttpPut()]
        [Route("update-order")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto updateOrderDto)
        {
            if (updateOrderDto == null)
                return NotFound();

            updateOrderDto.Validate();
            if (updateOrderDto.Invalid)
            {
                return NotFound(updateOrderDto);
            }

            var check = CheckRepeated.CheckUpdate(updateOrderDto);
            if (!check.Success)
            {
                return NotFound(check);
            }
            return await ExecuteAsync(async () => await _orderService.UpdateOrder(updateOrderDto));
        }

        [HttpDelete()]
        [Route("delete-order")]
        public async Task<IActionResult> DeleteOrder([FromQuery] Guid id)
        {
            return await ExecuteAsync(async () => await _orderService.DeleteOrder(id));
        }
        private async Task<IActionResult> ExecuteAsync(Func<Task<object>> func)
        {
            try
            {
                var result = await func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
