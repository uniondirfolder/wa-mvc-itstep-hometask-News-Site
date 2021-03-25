using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wa_mvc_itstep_hometask_News_Site.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter пароль")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
