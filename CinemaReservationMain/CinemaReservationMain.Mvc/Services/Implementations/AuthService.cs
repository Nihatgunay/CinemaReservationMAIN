using CinemaReservationMain.Mvc.ApiResponseMessages;
using CinemaReservationMain.Mvc.Services.Interfaces;
using CinemaReservationMain.Mvc.ViewModels.AuthVMs;
using RestSharp;

namespace CinemaReservationMain.Mvc.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly RestClient _restClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _restClient = new RestClient(_configuration.GetSection("Api:URL").Value);
        }

        public async Task<LoginResponseVM> Login(UserLoginVM vm)
        {
            var request = new RestRequest("/Auth/Login", Method.Post);
            request.AddJsonBody(vm);

            var response = await _restClient.ExecuteAsync<ApiResponseMessage<LoginResponseVM>>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("couldnt login");
            }

            return response.Data.Data;
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("token");
        }
    }
}
