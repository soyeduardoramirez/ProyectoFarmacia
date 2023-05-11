
CREATE PROCEDURE Sp_Ventas
    @opcion varchar(30), 
    @idventa int = 0, 
    @idempleado integer = null, 
    @idcliente integer = null, 
    @idproducto integer = null, 
    @cantidad int = null, 
    @fecha date = null, 
    @subtotal money = null, 
    @impuestos int = null,
    @total money = null,
    @mensaje varchar(100) output, 
    @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarVenta'
    BEGIN TRY
      BEGIN TRANSACTION;
      
      INSERT INTO Ventas (idempleado, idcliente, idproducto, cantidad, fecha, subtotal, impuestos, total)
      VALUES (@idempleado, @idcliente, @idproducto, @cantidad, @fecha, @subtotal, @impuestos, @total);

      UPDATE Inventarios
      SET stock = stock - @cantidad
      WHERE idproducto = @idproducto;

      COMMIT TRANSACTION;
      
       SET @mensaje = 'Registro correcto.'
       SET @exito = 1
    END TRY
    BEGIN CATCH
       ROLLBACK TRANSACTION;
       SET @mensaje = 'Ocurrio un error'
       SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarVentas'
    BEGIN 
		select v.idventa,e.idempleado,e.nombre_empleado,e.apellido_empleado,
		c.idcliente,c.nombre_cliente,c.apellido_cliente,p.idproducto,p.nombre_producto,
		v.cantidad,v.fecha,v.subtotal,v.impuestos,v.total
		from ventas v, Empleados e, Clientes c, Productos p
		where v.idempleado= e.idempleado AND c.idcliente = v.idcliente AND p.idproducto=v.idproducto;
    END 
  
  IF @opcion = 'ActualizarVenta'
    IF EXISTS (SELECT 1 FROM Ventas WHERE idventa = @idventa)
      BEGIN 
        UPDATE Ventas
        SET idempleado = ISNULL(@idempleado, idempleado),
            idcliente = ISNULL(@idcliente, idcliente),
            idproducto = ISNULL(@idproducto, idproducto),
            cantidad = ISNULL(@cantidad, cantidad),
            fecha = ISNULL(@fecha, fecha),
            subtotal = ISNULL(@subtotal, subtotal),
            impuestos = ISNULL(@impuestos, impuestos),
            total = ISNULL(@total, total)
        WHERE idventa = @idventa;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarVenta'  
    IF EXISTS (SELECT 1 FROM Ventas WHERE idventa = @idventa)
      BEGIN 
        DELETE FROM Ventas
        WHERE idventa = @idventa;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
