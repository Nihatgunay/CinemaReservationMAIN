using System.ComponentModel.DataAnnotations;
using CinemaReservationMain.Mvc.ViewModels.SeatReservationVMs;
using CinemaReservationMain.Mvc.ViewModels.ShowTimeVMs;

namespace CinemaReservationMain.Mvc.ViewModels.ReservationVMs
{
    public class ReservationCreateVM
    {
        [Required]
        public int ShowTimeId { get; set; }

        [Required]
        public int AppUserId { get; set; }

        [Required]
        public int Seats { get; set; }

        public DateTime ReservationDate { get; set; }
        public List<SeatReservationVM> SeatReservations { get; set; }
    }
}
