using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pankki.Muodot
{
    internal class Yhteinen
    {
        public List<Tili> tilit { get; set; }
        public List<Kayttaja> kayttajat { get; set; }

        public Yhteinen()
        {
            this.tilit = new List<Tili>();
            this.kayttajat = new List<Kayttaja>();
        }


    }
}
