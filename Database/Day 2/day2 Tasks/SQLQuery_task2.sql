use Company_SD

--(1)
select * from Employee

--(2)
select Fname, Lname, Salary, Dno
from Employee

--(3)
select pname , plocation , dnum
from project

--(4)
select fname + ' ' + lname as fullName , salary * 0.10 * 12  as [ANNUAL COMM]
from employee

--(5) 
select SSN, fname
from employee
where salary > 1000

--(6)
select SSN, fname
from employee
where salary * 12 > 10000

--(7)
select fname , salary
from Employee
where sex = 'F'

--(8)
select dnum , dname  
from Departments
where mgrssn = 968574

--(9)
select pnumber , pname , plocation 
from Project
where dnum = 10