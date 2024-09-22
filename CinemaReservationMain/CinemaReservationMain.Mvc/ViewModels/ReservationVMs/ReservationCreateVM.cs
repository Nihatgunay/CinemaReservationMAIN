using CinemaReservationMain.Mvc.ViewModels.SeatReservationVMs;

namespace CinemaReservationMain.Mvc.ViewModels.ReservationVMs
{
	public class ReservationCreateVM
	{
		public DateTime ReservationDate { get; set; }
		public int ShowTimeId { get; set; }
		public string AppUserId { get; set; }
		public List<SeatReservationVM> SeatReservations { get; set; }
	}
}
