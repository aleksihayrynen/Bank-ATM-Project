using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pankki.Muodot

{
 internal class Tapahtuma
    {
        public DateTime tapahtumaAika { get; set; }
        public double summa { get; set; }
        public string viesti { get; set; }
        public Boolean vastaanOtto { get; set; }
        public string vastaanOttaja { get; set; }
    }

    internal class Tili
    {
        public string tiliTunnus { get; set; }
        public string tiliOmistajakayttaja { get; set; }
        public double saldo { get; set; }

        public List<Tapahtuma> siirtoHistoria { get; set; }

        public Tili()
        {
            siirtoHistoria = new List<Tapahtuma>();
        
        }

        public Tili(string omistaja, string FI_tiliTunnus)
        {
            tiliOmistajakayttaja = omistaja;
            saldo = 0;
            tiliTunnus = FI_tiliTunnus;
        }
       
    }
}
