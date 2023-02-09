using Pankki.Muodot;
using System.Text.Json;

namespace Pankki
{
    internal static class db_pankki
    {
        private static Yhteinen Varasto = new Yhteinen();
        //Määritellään kiinteä tiedostonimi, mihin tämä olio tallentuu
        private static string tiedostonNimi = "KayttajaTiedot.json";

        public static Kayttaja LisaaKayttaja( string pin, string etunimi, string sukunimi)
        {
            int randNum = new Random().Next(1000000);
            string numero = randNum.ToString("D6");

            var uusiKayttaja = new Kayttaja(numero, pin, etunimi, sukunimi);
            Varasto.kayttajat.Add(uusiKayttaja);
            int randNum2 = new Random().Next(1000000);
            string numero2 = randNum2.ToString("D6");
            Varasto.tilit.Add(new Tili(uusiKayttaja.kayttaja,"FI"+ numero2));
            Tallenna();
            return uusiKayttaja;
        }

        private static string Tallenna()
        {
            var content = JsonSerializer.Serialize<Yhteinen>(Varasto);
            File.WriteAllText(tiedostonNimi, content);
            return content;
        }

        public static void tiedostoLuku()
        {
            try
            { // Yritetään lukea kanta-tiedosto
                var raakaJson = File.ReadAllText(tiedostonNimi);//Luetaan se "tiedostonNimi" -polun mukaan
                if (raakaJson.Length > 5) // Jos sen pituus on yli 5, niin se ei todennäkösesti ole tyhjä
                {
                    var varastoDB = JsonSerializer.Deserialize<Yhteinen>(raakaJson); // DeSerialisoidaan json -teksti takaisin objekti -muotoon
                    Console.WriteLine(varastoDB);
                    if (varastoDB != null) //Jos se objekti ei ole tyhjä, niiiiin -->
                    {
                        Varasto = varastoDB; //Asetetaan tämän olion listan sisältö luetun olion sisäisen listan mukaiseksi.
                    }
                }
                Console.WriteLine("Kantaluku onnistui!");
            }
            catch // Jos try -sisältö räjähti, niin softa ei kaadu, vaan tulee tähän.
            {
                Console.WriteLine("Epäonnistu vakavasti! Liian!");
            }

        }

        public static Boolean PoistaKayttaja(string kayttaja)
        {
            // sama tilille -> Varasto.tilit
            Varasto.kayttajat.RemoveAll(obj => obj.kayttaja == kayttaja);
            Varasto.tilit.RemoveAll(obj => obj.tiliOmistajakayttaja == kayttaja);
            return true;
        }

        public static Kayttaja HaeKayttaja(string kayttaja)
        {
            // sama tilille -> Varasto.tilit
            var haettuKayttaja = Varasto.kayttajat.Find(obj => obj.kayttaja == kayttaja);
            return haettuKayttaja;
        }

        public static List<Kayttaja> HaeKaikkiKayttajat()
        {
            // sama tilille -> Varasto.tilit
            var haettuKayttajat = Varasto.kayttajat;
            return haettuKayttajat;
        }

        public static Tili? HaeTili(string kayttaja)
        {
            // sama tilille -> Varasto.tilit
            try
            {   
                var haettuTili = Varasto.tilit.Find(obj => obj.tiliOmistajakayttaja == kayttaja);
                return haettuTili;
            }
            catch
            {
                return null;
            }
        }
        public static Boolean Siirto(string VastaanOttajakayttaja, string siirtajaKayttaja, double raha, string viesti="", Boolean vastaanOtto = true)
        {

            try { 
            if (Varasto.tilit.Find(obj => obj.tiliOmistajakayttaja == siirtajaKayttaja).saldo < raha)
                return false;

            Tapahtuma tapahtuma = new Tapahtuma();

            tapahtuma.summa = raha;
            tapahtuma.viesti = viesti;
            tapahtuma.vastaanOttaja = siirtajaKayttaja;
            tapahtuma.vastaanOtto = vastaanOtto;
            tapahtuma.tapahtumaAika = DateTime.Now;

            // Magic code .....
            Varasto.tilit.Find(obj => obj.tiliOmistajakayttaja == VastaanOttajakayttaja).siirtoHistoria.Add(tapahtuma);
            Varasto.tilit.Find(obj => obj.tiliOmistajakayttaja == VastaanOttajakayttaja).saldo += raha;
            Varasto.tilit.Find(obj => obj.tiliOmistajakayttaja == siirtajaKayttaja).saldo -= raha;

            Tallenna();

            return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
