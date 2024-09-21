using CinemaReservationMain.Business.Dtos.TokenDtos;
using CinemaReservationMain.Business.Dtos.UserDtos;
using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CinemaReservationMain.Business.Services.Implementations
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;

		public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
							RoleManager<IdentityRole> roleManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}

		public async Task<TokenResponseDto> Login(UserLoginDto dto)
		{
			AppUser appUser = null;

			appUser = await _userManager.FindByNameAsync(dto.UserName);

			if (appUser == null)
			{
				throw new NullReferenceException();
			}

			var result = await _signInManager.CheckPasswordSignInAsync(appUser, dto.Password, dto.RememberMe);

			if (!result.Succeeded)
			{
				throw new NullReferenceException();
			}

			var roles = await _userManager.GetRolesAsync(appUser);

			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, appUser.Id),
				new Claim(ClaimTypes.Name, appUser.UserName),
			};

			claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
			DateTime expiredt = DateTime.UtcNow.AddMinutes(1);
			string secretkey = _configuration.GetSection("JWT:secretKey").Value;

			SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
			SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
				signingCredentials: signingCredentials,
				claims: claims,
				audience: _configuration.GetSection("JWT:audience").Value,
				issuer: _configuration.GetSection("JWT:issuer").Value,
				expires: expiredt,
				notBefore: DateTime.UtcNow
				);

			string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

			return new TokenResponseDto(token, expiredt);
		}

		public async Task Register(UserRegisterDto dto)
		{
			AppUser appUser = new AppUser()
			{
				Email = dto.Email,
				UserName = dto.UserName
			};

			var result = await _userManager.CreateAsync(appUser, dto.Password);

			if (!result.Succeeded)
			{
				throw new NullReferenceException();
			}

            var member = await _userManager.FindByNameAsync(dto.UserName);

            if (member is not null)
            {
                await _userManager.AddToRoleAsync(member, "Member");
            }
        }
	}
}
