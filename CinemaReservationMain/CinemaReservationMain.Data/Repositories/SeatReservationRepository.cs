using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using CinemaReservationMain.Data.DAL;

namespace CinemaReservationMain.Data.Repositories
{

	public class SeatReservationRepository : GenericRepository<SeatReservation>, ISeatReservationRepository
	{
		public SeatReservationRepository(AppDbContext context) : base(context)
		{
		}
	}
}
