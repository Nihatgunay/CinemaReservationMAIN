using FluentValidation;

namespace CinemaReservationMain.Business.Dtos.ReservationDtos
{
    public record ReservationCreateDto(int ShowTimeId, string AppUserId);

    public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto>
    {
        public ReservationCreateDtoValidator()
        {
            RuleFor(x => x.ShowTimeId).NotNull().NotEmpty();
            RuleFor(x => x.AppUserId).NotNull().NotEmpty();
        }
    }
}
