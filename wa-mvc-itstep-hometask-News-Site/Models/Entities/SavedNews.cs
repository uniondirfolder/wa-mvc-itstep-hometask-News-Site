using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wa_mvc_itstep_hometask_News_Site.Models.Entities
{
    public class SavedNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string  Author { get; set; }
        public string Category { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public string PublicationDate { get; set; }

        #region Relation with User
        public int UserId { get; set; }
        public User User { get; set; }
        #endregion
    }
}
