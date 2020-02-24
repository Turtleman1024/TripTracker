using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelTrackerAPI.Models;
using TravelTrackerClient.Data;

namespace TravelTrackerClient
{
    public class DetailsModel : PageModel
    {
        private readonly TravelTrackerClient.Data.ApplicationDbContext _context;

        public DetailsModel(TravelTrackerClient.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Trip Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _context.Trip.FirstOrDefaultAsync(m => m.Id == id);

            if (Trip == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
