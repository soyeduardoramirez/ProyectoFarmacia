
CREATE PROCEDURE Sp_Clientes
  @opcion varchar(30),
  @idcliente int = 0,
  @idrol int=0,
  @nombre_cliente varchar(50) = '',
  @apellido_cliente varchar(50) = '',
  @direccion varchar(20) = '',
  @telefono varchar(10) = '',
  @email varchar(30) = '',
  @contrasena varchar(max)='',
  @mensaje varchar(100) output,
  @exito bit output

AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarCliente'
    BEGIN TRY
      INSERT INTO Clientes (idrol,nombre_cliente, apellido_cliente, direccion, telefono,email,contrasena)
      VALUES (@idrol,@nombre_cliente, @apellido_cliente, @direccion, @telefono, @email,@contrasena);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarClientes'
    BEGIN 
      SELECT * FROM Clientes;
    END 
  
  IF @opcion = 'ActualizarCliente'
    IF EXISTS (SELECT 1 FROM Clientes WHERE idcliente = @idcliente)
      BEGIN 
        UPDATE Clientes
        SET idrol = @idrol,
			nombre_cliente = @nombre_cliente, 
            apellido_cliente = @apellido_cliente,
            direccion = @direccion,
            telefono = @telefono,
            email = @email,
			contrasena=@contrasena
        WHERE idcliente = @idcliente;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarCliente'  
    IF EXISTS (SELECT 1 FROM Clientes WHERE idcliente = @idcliente)
      BEGIN 
        DELETE FROM Clientes
        WHERE idcliente = @idcliente;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END

