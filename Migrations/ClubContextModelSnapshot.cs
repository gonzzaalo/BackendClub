﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CLubBackend.Migrations
{
    [DbContext(typeof(ClubContext))]
    partial class ClubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CLubBackend.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SocioId")
                        .HasColumnType("int");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SocioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Cuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cuotas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Acceso a actividades deportivas",
                            Monto = 1500.00m,
                            Nombre = "Cuota Deportista"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Membresía del club",
                            Monto = 1000.00m,
                            Nombre = "Cuota Socio"
                        });
                });

            modelBuilder.Entity("Deporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Deportes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Deporte en equipo",
                            Hora = new TimeSpan(0, 18, 0, 0, 0),
                            Nombre = "Fútbol",
                            ProfesorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Juego de baloncesto",
                            Hora = new TimeSpan(0, 19, 30, 0, 0),
                            Nombre = "Básquet",
                            ProfesorId = 2
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Deporte acuático",
                            Hora = new TimeSpan(0, 17, 0, 0, 0),
                            Nombre = "Natación",
                            ProfesorId = 3
                        });
                });

            modelBuilder.Entity("Deportista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("CuotaId")
                        .HasColumnType("int");

                    b.Property<int>("DeporteId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CuotaId");

                    b.HasIndex("DeporteId");

                    b.ToTable("Deportistas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Ramírez",
                            CuotaId = 1,
                            DeporteId = 1,
                            Direccion = "Calle Falsa 123",
                            Email = "pedro@mail.com",
                            Nombre = "Pedro",
                            Telefono = "3456789012"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Martínez",
                            CuotaId = 1,
                            DeporteId = 2,
                            Direccion = "Av. Principal 456",
                            Email = "lucia@mail.com",
                            Nombre = "Lucía",
                            Telefono = "4567890123"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "González",
                            CuotaId = 1,
                            DeporteId = 3,
                            Direccion = "Calle Secundaria 789",
                            Email = "sofia@mail.com",
                            Nombre = "Sofía",
                            Telefono = "5678901234"
                        });
                });

            modelBuilder.Entity("Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Profesores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Pérez",
                            Nombre = "Juan",
                            Telefono = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Gómez",
                            Nombre = "María",
                            Telefono = "0987654321"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "López",
                            Nombre = "Carlos",
                            Telefono = "1122334455"
                        });
                });

            modelBuilder.Entity("Socio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("CuotaId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CuotaId");

                    b.ToTable("Socios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Pérez",
                            CuotaId = 2,
                            Direccion = "Av. Central 101",
                            Email = "ana@mail.com",
                            Nombre = "Ana",
                            Telefono = "6789012345"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Fernández",
                            CuotaId = 2,
                            Direccion = "Calle Real 202",
                            Email = "javier@mail.com",
                            Nombre = "Javier",
                            Telefono = "7890123456"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Rodríguez",
                            CuotaId = 2,
                            Direccion = "Av. Norte 303",
                            Email = "marina@mail.com",
                            Nombre = "Marina",
                            Telefono = "8901234567"
                        });
                });

            modelBuilder.Entity("CLubBackend.Models.Usuario", b =>
                {
                    b.HasOne("Socio", "Socio")
                        .WithMany()
                        .HasForeignKey("SocioId");

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("Deporte", b =>
                {
                    b.HasOne("Profesor", "Profesor")
                        .WithMany("Deportes")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Deportista", b =>
                {
                    b.HasOne("Cuota", "Cuota")
                        .WithMany("Deportistas")
                        .HasForeignKey("CuotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deporte", "Deporte")
                        .WithMany("Deportistas")
                        .HasForeignKey("DeporteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuota");

                    b.Navigation("Deporte");
                });

            modelBuilder.Entity("Socio", b =>
                {
                    b.HasOne("Cuota", "Cuota")
                        .WithMany("Socios")
                        .HasForeignKey("CuotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuota");
                });

            modelBuilder.Entity("Cuota", b =>
                {
                    b.Navigation("Deportistas");

                    b.Navigation("Socios");
                });

            modelBuilder.Entity("Deporte", b =>
                {
                    b.Navigation("Deportistas");
                });

            modelBuilder.Entity("Profesor", b =>
                {
                    b.Navigation("Deportes");
                });
#pragma warning restore 612, 618
        }
    }
}
