using CinemaReservationMain.Business.Dtos.TokenDtos;
using CinemaReservationMain.Business.Dtos.UserDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationMain.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IAuthService _authService;

		public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IAuthService authService)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_authService = authService;
		}

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            try
            {
                await _authService.Register(dto);
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            TokenResponseDto rDto = null;

            try
            {
                rDto = await _authService.Login(dto);
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(rDto);
        }

        //[HttpGet("")]
        //public async Task<IActionResult> CreateRole()
        //{
        //	IdentityRole role1 = new IdentityRole("SuperAdmin");
        //	IdentityRole role2 = new IdentityRole("Admin");
        //	IdentityRole role3 = new IdentityRole("Member");

        //	await _roleManager.CreateAsync(role1);
        //	await _roleManager.CreateAsync(role2);
        //	await _roleManager.CreateAsync(role3);

        //	return Ok();
        //}

        //[HttpGet("")]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //	AppUser appUser = await _userManager.FindByNameAsync("firstsuperadmin");

        //	await _userManager.AddToRoleAsync(appUser, "SuperAdmin"); //pass - SuperAdm123@

        //	return Ok();
        //}
    }
}
