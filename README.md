# Funcionalidad BD

```sql
CREATE TABLE Pais (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50)
);

CREATE TABLE Region (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50),
    pais_id INT REFERENCES Pais(id)
);

CREATE TABLE Ciudad (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50),
    region_id INT REFERENCES Region(id)
);
-- TIPOS Y TERCEROS
CREATE TABLE tipo_documentos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    descripcion VARCHAR(50)
);

CREATE TABLE tipo_terceros (
    id INT AUTO_INCREMENT PRIMARY KEY,
    descripcion VARCHAR(50)
);


CREATE TABLE terceros (
    id VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(50),
    apellidos VARCHAR(50),
    email VARCHAR(80) UNIQUE,
    tipo_doc_id INT,
    tipo_tercero_id INT,
    ciudad_id INT,
    FOREIGN KEY (tipo_doc_id) REFERENCES tipo_documentos(id),
    FOREIGN KEY (tipo_tercero_id) REFERENCES tipo_terceros(id),
    FOREIGN KEY (ciudad_id) REFERENCES Ciudad(id)
);

CREATE TABLE tercero_telefonos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    numero VARCHAR(20),
    tipo VARCHAR(20),
    tercero_id VARCHAR(20),
    FOREIGN KEY (tercero_id) REFERENCES terceros(id)
);

-- EMPRESA
CREATE TABLE Empresa (
    id VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(50),
    ciudad_id INT,
    fecha_reg DATE,
    FOREIGN KEY (ciudad_id) REFERENCES Ciudad(id)
);

-- EPS y ARL
CREATE TABLE EPS (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50)
);

CREATE TABLE ARL (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50)
);

-- EMPLEADO
CREATE TABLE Empleado (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tercero_id VARCHAR(20),
    fecha_ingreso DATE,
    salario_base DOUBLE,
    eps_id INT,
    arl_id INT,
    FOREIGN KEY (tercero_id) REFERENCES terceros(id),
    FOREIGN KEY (eps_id) REFERENCES EPS(id),
    FOREIGN KEY (arl_id) REFERENCES ARL(id)
);

-- CLIENTE
CREATE TABLE Cliente (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tercero_id VARCHAR(20),
    fecha_nac DATE,
    fecha_ultima_compra DATE,
    FOREIGN KEY (tercero_id) REFERENCES terceros(id)
);

-- PROVEEDOR
CREATE TABLE Proveedor (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tercero_id VARCHAR(20),
    dcto DOUBLE,
    dia_pago INT,
    FOREIGN KEY (tercero_id) REFERENCES terceros(id)
);

-- PRODUCTOS (CAMBIO A VARCHAR)
CREATE TABLE Productos (
    id VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(50),
    stock INT,
    stock_min INT,
    stock_max INT,
    created_at DATE,
    updated_at DATE,
    barcode VARCHAR(50) UNIQUE
);

-- RELACIÓN PRODUCTO - PROVEEDOR
CREATE TABLE Productos_Proveedor (
    producto_id VARCHAR(20),
    tercero_id VARCHAR(20),
    PRIMARY KEY (producto_id, tercero_id),
    FOREIGN KEY (producto_id) REFERENCES Productos(id),
    FOREIGN KEY (tercero_id) REFERENCES terceros(id)
);

-- COMPRAS
CREATE TABLE Compras (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tercero_prov_id VARCHAR(20),
    fecha DATE,
    tercero_empl_id VARCHAR(20),
    desc_compra TEXT,
    FOREIGN KEY (tercero_prov_id) REFERENCES terceros(id),
    FOREIGN KEY (tercero_empl_id) REFERENCES terceros(id)
);

CREATE TABLE Detalle_Compra (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATE,
    producto_id VARCHAR(20),
    cantidad INT,
    valor DOUBLE,
    compra_id INT,
    FOREIGN KEY (producto_id) REFERENCES Productos(id),
    FOREIGN KEY (compra_id) REFERENCES Compras(id)
);

-- VENTAS
CREATE TABLE Venta (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATE,
    tercero_cli_id VARCHAR(20),
    tercero_emp_id VARCHAR(20),
    forma_pago VARCHAR(50),
    FOREIGN KEY (tercero_cli_id) REFERENCES terceros(id),
    FOREIGN KEY (tercero_emp_id) REFERENCES terceros(id)
);

CREATE TABLE Detalle_Venta (
    id INT AUTO_INCREMENT PRIMARY KEY,
    factura_id INT,
    producto_id VARCHAR(20),
    cantidad INT,
    valor DOUBLE,
    FOREIGN KEY (factura_id) REFERENCES Venta(id),
    FOREIGN KEY (producto_id) REFERENCES Productos(id)
);

-- FACTURACIÓN
CREATE TABLE Facturacion (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fecha_resolucion DATE,
    num_inicio INT,
    num_final INT,
    fact_actual INT
);

-- TIPOS DE MOVIMIENTOS Y MOVIMIENTOS DE CAJA
CREATE TABLE tipo_mov_caja (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50),
    tipo VARCHAR(10) -- entrada o salida
);

CREATE TABLE Mov_Caja (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATE,
    tipo_mov_id INT,
    valor DOUBLE,
    concepto TEXT,
    tercero_id VARCHAR(20),
    FOREIGN KEY (tipo_mov_id) REFERENCES tipo_mov_caja(id),
    FOREIGN KEY (tercero_id) REFERENCES terceros(id)
);

-- PLANES Y PLAN_PRODUCTO
CREATE TABLE Planes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50),
    fecha_ini DATE,
    fecha_fin DATE,
    dcto DOUBLE
);

CREATE TABLE Plan_Producto (
    plan_id INT,
    producto_id VARCHAR(20),
    PRIMARY KEY (plan_id, producto_id),
    FOREIGN KEY (plan_id) REFERENCES Planes(id),
    FOREIGN KEY (producto_id) REFERENCES Productos(id)
);

```

# procedures

```sql
DELIMITER //

CREATE PROCEDURE insertar_tercero_y_cliente (
    IN p_tercero_id VARCHAR(20),
    IN p_nombre VARCHAR(50),
    IN p_apellidos VARCHAR(50),
    IN p_email VARCHAR(80),
    IN p_tipo_doc_id INT,
    IN p_tipo_tercero_id INT,
    IN p_ciudad_id INT,
    IN p_fecha_nac DATE,
    IN p_fecha_ultima_compra DATE
)
BEGIN

    INSERT INTO terceros (
        id, nombre, apellidos, email, tipo_doc_id, tipo_tercero_id, ciudad_id
    ) VALUES (
        p_tercero_id, p_nombre, p_apellidos, p_email, p_tipo_doc_id, p_tipo_tercero_id, p_ciudad_id
    );

    INSERT INTO Cliente (
        tercero_id, fecha_nac, fecha_ultima_compra
    ) VALUES (
        p_tercero_id, p_fecha_nac, p_fecha_ultima_compra
    );
END //

DELIMITER ;

DELIMITER //

CREATE PROCEDURE insertar_tercero_y_empleado(
    IN p_id VARCHAR(20),
    IN p_nombre VARCHAR(50),
    IN p_apellidos VARCHAR(50),
    IN p_email VARCHAR(80),
    IN p_tipo_doc_id INT,
    IN p_tipo_tercero_id INT,
    IN p_ciudad_id INT,
    IN p_fecha_ingreso DATE,
    IN p_salario_base DOUBLE,
    IN p_eps_id INT,
    IN p_arl_id INT
)
BEGIN
    INSERT INTO terceros (id, nombre, apellidos, email, tipo_doc_id, tipo_tercero_id, ciudad_id)
    VALUES (p_id, p_nombre, p_apellidos, p_email, p_tipo_doc_id, p_tipo_tercero_id, p_ciudad_id);

    INSERT INTO Empleado (tercero_id, fecha_ingreso, salario_base, eps_id, arl_id)
    VALUES (p_id, p_fecha_ingreso, p_salario_base, p_eps_id, p_arl_id);
END //

DELIMITER ;


DELIMITER $$

CREATE PROCEDURE actualizar_tercero_cliente (
    IN p_id VARCHAR(20),
    IN p_nombre VARCHAR(50),
    IN p_apellidos VARCHAR(50),
    IN p_email VARCHAR(80),
    IN p_tipo_doc_id INT,
    IN p_tipo_tercero_id INT,
    IN p_ciudad_id INT,
    IN p_fecha_nac DATE,
    IN p_fecha_ultima_compra DATE
)
BEGIN
    UPDATE terceros
    SET nombre = p_nombre,
        apellidos = p_apellidos,
        email = p_email,
        tipo_doc_id = p_tipo_doc_id,
        tipo_tercero_id = p_tipo_tercero_id,
        ciudad_id = p_ciudad_id
    WHERE id = p_id;

    UPDATE Cliente
    SET fecha_nac = p_fecha_nac,
        fecha_ultima_compra = p_fecha_ultima_compra
    WHERE tercero_id = p_id;
END$$

DELIMITER ;


DELIMITER $$

CREATE PROCEDURE actualizar_tercero_y_empleado(
    IN p_id VARCHAR(50),
    IN p_nombre VARCHAR(100),
    IN p_apellidos VARCHAR(100),
    IN p_email VARCHAR(100),
    IN p_tipo_doc_id INT,
    IN p_tipo_tercero_id INT,
    IN p_ciudad_id INT,
    IN p_fecha_ingreso DATE,
    IN p_salario_base DOUBLE,
    IN p_eps_id INT,
    IN p_arl_id INT
)
BEGIN

    UPDATE terceros
    SET nombre = p_nombre,
        apellidos = p_apellidos,
        email = p_email,
        tipo_doc_id = p_tipo_doc_id,
        tipo_tercero_id = p_tipo_tercero_id,
        ciudad_id = p_ciudad_id
    WHERE id = p_id;

    UPDATE Empleado
    SET fecha_ingreso = p_fecha_ingreso,
        salario_base = p_salario_base,
        eps_id = p_eps_id,
        arl_id = p_arl_id
    WHERE tercero_id = p_id;
END $$

DELIMITER ;

CREATE PROCEDURE insertar_compra_y_detalle (
    ->     IN p_proveedor_id VARCHAR(50),
    ->     IN p_empleado_id VARCHAR(50),
    ->     IN p_fecha_compra DATE,
    ->     IN p_descripcion VARCHAR(255),
    ->
    ->     IN p_fecha_detalle DATE,
    ->     IN p_producto_id VARCHAR(50),
    ->     IN p_cantidad INT,
    ->     IN p_valor DECIMAL(10,2)
    -> )
    -> BEGIN
    ->     DECLARE last_compra_id INT;
    ->
    ->     -- Insertar en la tabla compras (usando los nombres correctos de columnas)
    ->     INSERT INTO compras (tercero_prov_id, tercero_empl_id, fecha, desc_compra)
    ->     VALUES (p_proveedor_id, p_empleado_id, p_fecha_compra, p_descripcion);
    ->
    ->     -- Obtener el ID de la compra recién insertada
    ->     SET last_compra_id = LAST_INSERT_ID();
    ->
    ->     -- Insertar en la tabla detalle_compra
    ->     INSERT INTO detalle_compra (compra_id, fecha, producto_id, cantidad, valor)
    ->     VALUES (last_compra_id, p_fecha_detalle, p_producto_id, p_cantidad, p_valor);
    -> END$$



DELIMITER //

CREATE PROCEDURE sp_ActualizarCompra(
    IN p_id INT,
    IN p_tercero_prov_id VARCHAR(20),
    IN p_fecha DATE,
    IN p_tercero_empl_id VARCHAR(20),
    IN p_desc_compra TEXT,
    IN p_detalle_fecha DATE,
    IN p_producto_id VARCHAR(20),
    IN p_cantidad INT,
    IN p_valor DOUBLE
)
BEGIN
    -- Actualiza tabla Compras
    UPDATE Compras
    SET 
        tercero_prov_id = p_tercero_prov_id,
        fecha = p_fecha,
        tercero_empl_id = p_tercero_empl_id,
        desc_compra = p_desc_compra
    WHERE id = p_id;

    -- Actualiza tabla Detalle_Compra
    UPDATE Detalle_Compra
    SET
        fecha = p_detalle_fecha,
        producto_id = p_producto_id,
        cantidad = p_cantidad,
        valor = p_valor
    WHERE compra_id = p_id;
END //

DELIMITER ;


DELIMITER $$

CREATE PROCEDURE RegistrarVenta (
    IN p_fecha DATE,
    IN p_cliente VARCHAR(20),
    IN p_empleado VARCHAR(20),
    IN p_forma_pago VARCHAR(50),
    IN p_detalles JSON
)
BEGIN
    DECLARE v_venta_id INT;

    -- Insertar la venta
    INSERT INTO Venta (fecha, tercero_cli_id, tercero_emp_id, forma_pago)
    VALUES (p_fecha, p_cliente, p_empleado, p_forma_pago);

    SET v_venta_id = LAST_INSERT_ID();

    -- Insertar los detalles usando JSON_TABLE
    INSERT INTO Detalle_Venta (factura_id, producto_id, cantidad, valor)
    SELECT 
        v_venta_id,
        detalle.producto_id,
        detalle.cantidad,
        detalle.valor
    FROM JSON_TABLE(
        p_detalles,
        '$[*]' COLUMNS (
            producto_id VARCHAR(20) PATH '$.productoId',
            cantidad INT PATH '$.cantidad',
            valor DOUBLE PATH '$.valor'
        )
    ) AS detalle;
END$$

DELIMITER ;


```

# Inserts

```sql
-- País
INSERT INTO Pais (nombre) VALUES ('Colombia');

-- Región
INSERT INTO Region (nombre, pais_id) VALUES ('Santander', 1);

-- Ciudad
INSERT INTO Ciudad (nombre, region_id) VALUES ('Bucaramanga', 1);

-- Tipos de documentos
INSERT INTO tipo_documentos (descripcion) VALUES ('Cédula de ciudadanía');

-- Tipos de terceros
INSERT INTO tipo_terceros (descripcion) VALUES ('Cliente');

-- Terceros
INSERT INTO terceros (id, nombre, apellidos, email, tipo_doc_id, tipo_tercero_id, ciudad_id)
VALUES ('1234567890', 'Juan', 'Pérez', 'juan.perez@example.com', 1, 1, 1);

-- Teléfonos de terceros
INSERT INTO tercero_telefonos (numero, tipo, tercero_id) 
VALUES ('3001234567', 'Celular', '1234567890');

-- Empresa
INSERT INTO Empresa (id, nombre, ciudad_id, fecha_reg) 
VALUES ('EMP001', 'Empresa S.A.S.', 1, '2024-01-01');

-- EPS
INSERT INTO EPS (nombre) VALUES ('Nueva EPS');

-- ARL
INSERT INTO ARL (nombre) VALUES ('ARL Sura');

-- Empleado
INSERT INTO Empleado (tercero_id, fecha_ingreso, salario_base, eps_id, arl_id) 
VALUES ('1234567890', '2024-02-01', 2000000, 1, 1);

-- Cliente
INSERT INTO Cliente (tercero_id, fecha_nac, fecha_ultima_compra) 
VALUES ('1234567890', '1990-05-10', '2024-05-01');

-- Proveedor
INSERT INTO Proveedor (tercero_id, dcto, dia_pago) 
VALUES ('1234567890', 5.0, 15);

-- Productos
INSERT INTO Productos (id, nombre, stock, stock_min, stock_max, created_at, updated_at, barcode)
VALUES ('PROD001', 'Mouse inalámbrico', 100, 10, 200, '2024-04-01', '2024-05-01', 'ABC123456');

-- Productos_Proveedor
INSERT INTO Productos_Proveedor (producto_id, tercero_id) 
VALUES ('PROD001', '1234567890');

-- Compras
INSERT INTO Compras (tercero_prov_id, fecha, tercero_empl_id, desc_compra) 
VALUES ('1234567890', '2024-05-01', '1234567890', 'Compra de periféricos');

-- Detalle_Compra
INSERT INTO Detalle_Compra (fecha, producto_id, cantidad, valor, compra_id)
VALUES ('2024-05-01', 'PROD001', 50, 25000, 1);

-- Venta
INSERT INTO Venta (fecha, tercero_cli_id, tercero_emp_id, forma_pago)
VALUES ('2024-05-05', '1234567890', '1234567890', 'Efectivo');

-- Detalle_Venta
INSERT INTO Detalle_Venta (factura_id, producto_id, cantidad, valor) 
VALUES (1, 'PROD001', 2, 30000);

-- Facturación
INSERT INTO Facturacion (fecha_resolucion, num_inicio, num_final, fact_actual)
VALUES ('2024-01-01', 1000, 2000, 1001);

-- Tipo de movimientos de caja
INSERT INTO tipo_mov_caja (nombre, tipo) 
VALUES ('Ingreso por ventas', 'entrada');

-- Movimientos de caja
INSERT INTO Mov_Caja (fecha, tipo_mov_id, valor, concepto, tercero_id)
VALUES ('2024-05-05', 1, 60000, 'Venta de productos', '1234567890');

-- Planes
INSERT INTO Planes (nombre, fecha_ini, fecha_fin, dcto)
VALUES ('Descuento Primavera', '2024-04-01', '2024-06-01', 10.0);

-- Plan_Producto
INSERT INTO Plan_Producto (plan_id, producto_id)
VALUES (1, 'PROD001');

```
