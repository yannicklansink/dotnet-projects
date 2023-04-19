
use adventureworks
go

/* 🌶🌶🌶 Exercise 6 - Common Table Expression (CTE) Challenge */

/* 1. You want to compare total sales in different years. To do this, you use the SalesLT.OrderYear view.
Write a query that retrieves the:
	order year, 
	sales total, 
	sales total for the previous year,
	and the difference.

This is a two step problem:
• first you will have to calculate total sales per year
• then you need to compare total sales in different years
HINT: you need to use the same table expression multiple times. A CTE will be a better option than a Derived Table.
HINT: be sure to use a query that includes all three years in the results

  The result will consist off 3 rows, among them:

  OrderYear   TotalSales    PreviousTotalSale   SalesDifference
  ...         ...           ...                 ...
  2021        93662,7156    336319,148          -242656,4324
  ...         ...           ...                 ...
*/

with salestotals as 
(
	select 
		oy.orderyear, 
		sum(oy.orderqty * oy.unitprice * (1 - oy.unitpricediscount)) as totalsales
	from 
		saleslt.orderyear as oy
	group by 
		oy.orderyear
)
select 
	currentyear.orderyear, 
	currentyear.totalsales, 
	previousyear.totalsales as previous_year_total_sales,
	currentyear.totalsales - previousyear.totalsales as salesdifference
from 
	salestotals as currentyear
	left join salestotals as previousyear 
	on currentyear.orderyear = previousyear.orderyear + 1
order by 
	currentyear.orderyear desc;





select
	*
from
(
	select
		oy.OrderYear
		, sum(oy.OrderQty * oy.UnitPrice * (1 - oy.UnitPriceDiscount))	as TotalSalves
	from SalesLT.OrderYear as oy
	group by oy.OrderYear
)	as total_sales_per_year




select * from SalesLT.OrderYear