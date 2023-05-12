using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Model
{
    public class Burger
    {

        /*
         * CREATE TABLE Burgers (
	                id									INT IDENTITY 
										                CONSTRAINT PK_burgers_ID
										                PRIMARY KEY
	                , BSN								INT NOT NULL
	                , voornaam							VARCHAR(65) NOT NULL
	                , achternaam						VARCHAR(50) NOT NULL
	                , tussenvoegsel						VARCHAR(20)
	                , oorspronkelijke_naam				NVARCHAR(65) NOT NULL
	                , straat							VARCHAR(50) NOT NULL
	                , huisnummer						INT NOT NULL
	                , achtervoegsel_huisnummer			VARCHAR(5)
	                , postcode							CHAR(5) NOT NULL -- fixed length
	                , plaats							VARCHAR(58) NOT NULL -- Llanfairpwllgwyngyllgogerychwyrndrobwllllantysiliogogogoch
	                , geboorteplaats					VARCHAR(58) NOT NULL 
	                , geboorteland						VARCHAR(3) NOT NULL -- landcode
            );
            GO
        */
        public int Id { get; set; }

    
        public int Bsn { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Tussenvoegsel { get; set; }

        public string OorspronkelijkeNaam { get; set; }

        public string Straat { get; set; }

        public int Huisnummer { get; set; }

        public string AchtervoegselHuisnummer { get; set; }

        public string Postcode { get; set; }

        public string Plaats { get; set; }

        public string Geboorteplaats { get; set; }

        public string Geboorteland { get; set; }

        public List<Reisdocument> Reisdocumenten { get; set; }
    }
}
