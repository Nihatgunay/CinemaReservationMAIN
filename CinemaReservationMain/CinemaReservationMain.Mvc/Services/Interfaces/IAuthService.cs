using CinemaReservationMain.Mvc.ViewModels.AuthVMs;

namespace CinemaReservationMain.Mvc.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseVM> Login(UserLoginVM vm);
        void Logout();
    }
}
