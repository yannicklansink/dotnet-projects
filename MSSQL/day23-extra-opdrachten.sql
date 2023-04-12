-- day 23 (studiedag) | Extra opdracht (1)

USE adventureworks;
GO


CREATE TABLE BusinessUnits
(
	id	 int PRIMARY KEY,
	title	 nvarchar(50) NOT NULL,
	parent   int NULL
);
GO

INSERT INTO BusinessUnits
(id, title, parent)
VALUES
(1, 'Root', NULL),
(2, 'HR', 1),
(3, 'Talent Management', 2),
(4, 'Salaris Administratie', 2),
(5, 'Marketing', 1),
(6, 'Intern', 5),
(7, 'Extern', 5),
(8, 'ICT', 1);
GO


-- -----------------------------------------------------
/*
Schrijf een query die de title en title van de parent in één resultaatset weergeeft:
*/

select
	afdeling.title				as afdeling
	, hoofdafdeling.title		as hoofdafdeling
from BusinessUnits as afdeling
left outer join BusinessUnits as hoofdafdeling
on afdeling.parent = hoofdafdeling.id

-- --------------------------------------------------

-- Exercise 1
/* 1. Select the top 1000 rows of the sales orders table in the database adventureworks. 
(hint: use the SalesOrderHeader table in the SalesLT schema) */
select
	TOP 1000 *
from SalesLT.SalesOrderHeader as soh

/* 2. Select all rows (hint: use a *) of the sales order table. 
Add all address information to these sales orders using a join on the ShipToAddress. 
Give the tables aliases and use these aliases in the join clause. */
select
	TOP 1000 *
from SalesLT.SalesOrderHeader as soh
inner join SalesLT.Address as a
on soh.ShipToAddressID = a.AddressID

/* 3. Select only the sales order that are shipped to the United States. */
select
	TOP 1000 *
from SalesLT.SalesOrderHeader as soh
inner join SalesLT.Address as a
on soh.ShipToAddressID = a.AddressID
where a.CountryRegion = 'United States'

/* 4. Add the names of the customers to the above table. 
Only show the sales order number, the first name of the customer, 
the last name of the customer and their title. */
select
	soh.SalesOrderNumber
	, c.FirstName
	, c.LastName
	, c.Title
from SalesLT.SalesOrderHeader as soh
inner join SalesLT.Address as a
on soh.ShipToAddressID = a.AddressID
inner join SalesLT.Customer as c
on soh.CustomerID = c.CustomerID
where a.CountryRegion = 'United States'

/* 5. Create an new column that combines the title of the customer with the full name of the customer. 
(eg. Mr. John Johnson). Do not show the original columns of the customer table. */
select
	soh.SalesOrderNumber
	, CONCAT_WS(' ', c.Title, c.FirstName, c.LastName) as CustomerName
from SalesLT.SalesOrderHeader as soh
inner join SalesLT.Address as a
on soh.ShipToAddressID = a.AddressID
inner join SalesLT.Customer as c
on soh.CustomerID = c.CustomerID
where a.CountryRegion = 'United States'

/* 6. Add the total amount that the customer spent. Use the LineTotal from the SalesOrderDetail table. 
Remember the ‘GROUP BY’ clause when using an aggregate. */
select
	soh.SalesOrderNumber
	, CONCAT_WS(' ', c.Title, c.FirstName, c.LastName) as CustomerName
	, SUM(sod.LineTotal)				as totalAmountSpent
from SalesLT.SalesOrderHeader			as soh
inner join SalesLT.Address			as a	on soh.ShipToAddressID = a.AddressID
inner join SalesLT.Customer		    as c	on soh.CustomerID = c.CustomerID
inner join SalesLT.SalesOrderDetail as sod  on soh.SalesOrderID = sod.SalesOrderID
where a.CountryRegion = 'United States'
group by soh.SalesOrderNumber, c.Title, c.FirstName, c.LastName

/* 7. Add also the total quantity that a customer purchased and the average amount per product. */
select
	soh.SalesOrderNumber
	, CONCAT_WS(' ', c.Title, c.FirstName, c.LastName) as CustomerName
	, SUM(sod.LineTotal)				as totalAmountSpent
	, COUNT(sod.OrderQty)				as TotalQuantity
from SalesLT.SalesOrderHeader			as soh
inner join SalesLT.Address			as a	on soh.ShipToAddressID = a.AddressID
inner join SalesLT.Customer		    as c	on soh.CustomerID = c.CustomerID
inner join SalesLT.SalesOrderDetail as sod  on soh.SalesOrderID = sod.SalesOrderID
where a.CountryRegion = 'United States'
group by soh.SalesOrderNumber, c.Title, c.FirstName, c.LastName

-- Exercise 2
/* 1. Select all rows (hint: use a *) of the product table. */
select
	*
from SalesLT.Product

/* 2. Add the product category table to the product table. 
Make sure that all product categories are shown even if a 
product category is not coupled to a product. 
Give the tables aliases and use these aliases in the join clause. */
select
	*
from SalesLT.Product as p
right outer join SalesLT.ProductCategory as pc on p.ProductCategoryID = pc.ProductCategoryID 

/* 3. Add the parent product category to the previous table. 
Make sure that all parent product categories are shown even 
if the parent product category is a NULL value in the previous table. Again, use an alias. */
select
	*
from SalesLT.Product as p
right outer join SalesLT.ProductCategory as childCategory on p.ProductCategoryID = childCategory.ProductCategoryID 
left outer join SalesLT.ProductCategory as parentCategory on childCategory.ParentProductCategoryID = parentCategory.ProductCategoryID

/* 4. Only show the columns product name, the product category and the parent product category. */
select
	p.Name					as product_name
	, childCategory.Name	as product_category
	, parentCategory.Name	as parent_product_category
from SalesLT.Product as p
right outer join SalesLT.ProductCategory as childCategory on p.ProductCategoryID = childCategory.ProductCategoryID 
left outer join SalesLT.ProductCategory as parentCategory on childCategory.ParentProductCategoryID = parentCategory.ProductCategoryID

/* 5. Some categories don’t have a parent category. 
Replace these ‘empty’ values with: ‘The category is already the parent’. 
Maybe you can come up with more than one solution */
select
	p.Name					as product_name
	, childCategory.Name	as product_category
	, COALESCE(parentCategory.Name, 'The category is already the parent') as parent_product_category
from SalesLT.Product as p	
right outer join SalesLT.ProductCategory as childCategory on p.ProductCategoryID = childCategory.ProductCategoryID 
left outer join SalesLT.ProductCategory as parentCategory on childCategory.ParentProductCategoryID = parentCategory.ProductCategoryID

/* 6. Return only the rows that contain the word ‘bike’ somewhere in the category name. */
select
	p.Name					as product_name
	, childCategory.Name	as product_category
	, COALESCE(parentCategory.Name, 'The category is already the parent') as parent_product_category
from SalesLT.Product as p	
right outer join SalesLT.ProductCategory as childCategory on p.ProductCategoryID = childCategory.ProductCategoryID 
left outer join SalesLT.ProductCategory as parentCategory on childCategory.ParentProductCategoryID = parentCategory.ProductCategoryID
where childCategory.Name like '%Bike%' OR parentCategory.Name like '%Bike%'

/* 7. Retrieve the Sellstartdate and show in the format 'month spelled out Year' (eg. October 2020). 
Make sure it creates a date (using format), not a string. */ 
select
	p.Name					as product_name
	, childCategory.Name	as product_category
	, COALESCE(parentCategory.Name, 'The category is already the parent') as parent_product_category
	, FORMAT(p.SellStartDate, 'MMMM yyyy')
from SalesLT.Product as p	
right outer join SalesLT.ProductCategory as childCategory on p.ProductCategoryID = childCategory.ProductCategoryID 
left outer join SalesLT.ProductCategory as parentCategory on childCategory.ParentProductCategoryID = parentCategory.ProductCategoryID
where childCategory.Name like '%Bike%' OR parentCategory.Name like '%Bike%'