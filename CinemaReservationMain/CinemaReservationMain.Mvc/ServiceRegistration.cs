using CinemaReservationMain.Mvc.Services.Implementations;
using CinemaReservationMain.Mvc.Services.Interfaces;

namespace CinemaReservationMain.Mvc
{
    public static class ServiceRegistration
    {
        public static void AddRegisterService(this IServiceCollection services)
        {
            services.AddScoped<ICrudService, CrudService>();
            services.AddScoped<IAuthService, AuthService>();
		}
    }
}
