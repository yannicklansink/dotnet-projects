-- notes day 25 
use adventureworks;
go

/*
subqueries tot nu toe:
	- SELECT
	- WHERE

Table expressions is een virtueele tabel. 
	- derived table:					subquery in de FROM
	- common table expression:			statement met een WITH
	- view:								een opgeslagen query
	- table-valued function:			soort view met parameters
Mag geen order by gebruiken. Heel soms wel.

*/

-- Maak een VIEW
-- Gebruik 2 GO statements
-- or alter maakt het idempotent. (krijg hetzelfde resultaat zovaak je het uitvoerd)
create or alter view SalesLT.StateProvincesEnAantalen
as
select
	UPPER(LEFT(a.StateProvince, 2))		as stateprovince
	, COUNT(*)							as aantal_per_stateprovince
from SalesLT.Address as a
group by a.StateProvince;
go

-- view opvragen
select * from SalesLT.StateProvincesEnAantalen;

-- -------------------------------------------------
-- table valued function 
-- maken een view generieker
go

create or alter function SalesLT.StateProvincesEnAantalenTopX(@top as int, @letter as nvarchar(50))
returns table -- maar kan ook varchar, int, bity ...
as
return
(
	select TOP(@top) WITH TIES
		a.StateProvince						as stateprovince
		, COUNT(*)							as aantal_per_stateprovince
	from SalesLT.Address as a
	where a.StateProvince like CONCAT('%', @letter, '%')
	group by a.StateProvince
	order by aantal_per_stateprovince desc
)
go

select * from SalesLT.StateProvincesEnAantalenTopX(10, 'c');

-- -----------------------------------------------
-- Derived Table (subquery achter de from)
-- dit had ook met view of table valued function, maar mag je dat niet moet je derived function gebruiken. 
-- Derived table is niet heel efficient. Wat als je 10 derived tables hebt? of het later nog een wilt gebruiken?
select 
	*
from 
(
	select
		pc.Name
		, count(*)				as aantalproducten
		, max(p.StandardCost)	as highestprice
		, min(p.StandardCost)	as lowestprice
		, avg(p.StandardCost)	as averageprice
	from SalesLT.ProductCategory as pc
	inner join SalesLT.Product as p
	on pc.ProductCategoryID = p.ProductCategoryID
	where pc.ParentProductCategoryID is not null
	group by pc.Name
) as categorien_en_prijsinformatie
where aantalproducten > 25
and lowestprice > 200

-- opdracht:
select
	*
from 
(
	select 
	c.CustomerID
	, ca.AddressType
	, a.AddressLine1
	from SalesLT.Address as a
	inner join SalesLT.CustomerAddress as ca
	on a.AddressID = ca.AddressID
	inner join SalesLT.Customer as c
	on c.CustomerID = ca.CustomerID
) as customer_address_info
where AddressType like 'Main%';

-- --------------------------------------------------------
-- Common Table Expression (CTE)| a.k.a. WITH statement
-- vorige statement moet eindigen met ;
-- vervangt de Derived Table. 
-- beter om code te hergebruiken, want products kan je overal nu gebruiken.
WITH products as 
(
	select 
		* 
	from SalesLT.Product
) 
select
	*
from products;

-- opdracht 
WITH dummy as 
(
	SELECT 
        ProductCategoryID
        , Name
    FROM SalesLT.ProductCategory AS pc
    WHERE pc.ParentProductCategoryID IS NOT NULL
)
select 
	dummy.ProductCategoryID
	, dummy.Name
from dummy;

-- opdracht 2
WITH categorien_en_prijsinformatie as
(
	select
		pc.Name
		, count(*)				as aantalproducten
		, max(p.StandardCost)	as highestprice
		, min(p.StandardCost)	as lowestprice
		, avg(p.StandardCost)	as averageprice
	from SalesLT.ProductCategory as pc
	inner join SalesLT.Product as p
	on pc.ProductCategoryID = p.ProductCategoryID
	where pc.ParentProductCategoryID is not null
	group by pc.Name
)
select * from categorien_en_prijsinformatie as cep
where cep.aantalproducten > 25
and cep.lowestprice > 200;

-- ------------------------------------------------------------------------
-- Union
-- Om gegevens uit 2 tabellen aan elkaar vast te knopen.
-- UNION = eerst sorteren en daarna ontdubbelen
-- union all = wel de dubbelen gebruiken.



