-- day 29 | dinsdag 25-4-23

/*
De stof van vandaag:
	check constrains
	functions
	reorganize, rebuild
	statistics
	updatable views
	transactions
	isolation levels
	triggers
*/

-- CHECK constrains
USE tempdb;
GO

DROP TABLE IF EXISTS Leveranciers;

CREATE TABLE Leveranciers
(
	Id				int				NOT NULL
	, achternaam	nvarchar(50)	NULL
	, status		smallint	
					CONSTRAINT CHK_Status_Tussen_1_en_100
					CHECK(status BETWEEN 1 AND 100) -- CHECK CONSTRAINT
	, plaats		nvarchar(50)
					CONSTRAINT CHK_Geldige_Plaats
					CHECK(plaats IN ('Veenendaal', 'Amsterdam', 'Rotterdam'))
);

INSERT INTO Leveranciers
(Id, achternaam, status, plaats)
VALUES
(1001, 'Jansen', 200, 'AAmsterdam');
-- The INSERT statement conflicted with the CHECK constraint "CHK_Status_Tussen_1_en_100" 

-- TRUNCATE = delete alle rijen en reset een evt. IDENTITY
-- Super snel, maar gevaarlijk want er komt geen LOG file voor DBA'er
TRUNCATE TABLE Leveranciers

-- Is het mogelijk om een database diagram, zoals adventureworks 
-- te reverse engineeren zodat er naar de sql statements kan worden gekeken?
---


--dd








