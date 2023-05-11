USE [farmacia_v2]
GO

DECLARE	@return_value int,
		@mensaje varchar(100),
		@exito bit

EXEC	@return_value = [dbo].[Sp_Ventas]
		@opcion = N'agregarVenta',
		@idempleado = 2,
		@idcliente = 2,
		@idproducto = 2,
		@cantidad = 1,
		@fecha = '20230323',
		@subtotal = 380,
		@impuestos = 1,
		@total = 380,
		@mensaje = @mensaje OUTPUT,
		@exito = @exito OUTPUT

SELECT	@mensaje as N'@mensaje',
		@exito as N'@exito'

SELECT	'Return Value' = @return_value

GO
