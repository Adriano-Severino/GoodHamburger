using GH.Domain.Dto;

namespace GH.Service.Response
{
    public static class Result
    {
        public static ResultDto<T> Response<T>(List<T> result, bool ex = false, string sucessoMesage = "Pedidos encontrados", string FaledMessage = "Nenhum pedido foi encontrado!")
        {
            var resultDto = new ResultDto<T>();
            if (ex)
            {
                resultDto.Success = false;
                resultDto.Message = FaledMessage;
                resultDto.Data = new List<T>();
                return resultDto;
            }
            if (result.Count == 0)
            {
                resultDto.Success = false;
                resultDto.Message = FaledMessage;
                return resultDto;
            }
            resultDto.Success = true;
            resultDto.Message = sucessoMesage;
            resultDto.Data = result;
            return resultDto;
        }
    }
}
