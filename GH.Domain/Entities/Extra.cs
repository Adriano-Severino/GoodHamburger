using GH.Domain.Enums;
using GH.Infra.CrossCutting.Utils;

namespace GH.Domain.Entities
{
    public class Extra : BaseEntity
    {
        public Extra()
        {
            
        }
        public Extra(EnumExtraType enumExtraType)
        {
            Price = PriceProduct.GetPrice(enumExtraType.ToString());
            EnumExtraType = enumExtraType;
        }
        public EnumExtraType EnumExtraType { get; set; }
        public decimal Price { get; set; }
    }
}
