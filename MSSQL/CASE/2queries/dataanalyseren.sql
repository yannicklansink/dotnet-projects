-- ----------------------------------------------------------------------------
-- Opdracht 2: Queries data analyseren 
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
	SELECT  MedewerkerId
	FROM    Reisdocumenten
)

-- 3. Het aantal aanvragen uit specifiek de vorige maand gegroepeerd per type (Soort).
-- SELECT MONTH(DATEADD(MONTH, -1, CURRENT_TIMESTAMP));
DECLARE @startOfCurrentMonth DATETIM
SET @startOfCurrentMonth = DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0)

SELECT
	*
FROM Reisdocumenten AS r
WHERE r.Aanvraagdatum >= DATEADD(month, -1, CURRENT_TIMESTAMP) 
	  AND r.Aanvraagdatum < @startOfCurrentMonth
GROUP BY SoortId;

-- 4. Een lijst van alle burgers en medewerkers die in Hamelen wonen.
DECLARE @woonplaats VARCHAR(60)
SET @woonplaats = 'Hamelen'

SELECT		
	*
FROM Burgers AS b
INNER JOIN Reisdocumenten AS r
ON b.Id = r.Burgerid
INNER JOIN Medewerkers AS m
ON m.Id = r.MedewerkerId
WHERE
	b.plaats = @woonplaats 
	AND m.Woonplaats = @woonplaats;

-- ----------------------------------------------------------------------------
-- (RODE PISTE)
-- ----------------------------------------------------------------------------

-- 1. Totaalbedrag van alle reisdocumenten per maand

-- 2. Alle documenten die in de komende twee maanden verlopen zijn

-- 3. Per document het type, de status en het aantal

-- 4. Gegevens van elke werknemer met daarbij de gegevens van diens leidinggevende



-- ----------------------------------------------------------------------------
-- (ZWARTE PISTE)
-- ----------------------------------------------------------------------------

-- 1. Per jaar per documenttype het totaalbedrag dat werkelijk betaald is (de prijs van toen) en het totaalbedrag op basis van de huidige prijs (een fictief totaal)

-- 2. Per maand de procentuele toe- of afname van opgehaalde reisdocumenten.

-- 3. Challenge: Per week de eerste 3 opgehaalde reisdocumenten