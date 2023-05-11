
CREATE PROCEDURE Sp_Roles
  @opcion varchar(30),
  @idrol int = 0,
  @nombre_rol varchar(50) = '',
  @mensaje varchar(100) output,
  @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarRol'
    BEGIN TRY
      INSERT INTO Roles (nombre_rol)
      VALUES (@nombre_rol);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarRoles'
    BEGIN 
      SELECT * FROM Roles;
    END 
  
  IF @opcion = 'ActualizarRol'
    IF EXISTS (SELECT 1 FROM Roles WHERE idrol = @idrol)
      BEGIN 
        UPDATE Roles
        SET nombre_rol = @nombre_rol
        WHERE idrol = @idrol;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarRol'  
    IF EXISTS (SELECT 1 FROM Roles WHERE idrol = @idrol)
      BEGIN 
        DELETE FROM Roles
        WHERE idrol = @idrol;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
