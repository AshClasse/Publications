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
    }
}