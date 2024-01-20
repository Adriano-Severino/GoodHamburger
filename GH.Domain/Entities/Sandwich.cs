using GH.Domain.Enums;

namespace GH.Domain.Entities
{
    public class Sandwich : BaseEntity
    {
        public EnumSandwichType EnumSandwichType { get; set; }
        public decimal Price { get; set; }
    }
}
