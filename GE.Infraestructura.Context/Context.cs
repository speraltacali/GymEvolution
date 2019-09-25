using System;
using GE.Aplicacion.CadenaConexion;
using GE.Dominio.Entity;
using GE.Dominio.Entity.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static GE.Aplicacion.CadenaConexion.CadenaConexion;

namespace GE.Infraestructura.Context
{
    public class Context : DbContext
    {

        public Context()
        {
            
        }

        public Context(DbContextOptions<Context> Option) : base(Option)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AccesoCadenaConexion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente_Factura>().HasKey(x => new {x.ClienteId, x.FacturaId});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Factura> Factura { get; set; }

        public  DbSet<ClienteControl> ClienteControl { get; set; }

        public DbSet<Persona> Persona { get; set; }
    }
}
