using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pankki.Muodot

{
   struct Tapahtuma
    {
        DateTime tapahtumaAika;
        double summa;
        string viesti;
        Boolean vastaanOtto;
        string vastaanOttaja;
    }

    internal class Tili
    {
        public string tiliTunnus { get; set; }
        public string tiliOmistajakayttaja { get; set; }
        public double saldo { get; set; }

        public List<Tapahtuma> siirtoHistoria { get; set; }

        public Tili(string omistaja)
        {
            tiliOmistajakayttaja = omistaja;
            siirtoHistoria = new List<Tapahtuma>();
        }
       
    }
}
