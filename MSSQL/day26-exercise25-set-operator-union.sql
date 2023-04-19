/* 🌶🌶🌶 Exercise 25 - Set Operators */

/* 1. The Sales team is back. They want to contact the customers who placed the largest orders.
They request the CustomerIDs of the customers who placed the largest 3 orders in each of the past three years.
Write three queries to retrieve the CustomerIDs of customers who placed the top 3 orders (by total value).
One query for two years ago, one for last year and one for the current year. Make your code dynamic so it will also work in the future.
Important, you'll have to use the view 👉 SalesLT.OrderYear.
Include the orderid, year and total value in your result.
HINT: you'll need a couple of date time functions to make your code dynamic... */
select top 3 -- with ties
	oy.CustomerID
	, oy.OrderYear
	, sum(oy.OrderQty * oy.UnitPrice *(1 - oy.UnitPriceDiscount))		as total_order_price
from SalesLT.OrderYear as oy
where oy.OrderYear = cast(left(sysdatetime(), 4) as int) - 2
group by oy.CustomerID, oy.OrderYear

select top 3 -- with ties
	oy.CustomerID
	, oy.OrderYear
	, sum(oy.OrderQty * oy.UnitPrice *(1 - oy.UnitPriceDiscount))		as total_order_price
from SalesLT.OrderYear as oy
where oy.OrderYear = cast(left(sysdatetime(), 4) as int) - 1
group by oy.CustomerID, oy.OrderYear

select top 3 -- with ties
	oy.CustomerID
	, oy.OrderYear
	, sum(oy.OrderQty * oy.UnitPrice *(1 - oy.UnitPriceDiscount))		as total_order_price
from SalesLT.OrderYear as oy
where oy.OrderYear = cast(left(sysdatetime(), 4) as int) 
group by oy.CustomerID, oy.OrderYear

/* 2. The sales team is unhappy with the results, they find it cumbersome to have to combine them into one.
They ask you to combine the three queries into one result set. Please do so!
Order your results by total value */
select top 3 -- with ties
	oy.CustomerID
	, oy.OrderYear
	, sum(oy.OrderQty * oy.UnitPrice *(1 - oy.UnitPriceDiscount))		as total_order_price
from SalesLT.OrderYear as oy
where oy.OrderYear = cast(left(sysdatetime(), 4) as int) - 2
group by oy.CustomerID, oy.OrderYear
UNION
select top 3 -- with ties
	oy.CustomerID
	, oy.OrderYear
	, sum(oy.OrderQty * oy.UnitPrice *(1 - oy.UnitPriceDiscount))		as total_order_price
from SalesLT.OrderYear as oy
where oy.OrderYear = cast(left(sysdatetime(), 4) as int) - 1
group by oy.CustomerID, oy.OrderYear
union
select top 3 -- with ties
	oy.CustomerID
	, oy.OrderYear
	, sum(oy.OrderQty * oy.UnitPrice *(1 - oy.UnitPriceDiscount))		as total_order_price
from SalesLT.OrderYear as oy
where oy.OrderYear = cast(left(sysdatetime(), 4) as int) 
group by oy.CustomerID, oy.OrderYear
order by total_order_price desc

/* 3. Data from the adventureworks database needs to be migrated to a new system!
After 6 months of comparing tables and data fields, all findings are stored in Excel.
One of the Excel sheets contains:

  adventureworks.SalesLT.Customer:          tempdb.dbo.Customers:
  ====================================      ==================================
  FirstName (nvarchar, not nullable)        FullName (nvarchar(120), not nullable)
  MiddleName (nvarchar, not nullable)    
  LastName (nvarchar), not nullable)
  EmailAddress (nvarchar(50), nullable)     Email (nvarchar(50), not nullable)
  Phone (nvarchar, nullable)                Phone (nvarchar(10), not nullable)
  CompanyName(nvarchar(128), nullable)      Company (nvarchar(100), not nullable)
  (no other columns needed)                 Active (bit = 1, not nullable), important:
                                            • Two companies will be inactive:
                                            • 'Retreat Inn' and 'World of Bikes'

  The DBA has built a script for creation and an initial upload of 5 customers, run it.
  Then write a script to migrate only the remainder of customers. 
  Truncate values and/or fill in 'N/A' where applicable.

  👇 script to run:
*/
  DROP TABLE IF EXISTS tempdb.dbo.Customers;

  CREATE TABLE tempdb.dbo.Customers
  (
      ID          int IDENTITY(1,1) PRIMARY KEY,
      FullName    nvarchar(100) NOT NULL,
      Email       nvarchar(50) NOT NULL,
      Phone       nvarchar(10) NOT NULL,
      Company    nvarchar(100) NOT NULL,
      Active    bit NOT NULL
  );
  GO

  INSERT INTO tempdb.dbo.Customers
  VALUES
  ('Orlando N. Gee', 'orlando0@adventure-works.com', '245-555-01', 'A Bike Store', 1),
  ('Keith Harris', 'keith0@adventure-works.com', '170-555-01', 'Progressive Sports', 1),
  ('Donna F. Carreras', 'donna0@adventure-works.com', '279-555-01', 'Advanced Bike Components', 1),
  ('Janet M. Gates', 'janet1@adventure-works.com', '710-555-01', 'Modular Cycle Systems', 1),
  ('Lucy Harrington',  'lucy0@adventure-works.com', '828-555-01', 'Metropolitan Sports Supply', 1);
  GO

  -- --------------------
  -- geen idee of het zo moet :)
INSERT INTO tempdb.dbo.Customers (FullName, Email, Phone, Company, Active)
SELECT 
    COALESCE(CONCAT(FirstName, ' ', MiddleName, ' ', LastName), CONCAT(FirstName, ' ', LastName)) AS FullName,
    COALESCE(EmailAddress, 'N/A') AS Email,
    COALESCE(left(Phone, 10), 'N/A') AS Phone,
    COALESCE(CompanyName, 'N/A') AS Company,
    CASE 
		WHEN CompanyName = 'Retreat Inn' OR CompanyName = 'World of Bikes' THEN 0 
		ELSE 1 
	END AS Active
FROM 
    adventureworks.SalesLT.Customer