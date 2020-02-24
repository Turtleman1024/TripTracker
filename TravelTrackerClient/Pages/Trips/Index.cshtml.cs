using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelTrackerAPI.Models;
using TravelTrackerClient.Data;
using TravelTrackerClient.Services;

namespace TravelTrackerClient
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _client;

        public IndexModel(IApiClient client)
        {
            _client = client;
        }

        public IList<Trip> Trips { get;set; }

        public async Task OnGetAsync()
        {
            Trips = await _client.GetTripsAsync();
        }
    }
}
