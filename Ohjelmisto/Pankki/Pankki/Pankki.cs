using Pankki.Muodot;

namespace Pankki
{
    internal class Pankki
    {
        public Pankki()
        {

            Console.WriteLine("Tervetuloa pankkiin!!");

            while (true)
            {
                Console.Write("Käyttäjä: ");
                var kayttaja = Console.ReadLine();

                Console.Write("Salasana: ");
                var pinkoodi = Console.ReadLine();

                if (kayttaja == "admin" && pinkoodi == "salasana")
                {
                    Console.Clear();
                    new JarjestelmaValvoja();
                    return;
                }

                Kayttaja aktiivinen = db_pankki.HaeKayttaja(kayttaja);

                if (aktiivinen != null && Salasanahallinta.TarkistaSalasana(pinkoodi, aktiivinen.pin))
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
                        {
                            Console.WriteLine("Kiitos!");
                            return;
                        }

                        switch (vaihtoehto)
                        {
                            case 1:

                                Console.Write("Saajantili: ");
                                var saaja = Console.ReadLine();
                                if (db_pankki.HaeTili(saaja) == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Saaja ei ole olemassa!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }

                                Console.Write("Määrä: ");
                                var summa = double.Parse(Console.ReadLine());

                                Console.Write("Viesti: ");
                                var viesti = Console.ReadLine();
                                if (db_pankki.Siirto(saaja, aktiivinen.kayttaja, summa, viesti))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Siirto onnistui!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Siirto ei onnistunut!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;

                            case 2:
                                Console.Write("Talletuksen summa: ");
                                var talletusSumma = double.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Green;
                                if (db_pankki.Talletus(talletusSumma, aktiivinen.kayttaja))
                                    Console.WriteLine("Talletus onnistui!");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case 3:
                                Console.Write("Noston summa: ");
                                var nostoSumma = double.Parse(Console.ReadLine());
                                if (db_pankki.Nosto(nostoSumma, aktiivinen.kayttaja))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Nosto onnistui!");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ei voitu nostaa!");
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case 4:
                                Console.WriteLine("Historia: ");
                                var tiliHistoria = db_pankki.HaeTili(aktiivinen.kayttaja).siirtoHistoria;
                                foreach (var historia in tiliHistoria)
                                {
                                    Console.WriteLine("-------------------");
                                    Console.WriteLine(
                                        "Summa: " +(historia.vastaanOtto?"+":"-" ) + + historia.summa + "\nViesti: " +
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
                    Console.Clear();
                    Console.WriteLine("Väärä käyttäjätunnus tai salasana.");
                    continue;
                }
            }
        }


    }

}