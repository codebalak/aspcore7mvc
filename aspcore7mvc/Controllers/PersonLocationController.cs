using Microsoft.AspNetCore.Mvc;
using aspcore7mvc.Repository;
using aspcore7mvc.Models.Domain;

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
    }
}
