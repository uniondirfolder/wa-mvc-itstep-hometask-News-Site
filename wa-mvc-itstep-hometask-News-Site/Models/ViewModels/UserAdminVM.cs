using System;

namespace wa_mvc_itstep_hometask_News_Site.Models.ViewModels
{
    public class UserAdminVM
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool IsLocked { get; set; }
    }
}
