using Pankki.Muodot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pankki
{
    internal class JarjestelmaValvoja
    {
        public JarjestelmaValvoja() {
            /// KOOODI TÄNNE
            /// 
            Console.WriteLine("Tervetuloa Järjelmävalvoja systeemin scrum master hallitsija!" );
        
            while (true) // ehkä korvattavissa nintendo switchillä
            {
                Console.Write
                ("\n\n1: HAE KÄYTTÄJÄ\n2: POISTA KÄYTTÄJÄ\n3: HAE KAIKKI KÄYTTÄJÄTIEDOT\n4: JOTAIN INNOVATIIVISTÄ\n0: Poistu\n= ");
                var vaihtoehto = int.Parse(Console.ReadLine());

                if (vaihtoehto == 0)
                    break;

                switch (vaihtoehto)
                {
                    case 1:
                        Console.WriteLine("Syötä käyttäjätunnus");
                        var kayttajatunnus = Console.ReadLine();
                        var haettu = db_pankki.HaeKayttaja(kayttajatunnus);
                        if (haettu != null)
                            Console.WriteLine(haettu);
                        else
                        {
                            Console.WriteLine("Käyttäjää ei löytynyt");
                        }
                        break;
                    //ei toimi VIELÄ    
                    case 2:
                        Console.WriteLine("Syötä käyttäjätunnus, jonka haluat poistaa");
                        var poistettavaKayttaja = Console.ReadLine();
                        if (db_pankki.PoistaKayttaja(poistettavaKayttaja))
                        {
                            Console.WriteLine("Rehellisesti tää on nyt poistettu!!!");
                        }
                        else
                        {
                            Console.WriteLine("Ei löytynyt! Epäonnistu pahasti!");
                        }



                        break;

                    case 3:
                        var a = db_pankki.HaeKaikkiKayttajat();
                        foreach (var kayttaja in a)
                        {
                            Console.WriteLine(kayttaja.kayttaja + " | " + kayttaja.etunimi + " | " + kayttaja.sukunimi + " | " + kayttaja.pin + " | " + kayttaja.luontiPaiva);
                        }
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
        } 
    }
}

/*
db_pankki.PoistaKayttaja(kayttaja);
db_pankki.LisaaKayttaja( "1234", "janne", "niminen");
db_pankki.LisaaKayttaja("1534", "jonne", "niminen");
db_pankki.LisaaKayttaja("salasana", "Aleksi", "Opiskelija");
var henkilo = db_pankki.HaeKayttaja("Kokeilija");
db_pankki.HaeKaikkiKayttajat();

db_pankki.Siirto("1234", "Kokeilija", 22.5 );
db_pankki.Talletus(22.3, aktiivinen.kayttaja);
db_pankki.Nosto(22.3, aktiivinen.kayttaja);

*/