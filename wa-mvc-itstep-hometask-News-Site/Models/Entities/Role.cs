using System.Collections.Generic;

namespace wa_mvc_itstep_hometask_News_Site.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region Relation with User
        public List<User> Users { get; set; }
        #endregion


    }
}
