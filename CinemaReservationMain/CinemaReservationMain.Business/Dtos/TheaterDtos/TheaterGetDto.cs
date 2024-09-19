using CinemaReservationMain.Business.Dtos.ShowTimeDtos;

namespace CinemaReservationMain.Business.Dtos.TheaterDtos
{
	public record TheaterGetDto(string Name, string Location, int TotalSeats, ICollection<ShowTimeGetDto> ShowTimes);
}
