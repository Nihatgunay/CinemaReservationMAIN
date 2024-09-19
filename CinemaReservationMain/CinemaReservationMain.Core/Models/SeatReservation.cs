namespace CinemaReservationMain.Core.Models
{
	public class SeatReservation : BaseEntity
	{
		public int SeatNumber { get; set; }
		public bool IsBooked { get; set; }
		public int ShowTimeId { get; set; }
		public string AppUserId { get; set; }

		public ShowTime ShowTime { get; set; }
		public AppUser AppUser { get; set; }
	}
}
