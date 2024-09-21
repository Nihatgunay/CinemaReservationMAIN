using FluentValidation;

namespace CinemaReservationMain.Business.Dtos.SeatReservationDtos
{
    public record SeatReservationCreateDto(int SeatNumber, int ShowTimeId, int ReservationId);

    public class SeatReservationCreateDtoValidator : AbstractValidator<SeatReservationCreateDto>
    {
        public SeatReservationCreateDtoValidator()
        {
            RuleFor(x => x.SeatNumber).NotNull().NotEmpty().GreaterThan(0).WithMessage("invalid seat number");

            RuleFor(x => x.ShowTimeId).NotNull().NotEmpty();
            RuleFor(x => x.ReservationId).NotNull().NotEmpty();
        }
    }
}
