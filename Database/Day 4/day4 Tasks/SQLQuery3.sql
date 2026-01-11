use Company_SD

---(1)
select d.Dependent_name , d.sex
from Dependent d inner join employee e
on essn = ssn
where d.sex = 'f' and e.sex = 'f' 
union 
select d.Dependent_name , d.sex
from Dependent d inner join employee e
on essn = ssn
where d.sex = 'm' and e.sex = 'm'

---(2)
select Pname , sum(hours) as [total hours]
from Project inner join Works_for
on pno = Pnumber
group by pname 

---(3)
select d.*
from Departments d inner join employee
on dno = dnum
where ssn = (select min(ssn) from employee)

---(4)
select dname , min(salary) as minSalary , max(salary) as maxSalary , avg(Salary) as avgSalary
from Departments inner join Employee
on dno = Dnum
group by dname

---(5)
select CONCAT(fname,' ',lname) as fullName
from employee inner join Departments 
on MGRSSN = SSN
except
select distinct CONCAT(fname,' ',lname) as fullName
from Employee inner join Dependent 
on essn = ssn

---(6)
select dnum , dname , count(ssn)
from Departments inner join employee 
on dno = Dnum
group by dnum , Dname
having avg(salary) < (select avg(Salary) from Employee) 

---(7) 
select CONCAT(fname,' ',lname) as FullName , pname
from employee inner join Works_for 
on essn = ssn 
inner join Project
on pno = pnumber
order by dno ,fname , lname

---(8)
select max(salary)
from employee
where  salary = (select max(salary) from employee)
union
select max(salary)
from employee
where salary < (select max(salary) from employee)

---(9)
select CONCAT(fname , ' ' ,lname) as fullName
from employee e cross join Dependent de
where CONCAT(fname , ' ' ,lname) = de.Dependent_name

---(10)
select ssn , fname
from employee
where exists (select Dependent_name from Dependent where essn = ssn)

---(11)
insert into Departments 
values ('DEPT IT' , 100 , 112233 , '1-11-2006')

---(12)
update Departments
set MGRSSN = 968574
where dnum = 100

update Departments 
set MGRSSN = 102672
where dnum = 20

update employee
set dno = 20
where ssn = 102660 

update employee
set Superssn = 102672
where ssn = 102660 

---(13)
update employee 
set Superssn = 102672
where Superssn = 223344

delete from Dependent
where essn = 223344

update Departments 
set MGRSSN = 102672
where MGRSSN = 223344

update Works_for
set essn = 102672
where essn = 223344

delete from Employee
where ssn = 223344

---(14)
update Employee
set Salary += salary * 0.3
where ssn = (select ssn from employee inner join Works_for on ssn = ESSn inner join Project on pno = Pnumber where Pnumber = 200)
