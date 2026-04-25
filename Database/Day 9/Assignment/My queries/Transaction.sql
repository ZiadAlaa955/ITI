use ITI

create table parent(pid int primary key)
create table child (cid int foreign key references parent (pid))

insert into parent values(1)
insert into parent values(2)
insert into parent values(3)
insert into parent values(4)

insert into child values(1)
insert into child values(22)
insert into child values(3)
--Transaction-------------------------
--manual rollback
begin transaction 
	insert into child values (1)
	insert into child values (2)
	insert into child values (3)
rollback

--Try & catch
begin try
	begin transaction
		insert into child values(1)
		insert into child values(200) --error
		insert into child values(3)
	commit --this line never reached
end try
begin catch
	Rollback
	select 'ERROR'
end catch

--Rollback truncate
begin transaction 
	insert
	truncate --log file
	update
	delete --delete
rollback




