using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.ShowTimeVMs;
using CinemaReservationMain.Mvc.Services.Interfaces;
using CinemaReservationMain.Mvc.ViewModels.ReservationVMs;
using CinemaReservationMain.Mvc.ViewModels.SeatReservationVMs;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Mvc.Controllers;

public class ReservationController : Controller
{
	private readonly ICrudService _crudService;

	public ReservationController(ICrudService crudService)
	{
		_crudService = crudService;
	}

	public async Task<IActionResult> Create(int showTimeId)
	{
		var showTime = await _crudService.GetByIdAsync<ShowTimeGetVM>($"/showtimes/{showTimeId}", showTimeId);
		ViewBag.ShowTime = showTime;

		var seats = await _crudService.GetAllAsync<List<SeatReservationVM>>($"/showtimes/{showTimeId}");
		var vm = new ReservationCreateVM
		{
			ShowTimeId = showTimeId,
			ReservationDate = DateTime.Now,
			SeatReservations = seats
		};

		return View(vm);
	}

	[HttpPost]
	public async Task<IActionResult> Create(ReservationCreateVM vm)
	{
		if (ModelState.IsValid)
		{
			await _crudService.Create("/reservations", vm);
			return RedirectToAction("Index", "Home");
		}

		var seats = await _crudService.GetAllAsync<List<SeatReservationVM>>($"/showtimes/{vm.ShowTimeId}");
		vm.SeatReservations = seats;

		return View(vm);
	}
}
