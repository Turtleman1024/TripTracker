using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelTrackerAPI.Data;
using TravelTrackerAPI.Models;

namespace TravelTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : Controller
    {
        TripContext _dbContext;

        public TripsController(TripContext dbContext)
        {
            _dbContext = dbContext;
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region GET
        // GET api/Trips
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            //Get all the trips in the database
            //This should really be done in a different class
            var trips = await _dbContext.Trips
                                        .Include(t => t.Segments)
                                        .Select( t => new TripWithSegments
                                        {
                                            Id = t.Id,
                                            Name = t.Name,
                                            StartDate = t.StartDate,
                                            EndDate = t.EndDate,
                                            Segments = t.Segments
                                        })
                                        .ToListAsync();
            return Ok(trips);
        }

        // GET api/Trips/5
        [HttpGet("{id}")]
        public ActionResult<TripWithSegments> Get(int id)
        {
            //Get a Trip by the passed in primary key id
            //This should really be done in a different class
            return _dbContext.Trips.Select(t => new TripWithSegments
                                    {
                                        Id = t.Id,
                                        Name = t.Name,
                                        StartDate = t.StartDate,
                                        EndDate = t.EndDate,
                                        Segments = t.Segments
                                    }).SingleOrDefault( t => t.Id == id);
        }
        #endregion

        #region Post
        // POST api/Trips
        [HttpPost]
        public IActionResult Post([FromBody] Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Trips.Add(value);
            _dbContext.SaveChanges();

            return Ok();
        }
        #endregion

        #region Put
        // PUT api/Trips/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Trip value)
        {
            if(_dbContext.Trips.Any(t => t.Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Trips.Update(value);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        #endregion

        #region Delete
        // DELETE api/Trips/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAsync(int id)
        {
            var myTrip = _dbContext.Trips.Find(id);

            if (myTrip == null)
            {
                return NotFound();
            }

            _dbContext.Trips.Remove(myTrip);
            _dbContext.SaveChanges();

            return NoContent();
        }
        #endregion
    }
}