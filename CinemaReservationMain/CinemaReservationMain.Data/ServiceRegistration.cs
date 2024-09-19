using CinemaReservationMain.Core.Repositories;
using CinemaReservationMain.Data.DAL;
using CinemaReservationMain.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaReservationMain.Data
{
	public static class ServiceRegistration
	{
		public static void AddRepositories(this IServiceCollection services, string connectionstring)
		{
			services.AddScoped<IMovieRepository, MovieRepository>();
			services.AddScoped<IReservationRepository, ReservationRepository>();
			services.AddScoped<ISeatReservationRepository, SeatReservationRepository>();
			services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
			services.AddScoped<ITheaterRepository, TheaterRepository>();

			services.AddDbContext<AppDbContext>(op =>
			{
				op.UseSqlServer(connectionstring);
			});
		}
	}
}
