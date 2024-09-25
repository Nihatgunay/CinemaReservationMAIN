using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CinemaReservationMain.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string token = HttpContext.Request.Cookies["token"];
            var secret = "sdfgdf-463dgdfsd j-fdvnji2387nGood";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            string username = null;
            ClaimsPrincipal claimsPrincipal = null;
            if (token is not null)
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);
                username = claimsPrincipal.Identity.Name;
            }

            ViewBag.UserName = username;

            return View();
        }
    }
}
