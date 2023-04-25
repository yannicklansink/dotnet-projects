USE master;
GO

DROP DATABASE IF EXISTS WK2026;
GO

CREATE DATABASE WK2026;
GO

USE WK2026;
GO

-- ----------------------------------------------------------------------------
-- CREATE SCHEMAS
-- ----------------------------------------------------------------------------
CREATE SCHEMA Other; -- Teams, Poules
GO

CREATE SCHEMA GameInfo; -- Stadions, Wedstrijden
GO


-- Scalar | User Defined Functions (UDF)

--- DDL Statements
DROP TABLE IF EXISTS Teams;
GO

CREATE TABLE Other.Teams
(
	id				tinyint IDENTITY 
					CONSTRAINT PK_teams_ID
					PRIMARY KEY
	, land			varchar(50)  NOT NULL
	, wkpunten		tinyint NOT NULL
					DEFAULT 0
	, fifaranking	tinyint NOT NULL
);
GO

DROP TABLE IF EXISTS Poules;
GO

CREATE TABLE Other.Poules
(
	Id				tinyint IDENTITY 
					CONSTRAINT PK_pouls_ID
					PRIMARY KEY
	, PouleNaam		char NOT NULL
	, TeamID		tinyint
					CONSTRAINT FK_teamsid_ID
					FOREIGN KEY REFERENCES Other.Teams(id)
					ON DELETE SET NULL
					ON UPDATE NO ACTION
);
GO

DROP TABLE IF EXISTS Stadions;
GO

CREATE TABLE GameInfo.Stadions
(
	Id				tinyint IDENTITY 
					CONSTRAINT PK_stadions_ID
					PRIMARY KEY
	, StadionNaam	nvarchar(75) NOT NULL
	, Capaciteit	int NOT NULL
	, Plaats		nvarchar(50) NOT NULL
	, Land			nvarchar(50) NOT NULL
	, Huisnummer	tinyint
	, Postcode		varchar(10) NOT NULL
	, Eigenaar		nvarchar(50) NOT NULL
	, Bouwjaar		smallint NOT NULL
);
GO

DROP TABLE IF EXISTS Wedstrijden;
GO

CREATE TABLE GameInfo.Wedstrijden
(
	Id				tinyint IDENTITY 
					CONSTRAINT PK_wedstrijden_ID
					PRIMARY KEY
	, ThuisTeamID	tinyint
					CONSTRAINT FK_thuisteam_ID
					FOREIGN KEY REFERENCES Other.Teams(id)
					ON DELETE NO ACTION
					ON UPDATE NO ACTION
	, UitTeamID		tinyint
					CONSTRAINT FK_uitteam_ID
					FOREIGN KEY REFERENCES Other.Teams(id)
					ON DELETE NO ACTION
					ON UPDATE NO ACTION
	, ThuisGoals	tinyint
					DEFAULT 0
	, UitGoals		tinyint
					DEFAULT 0
	, Speeldatum	datetime2(0) NOT NULL
	, StadionID		tinyint 
					CONSTRAINT FK_wedstrijdstadion_ID
					FOREIGN KEY REFERENCES GameInfo.Stadions(id)
					ON DELETE NO ACTION
					ON UPDATE NO ACTION
);
GO


-- FILL TEAMS
INSERT INTO Other.Teams
(land, fifaranking)
VALUES
('Nederland', 6)
,('Argentinie', 1)
,('Marokko', 11)
,('Japan', 20)
,('Brazilie', 3)
,('België', 4)
,('Engeland', 5)
,('Kroatie', 7)
,('Italië', 8)
,('Portugal', 9)
,('Spanje', 10)
,('Zwitserland', 12)
,('USA', 13)
,('Duitsland', 14)
,('Mexico', 15)
,('Uruguay', 16);
GO

SELECT * FROM Other.Teams;

-- FILL POULES

DECLARE @teamID AS int = 1;
DECLARE @pouleNum AS int = 65;

WHILE @teamID <= 16
BEGIN
	INSERT INTO Other.Poules
	(PouleNaam, TeamID)
	VALUES
	(char(@pouleNum), @teamID);

	IF @teamID % 4 = 0
	BEGIN
		SET @pouleNum += 1;
	END

	SET @teamID += 1;
END
GO

SELECT
	PouleNaam
	, COUNT(*) AS AantalTeamsPerPoule
FROM Other.Poules
GROUP BY PouleNaam;

-- FILL STADIONS
INSERT INTO GameInfo.Stadions
(StadionNaam, Capaciteit, Plaats, Land, Huisnummer, Postcode, Eigenaar, Bouwjaar)
VALUES
('Camp Nou', 99354, 'Barcelona', 'Spanje', 12, '08028', 'FC Barcelona', 1954)
, ('Wembley Stadium', 90000, 'London', 'UK', NULL, 'HA9 0FA', 'Wembley National Stadium LTD', 2003)
, ('Signul Iduna Park', 81359, 'Dortmund', 'Duitsland', 50, '44139', 'Borussia Dortmund GMBH & Co', 1971)
, ('Estadio Santiago Bernabeu', 81044, 'Madrid', 'Spanje', 1, '28036', 'Real Madrid CF', 1947)
, ('Arena', 81044, 'Amsterdam', 'Nederland', 1, '3535', 'FC Ajax', 1988);
GO

select * from GameInfo.Stadions

-- FILL WEDSTRIJDEN

DECLARE @ThuisTeam AS tinyint = 1;
DECLARE @UitTeam AS tinyint = 2;
DECLARE @Speeldag AS int = 1;
DECLARE @Stadion AS int = 1;
DECLARE @AantalStadions AS int;

SELECT
	 @AantalStadions = COUNT(*)
FROM GameInfo.Stadions;

WHILE @UitTeam <= 16
BEGIN
	INSERT INTO GameInfo.Wedstrijden
	(ThuisTeamID, UitTeamID, Speeldatum, StadionID)
	VALUES
	(@ThuisTeam, @UitTeam, DATEADD(day, @Speeldag, SYSDATETIME()), @Stadion);

	SET @Stadion += 1;

		IF @Stadion % (@AantalStadions+1) = 0
	BEGIN
		SET @Stadion = 1;
	END
	 
	SET @ThuisTeam += 2;
	SET @UitTeam += 2;
	SET @Speeldag += 1;

END
GO

select * from GameInfo.Wedstrijden;

select * from Other.Teams;

SELECT * FROM GameInfo.Stadions

-- --------------------------------------------------------
-- Query: Laat de wedstrijden zien die worden gespeeld in [Camp Nou]
-- --------------------------------------------------------

SELECT
	w.Id
	, CONCAT_WS(' - ', t1.land, t2.land)			as landen
	, CONCAT_WS(' - ', w.ThuisGoals, w.UitGoals)	as score
	, w.Speeldatum
	, s.StadionNaam
	, s.Land
	, s.Capaciteit
FROM GameInfo.Wedstrijden as w
INNER JOIN Other.Teams as t1
ON t1.id = w.ThuisTeamID
INNER JOIN Other.Teams as t2
ON t2.id = w.UitTeamID
INNER JOIN GameInfo.Stadions as s
ON w.StadionID = s.Id
WHERE s.StadionNaam = 'Camp Nou'

-- --------------------------------------------------------
-- Query: Vraag de stand op van een poule
-- --------------------------------------------------------
UPDATE Other.Teams
SET wkpunten = 3
WHERE land = 'Nederland'

UPDATE Other.Teams
SET wkpunten = 1
WHERE land = 'Marokko' OR land = 'Japan'

SELECT 
	t.id
	, t.land
	, t.wkpunten
	, p.PouleNaam
FROM Other.Teams as t
INNER JOIN Other.Poules as p
ON p.TeamID = t.Id
WHERE p.PouleNaam = 'A'
ORDER BY t.wkpunten DESC

-- --------------------------------------------------------
-- Non-Clustured Index voor land in tabel Other.Teams
-- --------------------------------------------------------
DROP INDEX IF EXISTS NCI_TeamsLand
ON Other.Teams;
GO

SELECT t.land FROM Other.Teams as t WHERE t.land = 'Spanje' -- Clustured Index Scan

CREATE NONCLUSTERED INDEX NCI_TeamsLand
ON Other.Teams(Land);
GO

SELECT t.land FROM Other.Teams as t WHERE t.land = 'Spanje'; -- Index Seek

-- --------------------------------------------------------
-- Non-Clustured Index wiht include
-- --------------------------------------------------------

DROP INDEX IF EXISTS NCI_StadionsNaamEnLand
ON GameInfo.Stadions;
GO

SELECT 
	s.Land
	, s.StadionNaam
FROM GameInfo.Stadions as s 
WHERE s.Land = 'Spanje' -- Clustured Index Scan

CREATE NONCLUSTERED INDEX NCI_StadionsNaamEnLand
ON GameInfo.Stadions(Land)
INCLUDE (StadionNaam);
GO

SELECT 
	s.Land
	, s.StadionNaam
FROM GameInfo.Stadions as s 
WHERE s.Land = 'Spanje' -- Index Seek









/*

- Bouw 2 of 3 SCHEMAs en gebruik die in het database aanmaakscript
		Voorbeeld:
		    CREATE SCHEMA Persons;
		    GO
		Mogelijke schema's

- Schrijf enkele interessante queries (JOINs, WHERE-clauses ...)

- Bouw enkele extra indexes om de uitvoer van 
	bepaalde queries te versnellen.

*/

