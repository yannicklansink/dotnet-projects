using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_5_23.Model
{
    public class Album
    {

        public int Id { get; set; }

        public string Naam { get; set; }

        // lijst van nummers
        public List<Nummer> Nummers { get; set; }


    }
}
