using GH.Domain.Enums;

namespace GH.Domain.Dto
{
    public class ResultSandwichDto
    {
        public string Sandwich { get; set; }
        public EnumSandwichType EnumSandwichType { get; set; }
        public decimal Price { get; set; }
    }
}
