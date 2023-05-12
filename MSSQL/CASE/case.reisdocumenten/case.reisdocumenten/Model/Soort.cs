using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Model
{
    public class Soort
    {

        /*
         CREATE TABLE Soorten (
	        id			INT IDENTITY(1,1) 
				        CONSTRAINT PK_soorten_ID 
				        PRIMARY KEY
	        , soort		VARCHAR(20) NOT NULL
	        , prijs		DECIMAL(6, 2) NOT NULL
        );
        GO
        INSERT INTO Soorten (soort, prijs) VALUES ('paspoort', 100.00), ('id-kaart', 55.25), ('visum', 400.50);
 
        */

        public int Id { get; set; }

        public string Naam { get; set; }

        public decimal Prijs { get; set; }

        public List<Reisdocument> Reisdocumenten { get; set; }


    }
}
