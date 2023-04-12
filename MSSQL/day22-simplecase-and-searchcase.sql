
use adventureworks
go

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
-- https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-type-precedence-transact-sql?view=sql-server-ver16
from SalesLT.Product as p
where p.ProductCategoryID = 35

-- CAST
select
	DB_NAME() + CAST(SYSDATETIME() as nvarchar) -- expliciet convert datetime2 to nvarchar kan wel
from SalesLT.Product as p
where p.ProductCategoryID = 35

------------------------------------------------------------------------------------------

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

/* 🌶 Exercise 7 - Text functions */
/* 1. Write a query to retrieve data from the Customer table this way:
  FirstName   LengthFirstName   LastName    SalesPerson   SpecialCode
  Orlando     7                 GEE         pamela0       a_bike_store>>gee
  Keith       5                 HARRIS      david8        progressive_sports>>harris
  Donna       5                 CARRERAS    jillian0      advanced_bike_components>>carreras
  ...         ...               ...         ...           ...
  (result: 847 rows) */
 select
	c.FirstName
	, LEN(c.FirstName)
	, UPPER(c.LastName)
	, c.SalesPerson
	, CONCAT(LOWER(REPLACE(c.CompanyName, ' ', '_')), '>>', LOWER(c.LastName))
from SalesLT.Customer as c

/* 🌶🌶 Exercise 8 - Text functions */
/* 1. Write another query to retrieve data from the Customer table this way:
  CompanyName               NrOfWords   CustomerName
  A Bike Store              3           Orlando N. Gee
  Progressive Sports        2           Keith Harris
  Advanced Bike Components  3           Donna F. Carreras
  Modular Cycle Systems     3           Janet M. Gates
  ...                       ...         ...
  To solve the CustomerName challenge, you might use the IIF() scalar function. 
  A couple of solutions will be discussed after the exercise.
  (result: 847 rows) */ 

select
	c.CompanyName	--					  field       char
	, LEN(c.CompanyName) - len(replace(c.CompanyName, ' ', '')) + 1 as NrOfWords
	, CONCAT_WS(' ', c.FirstName, c.MiddleName, c.LastName) as CustomerName
from SalesLT.Customer c 

------------------------------------------------------------------------------------------

-- datetime2 
select PARSE('12-02-2023 13:47:22' AS datetime2 USING 'en-US')
select PARSE('12-02-2023 13:47:22' AS datetime2 USING 'nl-NL')

-- opdracht les 14:00
select
	CONCAT_WS(' ', c.FirstName, c.MiddleName, c.LastName)
from SalesLT.Customer as c

-- opdracht 2 | 542 rows?
select
	*
from SalesLT.SalesOrderHeader as soh
inner join SalesLT.SalesOrderDetail as sod
on soh.SalesOrderID = sod.SalesOrderID

------------------------------------------------------------------------------------------

-- opdracht 15:30 | group by
-- 1: per salesorderid het aantal regels
select
	count(soh.SalesOrderID)
from SalesLT.SalesOrderHeader as soh
group by soh.SalesOrderID

-- 2: per orderdat het aantal regels
select
	count(soh.OrderDate)
from SalesLT.SalesOrderHeader as soh
group by soh.OrderDate

-- 3: per title het aantal keren dat die voorkomt
select
	count(c.Title)
from SalesLT.Customer as c
group by c.Title	

-- 4: per city het aantal keren dat die voorkomt. (address)
select
	a.City
	, COUNT(a.City) as aantal
from SalesLT.Address as a
group by a.City

-- 5: per city, stateprovince het aantal keren dat deze combinatie voorkomt.(address)
select
	a.City
	, count(a.City)
	, count(a.StateProvince)
from SalesLT.Address as a
group by a.City, a.StateProvince

-- 6: per salesorderid het aantal regels en gemiddelde prijs (niet rekening houden met orderqty)
select
	sod.SalesOrderID
	, count(*)
	, avg(sod.UnitPrice)
from SalesLT.SalesOrderDetail as sod
group by sod.SalesOrderID

------------------------------------------------------------------------------------------

