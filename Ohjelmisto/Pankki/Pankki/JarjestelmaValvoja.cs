using Pankki.Muodot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pankki
{
    internal class JarjestelmaValvoja
    {
        public JarjestelmaValvoja() {
            Console.WriteLine("Tervetuloa Järjelmävalvoja systeemin scrum master hallitsija!" );
        
            while (true)
            {
                Console.Write
                ("\n\n1: HAE KÄYTTÄJÄ\n2: POISTA KÄYTTÄJÄ\n3: HAE KAIKKI KÄYTTÄJÄTIEDOT\n4: LISÄÄ KÄYTTÄJÄ\n5: HAE TILI\n0: Poistu\n= ");
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
                        {
                            Console.WriteLine(haettu.kayttaja + " | " + haettu.etunimi + " | " + haettu.sukunimi + " | " + haettu.pin + " | " + haettu.luontiPaiva);
                        }
                             
                         
                        else
                        {
                            Console.WriteLine("Käyttäjää ei löytynyt");
                        }
                        break;  
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

                        if (!a.Any())
                        {
                            Console.WriteLine("Ei ole yhtään käyttäjiä olemassa!");
                            return;
                        }
                           
                        foreach (var kayttaja in a)
                        {
                            Console.WriteLine(kayttaja.kayttaja + " | " + kayttaja.etunimi + " | " + kayttaja.sukunimi + " | " + kayttaja.pin + " | " + kayttaja.luontiPaiva);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Syötä etunimi");
                        var etunimi = Console.ReadLine();
                        Console.WriteLine("Syötä sukunimi");
                        var sukunimi = Console.ReadLine();
                        Console.WriteLine("Syötä 4-numeroinen pin-koodi");
                        var salasana = Console.ReadLine();
                        while (salasana.Length != 4)   
                        {
                            Console.WriteLine("Virheellinen salasana(4 numeroa)\nSyötä uudestaan: ");
                            salasana = Console.ReadLine();
                        }

                        db_pankki.LisaaKayttaja(salasana, etunimi, sukunimi);
                        Console.WriteLine("Käyttäjä luotu");
                        break;
                    case 5:
                        Console.WriteLine("Syötä tilinumero");
                        var tilinumero = Console.ReadLine();
                        var haettuTiliNumero = db_pankki.HaeTili(tilinumero);
                        if (haettuTiliNumero != null)
                        {
                            var aa = db_pankki.HaeKayttaja(tilinumero);
                            Console.WriteLine(aa.etunimi+" "+aa.sukunimi);
                            Console.WriteLine(haettuTiliNumero.tiliOmistajakayttaja + " | " + haettuTiliNumero.tiliTunnus + " | " + haettuTiliNumero.saldo + " e");

                        }
                        else
                        {
                            Console.WriteLine("Tiliä ei löytynyt");
                        }
                        break;

                    default:
                        break;
                }
            }
        } 
    }
}
