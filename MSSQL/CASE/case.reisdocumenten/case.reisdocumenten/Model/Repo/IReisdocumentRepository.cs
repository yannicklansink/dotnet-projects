using cases.reisdocumenten.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Model.Repo
{
    public interface IReisdocumentRepository
    {
        IEnumerable<Reisdocument> GetAllReisdocumenten();

        IEnumerable<LopendeAanvragen> GetLijstMetLopendeAanvragen();

        Reisdocument GetReisdocumentByDocumentNr(string documentNr);

        //IEnumerable<Reisdocument> AanvraagAfhandelen();

    }
}
