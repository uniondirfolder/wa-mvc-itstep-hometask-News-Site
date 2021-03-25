using System.Collections.Generic;
using wa_mvc_itstep_hometask_News_Site.Models.Helpers;

namespace wa_mvc_itstep_hometask_News_Site.Models.ViewModels
{
    public class OneNewsVM
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Date { get; set; }

        public string ImageLink { get; set; }

        public string Link { get; set; }

        public List<HtmlElement> HtmlElements { get; set; }
    }
}
