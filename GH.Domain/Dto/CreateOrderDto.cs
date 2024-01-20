using GH.Domain.Entities;
using GH.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System.Linq;

namespace GH.Domain.Dto
{
    public class CreateOrderDto : Notifiable, IValidatable
    {
        public SandwichDto Sandwich { get; set; }
        public List<ExtraDto> Extras { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Enum.IsDefined(typeof(EnumSandwichType), Sandwich.EnumSandwichType), "Sandwich.EnumSandwichType", "O tipo de sanduíche não é válido")
                .IsTrue(Extras.All(extra => Enum.IsDefined(typeof(EnumExtraType), extra.EnumExtraType)), "Extras", "Um ou mais extras não são válidos")
            );
        }
    }
}
