using Pankki.Muodot;

namespace Pankki
{
    internal class Pankki
    {
        public Pankki()
        {

            Console.WriteLine("Tervetuloa pankkiin!!");

            Console.Write("Käyttäjä: ");
            var kayttaja = Console.ReadLine();

            Console.Write("Salasana: ");
            var pinkoodi = Console.ReadLine();


            Kayttaja aktiivinen = db_pankki.HaeKayttaja(kayttaja);

            if (aktiivinen != null && aktiivinen.pin == pinkoodi)
            {
                Console.Clear();
                Console.WriteLine("Tervetuloa " + aktiivinen.etunimi + " " + aktiivinen.sukunimi + "!");

                while (true)
                {
                    Console.Write
                    ("\nNykyinen saldo: " +
                    db_pankki.HaeTili(aktiivinen.kayttaja).saldo +
                    "\n\n1: TEE TILISIIRTO\n2: TALLETA\n3: NOSTA\n4: TILITAPAHTUMA HISTORIA\n0: Poistu\n= ");

                    int vaihtoehto = int.Parse(Console.ReadLine());

                    if (vaihtoehto == 0)
                        break;

                    switch (vaihtoehto)
                    {
                        case 1:
                            Console.Write("Saajantili: ");
                            var saaja = Console.ReadLine();

                            Console.Write("Määrä: ");
                            var summa = double.Parse(Console.ReadLine());

                            Console.Write("Viesti: ");
                            var viesti = Console.ReadLine();
                            if (db_pankki.Siirto(saaja, aktiivinen.kayttaja, summa, viesti))
                            {
                                Console.WriteLine("Siirto onnistui!");
                            }
                            else
                            {
                                Console.WriteLine("Siirto ei onnistunut!");
                            }
                            break;

                        case 2:
                            Console.Write("Talletuksen summa: ");
                            var talletusSumma = double.Parse(Console.ReadLine());
                            db_pankki.Talletus(talletusSumma, aktiivinen.kayttaja);
                            break;

                        case 3:
                            Console.Write("Noston summa: ");
                            var nostoSumma = double.Parse(Console.ReadLine());
                            db_pankki.Nosto(nostoSumma, aktiivinen.kayttaja);
                            break;

                        case 4:
                            Console.WriteLine("Historia: ");
                            var tiliHistoria = db_pankki.HaeTili(aktiivinen.kayttaja).siirtoHistoria;
                            foreach (var historia in tiliHistoria)
                            {
                                Console.WriteLine("-------------------");
                                Console.WriteLine(
                                    "Summa: " + historia.summa + "\nViesti: " +
                                    historia.viesti + "\nAika: " +
                                    historia.tapahtumaAika
                                    );
                            }
                            break;
                        default:
                            
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Väärä käyttäjätunnus tai salasana.");
                return;
            }
            Console.WriteLine("Kiitos!");
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