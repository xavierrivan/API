using APIProductos.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace APIProductos.Data
{
    public class ApplicationDBC:DbContext
    {
        public ApplicationDBC(
            DbContextOptions<ApplicationDBC> options): base(options) 
        {

        }
        public DbSet<Paciente> Paciente{get; set;}
        public DbSet<Resultado> Resultado{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().HasData(



                new Paciente
                {
                    id = 1,
                    nombre = "Juan",
                    edad = 34,
                    genero = "Masculino"
                });
            modelBuilder.Entity<Resultado>().HasData(



                new Resultado
                {
                    Id= 1,
                    PacienteId = 1,
                    Hemoglobina = 14.5f,
                    GlobulosRojos = 4.6f,
                    Colesterol = 123.4f
                });


        }
    }
}
