CREATE DATABASE SampleDb;
GO

USE SampleDb;
GO

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL
);



INSERT INTO Customers (Name, Email, CreatedAt)
VALUES 
('Alice Johnson', 'alice@example.com', GETDATE()),
('Michael Smith', 'michael.smith@example.com', GETDATE()),
('Emma Brown', 'emma.brown@example.com', GETDATE());


SELECT * FROM Customers;