using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelTrackerAPI.Models
{
    public class Segment
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StateDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
        
    }
}
