using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Model
{
    public class Reisdocument
    {

        /*
         CREATE TABLE Reisdocumenten (
	            id							INT IDENTITY
								            CONSTRAINT PK_reisdocumenten_ID
								            PRIMARY KEY
                , documentnr				INT
                , soort_id					INT NOT NULL,
								            CONSTRAINT FK_reisdocumenten_soorten 
								            FOREIGN KEY (soort_id) 
								            REFERENCES Soorten(id)
                , aanvraagdatum				DATETIME NOT NULL
                , afgifteplaats				VARCHAR(50) 
								            DEFAULT 'Hamelen' NOT NULL
                , afgiftedatum				DATE
                , verloopdatum				DATE
                , [status]					VARCHAR(20) NOT NULL
                , opgehaald					BIT NOT NULL
								            DEFAULT 0
                , burger_id					INT NOT NULL
								            CONSTRAINT FK_Reisdocumenten_Burgers 
								            FOREIGN KEY REFERENCES Burgers(id)
        );
        GO
        */

      
        public int Id { get; set; }

        public int DocumentNr { get; set; }

        public virtual Soort Soort { get; set; }

        public DateTime Aanvraagdatum { get; set; }

        public string Afgifteplaats { get; set; }

        public DateTime? Afgiftedatum { get; set; }

        public DateTime? Verloopdatum { get; set; }

        public string Status { get; set; }

        public bool Opgehaald { get; set; }

        public virtual Burger Burger { get; set; }

    }
}
