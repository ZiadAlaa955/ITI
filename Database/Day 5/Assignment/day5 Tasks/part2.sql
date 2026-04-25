use AdventureWorks2012

---(1)
select SalesOrderID , ShipDate
from Sales.SalesOrderHeader
where OrderDate between '7/28/2002' and '7/29/2014'

---(2)
select ProductID , Name
from Production.Product
where StandardCost < 110.00

---(3)
select ProductID , Name
from Production.Product
where weight is NULL

---(4)
select *
from Production.Product
where Color in('red','silver','black')

---(5)
select *
from Production.Product
where Name like 'B%'

---(6)
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

select Description
from Production.ProductDescription
where Description like '%\_%' ESCAPE '\'

---(7)
select sum(TotalDue) , OrderDate
from sales.SalesOrderHeader
group by OrderDate
having OrderDate between '7/1/2001' and '7/31/2014'

---(8)
select distinct hireDate
from HumanResources.Employee

---(9)
select avg(distinct ListPrice)
from Production.Product

---(10)
select name as [product name], listPrice as [list price]
from Production.Product 
where ListPrice between 100 and 200
order by ListPrice

---(11)
create table [store_archive]
(
SalesPersonID int,
Name varchar(50),
rowguid uniqueidentifier
);

alter table [store_archive]
add Demographics xml(CONTENT Sales.StoreSurveySchemaCollection);

insert into store_archive 
select SalesPersonID ,Name, rowguid, Demographics
from Sales.Store

---(12)
select FORMAT(GETDATE(),'dd/mm/yyyy')
union
select FORMAT(GETDATE(),'mm/dd/yyyy')
union
select FORMAT(GETDATE(),'yyyy/dd/mm')
union
select FORMAT(GETDATE(),'yyyy/mm/dd')


