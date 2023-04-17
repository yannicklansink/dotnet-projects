-- Huiswerk 11 en 12. Group by en Having
USE adventureworks
GO

/* 🌶 Exercise 11 - GROUP BY, HAVING */

/* 1. Use the table Customer.
Retrieve per SalesPerson the number of customers where this is at least 140 customers
(result: 3 rows) */
select
	c.SalesPerson
	, COUNT(c.SalesPerson) as number_of_customers
from SalesLT.Customer as c
group by SalesPerson
having COUNT(c.SalesPerson) > 140

/* 2. Copy paste the previous query.
Now filter out the companies: 'Greater Bike Store', 'Metro Manufacturing' and 'Corner Bicycle Supply'.ABORT
(result: 2 rows) */

/* 3. Write a brand new query using the table Customer.
Show middle names (excluding NULL values) which occur at least 25 times, highest count on top:

  MiddleName  count
  J.          112
  M.          75
  ...         ...
  E.          25

  (result: 8 rows)
*/

/* 🌶🌶 Exercise 12 - GROUP BY, HAVING */

/* 1. Use the table SalesOrderDetail to retrieve these details:

  SalesOrderID    total
  71784           89869,2764
  71936           79589,616
  71938           74160,228
  71783           65683,3681
  71797           65123,4635
  71902           59894,2092

  Requirements:
  * DON'T USE the existing LineTotal column!
  * Exclude orders with a SalesOrderID less than 71780.
  * Only show orders with a total of at least 55000. Highest on top.
*/