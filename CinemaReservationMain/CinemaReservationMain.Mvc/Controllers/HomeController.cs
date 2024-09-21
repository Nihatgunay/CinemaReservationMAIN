using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
