using Publicaciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<Titles> Titles { get; set; }
        public DbSet<RoySched> RoyScheds { get; set; }
        public DbSet<Pub_Info> Pub_Infos { get; set; }
    }
}
