// See https://aka.ms/new-console-template for more information
using Pankki;
using Pankki.Muodot;

// ALKU
// Jatko koodi Esimerkki.cs tiedostosta
Console.WriteLine("Päätiedosto");
db_pankki.LisaaKayttaja("1234", "1234", "janne", "niminen");
db_pankki.LisaaKayttaja("1254", "1534", "jonne", "niminen");
db_pankki.LisaaKayttaja("Kokeilija", "salasana", "Aleksi", "Opiskelija");
var henkilo = db_pankki.HaeKayttaja("Kokeilija");


db_pankki.Siirto("1234", "Kokeilija");



Console.WriteLine(henkilo.etunimi +" toimii");
//Console.WriteLine(db_pankki.KaikkiJSONIKSI());
// LOPPU