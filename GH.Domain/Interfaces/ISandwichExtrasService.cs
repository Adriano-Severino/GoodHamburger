using GH.Domain.Dto;

namespace GH.Domain.Interfaces
{
    public interface ISandwichExtrasService
    {
        public Task<IEnumerable<ResultSandwichDto>> GetSandwiches();
        public Task<IEnumerable<ResultExtraDto>> GetExtras();
        public Task<ResultDto<Dictionary<string, object>>> GetSandwichesExtras();
    }
}
