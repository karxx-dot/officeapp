-- OfficeDb: script de base de datos (schemas HR, Inventory, Operations, Documents)
IF DB_ID('OfficeDb') IS NULL CREATE DATABASE OfficeDb;
GO
USE OfficeDb;
GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'HR') EXEC('CREATE SCHEMA [HR]');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'Inventory') EXEC('CREATE SCHEMA [Inventory]');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'Operations') EXEC('CREATE SCHEMA [Operations]');
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'Documents') EXEC('CREATE SCHEMA [Documents]');
GO

CREATE TABLE [HR].[Departments] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Departments] PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(300) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE [HR].[Positions] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Positions] PRIMARY KEY,
    [Title] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(300) NULL,
    [MinSalary] DECIMAL(18,2) NOT NULL,
    [MaxSalary] DECIMAL(18,2) NOT NULL
);
GO

CREATE TABLE [HR].[Employees] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Employees] PRIMARY KEY,
    [FirstName] NVARCHAR(80) NOT NULL,
    [LastName] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(150) NOT NULL,
    [Phone] NVARCHAR(30) NULL,
    [HireDate] DATETIME2 NOT NULL,
    [Salary] DECIMAL(18,2) NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    [DepartmentId] INT NOT NULL,
    [PositionId] INT NOT NULL,
    [ManagerId] INT NULL,
    CONSTRAINT [FK_Employees_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [HR].[Departments]([Id]),
    CONSTRAINT [FK_Employees_PositionId] FOREIGN KEY ([PositionId]) REFERENCES [HR].[Positions]([Id]),
    CONSTRAINT [FK_Employees_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [HR].[Employees]([Id]),
    CONSTRAINT [UQ_Employees_Email] UNIQUE ([Email])
);
GO

CREATE TABLE [HR].[Attendances] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Attendances] PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [CheckIn] DATETIME2 NOT NULL,
    [CheckOut] DATETIME2 NULL,
    [Notes] NVARCHAR(300) NULL,
    CONSTRAINT [FK_Attendances_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [HR].[Employees]([Id])
);
GO

CREATE TABLE [HR].[LeaveRequests] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_LeaveRequests] PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [StartDate] DATETIME2 NOT NULL,
    [EndDate] DATETIME2 NOT NULL,
    [Reason] NVARCHAR(300) NOT NULL,
    [Status] NVARCHAR(30) NOT NULL,
    CONSTRAINT [FK_LeaveRequests_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [HR].[Employees]([Id])
);
GO

CREATE TABLE [Inventory].[Categories] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Categories] PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(300) NULL
);
GO

CREATE TABLE [Inventory].[Suppliers] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Suppliers] PRIMARY KEY,
    [Name] NVARCHAR(150) NOT NULL,
    [ContactName] NVARCHAR(100) NULL,
    [Email] NVARCHAR(150) NULL,
    [Phone] NVARCHAR(30) NULL,
    [Address] NVARCHAR(250) NULL
);
GO

CREATE TABLE [Inventory].[Assets] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Assets] PRIMARY KEY,
    [Code] NVARCHAR(40) NOT NULL,
    [Name] NVARCHAR(150) NOT NULL,
    [Description] NVARCHAR(300) NULL,
    [PurchaseDate] DATETIME2 NOT NULL,
    [PurchaseCost] DECIMAL(18,2) NOT NULL,
    [Status] NVARCHAR(30) NOT NULL,
    [CategoryId] INT NOT NULL,
    [SupplierId] INT NOT NULL,
    CONSTRAINT [FK_Assets_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Inventory].[Categories]([Id]),
    CONSTRAINT [FK_Assets_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Inventory].[Suppliers]([Id]),
    CONSTRAINT [UQ_Assets_Code] UNIQUE ([Code])
);
GO

CREATE TABLE [Inventory].[AssetAssignments] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_AssetAssignments] PRIMARY KEY,
    [AssetId] INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    [AssignedDate] DATETIME2 NOT NULL,
    [ReturnedDate] DATETIME2 NULL,
    CONSTRAINT [FK_AssetAssignments_AssetId] FOREIGN KEY ([AssetId]) REFERENCES [Inventory].[Assets]([Id]),
    CONSTRAINT [FK_AssetAssignments_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [HR].[Employees]([Id])
);
GO

CREATE TABLE [Operations].[Rooms] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Rooms] PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Capacity] INT NOT NULL,
    [Location] NVARCHAR(150) NULL,
    [IsAvailable] BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE [Operations].[Reservations] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Reservations] PRIMARY KEY,
    [RoomId] INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    [StartTime] DATETIME2 NOT NULL,
    [EndTime] DATETIME2 NOT NULL,
    [Purpose] NVARCHAR(250) NOT NULL,
    CONSTRAINT [FK_Reservations_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [Operations].[Rooms]([Id]),
    CONSTRAINT [FK_Reservations_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [HR].[Employees]([Id])
);
GO

CREATE TABLE [Operations].[Meetings] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Meetings] PRIMARY KEY,
    [Title] NVARCHAR(150) NOT NULL,
    [Description] NVARCHAR(400) NULL,
    [ScheduledAt] DATETIME2 NOT NULL,
    [DurationMinutes] INT NOT NULL,
    [RoomId] INT NULL,
    [OrganizerId] INT NOT NULL,
    CONSTRAINT [FK_Meetings_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [Operations].[Rooms]([Id]),
    CONSTRAINT [FK_Meetings_OrganizerId] FOREIGN KEY ([OrganizerId]) REFERENCES [HR].[Employees]([Id])
);
GO

CREATE TABLE [Operations].[MeetingAttendees] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_MeetingAttendees] PRIMARY KEY,
    [MeetingId] INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    [Confirmed] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_MeetingAttendees_MeetingId] FOREIGN KEY ([MeetingId]) REFERENCES [Operations].[Meetings]([Id]),
    CONSTRAINT [FK_MeetingAttendees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [HR].[Employees]([Id])
);
GO

CREATE TABLE [Operations].[TaskItems] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_TaskItems] PRIMARY KEY,
    [Title] NVARCHAR(150) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [DueDate] DATETIME2 NOT NULL,
    [Priority] NVARCHAR(20) NOT NULL,
    [Status] NVARCHAR(30) NOT NULL,
    [AssignedToId] INT NOT NULL,
    CONSTRAINT [FK_TaskItems_AssignedToId] FOREIGN KEY ([AssignedToId]) REFERENCES [HR].[Employees]([Id])
);
GO

CREATE TABLE [Documents].[DocumentTypes] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_DocumentTypes] PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE [Documents].[Documents] (
    [Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Documents] PRIMARY KEY,
    [Title] NVARCHAR(200) NOT NULL,
    [FilePath] NVARCHAR(400) NOT NULL,
    [UploadedAt] DATETIME2 NOT NULL,
    [DocumentTypeId] INT NOT NULL,
    [UploadedById] INT NOT NULL,
    [DepartmentId] INT NULL,
    CONSTRAINT [FK_Documents_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [Documents].[DocumentTypes]([Id]),
    CONSTRAINT [FK_Documents_UploadedById] FOREIGN KEY ([UploadedById]) REFERENCES [HR].[Employees]([Id]),
    CONSTRAINT [FK_Documents_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [HR].[Departments]([Id])
);
GO

-- Datos de ejemplo
INSERT INTO [HR].[Departments] ([Name],[Description]) VALUES ('Administracion','Gestion administrativa'),('Tecnologia','Soporte y desarrollo'),('Finanzas','Contabilidad y presupuestos');
INSERT INTO [HR].[Positions] ([Title],[MinSalary],[MaxSalary]) VALUES ('Gerente',60000,120000),('Analista',25000,55000),('Asistente',15000,30000);
INSERT INTO [Inventory].[Categories] ([Name]) VALUES ('Equipos de computo'),('Mobiliario'),('Suministros');
INSERT INTO [Operations].[Rooms] ([Name],[Capacity],[Location]) VALUES ('Sala A',8,'Piso 1'),('Sala B',12,'Piso 2');
INSERT INTO [Documents].[DocumentTypes] ([Name]) VALUES ('Contrato'),('Factura'),('Politica interna');
GO
