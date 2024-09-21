using CinemaReservationMain.Business.Dtos.ShowTimeDtos;

namespace CinemaReservationMain.Business.Dtos.MovieDtos
{
    public record MovieGetDto(int Id, string Title, string Desc, double Duration, double Rating, string Genre, ICollection<ShowTimeGetDto> ShowTimes);
}
