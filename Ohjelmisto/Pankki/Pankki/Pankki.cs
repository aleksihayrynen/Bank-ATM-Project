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
            db_pankki.LisaaKayttaja( "1234", "janne", "niminen");
            db_pankki.LisaaKayttaja("1534", "jonne", "niminen");
            db_pankki.LisaaKayttaja("salasana", "Aleksi", "Opiskelija");
            var henkilo = db_pankki.HaeKayttaja("Kokeilija");
            db_pankki.HaeKaikkiKayttajat();
            db_pankki.Siirto("1234", "Kokeilija", 22.5 );

            if(henkilo != null)
                Console.WriteLine(henkilo.etunimi + " toimii");
        }
    }
}

