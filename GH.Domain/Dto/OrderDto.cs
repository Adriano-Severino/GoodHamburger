using GH.Domain.Entities;

namespace GH.Domain.Dto
{
    public class OrderDto
    {
        public Sandwich Sandwich { get; set; }
        public List<Extra> Extras { get; set; }

    }
}
