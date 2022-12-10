using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class PersonController : Controller
    {
        Personal_info persons = new Personal_info();
        public IActionResult all()
        {

            return View(persons.GetAllPerson());
        }
        public IActionResult getPersonById(int id)
        {

            return View(persons.GetPerson(id));
        }
        public IActionResult Search()
        {
            return View();
        }
        public IActionResult getPerson(IFormCollection collection)
        {
           
            int id = persons.GetId(collection["First Name"], collection["Country"]);

            return RedirectToAction("getPersonById","Person",new { id });
            
        }
    }
}
