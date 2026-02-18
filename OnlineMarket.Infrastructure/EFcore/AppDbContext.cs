using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Infrastructure.EFcore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders {  get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
    }
}
