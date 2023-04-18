-- day 25 | view opdracht 21

use adventureworks
go

/* 🌶 Exercise 21 - View */

/* 1. Your colleagues have created the below query, listing product models and their (shortened) English description.
They want to use this query often but have a hard time writing it.
To help them, you will need to turn the query into a view (use CREATE OR ALTER VIEW), named 'SalesLT.ProdModEnDesc'.
You may run into errors, try to solve them too.

  SELECT 
    PM.Name
    , LEFT(PD.[Description], CHARINDEX('.', PD.[Description]))
  FROM SalesLT.ProductModel AS PM
  INNER JOIN SalesLT.ProductModelProductDescription AS PMPD 
  ON PM.ProductModelID = PMPD.ProductModelID 
  INNER JOIN SalesLT.ProductDescription AS PD 
  ON PMPD.ProductDescriptionID = PD.ProductDescriptionID
  WHERE PMPD.Culture = 'en'
  ORDER BY PM.ModifiedDate;
  GO */
create or alter view SalesLT.ProdModEnDesc
as
SELECT 
	PM.Name
	, LEFT(PD.[Description], CHARINDEX('.', PD.[Description]))  as description
FROM SalesLT.ProductModel AS PM
INNER JOIN SalesLT.ProductModelProductDescription AS PMPD 
ON PM.ProductModelID = PMPD.ProductModelID 
INNER JOIN SalesLT.ProductDescription AS PD 
ON PMPD.ProductDescriptionID = PD.ProductDescriptionID
WHERE PMPD.Culture = 'en'
-- ORDER BY PM.ModifiedDate;
go

/* 2. Your colleagues are happy with the view, but now they send in a one time request.
They wish to know the length of the (shortened) descriptions.
Write a very short query displaying productmodel name, description and the length of the description.
Hint: use the view for a shorter query!
Challenge: can you also find how many words are in the description? Or how often the letter 'a' occurs?
(result: 127 rows) */

select
	*
	, LEN(pmed.description)													as desciption_length
	, LEN(pmed.description) - len(replace(pmed.description, ' ', '')) + 1	as number_of_words_in_description
	, LEN(pmed.description) - len(replace(pmed.description, 'a', ''))		as number_of_a_in_description
from SalesLT.ProdModEnDesc		as pmed

/* 3. Your colleagues are done analysing productmodel descriptions and are no longer using the view.
Execute below code to remove it from your database, preventing future issues with an unused view. */
drop view if exists SalesLT.ProdModEnDesc;