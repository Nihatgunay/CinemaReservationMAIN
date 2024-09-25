using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.MovieVMs;
using CinemaReservationMain.Mvc.Exceptions.Common;
using CinemaReservationMain.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles = "SuperAdmin, Admin")]
	public class MovieController : Controller
	{
		private readonly ICrudService _crudService;

		public MovieController (ICrudService crudService)
		{
			_crudService = crudService;
		}

		public async Task<IActionResult> Index()
		{
			var datas = await _crudService.GetAllAsync<List<MovieGetVM>>("/Movies");

			return View(datas);
		}

		public async Task<IActionResult> Detail(int id)
		{
			MovieGetVM data = null;
			try
			{
				data = await _crudService.GetByIdAsync<MovieGetVM>($"/Movies/{id}", id);
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

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(MovieCreateVM vm)
		{
			await _crudService.Create("/Movies", vm);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _crudService.Delete<object>($"/Movies/{id}", id);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
		{
			var data = await _crudService.GetByIdAsync<MovieUpdateVM>($"/Movies/{id}", id);

			return View(data);
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, MovieUpdateVM vm)
		{
			try
			{
				await _crudService.Update($"/Movies/{id}", vm);
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
