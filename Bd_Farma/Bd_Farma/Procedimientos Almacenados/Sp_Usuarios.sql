
CREATE PROCEDURE Sp_Usuarios
    @opcion varchar(30),
    @idusuario int = 0,
    @idrol integer = 0,
    @nombre_usuario varchar(50) = '',
    @contrasena varchar(max) = '',
    @mensaje varchar(100) output,
    @exito bit output

AS
BEGIN
    SET NOCOUNT ON;
	
    IF @opcion = 'AgregarUsuario'	
        BEGIN TRY
            INSERT INTO Usuarios (idrol, nombre_usuario, contrasena)
            VALUES (@idrol, @nombre_usuario, @contrasena);

            SET @mensaje = 'Registro correcto.'
            SET @exito = 1
        END TRY
        BEGIN CATCH
            SET @mensaje = 'Ocurrió un error'
            SET @exito = 0
        END CATCH
		
    IF @opcion = 'ListarUsuarios'
        BEGIN 
            SELECT * FROM Usuarios;
        END 
    
    IF @opcion = 'ActualizarUsuario'
        IF EXISTS (SELECT 1 FROM Usuarios WHERE idusuario = @idusuario)
            BEGIN 
                UPDATE Usuarios
                SET idrol = @idrol,
                    nombre_usuario = @nombre_usuario,
                    contrasena = @contrasena
                WHERE idusuario = @idusuario;	

                SET @mensaje = 'Actualización correcta.'
                SET @exito = 1
            END 
            ELSE
            BEGIN 
                SET @mensaje = 'Ocurrió un error'
                SET @exito = 0
            END 
		
    IF @opcion = 'EliminarUsuario'
        IF EXISTS (SELECT 1 FROM Usuarios WHERE idusuario = @idusuario)
            BEGIN 
                DELETE FROM Usuarios
                WHERE idusuario = @idusuario;		

                SET @mensaje = 'Eliminación correcta.'
                SET @exito = 1
            END 
            ELSE
            BEGIN 
                SET @mensaje = 'Ocurrió un error'
                SET @exito = 0
            END 
		
END
