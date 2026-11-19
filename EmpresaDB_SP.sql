CREATE DATABASE EmpresaDB;
GO

USE EmpresaDB;
GO

CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    CorreoElectronico NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Pedidos (
    PedidoID INT PRIMARY KEY IDENTITY(1,1),
    FechaPedido DATE NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    ClienteID INT NOT NULL,
    CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY (ClienteID)
        REFERENCES Clientes(ClienteID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
GO

INSERT INTO Clientes (Nombre, CorreoElectronico)
VALUES
('María Pérez', 'maria.perez@example.com'),
('Juan Torres', 'juan.torres@example.com'),
('Lucía Ramírez', 'lucia.ramirez@example.com');
GO

INSERT INTO Pedidos (FechaPedido, Monto, Estado, ClienteID)
VALUES
('2025-04-01', 150.00, 'Pendiente', 1),
('2025-04-02', 300.50, 'Entregado', 1),
('2025-04-03', 75.25, 'Cancelado', 2),
('2025-04-04', 500.00, 'Pendiente', 3);
GO

CREATE PROCEDURE sp_ListarClientes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ClienteID, Nombre, CorreoElectronico
    FROM Clientes
    ORDER BY ClienteID;
END
GO

CREATE PROCEDURE sp_ObtenerClientePorId
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ClienteID, Nombre, CorreoElectronico
    FROM Clientes
    WHERE ClienteID = @ClienteID;
END
GO

CREATE PROCEDURE sp_InsertarCliente
    @Nombre NVARCHAR(100),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Clientes (Nombre, CorreoElectronico)
    VALUES (@Nombre, @CorreoElectronico);
END
GO

CREATE PROCEDURE sp_ActualizarCliente
    @ClienteID INT,
    @Nombre NVARCHAR(100),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Clientes
    SET Nombre = @Nombre,
        CorreoElectronico = @CorreoElectronico
    WHERE ClienteID = @ClienteID;
END
GO

CREATE PROCEDURE sp_ListarPedidos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PedidoID, FechaPedido, Monto, Estado, ClienteID
    FROM Pedidos
    ORDER BY PedidoID;
END
GO

CREATE PROCEDURE sp_ObtenerPedidoPorId
    @PedidoID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PedidoID, FechaPedido, Monto, Estado, ClienteID
    FROM Pedidos
    WHERE PedidoID = @PedidoID;
END
GO

CREATE PROCEDURE sp_InsertarPedido
    @FechaPedido DATE,
    @Monto DECIMAL(10,2),
    @Estado NVARCHAR(50),
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Pedidos (FechaPedido, Monto, Estado, ClienteID)
    VALUES (@FechaPedido, @Monto, @Estado, @ClienteID);
END
GO

CREATE PROCEDURE sp_ActualizarPedido
    @PedidoID INT,
    @FechaPedido DATE,
    @Monto DECIMAL(10,2),
    @Estado NVARCHAR(50),
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Pedidos
    SET FechaPedido = @FechaPedido,
        Monto = @Monto,
        Estado = @Estado,
        ClienteID = @ClienteID
    WHERE PedidoID = @PedidoID;
END
GO
