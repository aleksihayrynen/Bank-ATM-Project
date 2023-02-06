// See https://aka.ms/new-console-template for more information
using Pankki;

// ALKU
// Jatko koodi Esimerkki.cs tiedostosta 
Console.WriteLine("Päätiedosto");
Esimerkki.LisaaKayttaja("1234", "1234", "janne", "niminen");
Esimerkki.LisaaKayttaja("1254", "1534", "jonne", "niminen");
var henkilo = Esimerkki.HaeKayttaja("1234");
Console.WriteLine(henkilo.etunimi);
Console.WriteLine(Esimerkki.KaikkiJSONIKSI());
// LOPPU