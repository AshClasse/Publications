using Microsoft.EntityFrameworkCore;
using Publicaciones.Domain.Entities;

namespace Publicaciones.Infrastructure.Context
{
    public class PublicacionesContext : DbContext
    {
        public PublicacionesContext(DbContextOptions<PublicacionesContext> options) : base(options)
        {

        }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>().HasKey(s => s.DiscountID);
            modelBuilder.Entity<Sale>().HasKey(s => new { s.StoreID, s.OrdNum, s.TitleID });
            modelBuilder.Entity<Store>().HasKey(s => s.StoreID);
            modelBuilder.Entity<Title>().HasKey(s => s.TitleID);

            base.OnModelCreating(modelBuilder);
        }
    }
}