using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelTrackerAPI.Models
{
    public class Trip : TravelTrackerDTO.TripDTO
    {
        public virtual ICollection<Segment> Segments { get; set; }
    }
}
