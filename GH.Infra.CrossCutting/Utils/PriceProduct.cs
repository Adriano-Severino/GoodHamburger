namespace GH.Infra.CrossCutting.Utils
{
    public static class PriceProduct
    {
        private static readonly Dictionary<string, decimal> productPrices = new Dictionary<string, decimal>
    {
        { "XBurger", 5.00m },
        { "XEgg", 4.50m },
        { "XBacon", 7.00m },
        { "Fries", 2.00m },
        { "SoftDrink", 2.50m }
    };

        public static decimal GetPrice(string product)
        {
            if (productPrices.TryGetValue(product, out var price))
            {
                return price;
            }
            else
            {
                return 0;
            }
        }
    }

}
