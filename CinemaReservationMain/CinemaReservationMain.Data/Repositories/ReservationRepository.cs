using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using CinemaReservationMain.Data.DAL;

namespace CinemaReservationMain.Data.Repositories
{
	public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
	{
		public ReservationRepository(AppDbContext context) : base(context)
		{
		}
	}
}
