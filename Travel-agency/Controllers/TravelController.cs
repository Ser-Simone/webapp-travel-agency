using Microsoft.AspNetCore.Mvc;
using Travel_agency.Data;
using Travel_agency.Models;

namespace Travel_agency.Controllers
{
    public class TravelController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Destinations> traveList;
            using (TravelContext db = new TravelContext())
            {
                traveList = db.destinationSet.ToList<Destinations>();
            }
            return View("HomePage");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (TravelContext db = new TravelContext())
            {
                try
                {
                    Destinations travelFound = db.destinationSet
                        .Where(travel => travel.Id == id)
                        .First();
                    return View("Details", travelFound);

            } catch (InvalidOperationException ex)
                {
                    return NotFound("Il viaggio non è stato trovato");
                }catch (Exception ex)
                {
                    return BadRequest();
                }
            }
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Destinations newTravel)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", newTravel);
            }

            using(TravelContext db = new TravelContext())
            {
                Destinations newDestination = new Destinations(newTravel.title, newTravel.description, newTravel.image, newTravel.price);
                db.destinationSet.Add(newDestination);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
