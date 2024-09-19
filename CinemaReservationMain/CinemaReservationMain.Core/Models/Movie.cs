namespace CinemaReservationMain.Core.Models
{
	public class Movie : BaseEntity
	{
		public string Title { get; set; }
		public string Desc { get; set; }
		public double Duration { get; set; }
		public double Rating { get; set; }
		public string Genre { get; set; }

		public ICollection<ShowTime> ShowTimes { get; set; }
	}
}
