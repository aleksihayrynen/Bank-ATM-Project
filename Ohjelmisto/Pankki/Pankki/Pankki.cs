using Pankki.Muodot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pankki
{
    internal class Pankki
    {
        public Pankki()
        {

            db_pankki.tiedostoLuku();

            Console.WriteLine("Tervetuloa pankkiin!!");

            Console.Write("Käyttäjä: ");
            var kayttaja = Console.ReadLine();

            Console.Write("Salasana: ");
            var pinkoodi = Console.ReadLine();


            Kayttaja haettu = db_pankki.HaeKayttaja(kayttaja);

            if (haettu.pin == pinkoodi)
            {
                Console.WriteLine("Pääsit sisään");
                Console.Write("1: TEE TILISIIRTO\n 2: TALLETA\n 3: NOSTA\n 4: TILITAPAHTUMA HISTORIA");
                var vaihtoehto = int.Parse(Console.ReadLine());
                switch(vaihtoehto)
                {
                    case 1:
                        Console.Write("Saajantili: ");
                        var saaja = Console.ReadLine();

                        Console.Write("Määrä: ");
                        var summa = double.Parse( Console.ReadLine());

                        Console.Write("Viesti: ");
                        var viesti = Console.ReadLine();

                        db_pankki.Siirto(saaja,haettu.kayttaja, summa, viesti);
                        break;
                    default:
                        break;
                }
            }  
            else
            {
                Console.WriteLine("Väärä käyttäjätunnus tai salasana.");
            }

        }
    }
}

/*
db_pankki.LisaaKayttaja( "1234", "janne", "niminen");
db_pankki.LisaaKayttaja("1534", "jonne", "niminen");
db_pankki.LisaaKayttaja("salasana", "Aleksi", "Opiskelija");
var henkilo = db_pankki.HaeKayttaja("Kokeilija");
db_pankki.HaeKaikkiKayttajat();
db_pankki.Siirto("1234", "Kokeilija", 22.5 );

if(henkilo != null)
    Console.WriteLine(henkilo.etunimi + " toimii");
*/