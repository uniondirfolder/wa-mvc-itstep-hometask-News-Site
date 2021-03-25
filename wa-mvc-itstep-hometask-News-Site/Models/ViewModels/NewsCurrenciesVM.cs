using System.Collections.Generic;
using wa_mvc_itstep_hometask_News_Site.Models.Helpers;

namespace wa_mvc_itstep_hometask_News_Site.Models.ViewModels
{
    public class NewsCurrenciesVM
    {
        public List<News> News { get; set; }

        public List<CurrencyItem> CurrencyItems { get; set; }

        public List<CurrencyItem> TopCurrencies { get; set; }

        public NewsCategoriesVM NewsCategoriesVM { get; set; }

        public NewsCurrenciesVM() => NewsCategoriesVM = new NewsCategoriesVM();
    }
}
