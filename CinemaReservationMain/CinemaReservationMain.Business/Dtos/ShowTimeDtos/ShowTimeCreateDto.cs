using FluentValidation;

namespace CinemaReservationMain.Business.Dtos.ShowTimeDtos
{
    public record ShowTimeCreateDto(int MovieId, int TheaterId, DateTime StartTime, DateTime EndTime);

    public class ShowTimeCreateDtoValidator : AbstractValidator<ShowTimeCreateDto>
    {
        public ShowTimeCreateDtoValidator()
        {
            RuleFor(x => x.MovieId).NotNull().NotEmpty();
            RuleFor(x => x.TheaterId).NotNull().NotEmpty();

            RuleFor(p => p.StartTime)
                .NotEmpty().WithMessage("cant be emoty")
                .GreaterThan(p => DateTime.Now).WithMessage("Starttime must be > Datetime.now");

            RuleFor(p => p.EndTime)
                .NotEmpty().WithMessage("cant be emoty")
                .GreaterThan(p => DateTime.Now).WithMessage("Endtime must be > Datetime.now")
                .GreaterThan(x => x.StartTime).WithMessage("end time > start time");
        }
    }
}
