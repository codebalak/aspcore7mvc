using Microsoft.AspNetCore.Mvc;
using aspcore7mvc.Repository;
using aspcore7mvc.Models.Domain;
using Microsoft.Build.Framework.Profiler;
using Microsoft.Identity.Client;

namespace aspcore7mvc.Controllers
{
    public class PersonLocationController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonLocationController(DatabaseContext ctx)
        {
            _ctx = ctx;//deppendency injection

        }

            public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllLocation()
        {

            PersonLocationRepo ploc = new PersonLocationRepo(_ctx);//passing parameter in constructor
            ViewBag.Locationlist = ploc.GetLocations();//c

            return View();
        }

        
        public IActionResult AddLocation()
        {
            PersonRepo p = new PersonRepo(_ctx);
            ViewBag.Personslist = p.GetPersons();
            return View();
        }


        //store location in the database

        [HttpPost]
        public IActionResult AddLocation(PersonLocation plocreqest)
        {
            if (ModelState.IsValid)
            {
                PersonLocationRepo ploc = new PersonLocationRepo(_ctx);//passing parameter in constructor
                TempData["msg"] = ploc.SaveLocation(plocreqest) ? "Added Successfully":"Failed to Add";//calling here def from repo

                return RedirectToAction("AllLocation");
            }
            else
            {
                PersonRepo p = new PersonRepo(_ctx);
                ViewBag.Personslist = p.GetPersons();
                return View();
            }


        }

        public IActionResult EditLocation(int id)
        {
            PersonRepo pr = new PersonRepo(_ctx);
            ViewBag.Personslist = pr.GetPersons();
            PersonLocationRepo p = new PersonLocationRepo(_ctx);
            // var persnlocation = p.GetDetailsById(id);
            var prlocation = _ctx.PersonLocation.FirstOrDefault(x=>x.Id == id);

            if (prlocation != null)
            {
                var personlocation = new PersonLocation()
                {
                    Id = prlocation.Id,
                    LocationName = prlocation.LocationName,
                    LocDate = prlocation.LocDate,
                    PersonID = prlocation.PersonID
                };

                return View(personlocation);
            }
            TempData["msg"] = "Location of This Person not Available";
            return RedirectToAction("AllLocation");
        }

        [HttpPost]
        public IActionResult  EditLocation(PersonLocation plocreqest)
        {
            if (ModelState.IsValid)
            {
                PersonLocationRepo ploc = new PersonLocationRepo(_ctx);//passing parameter in constructor
                TempData["msg"] = ploc.UpdateLocation(plocreqest) ? "Updated Successfully" : "Failed to Update";//calling here def from repo

                return RedirectToAction("AllLocation");
            }
            else
            {
                PersonRepo p = new PersonRepo(_ctx);
                ViewBag.Personslist = p.GetPersons();
                return View();
            }
                            
        }

                public IActionResult DeleteLocation(int? id)
        {

                    if(id == null)
            {
                return NotFound();
            }

            PersonLocationRepo pdel = new PersonLocationRepo(_ctx);

                            if(pdel.DestroyPersonLocation(id))
            {
                TempData["msg"] = "Person's Location Deleted Successfully";
                return RedirectToAction("AllLocation");
            }
                            TempData["msg"] = "Failed to delete";
                            return RedirectToAction("AllLocation");
        }
    }
}
