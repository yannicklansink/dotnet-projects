USE master;
GO

DROP DATABASE IF EXISTS WK2026;
GO

CREATE DATABASE WK2026;
GO

USE WK2026;
GO

-- Scalar | User Defined Functions (UDF)

--- DDL Statements
DROP TABLE IF EXISTS Teams;
GO

CREATE TABLE Teams
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

CREATE TABLE Poules
(
	Id				tinyint IDENTITY 
					CONSTRAINT PK_pouls_ID
					PRIMARY KEY
	, PouleNaam		char NOT NULL
	, TeamID		tinyint
					CONSTRAINT FK_teamsid_ID
					FOREIGN KEY REFERENCES Teams(id)
					ON DELETE SET NULL
					ON UPDATE NO ACTION
);
GO

DROP TABLE IF EXISTS Stadions;
GO

CREATE TABLE Stadions
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

CREATE TABLE Wedstrijden
(
	Id				tinyint IDENTITY 
					CONSTRAINT PK_wedstrijden_ID
					PRIMARY KEY
	, ThuisTeamID	tinyint
					CONSTRAINT FK_thuisteam_ID
					FOREIGN KEY REFERENCES Teams(id)
					ON DELETE NO ACTION
					ON UPDATE NO ACTION
	, UitTeamID		tinyint
					CONSTRAINT FK_uitteam_ID
					FOREIGN KEY REFERENCES Teams(id)
					ON DELETE NO ACTION
					ON UPDATE NO ACTION
	, ThuisGoals	tinyint
					DEFAULT 0
	, UitGoals		tinyint
					DEFAULT 0
	, Speeldatum	datetime2(0) NOT NULL
	, StadionID		tinyint 
					CONSTRAINT FK_wedstrijdstadion_ID
					FOREIGN KEY REFERENCES Stadions(id)
					ON DELETE NO ACTION
					ON UPDATE NO ACTION
);
GO


-- FILL TEAMS
INSERT INTO Teams
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

SELECT * FROM Teams;

-- FILL POULES

DECLARE @teamID AS int = 1;
DECLARE @pouleNum AS int = 65;

WHILE @teamID <= 16
BEGIN
	INSERT INTO Poules
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
FROM Poules
GROUP BY PouleNaam;

-- FILL STADIONS
INSERT INTO Stadions
(StadionNaam, Capaciteit, Plaats, Land, Huisnummer, Postcode, Eigenaar, Bouwjaar)
VALUES
('Camp Nou', 99354, 'Barcelona', 'Spanje', 12, '08028', 'FC Barcelona', 1954)
, ('Wembley Stadium', 90000, 'London', 'UK', NULL, 'HA9 0FA', 'Wembley National Stadium LTD', 2003)
, ('Signul Iduna Park', 81359, 'Dortmund', 'Duitsland', 50, '44139', 'Borussia Dortmund GMBH & Co', 1971)
, ('Estadio Santiago Bernabeu', 81044, 'Madrid', 'Spanje', 1, '28036', 'Real Madrid CF', 1947)
, ('Arena', 81044, 'Amsterdam', 'Nederland', 1, '3535', 'FC Ajax', 1988);
GO

select * from Stadions

-- FILL WEDSTRIJDEN

DECLARE @ThuisTeam AS tinyint = 1;
DECLARE @UitTeam AS tinyint = 2;
DECLARE @Speeldag AS int = 1;
DECLARE @Stadion AS int = 1;
DECLARE @AantalStadions AS int;

SELECT
	 @AantalStadions = COUNT(*)
FROM Stadions;

WHILE @UitTeam <= 16
BEGIN
	INSERT INTO Wedstrijden
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

select * from Wedstrijden;

select * from Teams;

SELECT * FROM Stadions

/*
Reserveer op woensdag of vrijdag een tijdslot van 
ca. 2 á 3 uur met je team (telefoon/Teams)

Spreek ideeën door om het database aanmaakscript 
verder in te vullen en verdeel het werk:

- Bouw 2 of 3 SCHEMAs en gebruik die in het database aanmaakscript
		    CREATE SCHEMA Persons;
		    GO

- Schrijf enkele interessante queries (JOINs, WHERE-clauses ...)
			CREATE NONCLUSTURED INDEX NCI_OrdersCityPhone
			ON Sales.ORders(City)
			INCLUDE (Phone);

- Bouw enkele extra indexes om de uitvoer van 
	bepaalde queries te versnellen.

*/

