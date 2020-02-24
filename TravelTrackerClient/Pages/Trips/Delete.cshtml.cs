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
    public class DeleteModel : PageModel
    {
        private readonly TravelTrackerClient.Data.ApplicationDbContext _context;

        public DeleteModel(TravelTrackerClient.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _context.Trip.FindAsync(id);

            if (Trip != null)
            {
                _context.Trip.Remove(Trip);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
