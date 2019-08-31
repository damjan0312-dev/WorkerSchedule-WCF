using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProveraRadnikaJun19
{
    [DataContract]
    class Radnik
    {
        [DataMember]
        public string ime { get; set; }
        public string ulogovan { get; set; }

        public List<string> lista_prisustva { get; set; }

        public Radnik(string ime)
        {
            this.ime = ime;
            this.ulogovan = "";

            lista_prisustva = new List<string>();
        }
    }
}
