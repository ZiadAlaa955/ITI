use Company_SD

---(1)
select   Dname , Dnum , Fname , ssn
from Departments d , Employee e
where d.MGRSSN = e.ssn

---(2)
select d.Dname , p.Pname 
from Departments d inner join Project p
on d.Dnum = p.Dnum
order by d.dname

---(3)
select e.Fname , de.*
from Employee e inner join Dependent de
on e.SSN = de.ESSN

---(4)
select Pnumber , Pname , Plocation 
from Project
where city in ('cairo','alex')

---(5)
select *
from Project
where Pname like 'a%'

---(6)
select * 
from Employee 
where Dno = 30 
and 
Salary between 1000 and 2000 

---(7)
select fname 
from Employee inner join Works_for 
on essn = ssn
inner join Project
on pno = pnumber
where hours >= 10 
and dno = 10
and Pname = 'AL Rabwah'

---(8)
select e.fname 
from employee e inner join employee sup
on sup.SSN  = e.Superssn
where sup.fname = 'Kamel' 

---(9)
select fname , pname
from employee inner join Works_for
on ssn = ESSn
inner join Project
on pnumber = pno
order by Pname

---(10)
select pnumber , dname , lname , address ,bdate
from employee e inner join Departments d
on e.ssn = d.MGRSSN
inner join project p
on d.dnum = p.Dnum
where p.city = 'cairo'

---(11)
select e.* 
from employee e inner join Departments d
on d.MGRSSN = e.ssn

---(12)
select e.* , de.*
from employee e left outer join Dependent de
on ssn = ESSN

---(13)
insert into Employee (dno,ssn,Superssn,Salary)
values(30,102672,112233,3000)

---(14)
insert into Employee (dno,ssn,fname,lname,bdate,address,sex)
values(30,102660,'Ziad','Alaa','2/9/2004','11 Ain shams.cairo','M')

---(15)
update Employee
set salary += salary * 0.2

