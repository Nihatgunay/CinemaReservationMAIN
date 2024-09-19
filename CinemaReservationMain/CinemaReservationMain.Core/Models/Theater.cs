namespace CinemaReservationMain.Core.Models
{
	public class Theater : BaseEntity
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public int TotalSeats { get; set; }

		public ICollection<ShowTime> ShowTimes { get; set; }
	}
}
