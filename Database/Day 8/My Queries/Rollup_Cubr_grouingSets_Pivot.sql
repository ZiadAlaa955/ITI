create table sales
(
	productID int,
	salesManName varchar(50),
	quantity int
)
insert into sales
values  
(1,'ahmed',10), (1,'khalid',20), (1,'ali',45),
(2,'ahmed',15), (2,'khalid',30), (2,'ali',20),
(3,'ahmed',30), (4,'ali',80),    (1,'ahmed',25),
(1,'khalid',10), (1,'ali',100),   (2,'ahmed',55),
(2,'khalid',40), (2,'ali',70),    (3,'ahmed',30),
(4,'ali',90),    (3,'khalid',30), (4,'khalid',90)

select ProductID,SalesmanName,quantity
from sales
--Grouping---------------------------
--1.Old way: Union
select salesManName as Name, sum(quantity) 
from Sales
Group by salesManName
union
Select 'Total Values', sum(quantity)
from Sales

--2.Rollup
select salesManName as Name, sum(quantity) 
from Sales
Group by Rollup (salesManName)

select ProductID as Name, sum(quantity) 
from Sales
Group by Rollup (productID)

select productID, SalesManName, sum(Quantity) 
from Sales
Group by Rollup(productID, salesManName)

--3.Cube
select ISNULL(productID, 0)  , ISNULL(SalesManName,'All SalesMen'), sum(Quantity) 
from Sales
Group by Cube(productID, salesManName)
order by productID asc


--3.Grouping sets
select productID, salesManName as Name, sum(quantity) 
from Sales
Group by grouping sets(productID, salesManName)



--Pivot: Matrix---------------------
select * from Sales
Pivot(sum(quantity) for SalesmanName in ([Ahmed],[Khalid],[Ali])) as PVT

select * from Sales
Pivot(sum(quantity) for ProductID in ([1],[2],[3],[4])) as PVT




