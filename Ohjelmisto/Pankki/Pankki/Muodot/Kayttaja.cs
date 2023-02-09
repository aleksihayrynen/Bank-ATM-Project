using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pankki.Muodot
{
    internal class Kayttaja 
    {
        public string kayttaja { get; set; }
        public string pin { get; set; }
        public string etunimi { get; set; }
        public string sukunimi { get; set; }
        public DateTime luontiPaiva { get; set; }

        public Kayttaja(string kayttaja, string pin, string etunimi, string sukunimi)
        {
            this.kayttaja = kayttaja;
            this.pin = pin;
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.luontiPaiva = DateTime.Now;
        }
    }
}
