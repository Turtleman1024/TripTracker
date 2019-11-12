using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelTrackerAPI.Models
{
    public class TripWithSegments : TravelTrackerDTO.TripDTO
    {
        public ICollection<Segment> Segments { get; set; }

    }
}
