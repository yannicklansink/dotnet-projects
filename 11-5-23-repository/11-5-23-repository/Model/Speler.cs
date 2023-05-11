using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_5_23_repository.Model
{
    public class Speler
    {
        public long Id { get; set; }

        public string Naam { get; set; }

        public decimal Saldo { get; set; }

        // Navigation prop. 
        public virtual Tafel Tafel { get; set; }
    }
}
