Use Farmacia

select * from Ventas
select * from bitacoraVentas
go

--DISPARADOR DE INSERTAR--

create trigger TR_VentasInsertar
on Ventas for insert
AS
set nocount on
declare @cantidad int, @subtotal money, @impuestos int, @total money
select @cantidad = cantidad, @subtotal = subtotal, @impuestos = impuestos, @total = total from inserted
insert into bitacoraVentas (fecha, cantidad, subtotal, impuestos, total,  tabla, descripcion)
values(getdate(), @cantidad, @subtotal, @impuestos, @total, 'Ventas', 'Registro Insertado')
go

--DISPARADOR DE ELIMINAR--

create trigger TR_VentasEliminados
on Ventas for delete
AS
set nocount on
declare @cantidad int, @subtotal money, @impuestos int, @total money
select @cantidad = cantidad, @subtotal = subtotal, @impuestos = impuestos, @total = total from deleted
insert into bitacoraVentas (fecha, cantidad, subtotal, impuestos, total,  tabla, descripcion)
values(getdate(), @cantidad, @subtotal, @impuestos, @total, 'Ventas', 'Registro Eliminado')
go

--DISPARADOR DE UPGRATE--

create trigger TR_VentasActualizados
on Ventas for update
AS
set nocount on
declare @cantidad int, @subtotal money, @impuestos int, @total money
select @cantidad = cantidad, @subtotal = subtotal, @impuestos = impuestos, @total = total from inserted
insert into bitacoraVentas (fecha, cantidad, subtotal, impuestos, total,  tabla, descripcion)
values(getdate(), @cantidad, @subtotal, @impuestos, @total, 'Ventas', 'Registro Actualizado')
go
