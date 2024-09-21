using CinemaReservationMain.Business.Dtos.SeatReservationDtos;

namespace CinemaReservationMain.Business.Dtos.ReservationDtos
{
    public record ReservationGetDto(int Id, int ShowTimeId, string AppUserId, DateTime ReservationDate, ICollection<SeatReservationGetDto> SeatReservations);
}
