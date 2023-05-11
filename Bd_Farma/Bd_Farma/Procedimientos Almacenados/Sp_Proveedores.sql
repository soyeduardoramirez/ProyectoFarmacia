
CREATE PROCEDURE Sp_Proveedores
  @opcion varchar(30),
  @idproveedor int = 0,
  @nombre_proveedor varchar(50) = '',
  @direccion varchar(100) = '',
  @telefono varchar(10) = '',
  @email varchar(30) = '',
  @mensaje varchar(100) output,
  @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarProveedor'
    BEGIN TRY
      INSERT INTO Proveedores (nombre_proveedor, direccion, telefono, email)
      VALUES (@nombre_proveedor, @direccion, @telefono, @email);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarProveedores'
    BEGIN 
      SELECT * FROM Proveedores;
    END 
  
  IF @opcion = 'ActualizarProveedor'
    IF EXISTS (SELECT 1 FROM Proveedores WHERE idproveedor = @idproveedor)
      BEGIN 
        UPDATE Proveedores
        SET nombre_proveedor = @nombre_proveedor, direccion = @direccion, telefono = @telefono, email = @email
        WHERE idproveedor = @idproveedor;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarProveedor'  
    IF EXISTS (SELECT 1 FROM Proveedores WHERE idproveedor = @idproveedor)
      BEGIN 
        DELETE FROM Proveedores
        WHERE idproveedor = @idproveedor;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
