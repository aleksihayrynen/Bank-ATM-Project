using System.Security.Cryptography;
using System.Text;


namespace Pankki
{
    internal class Salasanahallinta
    {
        static string merisuola = "makeasuola";
        public static string LuoSuolattuSalasana(string salasana)
        {
            return HashSalasana(salasana);
        }

        private static string HashSalasana(string salasana)
        {
            byte[] suolatutTiedot = Encoding.UTF8.GetBytes(salasana + merisuola);
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(suolatutTiedot);
                return Convert.ToBase64String(hash);
            }
        }
        public static bool TarkistaSalasana(string syotettySalasana, string tallennettuSuolattuSalasana)
        {
            string syotetynSalasananSuolattuHash = HashSalasana(syotettySalasana);
            return syotetynSalasananSuolattuHash == tallennettuSuolattuSalasana;
        }
    }
}
