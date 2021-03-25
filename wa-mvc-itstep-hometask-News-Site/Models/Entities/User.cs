﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wa_mvc_itstep_hometask_News_Site.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Column(TypeName = "boolean")]
        public bool IsLocked { get; set; }

        #region Relation with SavedNews
        public List<SavedNews> SavedNews { get; set; }
        #endregion

        #region Relation with Role
        public int RoleId { get; set; }
        public Role Role { get; set; }
        #endregion
    }
}
