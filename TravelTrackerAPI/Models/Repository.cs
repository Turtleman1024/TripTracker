using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelTrackerAPI.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
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
        };

        public List<Trip> Get()
        {
            return MyTrips;
        }

        public Trip Get(int id)
        {
            return MyTrips.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }

        public void Update (Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            Add(tripToUpdate);
        }

        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}
