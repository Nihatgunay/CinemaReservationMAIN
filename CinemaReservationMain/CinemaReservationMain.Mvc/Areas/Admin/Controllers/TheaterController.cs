using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.TheaterVMs;
using CinemaReservationMain.Mvc.Exceptions.Common;
using CinemaReservationMain.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TheaterController : Controller
	{
		private readonly ICrudService _crudService;

		public TheaterController(ICrudService crudService)
		{
			_crudService = crudService;
		}

		public async Task<IActionResult> Index()
		{
			//if (Request.Cookies["token"] == null)
			//{
			//	return RedirectToAction("login", "auth");
			//}
			var datas = await _crudService.GetAllAsync<List<TheaterGetVM>>("/Theaters");

			return View(datas);
		}

		public async Task<IActionResult> Detail(int id)
		{
			TheaterGetVM data = null;
			try
			{
				data = await _crudService.GetByIdAsync<TheaterGetVM>($"/Theaters/{id}", id);
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
		public async Task<IActionResult> Create(TheaterCreateVM vm)
		{
			await _crudService.Create("/Theaters", vm);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _crudService.Delete<object>($"/Theaters/{id}", id);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
		{
			var data = await _crudService.GetByIdAsync<TheaterUpdateVM>($"/Theaters/{id}", id);

			return View(data);
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, TheaterUpdateVM vm)
		{
			try
			{
				await _crudService.Update($"/Theaters/{id}", vm);
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
