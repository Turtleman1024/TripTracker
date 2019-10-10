using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        }

        #region GET
        // GET api/Trips
        [HttpGet]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            return _repository.Get();
        }

        // GET api/Trips/5
        [HttpGet("{id}")]
        public ActionResult<Trip> Get(int id)
        {
            return _repository.Get(id);
        }
        #endregion

        #region Post
        // POST api/Trips
        [HttpPost]
        public void Post([FromBody] Trip value)
        {
            _repository.Add(value);
        }
        #endregion

        #region Put
        // PUT api/Trips/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip value)
        {
            _repository.Update(value);
        }
        #endregion

        #region Delete
        // DELETE api/Trips/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
        #endregion
    }
}