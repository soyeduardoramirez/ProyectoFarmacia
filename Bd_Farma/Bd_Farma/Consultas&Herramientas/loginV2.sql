create PROCEDURE sp_Login
    @Email VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
		e.idempleado,--agregado
        e.email, 
        r.nombre_rol
    FROM 
        empleados e
        INNER JOIN Roles r ON e.idrol = r.idrol
    WHERE 
        e.Email = @Email AND e.contrasena = @Password
    UNION
    SELECT 
		c.idcliente, --agregado
        c.email, 
        r.nombre_rol
    FROM 
        Clientes c
        INNER JOIN Roles r ON c.idrol = r.idrol
    WHERE 
        c.Email = @Email AND c.contrasena = @Password
	 IF @@ROWCOUNT = 0
    BEGIN
        DECLARE @ErrorMessage NVARCHAR(4000) = 'No se encontró ningún usuario con el correo electrónico y la contraseña proporcionados.'
        RAISERROR(@ErrorMessage, 16, 1)
    END
END
