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
	, BSN									INT NOT NULL
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
);
GO
INSERT INTO Soorten (soort) VALUES ('paspoort'), ('id-kaart'), ('visum');

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
    , [status]					VARCHAR(20) NOT NULL
    , opgehaald					BIT NOT NULL
								DEFAULT 0
    , burger_id					INT NOT NULL
								CONSTRAINT FK_Reisdocumenten_Burgers 
								FOREIGN KEY REFERENCES Burgers(id)
);
GO




