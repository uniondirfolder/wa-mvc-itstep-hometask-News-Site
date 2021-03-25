namespace wa_mvc_itstep_hometask_News_Site.Services.Security
{
    public static class Cryptography
    {
        private readonly static string _secretKey = "0"; // secret key is hide

        public static string EncryptPassword(string password)
        {

            // code is hide
            return password+_secretKey;//🧨
        }
    }
}
