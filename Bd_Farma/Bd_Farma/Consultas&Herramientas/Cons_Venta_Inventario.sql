
select i.idinventario,p.idproducto,p.nombre_producto, s.idsucursal,s.nombre_sucursal,i.stock
from Inventarios i, Productos p, Sucursales s
where p.idproducto = i.idproducto AND s.idsucursal = i.idsucursal;


Select * from ventas;
select v.idventa,e.idempleado,e.nombre_empleado,e.apellido_empleado,
c.idcliente,c.nombre_cliente,c.apellido_cliente,p.idproducto,p.nombre_producto,
v.cantidad,v.fecha,v.subtotal,v.impuestos,v.total
from ventas v, Empleados e, Clientes c, Productos p
where v.idempleado= e.idempleado AND c.idcliente = v.idcliente AND p.idproducto=v.idproducto;