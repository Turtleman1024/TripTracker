using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelTrackerDTO;

namespace TravelTrackerAPI.Models
{
    public class TripWithSegments : TripDTO
    {
        public ICollection<Segment> Segments { get; set; }

    }
}
