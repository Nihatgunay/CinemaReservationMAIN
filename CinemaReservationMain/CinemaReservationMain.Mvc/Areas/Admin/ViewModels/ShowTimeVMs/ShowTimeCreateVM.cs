namespace CinemaReservationMain.Mvc.Areas.Admin.ViewModels.ShowTimeVMs
{
	public class ShowTimeCreateVM
	{
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int MovieId { get; set; }
		public int TheaterId { get; set; }
	}
}
