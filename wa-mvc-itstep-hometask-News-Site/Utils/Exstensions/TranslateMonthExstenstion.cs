namespace wa_mvc_itstep_hometask_News_Site.Utils.Exstensions
{
    public static class TranslateMonthExstenstion
    {
        public static string TranslateMonth(this string nameMonth)
        {
            if (nameMonth.Contains("Jan"))
            {
                nameMonth = nameMonth.Replace("Jan", "Янв");
                return nameMonth;
            }

            if (nameMonth.Contains("Feb"))
            {
                nameMonth = nameMonth.Replace("Feb", "Фев");
                return nameMonth;
            }

            if (nameMonth.Contains("Mar"))
            {
                nameMonth = nameMonth.Replace("Mar", "Марта");
                return nameMonth;
            }

            if (nameMonth.Contains("Apr"))
            {
                nameMonth = nameMonth.Replace("Apr", "Апр");
                return nameMonth;
            }

            if (nameMonth.Contains("May"))
            {
                nameMonth = nameMonth.Replace("May", "Мая");
                return nameMonth;
            }

            if (nameMonth.Contains("Jun"))
            {
                nameMonth = nameMonth.Replace("Jun", "Июня");
                return nameMonth;
            }

            if (nameMonth.Contains("Jul"))
            {
                nameMonth = nameMonth.Replace("Jul", "Июля");
                return nameMonth;
            }

            if (nameMonth.Contains("Aug"))
            {
                nameMonth = nameMonth.Replace("Aug", "Авг");
                return nameMonth;
            }

            if (nameMonth.Contains("Sep"))
            {
                nameMonth = nameMonth.Replace("Sep", "Сен");
                return nameMonth;
            }

            if (nameMonth.Contains("Oct"))
            {
                nameMonth = nameMonth.Replace("Oct", "Окт");
                return nameMonth;
            }

            if (nameMonth.Contains("Nov"))
            {
                nameMonth = nameMonth.Replace("Nov", "Ноя");
                return nameMonth;
            }

            if (nameMonth.Contains("Dec"))
            {
                nameMonth = nameMonth.Replace("Dec", "Дек");
                return nameMonth;
            }

            return nameMonth;
        }
    }
}
