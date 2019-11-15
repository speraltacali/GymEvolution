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

        public DbSet<Rutina> Rutina { get; set; }

        public DbSet<Ejercicio> Ejercicio { get; set; }

        public DbSet<Movimiento> Movimiento { get; set; }

        public DbSet<Pago_Factura> Pago_Factura { get; set; }

        public DbSet<Clase> Clase { get; set; }

        public DbSet<ClaseDetalle> ClaseDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago_Factura>().HasKey(x => new {x.FacturaId , x.CuotaId , x.ClienteId , x.EmpleadoId});

            //modelBuilder.Entity<Pago_Factura>()
            //    .HasOne(x => x.Factura)
            //    .WithMany(y => y.Pago_Facturas)
            //    .HasForeignKey(x => x.FacturaId)
            //    .HasPrincipalKey(y=>y.Id);

            //modelBuilder.Entity<Pago_Factura>()
            //    .HasOne(x => x.Cuotas)
            //    .WithMany(y => y.Pago_Facturas)
            //    .HasForeignKey(x => x.CuotaId);



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

            modelBuilder.Entity<ClaseDetalle>()
                .HasOne(x => x.Clase)
                .WithMany(y => y.ClaseDetalles)
                .HasForeignKey(x => x.ClaseId);

            modelBuilder.Entity<Ejercicio>()
                .HasOne(x => x.Rutina)
                .WithMany(y => y.Ejercicios)
                .HasForeignKey(x => x.RutinaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
