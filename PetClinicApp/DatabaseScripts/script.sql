-- Users tablosu
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
BEGIN
    CREATE TABLE Users (
        UserID INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        Password NVARCHAR(50) NOT NULL,
        Role NVARCHAR(20) NOT NULL
    );

    INSERT INTO Users (Username, Password, Role)
    VALUES ('admin','1234','Admin');
END

-- Customers tablosu
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers' AND xtype='U')
BEGIN
    CREATE TABLE Customers (
        CustomerID INT IDENTITY(1,1) PRIMARY KEY,
        FullName NVARCHAR(100) NOT NULL,
        Phone NVARCHAR(20),
        Email NVARCHAR(50)
    );
END

-- Pets tablosu
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Pets' AND xtype='U')
BEGIN
    CREATE TABLE Pets (
        PetID INT IDENTITY(1,1) PRIMARY KEY,
        CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
        PetName NVARCHAR(50),
        Species NVARCHAR(30),
        Breed NVARCHAR(50)
    );
END

-- Services tablosu
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Services' AND xtype='U')
BEGIN
    CREATE TABLE Services (
        ServiceID INT IDENTITY(1,1) PRIMARY KEY,
        ServiceName NVARCHAR(50),
        Price DECIMAL(10,2)
    );
END

-- Appointments tablosu
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Appointments' AND xtype='U')
BEGIN
    CREATE TABLE Appointments (
        AppointmentID INT IDENTITY(1,1) PRIMARY KEY,
        PetID INT FOREIGN KEY REFERENCES Pets(PetID),
        ServiceID INT FOREIGN KEY REFERENCES Services(ServiceID),
        AppointmentDate DATETIME,
        Notes NVARCHAR(255)
    );
END
