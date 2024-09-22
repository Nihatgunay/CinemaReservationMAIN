using System.Diagnostics;
using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.MovieVMs;
using CinemaReservationMain.Mvc.Services.Interfaces;
using CinemaReservationMain.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Mvc.Controllers
{
    public class HomeController : Controller
    {
		private readonly ICrudService _crudService;

		public HomeController(ICrudService crudService)
        {
			_crudService = crudService;
		}
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;

            ViewBag.Username = username;

            var movies = await _crudService.GetAllAsync<List<MovieGetVM>>("/movies");

            var homevm = new HomeVM()
            {
                Movies = movies
            };

            return View(homevm);
        }
    }
}
