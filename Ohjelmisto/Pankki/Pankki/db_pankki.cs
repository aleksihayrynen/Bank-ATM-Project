using Pankki.Muodot;
using System.Text.Json;

namespace Pankki
{
    internal static class db_pankki
    {
        private static Yhteinen Varasto = new Yhteinen();
        //Määritellään kiinteä tiedostonimi, mihin tämä olio tallentuu
        private static string tiedostonNimi = "KayttajaTiedot.json";

        public static Kayttaja LisaaKayttaja(string kayttaja, string pin, string etunimi, string sukunimi)
        {
            var uusiKayttaja = new Kayttaja(kayttaja, pin, etunimi, sukunimi);
            Varasto.kayttajat.Add(uusiKayttaja);
            Varasto.tilit.Add(new Tili(uusiKayttaja.kayttaja));
            Tallenna();
            return uusiKayttaja;
        }

        public static string Tallenna()
        {
            var content = JsonSerializer.Serialize<Yhteinen>(Varasto);
            File.WriteAllText(tiedostonNimi, content);
            return content;
        }

        public static Yhteinen JSONTIEDOSTOOBJEKTIKS(string jsontiedostosisalto)
        {
            jsontiedostosisalto = File.ReadAllText(tiedostonNimi);
            Yhteinen deserialized = JsonSerializer.Deserialize<Yhteinen>(jsontiedostosisalto);
            return deserialized;
        }

        public static Kayttaja HaeKayttaja(string kayttaja)
        {
            // sama tilille -> Varasto.tilit
            var haettuKayttaja = Varasto.kayttajat.Find(obj => obj.kayttaja == kayttaja);
            return haettuKayttaja;
        }
        public static Tili HaeTili(string kayttaja)
        {
            // sama tilille -> Varasto.tilit
            var haettuTili = Varasto.tilit.Find(obj => obj.tiliOmistajakayttaja == kayttaja);
            return haettuTili;
        }
        public static void Siirto(string VastaanOttajakayttaja, string siirtajaKayttaja)
        {
            // sama tilille -> Varasto.tilit
            //Esimerkki.HaeTili(kayttaja).saldo = 99.9;
            //Esimerkki.HaeTili(kayttaja).siirtoHistoria.Add(a);  
            Tapahtuma tapahtuma = new Tapahtuma();

            tapahtuma.summa = 22;
            tapahtuma.viesti = "Rahaa sinulle";
            tapahtuma.vastaanOttaja = siirtajaKayttaja;
            tapahtuma.vastaanOtto = true;
            tapahtuma.tapahtumaAika = DateTime.Now;

            Varasto.tilit.Find(obj => obj.tiliOmistajakayttaja == VastaanOttajakayttaja).siirtoHistoria.Add(tapahtuma);
            
          
            Tallenna();
        }


    }
}
