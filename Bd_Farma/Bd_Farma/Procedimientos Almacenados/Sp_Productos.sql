
CREATE PROCEDURE Sp_Productos
  @opcion varchar(30),
  @idproducto int = 0,
  @idcategoria integer = 0,
  @idmarca integer = 0,
  @nombre_producto varchar(max) = '',
  @precio money = null,
  @imagen varchar(max) = null,
  @mensaje varchar(100) output,
  @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarProducto'
    BEGIN TRY
      INSERT INTO Productos (idcategoria, idmarca, nombre_producto, precio, imagen)
      VALUES (@idcategoria, @idmarca, @nombre_producto, @precio, @imagen);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarProductos'
    BEGIN 
      select p.idproducto, c.nombre_categoria,c.idcategoria, m.nombre_marca,m.idmarca, p.nombre_producto, precio, imagen
		from Productos p, Categorias c, Marcas m
		where c.idcategoria = p.idcategoria AND m.idmarca = p.idmarca 
    END 
  
  IF @opcion = 'ActualizarProducto'
    IF EXISTS (SELECT 1 FROM Productos WHERE idproducto = @idproducto)
      BEGIN 
        UPDATE Productos
        SET idcategoria = @idcategoria,
            idmarca = @idmarca,
            nombre_producto = @nombre_producto, 
            precio = @precio,
            imagen = @imagen
        WHERE idproducto = @idproducto;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarProducto'  
    IF EXISTS (SELECT 1 FROM Productos WHERE idproducto = @idproducto)
      BEGIN 
        DELETE FROM Productos
        WHERE idproducto = @idproducto;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
