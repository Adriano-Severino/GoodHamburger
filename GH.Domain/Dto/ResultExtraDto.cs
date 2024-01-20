using GH.Domain.Enums;

namespace GH.Domain.Dto
{
    public class ResultExtraDto
    {
        public string Extra { get; set; }
        public EnumExtraType EnumExtraType { get; set; }
        public decimal Price { get; set; }
    }
}
