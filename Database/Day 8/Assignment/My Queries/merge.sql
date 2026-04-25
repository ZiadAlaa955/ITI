--Create tables & insert some data
create table lastTransactions (
	cid int,
	cname varchar(20),
	cvalue int
)
insert into lastTransactions values (1, 'Ahmed', 3000)
insert into lastTransactions values (2, 'Eman', 2000)
insert into lastTransactions values (3, 'Khalid', 1500)
insert into lastTransactions values (4, 'Hassan', 1000)

create table dailyTransactions (
	did int,
	dname varchar(20),
	dvalue int
)
insert into dailyTransactions values (1, 'Ahmed', 8000)
insert into dailyTransactions values (2, 'Eman', 100)
insert into dailyTransactions values (7, 'Nada', 9000)


--simple merge: update & insert
Merge into lastTransactions as T
using dailyTransactions as S
on T.cid = S.did
when matched then 
	Update 
	set T.cValue = S.dValue
when not matched then
	insert
	values(S.did, S.dname, S.dValue);
--------------------------------------------
update dailyTransactions
set dvalue = 300 
where did = 1

select * from lastTransactions
select * from dailyTransactions
--------------------------------------------
--conditions & delete
Merge into lastTransactions as T
using dailyTransactions as S
on T.cid = S.did
when matched AND (s.dvalue > t.cValue) then  --> update when daily val > last val
	Update 
	set T.cValue = S.dValue
when not matched by target then				 --> no matched id in target table
	insert
	values(S.did, S.dname, S.dValue)
when not matched by source then				 --> no matched id today 
	delete ;

