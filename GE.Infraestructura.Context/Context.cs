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


        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Factura> Factura { get; set; }

        public DbSet<ClienteControl> ClienteControl { get; set; }

        public DbSet<Caja> Caja { get; set; }

        public DbSet<DetalleCaja> DetalleCaja { get; set; }

        public DbSet<Cuota> Cuota { get; set; }

        public DbSet<Persona> Persona { get; set; }

        public DbSet<Movimiento> Movimiento { get; set; }

        public DbSet<Pago_Factura> Pago_Factura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago_Factura>().HasKey(x => new {x.UsuarioId, x.FacturaId , x.CuotaId});
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Cliente>().ToTable("Persona_Cliente");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Empleado>().ToTable("Persona_Empleado");
            modelBuilder.Entity<Pago_Factura>().ToTable("PagoFactura");

            base.OnModelCreating(modelBuilder);
        }
    }
}
