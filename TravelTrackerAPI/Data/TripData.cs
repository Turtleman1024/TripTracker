using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelTrackerAPI.Models;

namespace TravelTrackerAPI.Data
{
    public class TripData : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
    }
}
