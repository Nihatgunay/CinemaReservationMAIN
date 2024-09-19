namespace CinemaReservationMain.Core.Models
{
	public class Reservation : BaseEntity
	{
		public DateTime ReservationDate { get; set; }
		public int ShowTimeId { get; set; }
		public string AppUserId { get; set; }

		public ShowTime ShowTime { get; set; }
		public AppUser AppUser { get; set; }
		public ICollection<SeatReservation> SeatReservations { get; set; }
	}
}
