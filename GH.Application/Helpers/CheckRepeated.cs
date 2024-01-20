using GH.Domain.Dto;

namespace GH.Application.Helpers
{
    public static class CheckRepeated
    {
        public static ResultDto<CreateOrderDto> CheckCreate(CreateOrderDto createOrderDto)
        {
            var resultDto = new ResultDto<CreateOrderDto>();
            if (createOrderDto.Extras.GroupBy(o => o.EnumExtraType).Any(g => g.Count() > 1))
            {
                var result = Verification<CreateOrderDto>(resultDto);
                resultDto.Data = createOrderDto.Extras;
                return result;

            }

            resultDto.Success = true;
            return resultDto;
        }

        public static ResultDto<UpdateOrderDto> CheckUpdate(UpdateOrderDto updateOrderDto)
        {
            var resultDto = new ResultDto<UpdateOrderDto>();
            if (updateOrderDto.Extras.GroupBy(o => o.EnumExtraType).Any(g => g.Count() > 1))
            {
                var result = Verification<UpdateOrderDto>(resultDto);
                resultDto.Data = updateOrderDto.Extras;
                return result;
            }
            resultDto.Success = true;
            return resultDto;

        }
        private static ResultDto<TEntity> Verification<TEntity>(ResultDto<TEntity> resultDto) where TEntity : class
        {
            resultDto.Success = false;
            resultDto.Message = "Cada pedido não pode conter mais de um sanduíche, batata frita ou refrigerante.";
            return resultDto;
        }
    }
}
