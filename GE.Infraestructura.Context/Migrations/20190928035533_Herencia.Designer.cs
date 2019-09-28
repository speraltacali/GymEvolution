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
    [Migration("20190928035533_Herencia")]
    partial class Herencia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.ClienteControl", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClienteId");

                    b.Property<DateTime>("FechaAcceso");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClienteControl");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Cliente_Factura", b =>
                {
                    b.Property<long>("ClienteId");

                    b.Property<long>("FacturaId");

                    b.Property<DateTime>("FechaActualizacion");

                    b.HasKey("ClienteId", "FacturaId");

                    b.HasIndex("FacturaId");

                    b.ToTable("Cliente_Factura");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Factura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ClienteId");

                    b.Property<decimal>("Descuento");

                    b.Property<DateTime>("FechaOperacion");

                    b.Property<string>("NumeroFactura");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("SubTotal");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Factura");
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

                    b.Property<byte[]>("Foto");

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

                    b.Property<DateTime>("FechaVencimineto");

                    b.Property<int>("GrupoSanguineo");

                    b.ToTable("Persona_Cliente");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Empleado", b =>
                {
                    b.HasBaseType("GE.Dominio.Entity.Entidades.Persona");

                    b.Property<DateTime>("FechaIngreso");

                    b.Property<string>("Legajo");

                    b.ToTable("Persona_Empleado");

                    b.HasDiscriminator().HasValue("Empleado");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.ClienteControl", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Cliente_Factura", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GE.Dominio.Entity.Entidades.Factura", "Factura")
                        .WithMany("ClienteFactura")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Factura", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Cliente")
                        .WithMany("Factura")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("GE.Dominio.Entity.Entidades.Usuario", b =>
                {
                    b.HasOne("GE.Dominio.Entity.Entidades.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}