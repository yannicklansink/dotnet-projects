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