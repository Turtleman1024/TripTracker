using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelTrackerAPI.Models;

namespace TravelTrackerAPI.Data
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options) { }

        public TravelContext() { }

        public DbSet<Trip> Trips { get; set; }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider.GetService<TravelContext>();

                context.Database.EnsureCreated();

                if (context.Trips.Any()) return;

                context.Trips.AddRange(new Trip[]
                {
                new Trip
                {
                    Id = 1,
                    Name = "Disney Land 2019",
                    StartDate = new DateTime(2019, 10, 10),
                    EndDate = new DateTime(2019, 10, 15)
                },
                new Trip
                {
                    Id = 2,
                    Name = "Universal Studio 2019",
                    StartDate = new DateTime(2019, 10, 16),
                    EndDate = new DateTime(2019, 10, 18)
                },
                new Trip
                {
                    Id = 3,
                    Name = "Sea World 2019",
                    StartDate = new DateTime(2019, 10, 19),
                    EndDate = new DateTime(2019, 10, 20)
                }
                });
                context.SaveChanges();
            }
        }
    }

}
