using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using CinemaReservationMain.Data.DAL;

namespace CinemaReservationMain.Data.Repositories
{
	public class TheaterRepository : GenericRepository<Theater>, ITheaterRepository
	{
		public TheaterRepository(AppDbContext context) : base(context)
		{
		}
	}
}
