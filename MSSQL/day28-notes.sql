-- day 28 | Maandag 24-4-23


Computed colums:
	Velden worden berekend op het moment dat je ze opvraagt.
	PERSISTED -> Dan worden ze ook opgeslagen en op het moment dat data wijzigt opnieuw berekend.
	


-- CHECK(Punten <= 100)
-- UNIQUE(Naam, Plaats, PouleID) -> Mag maar 1 keer voorkomen.


-- DECLARE variable as A and increment it to B, C, D...
DECLARE @poulenaam as int = 65
select char(@poulenaam) 
SET @poulenaam += 1;
select char(@poulenaam)

-- uniqueidentifier (IDENTITY kan weg)
/*
	INSERT INTO tickets
	(TicketNr, Plaats)
	VALUES
	(NEWID(), 'Urk')
*/
SELECT NEWID(); -- get an uniqueidentifier

-- PERSISTED: snelle SELECT, trage UPDATE
-- geen PERSISTED: snelle UPDATE, trage SELECT

CREATE TABLE Engineers
(
	voornaam				nvarchar(50)
	, bruto_salaris				decimal(8,2)
	, indienst				date not null
	, overwinst				decimal(8,2)	
	, netto_salaris			AS bruto_salaris + overwinst PERSISTED -- COMPUTED VALUE.
)

-- Indexes
-- binary tree 

-- Indexing concepts:
/*
	Heap or Clustured index

	Heap: 
		first-in, first-out
		Traag met zoeken. Table scan
		Gebruiken dit niet!
	Clustured index: 
		Gesorteerd opgeslagen als binary tree.
		Snel met zoeken. Index seek.
		Primary key is een clustured index. 
		Je kan maar 1 clustured index hebben per tabel
	Non-clustured index
		Alleen een opzoek structuur
		Hier staat een secondary key van de table met een primary key. 
		Om efficient op te zoeken. 
		2 keer opzoeken. Eerst met non-clustered index, dan met de id in de clustured index
		Max 5 non-clustered index, ivm tragere inserts/updates/deletes			
*/

CREATE NONCLUSTERED INDEX
IX_PRODUCTVENDOR_VendorID ON Purchasing.ProductVendor(VendorID);
GO

DROP INDEX IX_ProductVendor_VendorID ON Purchasing.ProductVendor(VendorID);


-- Scalar | User Defined Function (UDF)
DROP FUNCTION IF EXISTS dbo.ProtocolUtiURL;
GO

CREATE OR ALTER FUNCTION dbo.ProtocolUtiURL
(
	@URL AS nvarchar(1000)
)
RETURNS nvarchar(100)
AS
BEGIN
	if (@URL like '%//%')
	RETURN (LEFT(@URL, COUNT(len(@URL) - len(replace(@URL,'//','')))))
END;
GO

SELECT dbo.ProtocolUtiURL('http://www.google.com');