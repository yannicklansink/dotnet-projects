using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_5_23.Model
{
    public interface INummerRepository
    {
        public IEnumerable<Nummer> GetAllNummers();
        public void VoegNummerToe(Nummer nummer);
        public void WijzigNummerLengte(Nummer nummer);
    }
}
