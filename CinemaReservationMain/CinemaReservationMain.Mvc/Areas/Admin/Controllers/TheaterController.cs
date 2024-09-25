using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.TheaterVMs;
using CinemaReservationMain.Mvc.Exceptions.Common;
using CinemaReservationMain.Mvc.Services.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaReservationMain.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles = "SuperAdmin, Admin")]
	public class TheaterController : Controller
	{
		private readonly ICrudService _crudService;

		public TheaterController(ICrudService crudService)
		{
			_crudService = crudService;
		}

		public async Task<IActionResult> Index()
		{
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
			try
			{
				await _crudService.Create("/Theaters", vm);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "cant be null");
				return View();
			}

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _crudService.Delete<object>($"/Theaters/{id}", id);
			}
			catch (Exception ex)
			{
				TempData["Err"] = "not found";
				return View("Error");
			}

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
        {
			TheaterUpdateVM data = null;

            try
			{
                data = await _crudService.GetByIdAsync<TheaterUpdateVM>($"/Theaters/{id}", id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Entity not found, changes will not be saved");
                return View(data);
            }

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
