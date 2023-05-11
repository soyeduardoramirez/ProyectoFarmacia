
CREATE PROCEDURE Sp_Empleados
  @opcion varchar(30),
  @idempleado int = 0,
  @idrol int = 0,
  @nombre_empleado varchar(50) = '',
  @apellido_empleado varchar(50) = '',
  @direccion varchar(100) = '',
  @telefono varchar(10) = '',
  @email varchar(50) = '',
  @puesto varchar(30) = '',
  @contrasena varchar(max)='',
  @mensaje varchar(100) output,
  @exito bit output
AS
BEGIN
  SET NOCOUNT ON;

  IF @opcion = 'AgregarEmpleado'
    BEGIN TRY
      INSERT INTO Empleados (idrol, nombre_empleado, apellido_empleado, direccion, telefono, email, puesto,contrasena)
      VALUES (@idrol, @nombre_empleado, @apellido_empleado, @direccion, @telefono, @email, @puesto,@contrasena);

      SET @mensaje = 'Registro correcto.'
      SET @exito = 1
    END TRY
    BEGIN CATCH
      SET @mensaje = 'Ocurrio un error'
      SET @exito = 0
    END CATCH
  
  IF @opcion = 'ListarEmpleados'
    BEGIN 
      select * from Empleados;
    END 
  
  IF @opcion = 'ActualizarEmpleado'
    IF EXISTS (SELECT 1 FROM Empleados WHERE idempleado = @idempleado)
      BEGIN 
        UPDATE Empleados
        SET idrol = @idrol, 
            nombre_empleado = @nombre_empleado, 
            apellido_empleado = @apellido_empleado,
            direccion = @direccion,
            telefono = @telefono,
            email = @email,
            puesto = @puesto,
			contrasena=@contrasena
        WHERE idempleado = @idempleado;	

        SET @mensaje = 'Actualizacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
  
  IF @opcion = 'EliminarEmpleado'  
    IF EXISTS (SELECT 1 FROM Empleados WHERE idempleado = @idempleado)
      BEGIN 
        DELETE FROM Empleados
        WHERE idempleado = @idempleado;		

        SET @mensaje = 'Eliminacion correcta.'
        SET @exito = 1
      END 
    ELSE
      BEGIN 
        SET @mensaje = 'Ocurrio un error'
        SET @exito = 0
      END 
END
