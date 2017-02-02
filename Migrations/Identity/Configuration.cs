namespace Lab03Canada.Migrations.Identity
{
    using Models;
    using Models.Places;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lab03Canada.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(Lab03Canada.Models.ApplicationDbContext context)
        {
            context.Provinces.AddOrUpdate(p => p.ProvinceCode, getProvincies());
            context.SaveChanges();
            context.Cities.AddOrUpdate(c => new { c.CityName, c.Population }, getCities(context));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private Provinces[] getProvincies()
        {
            var provinces = new List<Provinces>
            {
                new Provinces() {ProvinceCode = "BC", ProvinceName = "British Columbia" },
                new Provinces() {ProvinceCode = "AB",ProvinceName = "Alberta" },
                new Provinces() {ProvinceCode = "ON",ProvinceName = "Ontario" }
            };

            return provinces.ToArray();
        }

        private Cities[] getCities(ApplicationDbContext context)
        {
            var cities = new List<Cities>
            {
                new Models.Places.Cities()
                {
                    CityName = "Toronto",
                    Population = 5132794,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="ON").ProvinceCode

                },
                    new Models.Places.Cities()                {
                    CityName = "Hamilton",
                    Population = 670580,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="ON").ProvinceCode

                },
                  new Models.Places.Cities()
                {
                    CityName = "London",
                    Population = 366191,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="ON").ProvinceCode

                },
                new Models.Places.Cities()
                {
                    CityName = "Calgary",
                    Population = 1095404,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AB").ProvinceCode

                },
                 new Models.Places.Cities()
                {
                    CityName = "Edmonton",
                    Population = 960015,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AB").ProvinceCode

                },
                 new Models.Places.Cities()
                {
                    CityName = "Fort McMurray",
                    Population = 61374,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="AB").ProvinceCode

                },
                new Models.Places.Cities()
                {
                    CityName = "Vancouver",
                    Population = 2135201,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode

                },
                new Models.Places.Cities()
                {
                    CityName = "Victoria",
                    Population = 316327,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode

                },
                new Models.Places.Cities()
                {
                    CityName = "Abbotsford",
                    Population = 149855,
                    ProvinceCode = context.Provinces.FirstOrDefault(p => p.ProvinceCode=="BC").ProvinceCode

                },
            };
            return cities.ToArray();
        }

    }
}
