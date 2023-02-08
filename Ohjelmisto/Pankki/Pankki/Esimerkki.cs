using Pankki.Muodot;
using System.Text.Json;

namespace Pankki
{
    internal static class Esimerkki
    {
        private static Yhteinen Varasto = new Yhteinen();
        //Määritellään kiinteä tiedostonimi, mihin tämä olio tallentuu
        private static string tiedostonNimi = "C:\\Users\\aleks\\Documents\\GitHub\\OhjlemistoKehitys\\Ohjelmistokehitys-Projekti\\Ohjelmisto\\Pankki\\Pankki\\KayttajaTiedot.json";

        public static Kayttaja LisaaKayttaja(string kayttaja, string pin, string etunimi, string sukunimi)
        {
            var uusiKayttaja = new Kayttaja(kayttaja, pin, etunimi, sukunimi);
            Varasto.kayttajat.Add(uusiKayttaja);

            return uusiKayttaja;
        }

        public static string KaikkiJSONIKSI()
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
        /*public static Tili HaeTili(string kayttaja)
        {
            // sama tilille -> Varasto.tilit
            var haettuTili = Varasto.tilit.Find(obj => obj.saldo == kayttaja);
            return haettuTili;

        }*/
        
    }
}
