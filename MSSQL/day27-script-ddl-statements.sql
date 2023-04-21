-- SET NOCOUNT ON; -- globale script instellingen. Nu krijg je geen messages meer. 

USE master;
GO

DROP DATABASE IF EXISTS Huisdieren;
GO

CREATE DATABASE Huisdieren;
GO

USE Huisdieren;
GO

-- DDL Statements

-- begint met het script om het te wissen. idempotent
DROP TABLE IF EXISTS Huisdieren;
GO

CREATE TABLE Huisdieren
(
	id int IDENTITY(1, 1) 
		CONSTRAINT PK_Huisdier_ID 
		PRIMARY KEY
	, naam nvarchar(50) NOT NULL
);
GO

INSERT INTO Huisdieren
(naam)
VALUES
('Bello')
, ('Kazan')
, ('Ibbeltje')	
, ('Mies');
GO

-- --------------------------------------------------
DROP TABLE IF EXISTS Medewerkers
GO
DROP TABLE IF EXISTS Afdelingen 
GO

CREATE TABLE Afdelingen
(
	id int IDENTITY(1, 1) 
		CONSTRAINT PK_Afdelingen_ID 
		PRIMARY KEY
	, naam nvarchar(50) NOT NULL
);
GO

-- NO ACTION = standaard = foutmelding
-- CASCADE = doe hetzelfde in de andere tabel
-- NULL = plaats in de andere tabel waardes op null
-- DEFAULT = plaats in de andere tabel de zgn. DEFAULT value

CREATE TABLE Medewerkers
(
	id  int IDENTITY(1, 1) 
		CONSTRAINT PK_Medewerkers_ID 
		PRIMARY KEY
	, naam nvarchar(50) NOT NULL
	, afd_id int 
			 CONSTRAINT FK_medewafdid_afdelingenid
			 FOREIGN KEY REFERENCES Afdelingen(id)
				 ON DELETE SET NULL 
				 ON UPDATE CASCADE	 
);
GO

INSERT INTO Afdelingen
(naam)
VALUES
('HR')
, ('Aangiftes')
, ('IV')

INSERT INTO Medewerkers
(naam, afd_id)
VALUES
('Ad', 1)
, ('Bo', 2)
, ('Cas', 2)
, ('Anna', 3)

DROP TABLE IF EXISTS Logs;
GO

CREATE TABLE Logs
(
	id			int				IDENTITY
								PRIMARY KEY
	, logdatum	datetime2(0)	NOT NULL
								DEFAULT SYSDATETIME()
	, message	nvarchar(2000)	NOT NULL
)
GO

INSERT INTO Logs
(logdatum, message)
VALUES
('This is a message for the log')
, ('This is a message for the log');

select * from Logs




