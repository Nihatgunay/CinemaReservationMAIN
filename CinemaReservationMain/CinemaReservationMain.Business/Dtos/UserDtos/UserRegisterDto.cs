using FluentValidation;

namespace CinemaReservationMain.Business.Dtos.UserDtos
{
	public record UserRegisterDto(string UserName, string Email, string Password,
		string ConfirmPassword, string? PhoneNumber);

	public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
	{
		public UserRegisterDtoValidator()
		{
			RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(60);

			RuleFor(x => x.Email).NotNull().NotEmpty();

			RuleFor(x => x.Password).MinimumLength(8).MaximumLength(40);

			RuleFor(x => x).Custom((x, context) =>
			{
				if (x.Password != x.ConfirmPassword)
				{
					context.AddFailure("ConfirmPassword", "pw and confirm pw dont match");
				}
			});
		}
	}
}
