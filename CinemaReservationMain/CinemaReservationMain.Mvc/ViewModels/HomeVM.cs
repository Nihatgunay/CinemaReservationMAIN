using CinemaReservationMain.Mvc.ViewModels.MovieVMs;
using CinemaReservationMain.Mvc.ViewModels.ReservationVMs;
using CinemaReservationMain.Mvc.ViewModels.ShowTimeVMs;

namespace CinemaReservationMain.Mvc.ViewModels
{
	public class HomeVM
	{
		public List<MovieGetVM> Movies { get; set; }
		public List<ShowTimeGetVM> ShowTimes { get; set; }
        public string UserName { get; set; }
    }
}
