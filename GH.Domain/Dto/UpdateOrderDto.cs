using Flunt.Notifications;
using Flunt.Validations;
using GH.Domain.Entities;
using GH.Domain.Enums;
using System;

namespace GH.Domain.Dto
{
    public class UpdateOrderDto : Notifiable, IValidatable
    {
        public virtual Guid Id { get; set; }
        public SandwichDto Sandwich { get; set; }
        public List<ExtraDto> Extras { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(Id == Guid.Empty, "Id", "O Id não é um Guid válido")
                .IsTrue(Enum.IsDefined(typeof(EnumSandwichType), Sandwich.EnumSandwichType), "Sandwich.EnumSandwichType", "O tipo de sanduíche não é válido")
                .IsTrue(Extras.All(extra => Enum.IsDefined(typeof(EnumExtraType), extra.EnumExtraType)), "Extras", "Um ou mais extras não são válidos")
            );
        }
    }
}
