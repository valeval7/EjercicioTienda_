CREATE DATABASE Tienda;
USE Tienda;

CREATE TABLE Datos(
IdProducto INT AUTO_INCREMENT PRIMARY KEY,
Nombre VARCHAR(150),
Descripcion VARCHAR (250),
Precio DOUBLE);

DELIMITER //
CREATE PROCEDURE p_Agregar
(
   IN _IdProducto INT,
   IN _Nombre VARCHAR(150),
   IN _Descripcion VARCHAR(200),
   IN _Precio DOUBLE
)
BEGIN
DECLARE existe INT;
   SELECT COUNT(*) INTO existe FROM datos WHERE IdProducto=_IdProducto;
   IF existe = 0 THEN 
   INSERT INTO datos (IdProducto, Nombre, Descripcion, Precio) VALUES(_IdProducto, _Nombre, _Descripcion, _Precio);
	END IF;
END;
//

CALL p_Agregar(NULL, 'Coca-Cola', 'Refresco de 3L', 36.0);

DELIMITER //
CREATE PROCEDURE p_Eliminar
(
   IN _IdProducto INT
)
BEGIN
   DELETE FROM datos WHERE IdProducto=_IdProducto;
END;
//

CALL p_Eliminar(1);
CALL p_Agregar(NULL, 'Coca-Cola', 'Refresco de 3L', 36.0);

DELIMITER //
CREATE PROCEDURE p_Modificar
(
   IN _IdProducto INT,
   IN _Nombre VARCHAR(150),
   IN _Descripcion VARCHAR(200),
   IN _Precio DOUBLE
)
BEGIN 
  UPDATE Datos 
  SET
  Nombre=_Nombre,
  Descripcion= _Descripcion,
  Precio=_Precio
  WHERE IdProducto=_IdProducto;
END;
//

CALL p_Modificar(2, 'Coca-Cola', 'Refresco de 2L', 32.0);
