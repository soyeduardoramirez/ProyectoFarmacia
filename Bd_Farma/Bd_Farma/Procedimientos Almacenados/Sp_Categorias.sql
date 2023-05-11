
CREATE PROCEDURE Sp_Categorias
  @opcion varchar(30),
  @idcategoria int = 0,
  @nombre_categoria varchar(50) = '',
  @mensaje varchar(100) output,
  @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarCategoria'
    BEGIN TRY
      INSERT INTO Categorias (nombre_categoria)
      VALUES (@nombre_categoria);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarCategorias'
    BEGIN 
      SELECT * FROM Categorias;
    END 
  
  IF @opcion = 'ActualizarCategoria'
    IF EXISTS (SELECT 1 FROM Categorias WHERE idcategoria = @idcategoria)
      BEGIN 
        UPDATE Categorias
        SET nombre_categoria = @nombre_categoria
        WHERE idcategoria = @idcategoria;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarCategoria'  
    IF EXISTS (SELECT 1 FROM Categorias WHERE idcategoria = @idcategoria)
      BEGIN 
        DELETE FROM Categorias
        WHERE idcategoria = @idcategoria;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
