using cases.reisdocumenten.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Model.Repo
{
    public interface IBurgerRepository
    {

        Burger GetBurgerById(long id);

        Burger GetBurgerByNaam(string voornaam, string? tussenvoegsel, string achternaam);

        IEnumerable<BurgerGegevens> GetBurgerGegevens(Burger burger);

        //void UpdateBurgerReisdocumentStatus(string documentNr);
    }
}
