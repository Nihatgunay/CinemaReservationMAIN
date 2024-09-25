using CinemaReservationMain.Mvc.ViewModels.SeatReservationVMs;

namespace CinemaReservationMain.Mvc.ViewModels.ReservationVMs
{
    public class ReservationUpdateVM
    {
        public DateTime ReservationDate { get; set; }
        public int ShowTimeId { get; set; }
        public List<SeatReservationVM> SeatReservations { get; set; }
    }
}
