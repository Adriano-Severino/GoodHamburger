using GH.Domain.Enums;

namespace GH.Domain.Extensions
{

    public static class EnumExtensions
    {
        public static string ToSandwichFriendlyString(this EnumSandwichType me)
        {
            switch (me)
            {
                case EnumSandwichType.XBurger:
                    return "X Burger";
                case EnumSandwichType.XEgg:
                    return "X Egg";
                case EnumSandwichType.XBacon:
                    return "X Bacon";
                default:
                    return "Unknown";
            }
        }
        public static string ToExtraFriendlyString(this EnumExtraType me)
        {
            switch (me)
            {
                case EnumExtraType.SoftDrink:
                    return "Soft drink";
                case EnumExtraType.Fries:
                    return "Fries";
                default:
                    return "Unknown";
            }
        }
    }
}
