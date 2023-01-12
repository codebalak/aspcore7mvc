using Microsoft.AspNetCore.Mvc;
using aspcore7mvc.Models;
using aspcore7mvc.Models.Domain;

namespace aspcore7mvc.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx) 
        {
            _ctx = ctx;//deppendency injection
        }
        public IActionResult Index()
        {
            
            return View();
        }

        //get 
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                   _ctx.Person.Add(person);
                    _ctx.SaveChanges();
                TempData["msg"] = "Added Successfully"; ; 
                return RedirectToAction("AddPerson");
            }
            catch(Exception ex)
            {
                TempData["msg"] = "Internal Server Error";
            }   return View();
            /*TempData["msg"] = "Added Person";
            return View();*/
        }

        public IActionResult DisplayAllPersons()
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }

        public IActionResult Edit(int id)
        {
            var person = _ctx.Person.Find(id);
            if(person == null) 
            {
                TempData["msg"] = "Not found";
            }
            
            return View(person);
        }


        public IActionResult Delete(int id)
        {
            try
            {
                var person = _ctx.Person.Find(id);
                if (person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                    TempData["msg"] = "Deleted Successfully";
                }
            }
            catch(Exception ex) 
            {
                TempData["msg"] = "Internal Server Error";
            }

            return RedirectToAction("DisplayAllPersons");


        }

        [HttpPost]
        public IActionResult Edit(Person personreq)
        {

            if(!ModelState.IsValid)
            {
                return View();
            }

            try
            {
               
                _ctx.Person.Update(personreq);
                _ctx.SaveChanges();
                TempData["msg"] = "Updated Successfully";
            }
            catch(Exception ex)
            {
                TempData["msg"] = "Internal Server Error";
            }
            return RedirectToAction("DisplayAllPersons");
        }
    }
}
