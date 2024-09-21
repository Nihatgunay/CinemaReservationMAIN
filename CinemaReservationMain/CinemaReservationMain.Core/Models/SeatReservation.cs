namespace CinemaReservationMain.Core.Models
{
	public class SeatReservation : BaseEntity
	{
		public int SeatNumber { get; set; }
		public bool IsBooked { get; set; }
		public int ShowTimeId { get; set; }
        public int ReservationId { get; set; }

        public ShowTime ShowTime { get; set; }
        public Reservation Reservation { get; set; }
    }
}
