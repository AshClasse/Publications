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
        
        public DbSet<Employee> employee { get; set; }
        public DbSet<Jobs> jobs { get; set; }
        public DbSet<Publisher> publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jobs>().HasKey(e => e.JobID);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmpID);
            modelBuilder.Entity<Publisher>().HasKey(e => e.PubID);
        }
    }
}
