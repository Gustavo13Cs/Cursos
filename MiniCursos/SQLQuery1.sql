select * from Disciplinas where DISID=''
delete Disciplinas where DISID=''

select * from Disciplinas

select d. *,d.DISDESCRIACAO+' '+d.CURSOID as 'Completo' from Disciplinas d
where ISNUMERIC(d.cursoid)=0

update Disciplinas set DISDESCRIACAO= DISDESCRIACAO+' '+CURSOID where ISNUMERIC (cursoid)=0

update Disciplinas set CURSOID=null where ISNUMERIC(cursoid)=0

 select * from Disciplinas order by CURSOID desc

 update Disciplinas set DISCH= null

 Alter table disciplinas alter column Disid int;
 Alter table disciplinas alter column cursoid int;
 Alter table disciplinas alter column disch int;

 select * from Cursos
 select * from Disciplinas
 create sequence numerarCursoID start with 15 INCREMENT BY 1
 alter table cursos alter column cursoid int not null
 alter table cursos ADD CONSTRAINT seqIDcurso default next value for numerarCursoID for cursoid 
 go
 alter table cursos ADD CONSTRAINT Pk_cusoid PRIMARY KEY (cursoid); 
 Select * from Cursos order by CURSOID DESC
 insert Cursos (CURSODESCRICAO,CURSOCODHABILIDADE,CURSOMODALIDADE) values ('java JAVINHA','QJAVA','doido'
 ALTER table disciplinas add foreign key (cursoid) references cursos(cursoid);