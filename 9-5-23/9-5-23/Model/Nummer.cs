using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _9_5_23.Model
{
    public class Nummer
    {

        public int Id { get; set; }
        public string Naam { get; set; }
        public double Duur { get; set; }

        // en een album
        public Album Album { get; set; }

        public Artiest? Artiest { get; set; }

        //public List<Artiest>? Artiesten { get; set; }

    }
}
