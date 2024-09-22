using System.ComponentModel.DataAnnotations;

namespace CinemaReservationMain.Mvc.Areas.Admin.ViewModels.TheaterVMs
{
	public class TheaterUpdateVM
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Location { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int TotalSeats { get; set; }
	}
}
