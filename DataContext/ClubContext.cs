using Microsoft.EntityFrameworkCore;
using CLubBackend.Models;
using System;


    public class ClubContext : DbContext
    {
        public ClubContext(DbContextOptions<ClubContext> options) : base(options)
        {
        }

        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Deporte> Deportes { get; set; }
        public DbSet<Deportista> Deportistas { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones

            // Relación Deportista -> Deporte
            modelBuilder.Entity<Deportista>()
                .HasOne(d => d.Deporte)
                .WithMany(de => de.Deportistas)
                .HasForeignKey(d => d.DeporteId);

            // Relación Deportista -> Cuota
            modelBuilder.Entity<Deportista>()
                .HasOne(d => d.Cuota)
                .WithMany(c => c.Deportistas)
                .HasForeignKey(d => d.CuotaId);

            // Relación Socio -> Cuota
            modelBuilder.Entity<Socio>()
                .HasOne(s => s.Cuota)
                .WithMany(c => c.Socios)
                .HasForeignKey(s => s.CuotaId);

            // Relación Deporte -> Profesor
            modelBuilder.Entity<Deporte>()
                .HasOne(d => d.Profesor)
                .WithMany(p => p.Deportes)
                .HasForeignKey(d => d.ProfesorId);

            // Datos semilla

            // Profesores
            modelBuilder.Entity<Profesor>().HasData(
                new Profesor { Id = 1, Nombre = "Juan", Apellido = "Pérez", Telefono = "1234567890" },
                new Profesor { Id = 2, Nombre = "María", Apellido = "Gómez", Telefono = "0987654321" },
                new Profesor { Id = 3, Nombre = "Carlos", Apellido = "López", Telefono = "1122334455" }
            );

            // Deportes
            modelBuilder.Entity<Deporte>().HasData(
                new Deporte { Id = 1, Nombre = "Fútbol", Descripcion = "Deporte en equipo", Hora = new TimeSpan(18, 0, 0), ProfesorId = 1 },
                new Deporte { Id = 2, Nombre = "Básquet", Descripcion = "Juego de baloncesto", Hora = new TimeSpan(19, 30, 0), ProfesorId = 2 },
                new Deporte { Id = 3, Nombre = "Natación", Descripcion = "Deporte acuático", Hora = new TimeSpan(17, 0, 0), ProfesorId = 3 }
            );

            // Cuotas
            modelBuilder.Entity<Cuota>().HasData(
                new Cuota { Id = 1, Nombre = "Cuota Deportista", Descripcion = "Acceso a actividades deportivas", Monto = 1500.00m },
                new Cuota { Id = 2, Nombre = "Cuota Socio", Descripcion = "Membresía del club", Monto = 1000.00m }
            );

            // Deportistas
            modelBuilder.Entity<Deportista>().HasData(
                new Deportista { Id = 1, Nombre = "Pedro", Apellido = "Ramírez", Telefono = "3456789012", Direccion = "Calle Falsa 123", Email = "pedro@mail.com", DeporteId = 1, CuotaId = 1 },
                new Deportista { Id = 2, Nombre = "Lucía", Apellido = "Martínez", Telefono = "4567890123", Direccion = "Av. Principal 456", Email = "lucia@mail.com", DeporteId = 2, CuotaId = 1 },
                new Deportista { Id = 3, Nombre = "Sofía", Apellido = "González", Telefono = "5678901234", Direccion = "Calle Secundaria 789", Email = "sofia@mail.com", DeporteId = 3, CuotaId = 1 }
            );

            // Socios
            modelBuilder.Entity<Socio>().HasData(
                new Socio { Id = 1, Nombre = "Ana", Apellido = "Pérez", Telefono = "6789012345", Direccion = "Av. Central 101", Email = "ana@mail.com", CuotaId = 2 },
                new Socio { Id = 2, Nombre = "Javier", Apellido = "Fernández", Telefono = "7890123456", Direccion = "Calle Real 202", Email = "javier@mail.com", CuotaId = 2 },
                new Socio { Id = 3, Nombre = "Marina", Apellido = "Rodríguez", Telefono = "8901234567", Direccion = "Av. Norte 303", Email = "marina@mail.com", CuotaId = 2 }
            );
        }
    public DbSet<CLubBackend.Models.Usuario> Usuario { get; set; } = default!;

}

