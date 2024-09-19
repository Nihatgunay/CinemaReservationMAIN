using CinemaReservationMain.Core.Models;
using CinemaReservationMain.Core.Repositories;
using CinemaReservationMain.Data.DAL;

namespace CinemaReservationMain.Data.Repositories
{
	public class MovieRepository : GenericRepository<Movie>, IMovieRepository
	{
		public MovieRepository(AppDbContext context) : base(context)
		{
		}
	}
}
