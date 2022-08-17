alter table Disciplinas alter COLUMN DISID int not null
go 
ALTer table Disciplinas add CONSTRAINT PK_DISID PRIMARY KEY (DISID);
go

create sequence numerarDisid start with 138 Increment by 1
go

alter table disciplinas
 add constraint seqDisciplina 
 default next value for numerarDisid
 for disid