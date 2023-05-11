Create database farmacia_v2 

Use Farmacia_v2

--Tabla Categorias--
create table Categorias(
       idcategoria int identity primary key,
       nombre_categoria varchar(50) not null,
);

--Tabla Marcas--
create table Marcas(
       idmarca int identity primary key,
       nombre_marca varchar(50) not null,
);

--Tabla Roles--
create table Roles(
       idrol int identity primary key,
       nombre_rol varchar(50) not null,
);

--Tabla Clientes--
create table Clientes(
       idcliente int identity primary key,
	   idrol int not null,
       nombre_cliente varchar(50) not null,
	   apellido_cliente varchar(50) not null,
       direccion varchar(100) not null,
       telefono varchar(10) not null,
       email varchar(30) not null,
	   contrasena varchar(max) not null,
	   FOREIGN KEY (idrol) REFERENCES Roles (idrol)
);


--Tabla Sucursales--
create table Sucursales(
       idsucursal int identity primary key,
       nombre_sucursal varchar(50) not null,
       direccion varchar(100) not null,
       telefono varchar(10) not null,
       email varchar(30) not null,
);

--Tabla Proveedores--
create table Proveedores(
       idproveedor int identity primary key,
       nombre_proveedor varchar(50) not null,
       direccion varchar(100) not null,
       telefono varchar(10) not null,
       email varchar(30) not null,
);



--Tabla Seguridad2--
create table bitacoraClientes(
       idbitacoracliente int identity primary key,
	   idcliente integer,
       fecha datetime,
	   nombre_cliente varchar(50),
	   apellido_cliente varchar(50),
       telefono varchar(max),
	   tabla varchar(100),
	   descripcion varchar(100),
	   FOREIGN KEY (idcliente) REFERENCES Clientes (idcliente)
);

--Tabla Empleados--
create table Empleados(
       idempleado int identity primary key,
	   idrol int not null,
       nombre_empleado varchar(50) not null,
	   apellido_empleado varchar(50) not null,
       direccion varchar(100) not null,
       telefono varchar(10) not null,
       email varchar(30) not null,
	   puesto varchar(30) not null,
	   contrasena varchar(max) not null,
	   FOREIGN KEY (idrol) REFERENCES Roles (idrol)
);

--Tabla Seguridad3--
create table bitacoraEmpleados(
       idbitacoraempleado int identity primary key,
	   idempleado integer,
       fecha datetime,
       nombre_empleado varchar(50),
	   apellido_empleado varchar(50),
	   puesto varchar(30),
	   tabla varchar(100),
	   descripcion varchar(100),
	   FOREIGN KEY (idempleado) REFERENCES Empleados (idempleado)
);

--Tabla Productos--
create table Productos(
       idproducto int identity primary key,
	   idcategoria integer,
	   idmarca integer,
       nombre_producto varchar(max) not null,
       precio money not null,
       imagen varchar(max),
	   FOREIGN KEY (idcategoria) REFERENCES Categorias (idcategoria),
	   FOREIGN KEY (idmarca) REFERENCES Marcas (idmarca)
);

--Tabla Seguridad4--
create table bitacoraProductos(
       idbitacoraproducto int identity primary key,
	   idproducto integer,
       fecha datetime,
	   nombre_producto varchar(50),
       precio money,
	   tabla varchar(100),
	   descripcion varchar(100),
	   FOREIGN KEY (idproducto) REFERENCES Productos (idproducto)
);

--Tabla Inventarios--
create table Inventarios(
       idinventario int identity primary key,
	   idproducto integer,
	   idsucursal integer,
	   stock int not null,
	   FOREIGN KEY (idproducto) REFERENCES Productos (idproducto),
	   FOREIGN KEY (idsucursal) REFERENCES Sucursales (idsucursal),
);

--Tabla Compras--
create table Compras(
       idcompra int identity primary key,
	   idempleado integer,
	   idproveedor integer,
	   idproducto integer,
	   cantidad int not null,
	   fecha date not null,
	   FOREIGN KEY (idempleado) REFERENCES Empleados (idempleado),
	   FOREIGN KEY (idproveedor) REFERENCES Proveedores (idproveedor),
	   FOREIGN KEY (idproducto) REFERENCES Productos (idproducto)
);

--Tabla Seguridad5--
create table bitacoraCompras(
       idbitacoracompra int identity primary key,
	   idcompra integer,
       fecha datetime,
	   cantidad int,
	   tabla varchar(100),
	   descripcion varchar(100),
	   FOREIGN KEY (idcompra) REFERENCES Compras (idcompra)
);



--Tabla Ventas--
create table Ventas(
       idventa int identity primary key,
	   idempleado integer,
	   idcliente integer,
	   idproducto integer,
	   cantidad int not null,
	   fecha date not null,
	   subtotal money not null,
	   impuestos int not null,
	   total money not null,
	   FOREIGN KEY (idempleado) REFERENCES Empleados (idempleado),
	   FOREIGN KEY (idcliente) REFERENCES Clientes (idcliente),
	   FOREIGN KEY (idproducto) REFERENCES Productos (idproducto)
);

--Tabla Seguridad6--
create table bitacoraVentas(
       idbitacoraventa int identity primary key,
	   idventa integer,
       fecha datetime,
	   cantidad int,
	   subtotal money,
	   impuestos int,
	   total money,
	   tabla varchar(100),
	   descripcion varchar(100),
	   FOREIGN KEY (idventa) REFERENCES Ventas (idventa)
);