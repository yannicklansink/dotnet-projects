-- Exercise 5 (23)| Derived Table and Common Table Expression

use adventureworks;
go



/* 🌶🌶 Exercise 5 - Derived table and Common Table Expression (CTE) a.k.a. WITH statement */

/* 1. Consider the following request: What are the average and total order values per customer?
To calculate this, you'll probably want to split this problem in two queries:

  • retrieve the total value of each order (make it a table expression)
  • calculate the average and sum per CustomerID

  Instead of using SalesLT.SalesOrderHeader, use the view  SalesLT.CustomerOrders which creates more meaningful results.
  You can connect the view with SalesOrderDetails and/or Customers.

  Try to solve this problem with a Derived Table, then do the same with a Common Table Expression (CTE).
  There should be 5 results.
  If time permits you can also solve it with a View or a TVF. */


-- solve with derived table (subquery achter de from):
SELECT 
    co.CustomerID,
    AVG(total_value_per_order.sum_per_order) AS avg_order_value_per_customer,
    SUM(total_value_per_order.sum_per_order) AS total_order_value_per_customer
FROM 
(
	SELECT
		sod.SalesOrderID
		, SUM(sod.OrderQty * sod.UnitPrice * (1 - sod.UnitPriceDiscount)) AS sum_per_order
	FROM 
		SalesLT.SalesOrderDetail AS sod
	GROUP BY 
		sod.SalesOrderID
) AS total_value_per_order
	inner join SalesLT.CustomerOrders as co
    ON co.SalesOrderID = total_value_per_order.SalesOrderID
GROUP BY 
    co.CustomerID;
-- -------------------------------------------------------------------------------

-- with statement
WITH total_value_per_order as
(
	SELECT
		sod.SalesOrderID
		, SUM(sod.OrderQty * sod.UnitPrice * (1 - sod.UnitPriceDiscount)) AS sum_per_order
	FROM 
		SalesLT.SalesOrderDetail AS sod
	GROUP BY 
		sod.SalesOrderID
)
select
	co.CustomerID,
    AVG(tvpo.sum_per_order) AS avg_order_value_per_customer,
    SUM(tvpo.sum_per_order) AS total_order_value_per_customer
from total_value_per_order as tvpo
inner join SalesLT.CustomerOrders as co
    ON co.SalesOrderID = tvpo.SalesOrderID
GROUP BY 
    co.CustomerID;

