Use Farmacia

select * from Productos
select * from bitacoraProductos
go

--DISPARADOR DE INSERTAR--

create trigger TR_ProductosInsertar
on Productos for insert
AS
set nocount on
declare @nombre_producto varchar(max), @precio money
select @nombre_producto = nombre_producto, @precio = precio  from inserted
insert into bitacoraProductos (fecha, nombre_producto, precio, tabla, descripcion)
values(getdate(), @nombre_producto, @precio, 'Productos', 'Registro Insertado')
go

--DISPARADOR DE ELIMINAR--

create trigger TR_ProductosEliminados
on Productos for delete
AS
set nocount on
declare @nombre_producto varchar(max), @precio money
select @nombre_producto = nombre_producto, @precio = precio from deleted
insert into bitacoraProductos (fecha, nombre_producto, precio, tabla, descripcion)
values(getdate(), @nombre_producto, @precio,'Productos', 'Registro Eliminado')
go


--DISPARADOR DE UPGRATE--

create trigger TR_ProductosActualizados
on Productos for update
AS
set nocount on
declare @nombre_producto varchar(max), @precio money
select @nombre_producto = nombre_producto, @precio = precio from inserted
insert into bitacoraProductos (fecha, nombre_producto, precio, tabla, descripcion)
values(getdate(), @nombre_producto, @precio,'Productos', 'Registro Actualizado')
go