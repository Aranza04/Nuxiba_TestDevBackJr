drop database if exists bd_test;
create database bd_test;
use bd_test;

SET SQL_SAFE_UPDATES = 0;

create table usuarios(
	userId int primary key auto_increment,
    Login varchar(100),
    Nombre varchar(100),
    Paterno varchar(100),
    Materno varchar(100)
);

create table empleados(
	userId int primary key auto_increment,
    Sueldo double,
    FechaIngreso date,
    foreign key (userId) references usuarios(userId) on delete cascade on update cascade
);

select * from usuarios;
select * from empleados;

delete from usuarios where userId NOT IN (6,7,9,10);
update empleados set Sueldo = Sueldo + Sueldo * 0.1 where FechaIngreso BETWEEN '20000101' AND '20011231';
select Login, Paterno, FechaIngreso, Sueldo from usuarios inner join empleados on empleados.userId = usuarios.userId where Sueldo > 10000 and Paterno like 'T%' order by FechaIngreso asc;

create view consulta1 as select Paterno, Sueldo from usuarios inner join empleados on empleados.userId = usuarios.userId where Sueldo < 1200;
select * from consulta1;
create view consulta2 as select Paterno, Sueldo from usuarios inner join empleados on empleados.userId = usuarios.userId where Sueldo > 1199;
select * from consulta2;
select count(*) as total_menor_1200 from consulta1;
select count(*) as total_mayor_1200 from consulta2;

