using GE.Dominio.Entity;
using GE.Dominio.Entity.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationApis
{
    public class ContextApi : DbContext
    {
        public const string DataBase = "XXX";

        public const string Server = @"DESKTOP-066FGIK";


        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"Integrated Security=true";

        public ContextApi()
        {

        }

        public ContextApi(DbContextOptions<ContextApi> Option) : base(Option)
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
            modelBuilder.Entity<Pago_Factura>().HasKey(x => new { x.FacturaId, x.CuotaId, x.ClienteId, x.EmpleadoId });

            modelBuilder.Entity<DetalleCaja>()
                .HasOne(x => x.Caja)
                .WithMany(y => y.DetalleCajas)
                .HasForeignKey(x => x.CajaId);

            modelBuilder.Entity<ClienteControl>()
                .HasOne(x => x.Cliente)
                .WithMany(y => y.ClienteControl)
                .HasForeignKey(x => x.ClienteId);

            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.Empleado)
                .WithMany(y => y.Usuarios)
                .HasForeignKey(x => x.EmpleadoId);

            modelBuilder.Entity<Movimiento>()
                .HasOne(x => x.Empleado)
                .WithMany(y => y.Movimientos)
                .HasForeignKey(x => x.EmpleadoId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
