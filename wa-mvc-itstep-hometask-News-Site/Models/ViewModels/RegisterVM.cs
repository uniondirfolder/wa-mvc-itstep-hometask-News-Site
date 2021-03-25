using System.ComponentModel.DataAnnotations;

namespace wa_mvc_itstep_hometask_News_Site.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [MinLength(6, ErrorMessage = "Password min include 6 symbols")]
        [MaxLength(20, ErrorMessage = "Password max include 20 symbols")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat password")]
        [Compare("Password", ErrorMessage = "Passwords not equal")]
        public string RepeatPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
