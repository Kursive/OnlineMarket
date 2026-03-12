using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.EFcore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Orders> Orders {  get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                
                entity.ToTable("Orders");

                
                entity.HasKey(e => e.Id);

                
                entity.Property(e => e.Name)
                    .IsRequired()           
                    .HasMaxLength(200);     

                
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)");  

                
                entity.HasIndex(e => e.Name);

                
                entity.Property(e => e.Status)
                    .HasDefaultValue(Status.NotCreated);
            });
        }
    }
}
