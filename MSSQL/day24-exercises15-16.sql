-- day 24 | exercises 15 en 16

use adventureworks
go

/* 🌶🌶🌶 Exercise 15 - EXISTS */

/* 1. Write a JOIN query to retrieve ProductID and ThumbNailPhoto from Product
where the Productcategory contains either 'Caps' or 'Bib'.
(result: 4 rows) */
select
	p.ProductID
	, p.ThumbNailPhoto
	, pc.Name
from SalesLT.Product as p
inner join SalesLT.ProductCategory as pc
on p.ProductCategoryID = pc.ProductCategoryID
where pc.Name like '%Caps%' or pc.Name like '%Bib%'

/* 2. Copy paste the previous query.
Then rewrite the query to a solution with a selfcontained, multivalued subquery.
(result: 4 rows) */
select
	p.ProductID
	, p.ThumbNailPhoto
from SalesLT.Product as p
where p.ProductCategoryID in
(
	select
		pc.ProductCategoryID
	from SalesLT.ProductCategory as pc
	where pc.Name like '%Bib%' or pc.Name like '%Caps%'
)


/* 3. Copy paste the previous query.
Then rewrite the query to a solution with a correlated subquery and EXISTS.
(result: 4 rows) */
select
	p.ProductID
	, p.ThumbNailPhoto
from SalesLT.Product as p
where EXISTS
(
	select
		1
	from SalesLT.ProductCategory as pc
	where p.ProductCategoryID = pc.ProductCategoryID 
			and	(pc.Name like '%Bib%' or pc.Name like '%Caps%')
)

/* 🌶🌶🌶 Exercise 16 - EXISTS */

/* 1. Use the tables SalesOrderHeader and Customer to retrieve all orders
where the customer's CompanyName is 'Channel Outlet'. Use EXISTS.
(result: 1 row) */


/* 2. Use the tables Product and SalesOrderDetail to retrieve product names
which are used in more than 5 orders. Again, use EXISTS.
(result: 28 rows) */