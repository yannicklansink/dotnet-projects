using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_5_23.Model
{
    // [Table("Voorraad")]
    public class Voorraad
    {
        public long Id { get; set; }
        // [MaxLength(100)]
        public string Artikel { get; set; }
        public int Aantal { get; set; }
    }
}
