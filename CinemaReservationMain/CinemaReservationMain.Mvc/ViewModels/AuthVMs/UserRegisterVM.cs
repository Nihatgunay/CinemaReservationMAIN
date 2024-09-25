using System.ComponentModel.DataAnnotations;

namespace CinemaReservationMain.Mvc.ViewModels.AuthVMs
{
    public class UserRegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password length must be > 8")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confrim password dont match.")]
        public string ConfirmPassword { get; set; }
    }
}
