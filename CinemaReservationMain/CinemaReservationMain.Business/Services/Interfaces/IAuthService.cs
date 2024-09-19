using CinemaReservationMain.Business.Dtos.TokenDtos;
using CinemaReservationMain.Business.Dtos.UserDtos;

namespace CinemaReservationMain.Business.Services.Interfaces
{
	public interface IAuthService
	{
		Task Register(UserRegisterDto dto);

		Task<TokenResponseDto> Login(UserLoginDto dto);
	}
}
