using Microsoft.AspNetCore.Identity;

namespace CinemaReservationMain.Core.Models
{
	public class AppUser : IdentityUser
	{
		public ICollection<Reservation> Reservations { get; set; }
	}
}
