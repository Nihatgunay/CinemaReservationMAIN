namespace CinemaReservationMain.Mvc.ViewModels.ShowTimeVMs
{
	public class ShowTimeGetVM
	{
		public int Id { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string MovieTitle { get; set; }
		public string TheaterName { get; set; }
		public int MovieId { get; set; }
		public int TheaterId { get; set; }
	}
}
