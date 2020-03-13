using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTrips.Models;

namespace WebApiTrips.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        // GET: api/Trips
        [HttpGet]
        public ObservableCollection<TripModel> Get()
        {
            return new TripModel().GetAll();
        }

        // GET: api/Trips/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Trips
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Trips/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
