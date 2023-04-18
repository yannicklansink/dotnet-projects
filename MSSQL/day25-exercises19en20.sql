-- day 25 | like opdracht 19 en 20

use adventureworks;
go

/* 🌶 Exercise 19 - LIKE */

/* 1. Retrieve Customers in the format 'FirstName space lastName' where
- the 2nd character of the FirstName is NOT an 'a' or 'i'
- and the 3rd character is an 'e', 'm' or 'u'
(result: 54 rows) */
select
	CONCAT_WS(' ', c.FirstName, c.LastName) as customer_name
from SalesLT.Customer as c
where c.FirstName not like '_a%' and c.FirstName not like '_i%' 
		and (c.FirstName like '__e%' or c.FirstName like '__m%' or c.FirstName like '__u%')

/* 🌶🌶 Exercise 20 - LIKE */

/* 1. From the table Address retrieve AddressLine1, City and PostCode where
- the city is 'London'
- the PostalCode starts with 'SW' followed by 1 digit, 1 space, 1 digit and 2 characters
(result: 2 rows) */
select
	a.AddressLine1
	, a.City
	, a.PostalCode
from SalesLT.Address as a
where a.City = 'London' and a.PostalCode like 'SW[1234567890] [1234567890]__'