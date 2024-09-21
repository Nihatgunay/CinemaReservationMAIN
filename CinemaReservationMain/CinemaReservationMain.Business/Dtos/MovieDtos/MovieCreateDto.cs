namespace CinemaReservationMain.Business.Dtos.MovieDtos
{
    public record MovieCreateDto(string Title, string Desc, double Duration, double Rating, string Genre);
}
