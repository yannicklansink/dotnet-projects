-- subqueries exercises 13 en 14

use adventureworks
go

/* 🌶 Exercise 13 - Subqueries */

/* 1. Write a solution with a subquery to show ALL fields from the most recent order.
Use the table SalesOrderDetail.
(result: 1 row) */
select
	*
from SalesLT.SalesOrderDetail as sod
where sod.SalesOrderID = 
(
	select TOP 1
		soh.SalesOrderID
	from SalesLT.SalesOrderHeader as soh
	order by soh.OrderDate desc -- mag dit? order by moet niet in een subquery?
)

/* 2. Write a solution with a subquery to show the Name and ListPrice of products,
where ListPrice is greater than the average ListPrice. Use the table Product.
(result: 102 rows) */
select
	p.Name
	, p.ListPrice
from SalesLT.Product as p
where p.ListPrice > 
(
	select 
		avg(ListPrice)
	from SalesLT.Product as p2
)

/* 3. Copy paste the previous query and add a column AvgListPrice.
Attention Here you will need a subquery in the SELECT clause.
(result: 102 rows) */
select
	p.Name
	, p.ListPrice
	, (select avg(ListPrice) from SalesLT.Product) as AvgListPrice
from SalesLT.Product as p
where p.ListPrice > 
(
	select 
		avg(ListPrice)
	from SalesLT.Product as p2
)

/* 4. Copy paste the previous query and add a column DifferentFromAverage containing
the difference between the ListPrice and the AvgListPrice.
(result: 102 rows) */
select
	p.Name
	, p.ListPrice
	, (select avg(ListPrice) from SalesLT.Product)					as AvgListPrice
	, p.ListPrice - (select avg(ListPrice) from SalesLT.Product)	as DifferentFromAverage
from SalesLT.Product as p
where p.ListPrice > 
(
	select 
		avg(ListPrice)
	from SalesLT.Product as p2
)

/* 🌶🌶 Exercise 14 - Subqueries */

/* 1. Querying the tables SalesLT.ProductCategory and SalesLT.Product,
retrieve a list of Product Name and Color where the ProductCategory Name doesn't contain 'Bikes'.
Write 2 solutions: one with a JOIN, the other with a subquery.
(result: 198 rows)
*/
select
	p.Name
	, p.Color
from SalesLT.Product as p
where exists
(
	select 
		1
	from SalesLT.ProductCategory as pc
	where p.ProductCategoryID = pc.ProductCategoryID
		  and pc.Name not like ('%Bikes%')
)


