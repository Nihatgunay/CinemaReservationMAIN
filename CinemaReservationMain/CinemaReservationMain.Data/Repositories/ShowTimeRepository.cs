using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using CinemaReservationMain.Data.DAL;

namespace CinemaReservationMain.Data.Repositories
{
	public class ShowTimeRepository : GenericRepository<ShowTime>, IShowTimeRepository
	{
		public ShowTimeRepository(AppDbContext context) : base(context)
		{
		}
	}
}
