using CinemaReservationMain.Business.Dtos.ShowTimeDtos;

namespace CinemaReservationMain.Business.Dtos.TheaterDtos
{
	public record TheaterGetDto(int Id, string Name, string Location, int TotalSeats, ICollection<ShowTimeGetDto> ShowTimes);
}
