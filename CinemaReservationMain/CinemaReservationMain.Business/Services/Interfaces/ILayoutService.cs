using CinemaReservationMain.Core.Models;

namespace CinemaReservationMain.Business.Services.Interfaces
{
	public interface ILayoutService
	{
		Task<AppUser> GetUser(string username);
	}
}
