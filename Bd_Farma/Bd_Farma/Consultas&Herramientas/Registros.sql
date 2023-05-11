insert into Categorias (nombre_categoria)
values ('Farmacéutica');

insert into Categorias (nombre_categoria)
values ('Salud y cuidado personal');

insert into Categorias (nombre_categoria)
values ('Cuidado de la salud');

insert into Categorias (nombre_categoria)
values ('Alimentación y bebidas');

insert into Categorias (nombre_categoria)
values ('Cuidado bucal');

insert into Categorias (nombre_categoria)
values ('Cuidado personal y del hogar');

insert into Categorias (nombre_categoria)
values ('Bebes');
/*==============================================================================================================================*/
insert into Marcas (nombre_marca)
values ('Pfizer');

insert into Marcas (nombre_marca)
values ('GSK');

insert into Marcas (nombre_marca)
values ('Sanofi');

insert into Marcas (nombre_marca)
values ('Novartis');

insert into Marcas (nombre_marca)
values ('Bayer');

insert into Marcas (nombre_marca)
values ('Johnson & Johnson');

insert into Marcas (nombre_marca)
values ('Novartis');

insert into Marcas (nombre_marca)
values ('Abbott');

insert into Marcas (nombre_marca)
values ('Nestle');

insert into Marcas (nombre_marca)
values ('Colgate');

insert into Marcas (nombre_marca)
values ('Palmolive');

insert into Marcas (nombre_marca)
values ('Procter & Gamble');

insert into Marcas (nombre_marca)
values ('Bausch Health');

insert into Marcas (nombre_marca)
values ('Prestige Consumer Healthcare');

insert into Marcas (nombre_marca)
values ('Chattem');

insert into Marcas (nombre_marca)
values ('Reckitt Benckiser');

/*==============================================================================================================================*/
insert into Roles (nombre_rol)
values ('Administrador');

insert into Roles (nombre_rol)
values ('Empleado');

insert into Roles (nombre_rol)
values ('Cliente');
/*==============================================================================================================================*/
insert into Sucursales (nombre_sucursal, direccion, telefono, email)
values ('Farmacia San Juan', 'Calle 5, No. 123', '5512345678', 'info@farmaciasanjuan.com'),
       ('Farmacia López', 'Avenida 7, No. 456', '5523456789', 'info@farmacialopez.com'),
       ('Farmacia Guadalajara', 'Calle 9, No. 789', '5534567890', 'info@farmaciaguadalajara.com'),
       ('Farmacia del Ahorro', 'Avenida 12, No. 345', '5545678901', 'info@farmaciadelahorro.com'),
		('Farmacia Roma', 'Calle 20, No. 567', '5678901210', 'info@farmaciaroma.com'),
       ('Farmacia Moderna', 'Avenida 25, No. 789', '6789012310', 'info@farmaciamoderna.com'),
       ('Farmacia del Bosque', 'Calle 30, No. 901', '7890123409', 'info@farmaciadelbosque.com');

/*==============================================================================================================================*/


insert into Proveedores (nombre_proveedor, direccion, telefono, email)
values 
('McKesson Corporation', 'StreetSanFranciscoCA', '4159838300', 'info@mckesson.com'),
('AmerisourceBergen Corporation', '1300 Morris Drive, Chesterbrook, PA 19087', '6107277000', 'info@amerisourcebergen.com'),
('Cardinal Health', '7000 Cardinal Place, Dublin, OH 43017', '6147575000', 'info@cardinalhealth.com'),
('Morris & Dickson Co., LLC.', '510 E. 18th Street, Shreveport, LA 71101', '3182228711', 'info@morrisdickson.com'),
('Sysco Corporation', '1390 Enclave Parkway, Houston, TX 77077', '2815841390', 'info@sysco.com'),
('Performance Food Group', '12500 West Creek Parkway, Richmond, VA 23238', '8044847700', 'info@pfgc.com'),
('US Foods Holding Corp.', '9399 West Higgins Road, Suite 500, Rosemont, IL 60018', '8477208000', 'info@usfoods.com'),
('Univar Solutions', '3075 Highland Parkway, Suite 200, Downers Grove, IL 60515', '8448767272', 'info@univarsolutions.com'),
('Brenntag North America', '5083 Pottsville Pike, Reading, PA 19605', '6109266100', 'info@brenntag.com'),
('Nexeo Solutions', '3 Waterway Square Place, Suite 1000, The Woodlands, TX 77380', '2812970700', 'info@nexeosolutions.com');
/*==============================================================================================================================*/
insert into Empleados (nombre_empleado, apellido_empleado, direccion, telefono, email, puesto,contrasena,idrol)
values 
('Jesus', 'De Coss Fernádez', 'Calle 1, No. 200', '9687695400', 'JescoSS3@gmail.com','Gerente','jesus10',1),
('Eduardo', 'Ramirez Rivera', 'Avenida 14, No. 03', '9613547490', 'Eduardorami@gmail.com', 'Gerente','micontra123',1),
('Isaac', 'Ocampo Mendez', 'Avenida 220, No. 550', '9619093610', 'IsaOcame@gmail.com', 'Farmacéutico','isakmpo4',2),
('Juan', 'García López', 'Avenida 14, No. 567', '9688901234', 'juangalop@gmail.com', 'Cajero','generico1',2),
('Laura', 'Martínez Díaz', 'Calle 10, No. 456', '9619012345', 'lauramardiaz@gmail.com', 'Repartidora','generico1',2),
('Pedro', 'Hernández Ramírez', 'Avenida 14, No. 567', '9681234567', 'pedherram@gmail.com', 'Farmacéutico','generico1',2),
('Mónica', 'González Cruz', 'Calle 11, No. 123', '9612345678', 'monigonzcruz@gmail.com', 'Cajera','generico1',2),
('Miguel', 'Castro Santos', 'Calle 9, No. 234', '9613456789', 'migcasan@gmail.com', 'Repartidor','generico1',2),
('Fernanda', 'Pérez López', 'Avenida 14, No. 567', '9684567890', 'ferperlop@gmail.com', 'Farmacéutica','generico1',2);
/*==============================================================================================================================*/

insert into Clientes (nombre_cliente, apellido_cliente, direccion, telefono, email,contrasena,idrol)
values ('Juan', 'Pérez', 'Calle 12, No. 345', '9612345678', 'juanperez@gmail.com','mipass123',3),
       ('María', 'García', 'Avenida 5, No. 678', '9683456789', 'mariagarcia@gmail.com','mipass124',3),
	   ('Yuli Belen', 'Molina Salgado', 'Calle 8, No. 120', '9618821294', 'yuli.be@gmail.com','mipass125',3),
       ('Pedro', 'Martínez', 'Calle 7, No. 890', '9614567890', 'pedromartinez@gmail.com','mipass126',3),
		('Ana', 'López', 'Calle 9, No. 234', '9615678901', 'anlopez@gmail.com','mipass127',3),
       ('Jorge', 'Hernández', 'Avenida 14, No. 567', '9686789012', 'jorhernandez@gmail.com','mipass128',3),
       ('Sofía', 'Ruiz', 'Calle 11, No. 123', '9617890123', 'sofia.ruiz@gmail.com','mipass193',3);
/*==============================================================================================================================*/
insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (7,7,'Augmentin', '380.00', 'https://www.farmalisto.com.mx/79009-large_default/comprar-augmentin-es-600-mg-429-mg-5-ml-frasco-en-polvo-para-50-ml-rx2-antibiotico-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (7,6,'Aderogyl', '138.00', 'https://www.farmalisto.com.mx/94643-large_default/comprar-aderogyl-solucion-3-ml-con-5-ampolletas-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (7,7,'Voltarén', '524.00', 'https://www.farmalisto.com.mx/95874-large_default/voltaren-50-con-50-mg-caja-con-30-tabletas.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (7,8,'Aspirina', '16.79', 'https://www.farmalisto.com.mx/105935-large_default/comprar-aspirina-500-mg-caja-con-10-tabletas-masticables-precio.jpg');

/**/
insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (2,6,'TALCO JOHNSON BABY', '69.60', 'https://www.farmalisto.com.mx/100068-large_default/talco-johnson-baby-200-g.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (7,13,'FRM-Ensure', '339.00', 'https://www.farmalisto.com.mx/100390-large_default/comprar-ensure-tarro-lata-con-400-g-sabor-a-chocolate-suplemento-alimenticio-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (7,16,'Nan 3 OptimalPro', '135.00', 'https://www.farmalisto.com.mx/104560-large_default/comprar-nan-3-optipro-lata-con-polvo-de-400-g-formulas-infantiles-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (5,10,'Colgate Total 12', '102.45', 'https://www.farmalisto.com.mx/101707-large_default/comprar-colgate-total-12-h-clean-mint-caja-con-tubo-con-195-g-limpieza-bucal-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (2,11,'Palmolive Optims 4 Shampoo', '56.00', 'https://www.farmalisto.com.mx/84555-large_default/comprar-palmolive-optims-4-shampoo-extra-intensivo-2-en-1-frasco-con-400-ml-aseo-personal-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (2,15,'OLD SPICE 145ml', '34.80', 'https://www.farmalisto.com.mx/82225-large_default/comprar-old-spice-fiji-aerosol-con-145-ml-spray-corporal-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (5,16,'Vantal Bucofaríngeo', '234.00', 'https://www.farmalisto.com.mx/96511-large_default/vantal-bucofaringeo-solucion-frasco-con-360-ml.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (1,2,'Gavindo', '1,198.00', 'https://www.farmalisto.com.mx/106668-large_default/comprar-gavindo-n-caja-con-30-capsulas-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (2,15,'Old Spice Desodorante', '46.54', 'https://www.farmalisto.com.mx/102444-large_default/comprar-old-spice-desodorante-en-aerosol-showtime-96g-precio.jpg');

insert into Productos (idcategoria,idmarca,nombre_producto, precio, imagen)
values (6,14,'Lysol Gel Antibacterial', '56.00', 'https://www.farmalisto.com.mx/105701-large_default/lysol-gel-antibacterial-para-manos-envase-con-200-ml.jpg');
/*==============================================================================================================================*/
insert into Inventarios(idproducto,idsucursal,stock)
values (1,1,30);
insert into Inventarios(idproducto,idsucursal,stock)
values (2,2,20);
insert into Inventarios(idproducto,idsucursal,stock)
values (3,3,15);
insert into Inventarios(idproducto,idsucursal,stock)
values (15,4,25);
insert into Inventarios(idproducto,idsucursal,stock)
values (16,5,30);
insert into Inventarios(idproducto,idsucursal,stock)
values (17,6,30);
insert into Inventarios(idproducto,idsucursal,stock)
values (18,7,10);
insert into Inventarios(idproducto,idsucursal,stock)
values (19,1,15);
insert into Inventarios(idproducto,idsucursal,stock)
values (20,2,20);
insert into Inventarios(idproducto,idsucursal,stock)
values (21,3,20);
insert into Inventarios(idproducto,idsucursal,stock)
values (22,4,25);
insert into Inventarios(idproducto,idsucursal,stock)
values (23,5,25);
insert into Inventarios(idproducto,idsucursal,stock)
values (24,6,15);
insert into Inventarios(idproducto,idsucursal,stock)
values (24,7,10);
/*==============================================================================================================================*/
