using Microsoft.AspNetCore.Mvc;

namespace aspcore7mvc.Controllers
{
    public class GuideController : Controller
    {
        public IActionResult LandingPage()
        {

            return View();
        }
    }
}
