using GH.Domain.Enums;

namespace GH.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Sandwich Sandwich { get; set; }
        public IList<Extra> Extras { get; set; }
        public decimal TotalPrice
        {
            get
            {
                var discount = CalculateDiscount();
                var sandwichPrice = Sandwich?.Price ?? 0;
                var extrasPrice = Extras?.Sum(extra => extra.Price) ?? 0;
                return (sandwichPrice + extrasPrice) * (1 - discount);
            }
        }
        private decimal CalculateDiscount()
        {
            if (Sandwich != null && Extras != null)
            {
                if (Extras.Any(extra => extra.EnumExtraType == EnumExtraType.Fries) && Extras.Any(extra => extra.EnumExtraType == EnumExtraType.SoftDrink))
                {
                    return 0.20m;
                }
                else if (Extras.Any(extra => extra.EnumExtraType == EnumExtraType.SoftDrink))
                {
                    return 0.15m;
                }
                else if (Extras.Any(extra => extra.EnumExtraType == EnumExtraType.Fries))
                {
                    return 0.10m;
                }
            }
            return 0m;
        }
    }
}
