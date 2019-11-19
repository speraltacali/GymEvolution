﻿// <auto-generated />
using System;
using GE.Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GE.Infraestructura.Context.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20191119031040_TerminandoCode")]
    partial class TerminandoCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Caja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("FechaApertura");

                    b.Property<DateTime>("FechaCierre");

                    b.Property<decimal>("MontoApertura");

                    b.Property<decimal>("MontoCierre");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<long>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Caja");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Clase", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Foto");

                    b.Property<string>("Nombre");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Clase");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.ClaseDetalle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClaseId");

                    b.Property<int>("Dia");

                    b.Property<TimeSpan>("HoraFin");

                    b.Property<TimeSpan>("HoraInicio");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ClaseId");

                    b.ToTable("ClaseDetalle");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.ClienteControl", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClienteId");

                    b.Property<int>("Estado");

                    b.Property<DateTime>("FechaAcceso");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClienteControl");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Cuota", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<long>("ClienteId");

                    b.Property<DateTime>("CuotaVencimiento");

                    b.Property<DateTime>("CuotaVigente");

                    b.Property<int>("Estado");

                    b.Property<string>("Numero");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Cuota");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.DetalleCaja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CajaId");

                    b.Property<decimal>("Monto");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("TipoPago");

                    b.HasKey("Id");

                    b.HasIndex("CajaId");

                    b.ToTable("DetalleCaja");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Ejercicio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foto");

                    b.Property<int>("Musculo");

                    b.Property<string>("Nombre");

                    b.Property<int>("Repeticiones");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<long>("RutinaId");

                    b.Property<int>("Series");

                    b.HasKey("Id");

                    b.HasIndex("RutinaId");

                    b.ToTable("Ejercicio");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Factura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Descuento");

                    b.Property<DateTime>("FechaOperacion");

                    b.Property<string>("Numero");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("SubTotal");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Movimiento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<long>("EmpleadoId");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<decimal>("Monto");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("TipoMovimiento");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Movimiento");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Pago_Factura", b =>
                {
                    b.Property<long>("FacturaId");

                    b.Property<long>("CuotaId");

                    b.Property<long>("ClienteId");

                    b.Property<long>("EmpleadoId");

                    b.HasKey("FacturaId", "CuotaId", "ClienteId", "EmpleadoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CuotaId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("PagoFactura");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Persona", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Dni");

                    b.Property<string>("Domicilio");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("FotoLink");

                    b.Property<string>("Mail");

                    b.Property<string>("Nombre");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("Sexo");

                    b.Property<string>("Telefono");

                    b.HasKey("Id");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Rutina", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Rutina");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EmpleadoId");

                    b.Property<bool>("EstaBloqueado");

                    b.Property<string>("Password");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Cliente", b =>
                {
                    b.HasBaseType("GE.Dominio.Entity.Entidades.Persona");

                    b.Property<DateTime>("FechaDeIngreso");

                    b.Property<int>("GrupoSanguineo");

                    b.ToTable("Persona_Cliente");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Empleado", b =>
                {
                    b.HasBaseType("GE.Dominio.Entity.Entidades.Persona");

                    b.Property<DateTime>("FechaIngreso");

                    b.Property<byte[]>("Foto");

                    b.Property<string>("Legajo");

                    b.ToTable("Persona_Empleado");

                    b.HasDiscriminator().HasValue("Empleado");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Caja", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.ClaseDetalle", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Entidades.Clase", "Clase")
                        .WithMany("ClaseDetalles")
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.ClienteControl", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Cliente", "Cliente")
                        .WithMany("ClienteControl")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.DetalleCaja", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Entidades.Caja", "Caja")
                        .WithMany("DetalleCajas")
                        .HasForeignKey("CajaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Ejercicio", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Entidades.Rutina", "Rutina")
                        .WithMany("Ejercicios")
                        .HasForeignKey("RutinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Movimiento", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Entidades.Empleado", "Empleado")
                        .WithMany("Movimientos")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Pago_Factura", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Cliente", "Cliente")
                        .WithMany("PagoFacturas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GE.Dominio.Entity.Entidades.Cuota", "Cuota")
                        .WithMany("Pago_Facturas")
                        .HasForeignKey("CuotaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GE.Dominio.Entity.Entidades.Empleado", "Empleado")
                        .WithMany("Pago_Facturas")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GE.Dominio.Entity.Entidades.Factura", "Factura")
                        .WithMany("Pago_Facturas")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Usuario", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Entidades.Empleado", "Empleado")
                        .WithMany("Usuarios")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
