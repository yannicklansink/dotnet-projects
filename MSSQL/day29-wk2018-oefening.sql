USE WorldCup2018;
GO

-- Cleanup for comparison and repeatability
DROP INDEX IF EXISTS NCIFamilyName ON Persons.Spectators;
DROP INDEX IF EXISTS NCIFullName ON Persons.Spectators;
GO

/*
Use Ctrl + M (or click icon) to see actual execution plan with each query
*/

-- Inspect the Persons.Spectators table (1.000.000 rows)
SELECT COUNT(*) FROM Persons.Spectators;
SELECT TOP 10 * FROM Persons.Spectators;
SELECT * FROM Persons.Spectators; -- ~12 sec
SELECT * FROM Persons.Spectators AS s WHERE s.SpectatorId = 499999; -- Clustured index seek

/*
Execute both queries with the index creation in the middle.
Compare 'Estimated subtree cost' on the SELECT icon of both queries (ignore the index creation plan)
Note that the index saves about 40%. However, it collects 0.1% of the total data, so 40% savings isn't that high.
*/

-- Finding people will often happen based on name instead of Id. Time for an index!
SELECT *
FROM Persons.Spectators
WHERE FamilyName = 'Adamides'; -- estimated subtree cost = 4,8..	-- Clustured index scan

CREATE NONCLUSTERED INDEX NCIFamilyName 
ON Persons.Spectators (FamilyName)
GO

SELECT *
FROM Persons.Spectators
WHERE FamilyName = 'Adamides'; -- estimated subtree cost = 3,0..	-- Index Seek

-- Let's experiment further with these queries:
-- 1. Create a more selective query and matching index
SELECT *
FROM Persons.Spectators as s
WHERE FamilyName = 'Adamides' and s.SpectatorId = 2578;

-- 2. Create a query that can be resolved by just the nonclustered index

-- Let's try both of these.

/*
Execute the two queries plus index creation as a unit again while having the actual execution plan option on.
Note how the first query starts with a clustered index scan using multiple executions in parallel,
and the estimated subtree cost is 5,0.. (more expensive than previous query)
Also note how our composite index has improved performance more than 6x by only reading and looking up 32 rows.
*/

SELECT *
FROM Persons.Spectators
WHERE FamilyName LIKE 'Ad%' AND FirstName LIKE 'Ad%';

CREATE NONCLUSTERED INDEX NCIFullName ON Persons.Spectators (FamilyName, Firstname)
GO

SELECT *
FROM Persons.Spectators
WHERE FamilyName LIKE 'Ad%' AND FirstName LIKE 'Ad%';

/*
Next, let's see what happens if we just want to find the IDs.
Remember, nonclustered indexes always contain the clustering key at the leaf level (the column(s) defining the clustered index),
in this case SpectatorId.
Execute both queries simultaneously and compare the plans and costs.
*/

SELECT *
FROM Persons.Spectators
WHERE FamilyName LIKE 'Ad%' AND FirstName LIKE 'Ad%';

SELECT SpectatorId
FROM Persons.Spectators
WHERE FamilyName LIKE 'Ad%' AND FirstName LIKE 'Ad%';

/*
Bonus question: can you predict which operation below query will do?

index (clustered or nonclustered) or heap
seek or scan
Execute and check the query plan carefully.
*/
SELECT
COUNT(*)
FROM Persons.Spectators;

-- Conclusion: an index can help with more queries than just the ones filtering on its keys.