-- Crear la base de datos
CREATE DATABASE Inventario;
GO

-- Usar la base de datos recién creada
USE Inventario;
GO

-- Crear tabla para productos
CREATE TABLE Productos (
    ProductoId UNIQUEIDENTIFIER PRIMARY KEY, 
    Nombre VARCHAR(100) NOT NULL,          
    Descripcion TEXT,                   
    Categoria VARCHAR(50),               
    Imagen VARCHAR(255),                 
    Precio DECIMAL(10, 2),              
    StockCantidad INT,                   
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE() 
);

-- Crear tabla para inventarios
CREATE TABLE Transacciones (
    TransaccionId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Fecha DATETIME DEFAULT GETDATE(),                          
    TipoTransaccion VARCHAR(10) CHECK (TipoTransaccion IN ('compra', 'venta')), 
    ProductoId UNIQUEIDENTIFIER NOT NULL,                      
    Cantidad INT CHECK (Cantidad > 0) NOT NULL,                
    PrecioUnitario DECIMAL(10, 2) CHECK (PrecioUnitario > 0) NOT NULL, 
    PrecioTotal AS (Cantidad * PrecioUnitario) PERSISTED,      
    Detalle TEXT NULL,                                         
    FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId) 
);