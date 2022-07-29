
ALTER DATABASE bd_prueba SET MULTI_USER;
create database bd_prueba;
use bd_prueba;

create table usuarios(
	userId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Login varchar(100),
    Nombre varchar(100),
    Paterno varchar(100),
    Materno varchar(100)
);

create table empleados(
	empleadoId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	userId int,
    Sueldo decimal(18,2),
    FechaIngreso date,
    foreign key (userId) references usuarios(userId) on delete cascade on update cascade
);

delete from usuarios where userId NOT IN (6,7,9,10);
update empleados set Sueldo = Sueldo + Sueldo * 0.1 where FechaIngreso BETWEEN '20000101' AND '20011231';
select Login, Paterno, FechaIngreso, Sueldo from usuarios inner join empleados on empleados.userId = usuarios.userId where Sueldo > 10000 and Paterno like 'T%' order by FechaIngreso asc;

select consulta1.Sueldo as sueldo_menor, consulta2.Sueldo as sueldo_mayor_igual 
from consulta1 full join consulta2 on consulta1.userId = consulta2.userId;

select count(*) as sueldo_menor from consulta1;
select count(*) as sueldo_mayor_igual from consulta2;

/*Prueba 2*/
CREATE PROCEDURE selectTop10 AS SELECT TOP 10 * FROM usuarios GO;
EXEC selectTop10;

CREATE PROCEDURE updateSalario @newSalario decimal(18,2), @userId varchar(100)  
AS UPDATE empleados set Sueldo = @newSalario where userId = @userId;
EXEC updateSalario @newSalario = 1000, @userId = 5;

CREATE PROCEDURE agregarUsuario 
@Login nvarchar(100), @Nombre nvarchar(100), @Paterno nvarchar(100), @Materno nvarchar(100),
@Salario decimal(18,2) 
AS 
BEGIN
DECLARE @idaux int
DECLARE @idemp int
DECLARE @fecha date

SET @idaux = 1 + CONVERT(INT,(SELECT TOP 1 userId FROM usuarios ORDER BY userId DESC));
insert into usuarios values (@Login, @Nombre,@Paterno, @Materno, @idaux);

SET @fecha = CONVERT(DATE,GETDATE());
SET @idemp = 1 + CONVERT(INT,(SELECT TOP 1 empleadoId FROM empleados ORDER BY empleadoId DESC));
insert into empleados values (@Salario, @fecha, @idaux, @idemp);
END

/*
EXEC agregarUsuario @Login = 'user48', @Nombre = 'Carolina', @Paterno = 'Guitérrez', @Materno = 'Hernández', @Salario = 800;

select * from empleados;

drop procedure agregarUsuario;

select * from consultaUsuarios;
*/

CREATE VIEW consultaUsuarios AS
SELECT Login, Nombre, Paterno, Materno, Sueldo, FechaIngreso
FROM usuarios inner join empleados on usuarios.userId = empleados.userId;
 
