using System.ComponentModel.DataAnnotations;

namespace CinemaReservationMain.Mvc.Areas.Admin.ViewModels.MovieVMs
{
	public class MovieCreateVM
	{
		[Required]
		public string Title { get; set; }
		public string Desc { get; set; }
		public double Duration { get; set; }
		public double Rating { get; set; }
		[Required]
		public string Genre { get; set; }
	}
}
