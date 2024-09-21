using FluentValidation;

namespace CinemaReservationMain.Business.Dtos.ReservationDtos
{
    public record ReservationUpdateDto(int ShowTimeId, string AppUserId);

    public class ReservationUpdateDtoValidator : AbstractValidator<ReservationUpdateDto>
    {
        public ReservationUpdateDtoValidator()
        {
            RuleFor(x => x.ShowTimeId).NotNull().NotEmpty();
            RuleFor(x => x.AppUserId).NotNull().NotEmpty();
        }
    }
}
