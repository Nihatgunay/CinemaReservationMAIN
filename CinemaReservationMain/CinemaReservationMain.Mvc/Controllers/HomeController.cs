using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CinemaReservationMain.Mvc.Services.Interfaces;
using CinemaReservationMain.Mvc.ViewModels;
using CinemaReservationMain.Mvc.ViewModels.MovieVMs;
using CinemaReservationMain.Mvc.ViewModels.ShowTimeVMs;
using CinemaReservationMain.Mvc.ViewModels.TheaterVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CinemaReservationMain.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICrudService _crudService;
        private readonly HttpClient _httpClient;

        public HomeController(ICrudService crudService, HttpClient httpClient)
        {
            _crudService = crudService;
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
			string token = HttpContext.Request.Cookies["token"];
			if (token == null)
			{
				return Unauthorized();
			}

			var secretKey = "";

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);
			ClaimsPrincipal claimsPrincipal = null;

			try
			{
				claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters()
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key)
				}, out SecurityToken validatedToken);
			}
			catch (SecurityTokenException)
			{
				return Unauthorized();
			}

			string username = claimsPrincipal?.Identity?.Name;

			if (username == null)
			{
				return Unauthorized();
			}

			ViewBag.UserName = username;


			var movies = await _crudService.GetAllAsync<List<MovieGetVM>>("/movies");

            var showtimes = await _crudService.GetAllAsync<List<ShowTimeGetVM>>("/showtimes");

            var theaters = await _crudService.GetAllAsync<List<TheaterGetVm>>("/theaters");

            foreach (var movie in movies)
            {
                movie.ShowTimes = showtimes.Where(st => st.MovieId == movie.Id).ToList();
            }

            foreach (var item in showtimes)
            {
                var theatername = theaters.FirstOrDefault(t => t.Id == item.TheaterId);

                item.TheaterName = theatername.Name;
            }

            var homevm = new HomeVM()
            {
                Movies = movies,
                ShowTimes = showtimes,
                UserName = username
            };

            return View(homevm);
        }
    }
}
