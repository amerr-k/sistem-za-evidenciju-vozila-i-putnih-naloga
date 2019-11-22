using Microsoft.EntityFrameworkCore;
using System;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data
{
    public class SEVPNContext : DbContext
    {
        public SEVPNContext() : base()
        {

        }
        public SEVPNContext(DbContextOptions<SEVPNContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarBrand>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<CarModel>()
                .HasIndex(x => new { x.Name, x.CarBrandId })
                .IsUnique();

            modelBuilder.Entity<CarBrand>()
                .HasData(
                    new CarBrand { CarBrandId = 1, Name = "Audi" },
                    new CarBrand { CarBrandId = 2, Name = "Peuget" },
                    new CarBrand { CarBrandId = 3, Name = "Mercedes" },
                    new CarBrand { CarBrandId = 4, Name = "BMW" },
                    new CarBrand { CarBrandId = 5, Name = "Citroen" },
                    new CarBrand { CarBrandId = 6, Name = "Renault" },
                    new CarBrand { CarBrandId = 7, Name = "VW" }
                );
            modelBuilder.Entity<CarModel>()
                 .HasData(
                    new CarModel { CarModelId = 1, Name = "TT", CarBrandId = 1 },
                    new CarModel { CarModelId = 2, Name = "306", CarBrandId = 2 },
                    new CarModel { CarModelId = 3, Name = "S", CarBrandId = 3 },
                    new CarModel { CarModelId = 4, Name = "X6", CarBrandId = 4 },
                    new CarModel { CarModelId = 5, Name = "r2", CarBrandId = 2 },
                    new CarModel { CarModelId = 6, Name = "er2", CarBrandId = 3 },
                    new CarModel { CarModelId = 7, Name = "Golf 2", CarBrandId = 7 }
            );
        }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<CarBrand> CarBrand { get; set; }

    }
}
