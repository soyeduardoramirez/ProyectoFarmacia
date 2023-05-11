Use Farmacia

select * from Empleados
select * from bitacoraEmpleados
go

--DISPARADOR DE INSERTAR--

create trigger TR_EmpleadosInsertar
on Empleados for insert
AS
set nocount on
declare @nombre_empleado varchar(50), @apellido_empleado varchar(50), @puesto varchar(50)
select @nombre_empleado = nombre_empleado, @apellido_empleado = apellido_empleado, @puesto = puesto from inserted
insert into bitacoraEmpleados (fecha, nombre_empleado, apellido_empleado, puesto, tabla, descripcion)
values(getdate(), @nombre_empleado, @apellido_empleado, @puesto, 'Empleados', 'Registro Insertado')
go

--DISPARADOR DE ELIMINAR--

create trigger TR_EmpleadosEliminados
on Empleados for delete
AS
set nocount on
declare @nombre_empleado varchar(50), @apellido_empleado varchar(50), @puesto varchar(50)
select @nombre_empleado = nombre_empleado, @apellido_empleado = apellido_empleado, @puesto = puesto from deleted
insert into bitacoraEmpleados (fecha, nombre_empleado, apellido_empleado, puesto, tabla, descripcion)
values(getdate(), @nombre_empleado, @apellido_empleado, @puesto, 'Empleados', 'Registro Eliminado')
go

--DISPARADOR DE UPGRATE--

create trigger TR_EmpleadosActualizados
on Empleados for update
AS
set nocount on
declare @nombre_empleado varchar(50), @apellido_empleado varchar(50), @puesto varchar(50)
select @nombre_empleado = nombre_empleado, @apellido_empleado = apellido_empleado, @puesto = puesto from inserted
insert into bitacoraEmpleados (fecha, nombre_empleado, apellido_empleado, puesto, tabla, descripcion)
values(getdate(), @nombre_empleado, @apellido_empleado, @puesto, 'Empleados', 'Registro Actualizado')
go


