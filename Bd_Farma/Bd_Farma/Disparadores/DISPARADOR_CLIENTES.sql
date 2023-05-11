Use Farmacia

select * from Clientes
select * from bitacoraClientes
go

--DISPARADOR DE INSERTAR--

create trigger TR_ClientesInsertar
on Clientes for insert
AS
set nocount on
declare @nombre_cliente varchar(50), @apellido_cliente varchar(50), @telefono varchar(20)
select @nombre_cliente = nombre_cliente, @apellido_cliente = apellido_cliente, @telefono = telefono from inserted
insert into bitacoraClientes (fecha, nombre_cliente, apellido_cliente, telefono, tabla, descripcion)
values(getdate(), @nombre_cliente, @apellido_cliente, @telefono, 'Clientes', 'Registro Insertado')
go

--DISPARADOR DE ELIMINAR--

create trigger TR_ClientesEliminados
on Clientes for delete
AS
set nocount on
declare @nombre_cliente varchar(50), @apellido_cliente varchar(50), @telefono varchar(20)
select @nombre_cliente = nombre_cliente, @apellido_cliente = apellido_cliente, @telefono = telefono from deleted
insert into bitacoraClientes (fecha, nombre_cliente, apellido_cliente, telefono, tabla, descripcion)
values(getdate(), @nombre_cliente, @apellido_cliente, @telefono, 'Clientes', 'Registro Eliminado')
go


--DISPARADOR DE UPGRATE--

create trigger TR_ClientesActualizados
on Clientes for update
AS
set nocount on
declare @nombre_cliente varchar(50), @apellido_cliente varchar(50), @telefono varchar(20)
select @nombre_cliente = nombre_cliente, @apellido_cliente = apellido_cliente, @telefono = telefono from inserted
insert into bitacoraClientes (fecha, nombre_cliente, apellido_cliente, telefono, tabla, descripcion)
values(getdate(), @nombre_cliente, @apellido_cliente, @telefono, 'Clientes', 'Registro Actualizado')
go




