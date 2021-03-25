namespace wa_mvc_itstep_hometask_News_Site.Utils.Exstensions
{
    public static class TranslateWeekdayExstension
    {
        public static string TranslateWeekday(this string weekName)
        {
            if (weekName.Contains("Sun"))
            {
                weekName = weekName.Replace("Sun", "Вс");
                return weekName;
            }

            if (weekName.Contains("Mon"))
            {
                weekName = weekName.Replace("Mon", "Пн");
                return weekName;
            }

            if (weekName.Contains("Tue"))
            {
                weekName = weekName.Replace("Tue", "Вт");
                return weekName;
            }

            if (weekName.Contains("Wed"))
            {
                weekName = weekName.Replace("Wed", "Ср");
                return weekName;
            }

            if (weekName.Contains("Thu"))
            {
                weekName = weekName.Replace("Thu", "Чт");
                return weekName;
            }

            if (weekName.Contains("Fri"))
            {
                weekName = weekName.Replace("Fri", "Пят");
                return weekName;
            }

            if (weekName.Contains("Sat"))
            {
                weekName = weekName.Replace("Sat", "Сб");
                return weekName;
            }

            return weekName;
        }
    }
}
