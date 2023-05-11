
CREATE PROCEDURE Sp_Sucursales
  @opcion varchar(30),
  @idsucursal int = 0,
  @nombre_sucursal varchar(50) = '',
  @direccion varchar(100) = '',
  @telefono varchar(10) = '',
  @email varchar(30) = '',
  @mensaje varchar(100) output,
  @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarSucursal'
    BEGIN TRY
      INSERT INTO Sucursales (nombre_sucursal, direccion, telefono, email)
      VALUES (@nombre_sucursal, @direccion, @telefono, @email);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarSucursales'
    BEGIN 
      SELECT * FROM Sucursales;
    END 
  
  IF @opcion = 'ActualizarSucursal'
    IF EXISTS (SELECT 1 FROM Sucursales WHERE idsucursal = @idsucursal)
      BEGIN 
        UPDATE Sucursales
        SET nombre_sucursal = @nombre_sucursal,
            direccion = @direccion,
            telefono = @telefono,
            email = @email
        WHERE idsucursal = @idsucursal;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarSucursal'  
    IF EXISTS (SELECT 1 FROM Sucursales WHERE idsucursal = @idsucursal)
      BEGIN 
        DELETE FROM Sucursales
        WHERE idsucursal = @idsucursal;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
