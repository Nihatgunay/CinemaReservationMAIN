using CinemaReservationMain.Mvc.ViewModels.SeatReservationVMs;

namespace CinemaReservationMain.Mvc.ViewModels.ReservationVMs
{
	public class ReservationGetVM
	{
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ShowTimeId { get; set; }
        public string MovieTitle { get; set; }
        public string TheaterName { get; set; }
        public string ShowTimeStart { get; set; }
        public string ShowTimeEnd { get; set; }
        public List<SeatReservationVM> SeatReservations { get; set; }
    }
}
