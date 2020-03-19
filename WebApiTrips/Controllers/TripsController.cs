using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiTrips.Models;

namespace WebApiTrips.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public TripsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/Trips
        [HttpGet]
        public ObservableCollection<TripModel> Get()
        {
            return new TripModel().GetAll(Configuration.GetConnectionString("MySQL"));
        }

        // GET: api/Trips/5
        [HttpGet("{id}", Name = "Get")]
        public TripModel Get(int id)
        {
            return new TripModel().Get(Configuration.GetConnectionString("MySQL"), id);
        }

        // POST: api/Trips
        [HttpPost]
        public int Post([FromBody]TripModel trip)
        {
            return trip.Insert(Configuration.GetConnectionString("MySQL"));
        }

        // PUT: api/Trips/5
        [HttpPut] //("{id}")]
        public void Put([FromBody]TripModel trip)
        {
            trip.Update(Configuration.GetConnectionString("MySQL"));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new TripModel().Delete(Configuration.GetConnectionString("MySQL"), id);
        }
    }
}
