using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.MovieVMs;
using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.ShowTimeVMs;
using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.TheaterVMs;
using CinemaReservationMain.Mvc.Exceptions.Common;
using CinemaReservationMain.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles = "SuperAdmin, Admin")]
	public class ShowTimeController : Controller
	{
		private readonly ICrudService _crudService;

		public ShowTimeController(ICrudService crudService)
		{
			_crudService = crudService;
		}

		public async Task<IActionResult> Index()
		{
			var showTimes = await _crudService.GetAllAsync<List<ShowTimeGetVM>>("/ShowTimes");

			var movies = await _crudService.GetAllAsync<List<MovieGetVM>>("/movies");
			var theaters = await _crudService.GetAllAsync<List<TheaterGetVM>>("/theaters");

			foreach (var showTime in showTimes)
			{
				var movie = movies.FirstOrDefault(m => m.Id == showTime.MovieId);
				var theater = theaters.FirstOrDefault(t => t.Id == showTime.TheaterId);

				showTime.MovieTitle = movie.Title; 
				showTime.TheaterName = theater.Name;
			}

			return View(showTimes);
		}

		public async Task<IActionResult> Detail(int id)
		{
			ShowTimeGetVM data = null;
			try
			{
				data = await _crudService.GetByIdAsync<ShowTimeGetVM>($"/ShowTimes/{id}", id);
			}
			catch (BadrequestException ex)
			{
				TempData["Err"] = ex.Message;
				return View("Error");
			}
			catch (ModelNotFoundException ex)
			{
				TempData["Err"] = ex.Message;
				return View("Error");
			}
			catch (Exception ex)
			{
				TempData["Err"] = ex.Message;
				return View("Error");
			}

			return View(data);
		}

		public async Task<IActionResult> Create()
		{
			ViewBag.Movies = await _crudService.GetAllAsync<List<MovieGetVM>>("/movies");
			ViewBag.Theaters = await _crudService.GetAllAsync<List<TheaterGetVM>>("/theaters");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ShowTimeCreateVM vm)
		{
			ViewBag.Movies = await _crudService.GetAllAsync<List<MovieGetVM>>("/movies");
			ViewBag.Theaters = await _crudService.GetAllAsync<List<TheaterGetVM>>("/theaters");

			await _crudService.Create("/ShowTimes", vm);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _crudService.Delete<object>($"/ShowTimes/{id}", id);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
		{
			ViewBag.Movies = await _crudService.GetAllAsync<List<MovieGetVM>>("/movies");
			ViewBag.Theaters = await _crudService.GetAllAsync<List<TheaterGetVM>>("/theaters");

			var data = await _crudService.GetByIdAsync<ShowTimeUpdateVM>($"/ShowTimes/{id}", id);

			return View(data);
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, ShowTimeUpdateVM vm)
		{
			ViewBag.Movies = await _crudService.GetAllAsync<List<MovieGetVM>>("/movies");
			ViewBag.Theaters = await _crudService.GetAllAsync<List<TheaterGetVM>>("/theaters");

			try
			{
				await _crudService.Update($"/ShowTimes/{id}", vm);
			}
			catch (ModelStateException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View();
			}
			catch (BadrequestException ex)
			{
				TempData["Err"] = ex.Message;
				return View("Error");
			}
			catch (ModelNotFoundException ex)
			{
				TempData["Err"] = ex.Message;
				return View("Error");
			}
			catch (Exception ex)
			{
				TempData["Err"] = ex.Message;
				return View("Error");
			}

			return RedirectToAction("Index");
		}
	}
}
