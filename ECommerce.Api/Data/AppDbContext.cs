using ECommerce.Api.Data.Entities;
using ECommerce.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<PaymentTicket> PaymentTickets { get; set; }
    }
}
