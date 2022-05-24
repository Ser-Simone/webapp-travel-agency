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
            return View("HomePage", traveList);
        }
        [HttpGet]
        public IActionResult User()
        {
            List<Destinations> traveList;
            using (TravelContext db = new TravelContext())
            {
                traveList = db.destinationSet.ToList<Destinations>();
            }
            return View("User", traveList);
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
        public IActionResult Create (Destinations? newTravel)
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Destinations editTravel = null;

            using (TravelContext db = new TravelContext())
            {
                editTravel = db.destinationSet
                     .Where(travel => travel.Id == id)
                     .FirstOrDefault();

            }

            if (editTravel == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", editTravel);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Destinations destinations )
        {
            if(!ModelState.IsValid)
            {
                return View("Edit", destinations);
            }
            Destinations editTravel = null;

            using (TravelContext db = new TravelContext())
            {
                editTravel = db.destinationSet
                    .Where(travel => travel.Id == id)
                    .FirstOrDefault();

                if (editTravel != null)
                {
                    editTravel.title = destinations.title;
                    editTravel.description = destinations.description;
                    editTravel.image = destinations.image;
                    editTravel.price = destinations.price;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using(TravelContext db = new TravelContext())
            {
                Destinations? deleteTravel = db.destinationSet
                    .Where(travel => travel.Id == id)
                    .FirstOrDefault();

                if (deleteTravel != null)
                {
                    db.destinationSet.Remove(deleteTravel);
                    db.SaveChanges();

                   return RedirectToAction("Index");
                }else
                {
                    return NotFound();
                }
            }
        }
    }
}
