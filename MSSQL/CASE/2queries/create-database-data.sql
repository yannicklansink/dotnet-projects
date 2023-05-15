USE master;
GO

DROP DATABASE IF EXISTS ReisdocumentenDB;
GO

CREATE DATABASE ReisdocumentenDB;
GO

USE ReisdocumentenDB;
GO

-- ----------------------------------------------------------------------------
-- CREATE SCHEMAS
-- ----------------------------------------------------------------------------
--CREATE SCHEMA Hamelen; 
--GO

-- ----------------------------------------------------------------------------
-- DDL Statements
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS Burgers;
GO

CREATE TABLE Burgers (
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

DROP TABLE IF EXISTS Soorten;
GO

CREATE TABLE Soorten (
	id			INT IDENTITY(1,1) 
				CONSTRAINT PK_soorten_ID 
				PRIMARY KEY
	, soort		VARCHAR(20) NOT NULL
	, prijs		DECIMAL(6, 2) NOT NULL
);
GO

DROP TABLE IF EXISTS Medewerkers;
GO

CREATE TABLE Medewerkers (
	Id							INT IDENTITY
								CONSTRAINT PK_medewerkers_ID
								PRIMARY KEY
	, Naam						VARCHAR(65) NOT NULL
	, Straat					VARCHAR(65) 
	, Huisnummer				INT 
	, Postcode					CHAR(5) --https://www.spotzi.com/nl/data-catalog/categorieen/postcodes/duitsland/#:~:text=Uit%20hoeveel%20tekens%20bestaat%20een,postcode%20bestaat%20uit%205%20cijfers.
	, Woonplaats				VARCHAR(58) NOT NULL
	, Afdeling					VARCHAR(30) --Reisdocumenten, Reisdocumenten, Informatievoorziening
	, ManagerId					INT	
    , FOREIGN KEY (ManagerId)	REFERENCES Medewerkers (Id) 
);
GO

DROP TABLE IF EXISTS Reisdocumenten;
GO

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
    , [status]					VARCHAR(20) NOT NULL --actief, verlopen, verloren, gestolen, ingeleverd
    , opgehaald					BIT NOT NULL
								DEFAULT 0
    , burger_id					INT 
								CONSTRAINT FK_Reisdocumenten_Burgers 
								FOREIGN KEY REFERENCES Burgers(id)
	, medewerker_id				INT NOT NULL
								CONSTRAINT FK_Medewerkers_Medewerker
								FOREIGN KEY REFERENCES Medewerkers(Id)
);
GO

-- ----------------------------------------------------------------------------
-- Add dummy data
-- ----------------------------------------------------------------------------


INSERT 
	INTO Soorten (soort, prijs) 
VALUES 
	('paspoort', 100.00), ('id-kaart', 55.25), ('visum', 400.50), ('paspoort', 120.00), ('visum', 450.50);


-- Source: CHATGPT
INSERT INTO Burgers 
	(BSN, voornaam, achternaam, tussenvoegsel, oorspronkelijke_naam, straat, huisnummer, achtervoegsel_huisnummer, postcode, plaats, geboorteplaats, geboorteland)
VALUES 
	(123456789, 'John', 'Doe', NULL, 'Doe', 'Main Street', 1, 'A', '12345', 'Hamelen', 'Hamelen', 'USA'),
	(234567890, 'Jane', 'Doe', NULL, 'Doe', 'Oak Avenue', 25, NULL, '67890', 'Los Angeles', 'California', 'USA'),
	(345678901, 'Robert', 'Smith', NULL, 'Smith', 'High Street', 10, NULL, '23456', 'London', 'London', 'GBR'),
	(456789012, 'Emma', 'Jones', NULL, 'Jones', 'Park Lane', 5, NULL, '34567', 'Hamelen', 'Manchester', 'GBR'),
	(567890123, 'Hans', 'Müller', NULL, 'Müller', 'Hauptstraße', 20, 'B', '12345', 'Berlin', 'Berlin', 'DEU'),
	(678901234, 'Maria', 'García', NULL, 'García', 'Calle Mayor', 15, NULL, '28001', 'Madrid', 'Madrid', 'ESP');

INSERT INTO Medewerkers 
	(Naam, Straat, Huisnummer, Postcode, Woonplaats, Afdeling, ManagerId)
VALUES 
	('Mieke', 'Oak Avenue', 25, '67890', 'Los Angeles', 'Reisdocumenten', NULL),
	('Arend', 'Main Street', 1, '12345', 'New York', 'Informatievoorziening', 1),
	('Els', 'High Street', 10, '23456', 'London', 'Informatievoorziening', 2),
	('Mo', 'Park Lane', 5, '34567', 'Hamelen', 'Reisdocumenten', 2),
	('Boris', 'Hauptstraße', 20, '12345', 'Berlin', 'Informatievoorziening', 2),
	('Angela', 'Calle Mayor', 15, '28001', 'Madrid', 'Reisdocumenten', 2);


INSERT INTO Reisdocumenten 
	(documentnr, soort_id, aanvraagdatum, afgifteplaats, afgiftedatum, verloopdatum, [status], opgehaald, burger_id, medewerker_id)
VALUES
    (123456, 1, '2024-03-20 12:30:00', 'Hamelen', '2024-04-25', '2023-07-25', 'Actief', 1, 1, 4),
    (234567, 5, '2023-04-22 09:45:00', 'Den Haag', '2023-04-27', '2024-04-27', 'verlopen', 0, 2, 2),
    (345678, 2, '2023-04-24 11:15:00', 'Rotterdam', '2023-04-29', '2024-04-29', 'Actief', 1, 3, 3),
    (456789, 5, '2024-04-26 15:00:00', 'Utrecht', '2024-05-01', '2023-05-01', 'Actief', 0, 4, 4),
    (567890, 3, '2023-04-28 13:30:00', 'Amsterdam', '2023-05-03', '2023-06-03', 'Actief', 1, 5, 5),
    (678901, 4, '2024-04-30 10:00:00', 'Den Haag', '2024-05-05', '2024-05-05', 'ingeleverd', 0, NULL, 6);

-- ----------------------------------------------------------------------------
-- Opdracht 2: Queries, data analyseren 
-- ----------------------------------------------------------------------------

USE ReisdocumentenDB;
GO

-- ----------------------------------------------------------------------------
-- (BLAUWE PISTE)
-- ----------------------------------------------------------------------------

-- 1. Een lijst van alle burgers en hun reisdocument(en) 
--	  inclusief burgers zonder reisdocumenten.
SELECT 
	*
FROM Burgers AS b
LEFT JOIN Reisdocumenten AS r
ON b.Id = r.burger_id

-- 2. Een lijst van de medewerkers die nog nooit een 
--    reisdocument aanvraag hebben behandeld.
SELECT 
	*
FROM Medewerkers AS m
WHERE m.Id NOT IN 
(
	SELECT  r.medewerker_id
	FROM    Reisdocumenten as r
)

SELECT 
	*
FROM Medewerkers AS m
WHERE NOT EXISTS 
(
	SELECT  1
	FROM    Reisdocumenten as r
	WHERE	r.medewerker_id = m.Id
)

-- 3. Het aantal aanvragen uit specifiek de vorige maand gegroepeerd per type (Soort).
DECLARE @startOfCurrentMonth DATETIME
SET @startOfCurrentMonth = DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0)

SELECT
	r.soort_id
	, COUNT(*) AS aantal
FROM Reisdocumenten AS r
WHERE r.Aanvraagdatum >= DATEADD(month, -1, CURRENT_TIMESTAMP) 
	  AND r.Aanvraagdatum < @startOfCurrentMonth
GROUP BY 
	r.soort_id


-- 4. Een lijst van alle burgers en medewerkers die in Hamelen wonen.
DECLARE @woonplaats VARCHAR(60)
SET @woonplaats = 'Hamelen'

SELECT		
	*
FROM Burgers AS b
INNER JOIN Reisdocumenten AS r
ON b.Id = r.burger_id
INNER JOIN Medewerkers AS m
ON m.Id = r.medewerker_id
WHERE
	b.plaats = @woonplaats 
	AND m.Woonplaats = @woonplaats;

-- ----------------------------------------------------------------------------
-- (RODE PISTE)
-- ----------------------------------------------------------------------------

-- 1. Totaalbedrag van alle reisdocumenten per maand
SELECT
	r.soort_id
	, s.soort
	, sum(s.prijs)		AS totaal_prijs
FROM Reisdocumenten	AS r
INNER JOIN Soorten AS s
ON r.soort_id = s.id
GROUP BY 
	r.soort_id
	, s.soort

-- 2. Alle documenten die in de komende twee maanden verlopen zijn
DECLARE @startOfNextMonth DATETIME
SET @startOfNextMonth = DATEADD(month, DATEDIFF(month,0,GETDATE())+1,0) 

SELECT
	*
FROM Reisdocumenten
WHERE verloopdatum BETWEEN @startOfNextMonth AND DATEADD(month, 2, @startOfNextMonth) 

-- 3. Per document het type, de status en het aantal
SELECT
	soort
	, r.status
	, COUNT(*)	AS aantal
FROM Reisdocumenten AS r
INNER JOIN Soorten AS s
ON r.soort_id = s.id
GROUP BY 
	soort
	, r.status

-- 4. Gegevens van elke werknemer met daarbij de gegevens van diens leidinggevende
SELECT 
	*
FROM Medewerkers as med
LEFT JOIN Medewerkers as man 
ON med.ManagerId = man.Id

-- ----------------------------------------------------------------------------
-- (ZWARTE PISTE)
-- ----------------------------------------------------------------------------

-- 1. Per jaar per documenttype het totaalbedrag dat werkelijk betaald is 
--    (de prijs van toen) en het totaalbedrag op basis van de huidige prijs (een fictief totaal)
-- Niet helemaal goed. Hier pak ik de hoogste prijs, maar moet de laatste prijs verandering zijn.
SELECT 
	s.soort
	, YEAR(r.afgiftedatum)		AS afgiftedatum_per_jaar
	, SUM(s.prijs)				AS totaal_bedrag
	, MAX(s.prijs) * COUNT(*)	AS fictief_totaal_max_prijs
FROM Reisdocumenten AS r
INNER JOIN Soorten AS s 
	ON s.id = r.soort_id
GROUP BY 
	YEAR(r.afgiftedatum)
	, s.soort


-- 2. Per maand de procentuele toe- of afname van opgehaalde reisdocumenten.
-- WITH Statement
GO
WITH cte_previous_month
AS
(
	SELECT	
		MONTH(afgiftedatum)					as aantal_per_maand
		, SUM(IIF(opgehaald = 1, 1, 0))		as sum_opgehaald
	FROM Reisdocumenten AS r
	WHERE MONTH(afgiftedatum) >= 4 AND MONTH(afgiftedatum) < 5
	GROUP BY 
		MONTH(afgiftedatum)
)
SELECT 
*
	--100.0*(sum_opgehaald - prev.Val)/ prev.Val As PercentDiff
FROM cte_previous_month

-- 3. Challenge: Per week de eerste 3 opgehaalde reisdocumenten