
CREATE PROCEDURE Sp_Inventarios
  @opcion varchar(30),
  @idinventario int = 0,
  @idproducto int = 0,
  @idsucursal int = 0,
  @stock int = 0,
  @mensaje varchar(100) output,
  @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarInventario'
    BEGIN TRY
      INSERT INTO Inventarios (idproducto, idsucursal, stock)
      VALUES (@idproducto, @idsucursal, @stock);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarInventarios'
    BEGIN 
		select i.idinventario,p.idproducto,p.nombre_producto, s.idsucursal,s.nombre_sucursal,i.stock
		from Inventarios i, Productos p, Sucursales s
		where p.idproducto = i.idproducto AND s.idsucursal = i.idsucursal;
    END 
  
  IF @opcion = 'ActualizarInventario'
    IF EXISTS (SELECT 1 FROM Inventarios WHERE idinventario = @idinventario)
      BEGIN 
        UPDATE Inventarios
        SET idproducto = @idproducto, 
            idsucursal = @idsucursal,
            stock = @stock
        WHERE idinventario = @idinventario;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarInventario'  
    IF EXISTS (SELECT 1 FROM Inventarios WHERE idinventario = @idinventario)
      BEGIN 
        DELETE FROM Inventarios
        WHERE idinventario = @idinventario;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
