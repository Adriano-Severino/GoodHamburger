using GH.Domain.Enums;
using GH.Infra.CrossCutting.Utils;
//using GH.Domain.Extensions;

namespace GH.Domain.Entities
{
    public class Sandwich : BaseEntity
    {
        public EnumSandwichType EnumSandwichType { get; set; }
        public decimal Price { get; set; }
    }
}
