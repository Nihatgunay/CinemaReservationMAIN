namespace CinemaReservationMain.Core.Models
{
	public class ShowTime : BaseEntity
	{
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int MovieId { get; set; }
		public int TheaterId { get; set; }

		public Movie Movie { get; set; }
		public Theater Theater { get; set; }
		public ICollection<SeatReservation> SeatReservations { get; set; }
		public ICollection<Reservation> Reservations { get; set; }
    }
}
