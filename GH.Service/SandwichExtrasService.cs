using GH.Domain.Dto;
using GH.Domain.Entities;
using GH.Domain.Extensions;
using GH.Domain.Interfaces;

namespace GH.Service
{
    public class SandwichExtrasService : ISandwichExtrasService
    {
        private readonly IBaseRepository<Extra> _extraRepository;
        private readonly IBaseRepository<Sandwich> _sandwichRepository;
        public SandwichExtrasService(IBaseRepository<Extra> extraRepository, IBaseRepository<Sandwich> sandwichRepository)
        {
            _extraRepository = extraRepository;
            _sandwichRepository = sandwichRepository;
        }

        public async Task<IEnumerable<ResultSandwichDto>> GetSandwiches()
        {
            var sandwich = await _sandwichRepository.SelectAsync();
            var resultSandwichDto = new List<ResultSandwichDto>();

            // Agrupar por Sandwich e selecionar o primeiro de cada grupo
            var distinctSandwich = sandwich
                .GroupBy(e => e.EnumSandwichType)
                .Select(g => g.First())
                .ToList();

            foreach (var item in distinctSandwich)
            {
                resultSandwichDto.Add(new ResultSandwichDto
                {
                    Sandwich = item.EnumSandwichType.ToSandwichFriendlyString(),
                    Price = item.Price,
                    EnumSandwichType = item.EnumSandwichType
                });
            }

            return resultSandwichDto;
        }
        public async Task<IEnumerable<ResultExtraDto>> GetExtras()
        {
            var extras = await _extraRepository.SelectAsync();
            var resultExtraDto = new List<ResultExtraDto>();

            // Agrupar por extra e selecionar o primeiro de cada grupo
            var distinctExtras = extras
                .GroupBy(e => e.EnumExtraType)
                .Select(g => g.First())
                .ToList();

            foreach (var item in distinctExtras)
            {
                resultExtraDto.Add(new ResultExtraDto
                {
                    Extra = item.EnumExtraType.ToExtraFriendlyString(),
                    Price = item.Price,
                    EnumExtraType = item.EnumExtraType
                });

            }

            return resultExtraDto;
        }
        public async Task<ResultDto<Dictionary<string, object>>> GetSandwichesExtras()
        {
            var result = new ResultDto<Dictionary<string, object>>();
            var dictionary = new Dictionary<string, object>();
            var resultExtraDto = new List<ResultExtraDto>();
            var resultSandwichDto = new List<ResultSandwichDto>();
            var extras = await _extraRepository.SelectAsync();
            var sandwich = await _sandwichRepository.SelectAsync();

            // Agrupar por extra e selecionar o primeiro de cada grupo
            var distinctExtras = extras
                   .GroupBy(e => e.EnumExtraType)
                   .Select(g => g.First())
                   .ToList();

            // Agrupar por Sandwich e selecionar o primeiro de cada grupo
            var distinctSandwich = sandwich
                .GroupBy(e => e.EnumSandwichType)
                .Select(g => g.First())
                .ToList();

            foreach (var item in distinctExtras)
            {
                resultExtraDto.Add(new ResultExtraDto
                {
                    Extra = item.EnumExtraType.ToExtraFriendlyString(),
                    Price = item.Price,
                    EnumExtraType = item.EnumExtraType
                });

            }

            foreach (var item in distinctSandwich)
            {
                resultSandwichDto.Add(new ResultSandwichDto
                {
                    Sandwich = item.EnumSandwichType.ToSandwichFriendlyString(),
                    Price = item.Price,
                    EnumSandwichType = item.EnumSandwichType
                });
            }

            dictionary.Add("Sandwich:", resultSandwichDto);
            dictionary.Add("Extras:", resultExtraDto);
            result.Success = true;
            result.Message = "sanduíche, batata frita e refrigerante:";
            result.Data = dictionary;

            return result;
        }
    }
}
