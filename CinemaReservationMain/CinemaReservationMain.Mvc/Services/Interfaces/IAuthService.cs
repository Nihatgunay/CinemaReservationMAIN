using CinemaReservationMain.Mvc.ViewModels.AuthVMs;

namespace CinemaReservationMain.Mvc.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseVM> Login(UserLoginVM vm);
        Task<LoginResponseVM> AdminLogin(UserLoginVM vm);
        void Logout();
        Task<bool> Register(UserRegisterVM vm);
    }
}
