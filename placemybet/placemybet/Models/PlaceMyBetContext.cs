using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//migracion: crearemos la base de datos, abrimos consolan(herramientas,administrador de paquenetes nuget,consola del administrador de paquetes)
// escribimos en consola add-migration m1 -Context PlaceMyBetContext (xa crear la primera tabla y se creara la carpeta migrations en la derecha, con la primera migracion y el nombre m1 q acabo de poner)
//add-migration aria una nueva migracion pudiendo añadir nuevas tablas
// update-databade -Context PlaceMyBetContext , aplica los cambios y creara o realizara los cambios (sin esto no crearia las tablas x ejem)
//remove-migration borra la ultima migracion
namespace placemybet.Models
{
    public class PlaceMyBetContext : DbContext
    {
        //tablas q vamos a crear,nombres en plurar x convenio-
        public DbSet<eventos> eventos { get; set; }
        public DbSet<mercados> mercados { get; set; }
        public DbSet<apuestas> apuesta { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<cuentas> cuentas { get; set; }

        public PlaceMyBetContext()
        {

        }

        public PlaceMyBetContext(DbContextOptions options)
            : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=placemybet2;Uid=root;Pwd=''; SslMode = none");//màquina retos

            }
        }

        ////Inserció inicial de dades
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Grupo>().HasData(new Grupo(1, "Iron Maiden"));
        //    modelBuilder.Entity<Grupo>().HasData(new Grupo(2, "Gamma Ray"));
        //    modelBuilder.Entity<Grupo>().HasData(new Grupo(3, "Stratovarius"));
        //    modelBuilder.Entity<Disco>().HasData(new Disco(1, "The number of the beast", 1982, 1));
        //    modelBuilder.Entity<Disco>().HasData(new Disco(2, "Land of the free", 1998, 2));
        //}
    }

    
}