using GH.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GH.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }

    }
}
