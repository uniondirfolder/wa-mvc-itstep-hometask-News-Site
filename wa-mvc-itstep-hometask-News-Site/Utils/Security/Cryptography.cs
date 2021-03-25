using wa_mvc_itstep_hometask_News_Site.Utils.Exstensions;

namespace wa_mvc_itstep_hometask_News_Site.Services.Security
{
    public static class Cryptography
    {
        private readonly static string _secretKey = "z14ca58u8a4e4n38ntce2eaj908a5687"; // secret key is hide

        public static string EncryptPassword(string password)
        {

            // code is hide
            return EncryptionDecryptionUsingSymmetricKey.EncryptString(_secretKey, password);//🧨
        }
    }
}
