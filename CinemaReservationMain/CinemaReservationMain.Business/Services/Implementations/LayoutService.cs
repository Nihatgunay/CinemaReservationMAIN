using CinemaReservationMain.Business.Services.Interfaces;
using CinemaReservationMain.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace CinemaReservationMain.Business.Services.Implementations
{
	public class LayoutService : ILayoutService
	{
		private readonly UserManager<AppUser> _userManager;

		public LayoutService(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<AppUser> GetUser(string username)
		{
			AppUser user = null;

			user = await _userManager.FindByNameAsync(username);

			return user;
		}
	}
}
