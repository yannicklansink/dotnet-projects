

USE adventureworks -- soort namespace
GO

/*
ms transact-sql 
dat is des microsofts waar statements aan de standaard ansi sql is toegevoegd.
statements zoals: 
	- []
	- TOP
	- ISNULL()
*/

/*
Scheme is een container. Om objecten die bij elkaar horen te groeperen
Database heeft meerdere schemes.
Wordt gebruikt om te categoriseren.
	- Zoals de production afdeling:
		- Production.Categories
		- Production.Products
		- Production.Suppliers
Ook een tool om permissies toe te kennen op schema niveau. 
DBO is het standaard schema.
*/

select
	sod.SalesOrderID
	, SUM(sod.OrderQty)			as totaal_orderqty -- aggregation function
from SalesLT.SalesOrderDetail   as sod
where sod.SalesOrderID >= 71850
group by sod.SalesOrderID 
having SUM(sod.OrderQty) >= 80 -- helaas moet je de sum in having overschrijven

-- subquery
select
	*
from SalesLT.Product as p
where p.ListPrice = 
(
	select 
		MAX(p.ListPrice)
	from SalesLT.Product as p
)

-- TOP met TIES. Returned niet 1, maar 3 want die hebben dezelfde waarde
-- kan ook met TOP 10 PRECENT
select TOP 1
	*
from SalesLT.SalesOrderDetail as sod
order by sod.UnitPrice

-- N om expliciet aan te geven wat het data type is.
select
	c.FirstName
	, a.City
from SalesLT.Customer as c
inner join SalesLT.CustomerAddress as ca on c.CustomerID = ca.CustomerID
inner join SalesLT.Address as a on a.AddressID = ca.AddressID
where a.City = N'london'
-- where c.LastName = N'logan' -- de N maakt het sneller. Dit kan alleen als je te maken hebt met nvarchar()

-- subquery met meer rijen. self-contained subquery.
select
	ca.CustomerID
	, ca.AddressType
from SalesLT.CustomerAddress as ca 
where ca.AddressID in
(
	select
		a.AddressID -- a.addressid moet matchen met ca.addressid
	from SalesLT.Address as a
	where a.City = N'London'
)

-- exists. correlated subquery
select
	ca.CustomerID
	, ca.AddressType
from SalesLT.CustomerAddress as ca 
where EXISTS
(
	select
		1
	from SalesLT.Address as a
	where a.City = N'London'
	and a.AddressID = ca.AddressID
)

-- subquery in select
select
	p.ProductNumber
	, p.ListPrice
	, p.ListPrice / (select sum(ListPrice) from SalesLT.Product) * 100 as totaalprijs
from SalesLT.Product as p

/*
4 typen subqueries:
	- single valued subquery: returned 1 record
	- multi valued qubquery: returned meerdere records
	- correlated subquery (EXISTS)
	- select subquery
*/

select SYSDATETIME() -- datetime2
select GETDATE() -- datetime
select DATEPART(QUARTER, SYSDATETIME())

select dateadd(QUARTER, 1, SYSDATETIME())

select EOMONTH(SYSDATETIME(), 1)

select a.PostalCode from SalesLT.Address as a where a.PostalCode like '_[89]%'
/*
	% = 0 of meer karakters
	_ = exact 1 karakter
	[ABab] = exact 1 karakter van A, B, a of b
*/

drop table if exists RaceAutos
create table RaceAutos
(
	id int IDENTITY PRIMARY KEY,
	naam nvarchar(15), 
	maxSnelheid decimal(5,2) NULL,
)
go

insert into RaceAutos
(naam, maxSnelheid)
values 
('rb18', 340.00),
('aeg12', 670)
go


