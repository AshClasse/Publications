using Microsoft.EntityFrameworkCore;
using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>().HasNoKey();
            modelBuilder.Entity<Sale>().HasKey(s => new { s.Stor_id, s.Ord_num, s.Title_id });
            modelBuilder.Entity<Store>().HasKey(s => s.Stor_ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}