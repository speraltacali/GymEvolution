using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationApi.Contex
{
    public class Acceso : DbContext
    {

        public Acceso()
        {

        }

        public Acceso(DbContextOptions<Acceso> Option) : base(Option)
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

            //modelBuilder.Entity<Pago_Factura>()
            //    .HasOne(x => x.Facturas)
            //    .WithMany(y => y.Pago_Facturas)
            //    .HasForeignKey(x => x.FacturaId);

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


            //modelBuilder.Entity<Persona>().ToTable("Persona");
            ////modelBuilder.Entity<Cliente>().ToTable("Persona_Cliente");
            //modelBuilder.Entity<Usuario>().ToTable("Usuario");
            ////modelBuilder.Entity<Empleado>().ToTable("Persona_Empleado");
            //modelBuilder.Entity<Pago_Factura>().ToTable("PagoFactura");

            base.OnModelCreating(modelBuilder);
        }


    }
}