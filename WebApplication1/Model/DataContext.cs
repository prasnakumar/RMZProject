using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.DataModel;

namespace WebApplication1.Model
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<CityModel> City { get; set; }
        public DbSet<FacilityModel> Facility { get; set; }

        public DbSet<BuildingModel> Building { get; set; }

        public DbSet<FloorModel> Floor { get; set; }
        public DbSet<ZoneModel> Zone { get; set; }

        public DbSet<WaterMeterModel> WaterMeter { get; set; }

        public DbSet<ElectricMeterModel> ElectricMeter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityModel>().HasData(new { Id = 1, CityName = "bengaluru",Rmz="ABC"});
            modelBuilder.Entity<FacilityModel>().HasData(new { Id = 1, FacilityName = "RMZ", localtion = "ULSOOR", CityIdId=1 },
                new { Id = 2, FacilityName = "RMZMG", localtion = "MG Road", CityIdId = 1 });
            modelBuilder.Entity<BuildingModel>().HasData(new { Id = 1, BuildName = "RMZ Corp", FacilityIdId = 1 },
                new { Id = 2, BuildName = "RMZNext", FacilityIdId = 2 },
                new { Id = 3, BuildName = "RMZ Corp 2", FacilityIdId = 1 });
            modelBuilder.Entity<FloorModel>().HasData(new { Id = 1, FloorName = "First Floor", BuildingIdId = 1, FacilityIdId = 1 });
           modelBuilder.Entity<ZoneModel>().HasData(new { Id = 1, ZoneName = "#1", FloorId = 1, cityId = 1, BuildingId = 1, FacilityId = 1 });
            modelBuilder.Entity<ZoneModel>().HasData(new { Id = 2, ZoneName = "#2", FloorId = 1, cityId = 1, BuildingId = 1, FacilityId = 1 },
            new { Id = 3, ZoneName = "#3", FloorId = 1, cityId = 1, BuildingId = 1, FacilityId = 1 });

            modelBuilder.Entity<FloorModel>().HasData(new { Id = 6, FloorName = "First Floor", BuildingIdId = 3, FacilityIdId = 1 });
            modelBuilder.Entity<ZoneModel>().HasData(new { Id = 10, ZoneName = "#11", FloorId = 1, cityId = 1, BuildingId = 3, FacilityId = 1 });
            modelBuilder.Entity<ZoneModel>().HasData(new { Id = 11, ZoneName = "#12", FloorId = 1, cityId = 1, BuildingId = 3, FacilityId = 1 },
            new { Id = 13, ZoneName = "#13", FloorId = 1, cityId = 1, BuildingId = 3, FacilityId = 1 });


            modelBuilder.Entity<ElectricMeterModel>().HasData(new { Id = 1, ZoneId = 1, Date = DateTime.ParseExact("30/08/2022", "dd/MM/yyyy", null), Cost = 100 }
            ,new { Id = 2, ZoneId = 1, Date = DateTime.ParseExact("30/07/2022", "dd/MM/yyyy", null), Cost = 200 }
            , new { Id = 3, ZoneId = 1, Date = DateTime.ParseExact("30/06/2022", "dd/MM/yyyy", null), Cost = 300 });
            modelBuilder.Entity<WaterMeterModel>().HasData(new { Id = 4, ZoneId = 1, Date = DateTime.ParseExact("30/08/2022", "dd/MM/yyyy", null), Cost = 100 }
            , new { Id = 5, ZoneId = 1, Date = DateTime.ParseExact("30/07/2022", "dd/MM/yyyy", null), Cost = 200 }
            , new { Id = 6, ZoneId = 1, Date = DateTime.ParseExact("30/06/2022", "dd/MM/yyyy", null), Cost = 300 });
            modelBuilder.Entity<ElectricMeterModel>().HasData(new { Id = 7, ZoneId = 2, Date = DateTime.ParseExact("30/08/2022", "dd/MM/yyyy", null), Cost = 100 }
            , new { Id = 8, ZoneId = 10, Date = DateTime.ParseExact("30/07/2022", "dd/MM/yyyy", null), Cost = 800 }
            , new { Id = 9, ZoneId = 11, Date = DateTime.ParseExact("30/06/2022", "dd/MM/yyyy", null), Cost = 900 });

            base.OnModelCreating(modelBuilder);

        }
    }
}
