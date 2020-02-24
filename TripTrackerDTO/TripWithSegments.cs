using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelTrackerDTO
{
    public class TripWithSegments : TravelTrackerDTO.TripDTO
    {
        public ICollection<SegmentDTO> Segments { get; set; }

    }
}
