using System.ComponentModel.DataAnnotations;

namespace AdBoard.ViewModels
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        public Ad[] Ads { get; set; }
    }
}