using CinemaReservationMain.Business.Services.Implementations;
using CinemaReservationMain.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaReservationMain.Business
{
	public static class ServiceRegistration
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<ITheaterService, TheaterService>();
        }
	}
}
