using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CinemaReservationMain.Mvc.Services.Interfaces;
using CinemaReservationMain.Mvc.ViewModels.ReservationVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CinemaReservationMain.Mvc.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ICrudService _crudService;

        public ReservationController(ICrudService crudService)
        {
            _crudService = crudService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateVM createVM)
        {
            var token = HttpContext.Request.Cookies["token"];
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sdfgdf-463dgdfsd j-fdvnji2387nGood");
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
            catch (Exception)
            {
                return Unauthorized(); 
            }
            
            await _crudService.Create("/reservations", createVM);

            var createdReservations = await _crudService.GetAllAsync<List<ReservationGetVM>>("/reservations");

            var latestReservation = createdReservations
                .Where(r => r.AppUserId == createVM.AppUserId && r.ReservationDate.Date == DateTime.Now.Date)
                .FirstOrDefault();

            if (latestReservation == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
