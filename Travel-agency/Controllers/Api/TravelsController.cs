using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel_agency.Data;
using Travel_agency.Models;

namespace Travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string search)
        {
            List<Destinations> destinations = new List<Destinations>();

            using (TravelContext db = new TravelContext())
            {
                destinations = db.destinationSet.ToList<Destinations>();
            }
            return Ok(destinations);
        }
    }
}
