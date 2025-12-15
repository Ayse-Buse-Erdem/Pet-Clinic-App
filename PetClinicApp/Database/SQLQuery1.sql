CREATE TABLE [dbo].[Customers] (
    [CustomerID] INT            IDENTITY (1, 1) NOT NULL,
    [FullName]   NVARCHAR (100) NOT NULL,
    [Phone]      NVARCHAR (20)  NULL,
    [Email]      NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

CREATE TABLE [dbo].[Services] (
    [ServiceID]   INT             IDENTITY (1, 1) NOT NULL,
    [ServiceName] NVARCHAR (50)   NULL,
    [Price]       DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([ServiceID] ASC)
);

CREATE TABLE [dbo].[Users] (
    [UserID]   INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Role]     NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);


CREATE TABLE [dbo].[Pets] (
    [PetID]      INT           IDENTITY (1, 1) NOT NULL,
    [CustomerID] INT           NULL,
    [PetName]    NVARCHAR (50) NULL,
    [Species]    NVARCHAR (30) NULL,
    [Breed]      NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([PetID] ASC),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID])
);


CREATE TABLE [dbo].[Appointments] (
    [AppointmentID]   INT            IDENTITY (1, 1) NOT NULL,
    [PetID]           INT            NULL,
    [ServiceID]       INT            NULL,
    [AppointmentDate] DATETIME       NULL,
    [Notes]           NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([AppointmentID] ASC),
    FOREIGN KEY ([PetID]) REFERENCES [dbo].[Pets] ([PetID]),
    FOREIGN KEY ([ServiceID]) REFERENCES [dbo].[Services] ([ServiceID])
);

INSERT INTO Customers (CustomerID, FullName, Phone, Email) VALUES
(18, 'John Smith', '555-1834', 'john.smith@.com'),
(19, 'Michael Brown', '555-4380', 'michael.brown@example.com'),
(20, 'Sophia Davis', '555-7080', 'sophia.davis@example.com'),
(21, 'Daniel Wilson', '555-3055', 'daniel.wilson@example.com'),
(22, 'Emma Johnson', '555-2122', 'emma.johnson@example.com'),
(23, 'Jane Doe', '555-1234', 'jane.doe@example.com'),
(24, 'William Johnson', '555-7890', 'william.johnson@example'),
(25, 'Benjamin Taylor', '555-4555', 'benjamin.taylor@example.com'),
(26, 'Alexander Anderson', '555-6775', 'alexander.anderson@example.com'),
(27, 'Charlotte Robinson', '555-2318', 'charlotte.robinson@example.com');


INSERT INTO Services (ServiceID, ServiceName, Price) VALUES
(18, 'Vaccination', 30.00),
(19, 'Microchipping', 100.00),
(20, 'Dental Cleaning', 200.00),
(21, 'Nail Clipping', 45.00),
(22, 'Deworming', 350.00);

INSERT INTO Users (UserID, Username, Password, Role) VALUES
(1, 'admin', '1234', 'Admin');

INSERT INTO Pets (PetID, CustomerID, PetName, Species, Breed) VALUES
(16, 18, 'Max', 'Dog', 'Golden Retriever'),
(17, 19, 'Luna', 'Cat', 'British Shorthair'),
(18, 20, 'Coco', 'Rabbit', 'Holland Lop'),
(19, 21, 'Kiwi', 'Bird', 'Parakeet'),
(20, 27, 'Rocky', 'Dog', 'German Shepherd'),
(21, 24, 'Charlie', 'Dog', 'Bulldog'),
(22, 26, 'Milo', 'Cat', 'Siamese'),
(23, 22, 'Spike', 'Reptile', 'Bearded Dragon');

INSERT INTO Appointments (AppointmentID, PetID, ServiceID, AppointmentDate, Notes) VALUES
(7, 16, 18, '2025-12-03 15:32:37', 'Distemper combo given, next dose in 3 weeks'),
(8, 17, 20, '2025-11-18 15:35:00', 'Dental cleaning completed, mild tartar observed on molars'),
(9, 16, 18, '2025-12-15 15:55:12', NULL),
(10, 20, 22, '2025-08-01 15:44:11', 'Administered broad-spectrum dewormer, follow-up in 2 weeks'),
(11, 21, 21, '2025-11-29 15:52:34', 'Dental cleaning is completed, come back in 3 weeks'),
(12, 19, 19, '2025-01-31 15:55:37', 'chip installed successfully');





