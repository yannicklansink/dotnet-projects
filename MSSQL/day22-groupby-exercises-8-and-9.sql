-- Group by | exercises 8 and 9

use adventureworks
go

/* 🌶 Exercise 9 - GROUP BY */
/* 1. Use the table Customer. Write a query which retrieves per SalesPerson the number of customers.
Use a COUNT(*) and GROUP BY. (result: 9 rows) */
select
	c.SalesPerson
	, count(*) as numberOfCustomers
from SalesLT.Customer as c
group by c.SalesPerson

select
	c.SalesPerson
	, count(c.CustomerID) as numberOfCustomers
from SalesLT.Customer as c
group by c.SalesPerson
-- Welke is beter: Count(*) of count(c.CustomerID)?

/* 2. How often is each Title used? Write a new query to answer that.
(result: 5 rows) */
select
	c.Title
	, COUNT(c.Title) as aantalKeerVoorkomend
from SalesLT.Customer as c
group by c.Title

/* 3. How often is each Suffix used? Write a new query.
(result: 6 rows) */
select
	c.Suffix
	, count(c.Suffix) as numberOfTimesSuffixIsUsed
from SalesLT.Customer as c
group by c.Suffix

/* 4. How often is each combination Title, Suffix used? Write a new query.
(result: 10 rows) */
select
	c.Title
	, c.Suffix
from SalesLT.Customer as c
group by c.Title, c.Suffix

/* 🌶🌶 Exercise 10 - GROUP BY */
/* 1. Get a list on how often each Color is used in the table Product.
(result: 10 rows) */
select
	Color
	, COUNT(p.Color) as numberOfTimesColorIsUsed
from SalesLT.Product as p
group by p.Color

/* 2. Retrieve this resultset:

  ProductCategoryID   count  most_expensive_price   cheapest_price  avg_price
  5                   32     3399,9900              539,9900        1683,3650
  6                   43     3578,2700              539,9900        1597,4500
  ...                 ...    ...                    ...             ...
  (result: 37 rows) */
select
	c.ProductCategoryID
	, COUNT(c.ProductCategoryID) as numberOfTimesProductCateogoryIDIsUsed
	, MAX(c.ListPrice)			 as most_expensive_price
	, MIN(c.ListPrice)			 as cheapest_price
	, AVG(c.ListPrice)			 as avg_price
from SalesLT.Product as c
group by c.ProductCategoryID

/* 3. Copy paste the previous query.
Update the query to show the ProductCategoryName instead of ProductCategoryID
(result: 37 rows)
*/
select
	pc.Name
	, COUNT(c.ProductCategoryID) as numberOfTimesProductCateogoryIDIsUsed
	, MAX(c.ListPrice)			 as most_expensive_price
	, MIN(c.ListPrice)			 as cheapest_price
	, AVG(c.ListPrice)			 as avg_price
from SalesLT.Product as c
inner join SalesLT.ProductCategory as pc
on pc.ProductCategoryID = c.ProductCategoryID
group by pc.Name
