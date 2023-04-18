-- Opdracht 22 | Table Valued Function

/* 🌶🌶 Exercise 22 - Table Valued Function (TVF) */
/* 1. The Sales team is (as always) interested in the money that is earned per product.
Specifically, they want to know the products with the highest markup,
which is defined as (price - cost) / cost
Just as you are about to leave to write their query, one shouts:
'Can you also give the top markups for Gloves?'.
Time for a multi-purpose solution:
Let's start with a query calculating markups, selecting the 5 highest markups.
Then add a filter for product category (in text), try it with 'Gloves'.
Don't forget to show the product name and ID for your sales colleagues. */
select top 5
	p.Name
	, p.ProductID
	, pc.Name
	, (p.ListPrice - p.StandardCost) / p.StandardCost as markups
from SalesLT.Product as p
inner join SalesLT.ProductCategory as pc 
on p.ProductCategoryID = pc.ProductCategoryID
where pc.Name = 'Gloves'

/* 2. Now let's use your query to create a Table Valued Function for your sales team.
That way, they can reuse the same function while looking at the top results for different categories.
First simply paste your query into the supplied code.
Then change your filter to @category, the supplied parameter.
Bonus question: why are you allowed to use ORDER BY? Because we use a TOP statement
Bonus question: Looking at gloves, it is likely more products have the same markup. How would you deal with this? */

GO
CREATE OR ALTER FUNCTION SalesLT.Top5MarkupPerCat(@category nvarchar(50))
RETURNS TABLE
AS RETURN
(
	select top 5
		p.[Name]		as product_name
		, p.ProductID
		, pc.[Name]		as category_name
		, (p.ListPrice - p.StandardCost) / p.StandardCost as markups
	from SalesLT.Product as p
	inner join SalesLT.ProductCategory as pc 
	on p.ProductCategoryID = pc.ProductCategoryID
	where pc.[Name] = @category
	order by markups desc
);
GO
/* 3. Your function has been saved to the database. Time to test it.
Write a query returning the top 5 gloves based on markup.
Make sure to use your function instead of reusing your query from earlier.
Check if the results are the same (they should be). */
select * from SalesLT.Top5MarkupPerCat('Gloves')

/* 4. CHALLENGE! (nog niet uitgelegd)
You have done your job, your sales colleagues can now use child friendly queries to get their data.
Challenge - you could now also write a single query to return the top 5 markup products for every each category.
You will need to use CROSS APPLY, combined with your new function. Include the categorynames in your result.
If you used a simple TOP (no WITH TIES), you should retrieve 119 rows with this query. */

--?

/* 5. Remove the function SalesLT.Top5MarkupPerCat */

DROP FUNCTION IF EXISTS SalesLT.Top5MarkupPerCat;
GO