﻿using CinemaReservationMain.Mvc.Services.Interfaces;
using CinemaReservationMain.Mvc.ViewModels.AuthVMs;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Mvc.Controllers
{
	public class AuthController : Controller
	{
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM vm)
        {
            if (!ModelState.IsValid) return View();


            var data = await _authService.Login(vm);

            if (data == null)
            {
                ModelState.AddModelError("", "couldnt login2");
                return View();
            }

            HttpContext.Response.Cookies.Append("token", data.AccessToken, new CookieOptions
            {
                Expires = data.ExpireDate,
                HttpOnly = true
            });

            return RedirectToAction("index", "home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM vm)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                var data = await _authService.Register(vm);

                if (data)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "couldnt register 2");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public IActionResult Logout()
        {
            _authService.Logout();

            return RedirectToAction("login");
        }
    }
}
