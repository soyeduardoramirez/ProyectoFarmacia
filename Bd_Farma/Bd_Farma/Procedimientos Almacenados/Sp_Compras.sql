
CREATE PROCEDURE Sp_Compras
  @opcion varchar(30),
  @idcompra int = 0,
  @idempleado integer = null,
  @idproveedor integer = null,
  @idproducto integer = null,
  @cantidad int = 0,
  @fecha date = null,
  @mensaje varchar(100) output,
  @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarCompra'
    BEGIN TRY
      INSERT INTO Compras (idempleado, idproveedor, idproducto, cantidad, fecha)
      VALUES (@idempleado, @idproveedor, @idproducto, @cantidad, @fecha);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarCompras'
    BEGIN 
      SELECT * FROM Compras;
    END 
  
  IF @opcion = 'ActualizarCompra'
    IF EXISTS (SELECT 1 FROM Compras WHERE idcompra = @idcompra)
      BEGIN 
        UPDATE Compras
        SET idempleado = ISNULL(@idempleado, idempleado),
            idproveedor = ISNULL(@idproveedor, idproveedor),
            idproducto = ISNULL(@idproducto, idproducto),
            cantidad = ISNULL(@cantidad, cantidad),
            fecha = ISNULL(@fecha, fecha)
        WHERE idcompra = @idcompra;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarCompra'  
    IF EXISTS (SELECT 1 FROM Compras WHERE idcompra = @idcompra)
      BEGIN 
        DELETE FROM Compras
        WHERE idcompra = @idcompra;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
