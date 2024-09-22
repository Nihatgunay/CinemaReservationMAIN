using System.ComponentModel.DataAnnotations;

namespace CinemaReservationMain.Mvc.Areas.Admin.ViewModels.MovieVMs
{
	public class MovieGetVM
	{
        public int Id { get; set; }
        public string Title { get; set; }
		public string Desc { get; set; }
		public double Duration { get; set; }
		public double Rating { get; set; }
		public string Genre { get; set; }
	}
}
