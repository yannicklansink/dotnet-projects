/*
		/* 🌶 Exercise 5 - CASE */

		/* 1. Write a query to retrieve all unique colors from the table Product.
		We'll need a couple of these values in the next exercise.
		(result: 10 rows) */

		/* 2. Write a query to retrieve a couple of fields including Color from the table Product.
		Add a new column 'ColorCode' in the result set:
		When Color is 'black' then show 'AAA' for ColorCode.
		Define 3 such color codes, for the remainder of the colors ColorCode will be 'TBD' (To Be Determined).
		Use a SIMPLE CASE.
		(result: 295 rows) */
		
*/

-- 1
select distinct
	p.Color
from SalesLT.Product as p

-- 2
select 
	p.Color
	, case p.Color
		when 'Black'	then 'AAA'	
		when 'Blue'		then 'BBB'
		when 'Grey'		then 'GGG'
		else			     'TBD'
	end
from SalesLT.Product as p

/* 🌶🌶 Exercise 6 - CASE */

		/* 1. Write a query using a SEARCHED CASE.
		Retrieve from the table Product 3 columns: Name, ListPrice en PriceIndex.
		The latter will contain one of 3 values:
		'cheap', 'medium' or 'expensive'. (intermediate boundary ListPrice values are 500 and 1000).
		(result: 295 rows) 
*/

select
	p.Name
	, p.ListPrice
	, case 
		when p.ListPrice < 500								then 'cheap'
		when p.ListPrice >= 500 and p.ListPrice < 1000		then 'medium'
		when p.ListPrice > 1000								then 'expensive'
	end
from SalesLT.Product p


-- samen opdracht
select 
	p.Name
	, case 
		when p.Size is null then 'niet beschikbaar'
		else					  p.Size
	end as grootte
from SalesLT.Product as p

-- dit is hetzelfde als de case hierboven.
-- COALESCE: retourneerd de eerste niet null value van de parameters.
select 
	p.Name
	, coalesce(p.Size, 'niet beschikbaar') as grootte
from SalesLT.Product as p


-- sql has 29 different data types. 
select 
	s.OrderQty
	, s.UnitPrice
	, s.OrderQty * s.UnitPrice as totaalprijs -- impliciet convert int value to decimal.
from SalesLT.SalesOrderDetail as s

select
	DB_NAME() + SYSDATETIME() --  FOUT: convert van datetime2 to nvarchar kan niet. 
							  --  want een datetime2 is hoger dan een nvarchar
from SalesLT.Product as p
where p.ProductCategoryID = 35

-- CAST
select
	DB_NAME() + CAST(SYSDATETIME() as nvarchar) -- expliciet convert datetime2 to nvarchar kan wel
from SalesLT.Product as p
where p.ProductCategoryID = 35