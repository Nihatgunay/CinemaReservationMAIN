using CinemaReservationMain.Business.Dtos.ReservationDtos;
using CinemaReservationMain.Business.Dtos.SeatReservationDtos;
using CinemaReservationMain.Core.Models;

namespace CinemaReservationMain.Business.Dtos.ShowTimeDtos
{
	public record ShowTimeGetDto(int Id, int MovieId, int TheaterId, DateTime StartTime, DateTime EndTime, ICollection<ReservationGetDto> Reservations, ICollection<SeatReservationGetDto> SeatReservations);
}
