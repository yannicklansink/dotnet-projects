-- day 29 | dinsdag 25-4-23 | SQLDev Essentials

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

-- ------------------------------------------------------

-- oefening Functions
DROP FUNCTION IF EXISTS dbo.ProtocolUtiURL;
GO

CREATE OR ALTER FUNCTION dbo.ProtocolUtiURL
(
	@URL AS nvarchar(1000)
)
RETURNS nvarchar(100)
AS
BEGIN
	DECLARE @Protocol AS nvarchar(10)
    
    IF (LEFT(@URL, 7) = 'http://')
        SET @Protocol = 'http'
    ELSE IF (LEFT(@URL, 8) = 'https://')
        SET @Protocol = 'https'
    ELSE IF (LEFT(@URL, 6) = 'ftp://')
        SET @Protocol = 'ftp'
    ELSE
        SET @Protocol = ''
    
    RETURN @Protocol
END;
GO

SELECT dbo.ProtocolUtiURL('http://www.google.com');

-- ------------------------------------------------------

-- create non-clustured index
CREATE NONCLUSTERED INDEX NCI_City
ON MyClusturedIndex(City); 

SELECT * FROM MyClusturedIndex WHERE city = 'Urk'; -- Index Seek

-- ------------------------------------------------------

-- Covering Index
-- NCI with an INCLUDE
-- Je neem hier aan dat de field in de include vaak op wordt gezocht
/*
CREATE NONCLUSTURED INDEX NCI_OrdersCityPhone
ON Sales.ORders(City)
INCLUDE (Phone);

-- Deze select gaat heel snel en loopt alleen via de non-clustured index
SELECT
	City
	, Phone
FROM Sales.Orders
WHERE city = 'Ede';
*/

-- Kijk met 'Estimated Subtree Cost' hoe snel de query is.

-- --------------------------------------------------------
-- Herhaling indexes
/*
	Tabel wordt Clustured index indien PRIMARY KEY gedefineerd:
		Clustured index = tabel + binary tree (de hele tabel)

	Tabel wordt nonclustured index indien CREATE wordt gebruikt op velden
		Non-Clustured index = binary tree

	Voordeel index = snelle select 
	Nadeel index = slome update, insert, delete

	Hoeveel Clustured indexen per tabel: 1
	Hoeveel Non-Clustured indexen per tabel: 999 (liever max. 5)

	INCLUDE index: Bevat op leaflevel velden die in SELECT-clause altijd gebruiken
*/

-- ---------------------------------------------------------------
-- Updatable views
USE Huisdieren;
GO

CREATE OR ALTER VIEW dbo.BelastingAfdelingen
AS
(
	SELECT
		id
		, naam
	FROM dbo.Afdelingen
);
GO

SELECT * FROM dbo.BelastingAfdelingen

-- insert into view. 
-- alleen mogelijk bij 1 tabel.
INSERT INTO dbo.BelastingAfdelingen
(naam)
VALUES
('Docker');

SELECT * FROM dbo.BelastingAfdelingen

-- ------------------------------------------------------------

-- Transacties
-- Alles of niets. 
-- Vaak bij 2 queries. Denk aan Orders en Payment. 
-- Je wilt dat bij een insert dat allebij de queries worden uitgevoerd en anders geen van beide
-- Isolation levels

CREATE PROCEDURE Sales.InsertPayments
	@amount AS decimal(9,2)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO Orders... @amount
			INSERT INTO Payments... @amount
		COMMIT TRANSACTION
	END TRY
		BEGIN CATCH
		SELECT ERROR_NUMBER();
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END


