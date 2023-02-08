// See https://aka.ms/new-console-template for more information
using Pankki;
using Pankki.Muodot;

// ALKU
// Jatko koodi Esimerkki.cs tiedostosta
Console.WriteLine("Päätiedosto");
Esimerkki.LisaaKayttaja("1234", "1234", "janne", "niminen");
Esimerkki.LisaaKayttaja("1254", "1534", "jonne", "niminen");
Esimerkki.LisaaKayttaja("Kokeilija", "salasana", "Aleksi", "Opiskelija");
var henkilo = Esimerkki.HaeKayttaja("Kokeilija");
Console.WriteLine(henkilo.etunimi +" toimii");
Console.WriteLine(Esimerkki.KaikkiJSONIKSI());
// LOPPU