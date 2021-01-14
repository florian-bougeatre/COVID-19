using COVID_19.Models;
using System;
using System.Collections.Generic;

namespace COVID_19.DAL
{
    public class CovidInitializer : System.Data.Entity.DropCreateDatabaseAlways<CovidContext>
    {
        protected override void Seed(CovidContext context)
        {
            var countries = new List<Country>
            {
                new Country{Name = "Belgium", Code = "BE"},
                new Country{Name = "France", Code = "FR"},
                new Country{Name = "Luxembourg", Code = "LU"},
                new Country{Name = "Germany", Code = "DE"},
                new Country{Name = "Netherlands", Code = "NL"},
                new Country{Name = "Spain", Code = "ES"},
                new Country{Name = "Italy", Code = "IT"},
                new Country{Name = "Switzerland", Code = "CH"},
                new Country{Name = "Portugal", Code = "PT"}
            };
            countries.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();

            var cases = new List<Case>
            {
                //BELGIUM
                new Case{Confirmed = 40956, Deaths = 5998, Recovered = 9002, Active = 25956, Date = DateTime.Parse("2020-04-21"), CountryID = 1},
                new Case{Confirmed = 515391, Deaths = 13758, Recovered = 31130, Active = 470503, Date = DateTime.Parse("2020-11-11"), CountryID = 1},
                //FRANCE
                new Case{Confirmed = 51251, Deaths = 10874, Recovered = 21452, Active = 18925, Date = DateTime.Parse("2020-04-08"), CountryID = 2},
                new Case{Confirmed = 777378, Deaths = 32730, Recovered = 103232, Active = 641416, Date = DateTime.Parse("2020-10-11"), CountryID = 2},
                //LUXEMBOURG
                new Case{Confirmed = 4063, Deaths = 110, Recovered = 3922, Active = 31, Date = DateTime.Parse("2020-06-13"), CountryID = 3},
                new Case{Confirmed = 27681, Deaths = 240, Recovered = 18024, Active = 9417, Date = DateTime.Parse("2020-11-17"), CountryID = 3},
                //GERMANY
                new Case{Confirmed = 159912, Deaths = 6314, Recovered = 117400, Active = 36198, Date = DateTime.Parse("2020-04-28"), CountryID = 4},
                new Case{Confirmed = 531790, Deaths = 10483, Recovered = 356410, Active = 164897, Date = DateTime.Parse("2020-10-31"), CountryID = 4},
                //NETHERLANDS
                new Case{Confirmed = 50545, Deaths = 6134, Recovered = 186, Active = 44225, Date = DateTime.Parse("2020-07-01"), CountryID = 5},
                new Case{Confirmed = 721429, Deaths = 10720, Recovered = 8743, Active = 701966, Date = DateTime.Parse("2020-12-22"), CountryID = 5},
                //SPAIN
                new Case{Confirmed = 204178, Deaths = 21282, Recovered = 82514, Active = 100382, Date = DateTime.Parse("2020-04-21"), CountryID = 6},
                new Case{Confirmed = 888968, Deaths = 33124, Recovered = 150376, Active = 705468, Date = DateTime.Parse("2020-10-12"), CountryID = 6},
                //ITALY
                new Case{Confirmed = 233836, Deaths = 33601, Recovered = 160938, Active = 39297, Date = DateTime.Parse("2020-06-03"), CountryID = 7},
                new Case{Confirmed = 731588, Deaths = 39059, Recovered = 296017, Active = 396512, Date = DateTime.Parse("2020-11-02"), CountryID = 7},
                //SWITZERLAND
                new Case{Confirmed = 31094, Deaths = 1938, Recovered = 28800, Active = 356, Date = DateTime.Parse("2020-06-13"), CountryID = 8},
                new Case{Confirmed = 103653, Deaths = 2067, Recovered = 55800, Active = 45786, Date = DateTime.Parse("2020-10-23"), CountryID = 8},
                //PORTUGAL
                new Case{Confirmed = 80312, Deaths = 2032, Recovered = 50712, Active = 27568, Date = DateTime.Parse("2020-10-06"), CountryID = 9},
                new Case{Confirmed = 340287, Deaths = 5373, Recovered = 263648, Active = 71266, Date = DateTime.Parse("2020-12-11"), CountryID = 9}
            };
            cases.ForEach(c => context.Cases.Add(c));
            context.SaveChanges();
        }
    }
}