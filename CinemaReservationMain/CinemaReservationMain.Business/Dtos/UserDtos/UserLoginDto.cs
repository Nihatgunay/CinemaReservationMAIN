using FluentValidation;

namespace CinemaReservationMain.Business.Dtos.UserDtos
{
	public record UserLoginDto(string UserName, string Password, bool RememberMe);

	public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
	{
		public UserLoginDtoValidator()
		{
			RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(60);

			RuleFor(x => x.Password).NotEmpty().NotNull();
		}
	}
}
