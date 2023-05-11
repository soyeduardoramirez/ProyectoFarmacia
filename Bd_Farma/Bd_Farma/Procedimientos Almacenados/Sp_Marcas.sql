
CREATE PROCEDURE Sp_Marcas
  @opcion varchar(30),
  @idmarca int = 0,
  @nombre_marca varchar(50) = '',
  @mensaje varchar(100) output,
  @exito bit output
 
AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarMarca'
    BEGIN TRY
      INSERT INTO Marcas (nombre_marca)
      VALUES (@nombre_marca);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarMarcas'
    BEGIN 
      SELECT * FROM Marcas;
    END 
  
  IF @opcion = 'ActualizarMarca'
    IF EXISTS (SELECT 1 FROM Marcas WHERE idmarca = @idmarca)
      BEGIN 
        UPDATE Marcas
        SET nombre_marca = @nombre_marca
        WHERE idmarca = @idmarca;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarMarca'  
    IF EXISTS (SELECT 1 FROM Marcas WHERE idmarca = @idmarca)
      BEGIN 
        DELETE FROM Marcas
        WHERE idmarca = @idmarca;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
