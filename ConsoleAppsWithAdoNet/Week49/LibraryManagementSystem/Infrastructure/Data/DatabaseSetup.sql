-- =============================================
-- Library Management System Database Script
-- Week49 - ADO.NET Practice with Generic Collections
-- =============================================

-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LibraryDB')
BEGIN
    CREATE DATABASE LibraryDB;
END
GO

USE LibraryDB;
GO

-- =============================================
-- Create Books Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Books')
BEGIN
    CREATE TABLE Books (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Title NVARCHAR(200) NOT NULL,
        Author NVARCHAR(100) NOT NULL,
        ISBN NVARCHAR(20) NOT NULL UNIQUE,
        PublishedYear INT NOT NULL,
        Genre NVARCHAR(50) NOT NULL,
        TotalCopies INT NOT NULL DEFAULT 1,
        AvailableCopies INT NOT NULL DEFAULT 1,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME NULL
    );

    -- Create index on ISBN for faster lookups
    CREATE INDEX IX_Books_ISBN ON Books(ISBN);
    CREATE INDEX IX_Books_Title ON Books(Title);
    CREATE INDEX IX_Books_Author ON Books(Author);
END
GO

-- =============================================
-- Create Members Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Members')
BEGIN
    CREATE TABLE Members (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) NOT NULL UNIQUE,
        Phone NVARCHAR(20) NULL,
        Address NVARCHAR(200) NULL,
        MembershipDate DATETIME NOT NULL DEFAULT GETDATE(),
        IsActive BIT NOT NULL DEFAULT 1,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME NULL
    );

    -- Create index on Email for faster lookups
    CREATE INDEX IX_Members_Email ON Members(Email);
    CREATE INDEX IX_Members_Name ON Members(LastName, FirstName);
END
GO

-- =============================================
-- Create BookBorrowRecords Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'BookBorrowRecords')
BEGIN
    CREATE TABLE BookBorrowRecords (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        BookId INT NOT NULL,
        MemberId INT NOT NULL,
        BorrowDate DATETIME NOT NULL DEFAULT GETDATE(),
        DueDate DATETIME NOT NULL,
        ReturnDate DATETIME NULL,
        IsReturned BIT NOT NULL DEFAULT 0,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME NULL,
        
        -- Foreign Key Constraints
        CONSTRAINT FK_BookBorrowRecords_Books FOREIGN KEY (BookId) REFERENCES Books(Id),
        CONSTRAINT FK_BookBorrowRecords_Members FOREIGN KEY (MemberId) REFERENCES Members(Id)
    );

    -- Create indexes for faster lookups
    CREATE INDEX IX_BookBorrowRecords_BookId ON BookBorrowRecords(BookId);
    CREATE INDEX IX_BookBorrowRecords_MemberId ON BookBorrowRecords(MemberId);
    CREATE INDEX IX_BookBorrowRecords_DueDate ON BookBorrowRecords(DueDate);
    CREATE INDEX IX_BookBorrowRecords_IsReturned ON BookBorrowRecords(IsReturned);
END
GO

-- =============================================
-- Insert Sample Data - Books
-- =============================================
IF NOT EXISTS (SELECT * FROM Books)
BEGIN
    INSERT INTO Books (Title, Author, ISBN, PublishedYear, Genre, TotalCopies, AvailableCopies)
    VALUES 
        ('Clean Code', 'Robert C. Martin', '978-0132350884', 2008, 'Technology', 3, 3),
        ('The Pragmatic Programmer', 'David Thomas', '978-0135957059', 2019, 'Technology', 2, 2),
        ('Design Patterns', 'Gang of Four', '978-0201633610', 1994, 'Technology', 2, 2),
        ('C# in Depth', 'Jon Skeet', '978-1617294532', 2019, 'Technology', 3, 3),
        ('Head First Design Patterns', 'Eric Freeman', '978-0596007126', 2004, 'Technology', 2, 2),
        ('The Lord of the Rings', 'J.R.R. Tolkien', '978-0618640157', 1954, 'Fantasy', 4, 4),
        ('1984', 'George Orwell', '978-0451524935', 1949, 'Fiction', 3, 3),
        ('To Kill a Mockingbird', 'Harper Lee', '978-0060935467', 1960, 'Fiction', 2, 2),
        ('Pride and Prejudice', 'Jane Austen', '978-0141439518', 1813, 'Romance', 2, 2),
        ('A Brief History of Time', 'Stephen Hawking', '978-0553380163', 1988, 'Science', 2, 2);
END
GO

-- =============================================
-- Insert Sample Data - Members
-- =============================================
IF NOT EXISTS (SELECT * FROM Members)
BEGIN
    INSERT INTO Members (FirstName, LastName, Email, Phone, Address, IsActive)
    VALUES 
        ('John', 'Doe', 'john.doe@email.com', '+1234567890', '123 Main St, City', 1),
        ('Jane', 'Smith', 'jane.smith@email.com', '+1234567891', '456 Oak Ave, Town', 1),
        ('Bob', 'Johnson', 'bob.johnson@email.com', '+1234567892', '789 Pine Rd, Village', 1),
        ('Alice', 'Williams', 'alice.williams@email.com', '+1234567893', '321 Elm St, City', 1),
        ('Charlie', 'Brown', 'charlie.brown@email.com', '+1234567894', '654 Maple Dr, Town', 0);
END
GO

-- =============================================
-- Stored Procedures
-- =============================================

-- Get Book with Borrow Count
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetBookWithBorrowCount')
    DROP PROCEDURE sp_GetBookWithBorrowCount;
GO

CREATE PROCEDURE sp_GetBookWithBorrowCount
    @BookId INT
AS
BEGIN
    SELECT 
        b.*,
        (SELECT COUNT(*) FROM BookBorrowRecords WHERE BookId = b.Id) AS TotalBorrows,
        (SELECT COUNT(*) FROM BookBorrowRecords WHERE BookId = b.Id AND IsReturned = 0) AS ActiveBorrows
    FROM Books b
    WHERE b.Id = @BookId;
END
GO

-- Get Member with Borrow Summary
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetMemberWithBorrowSummary')
    DROP PROCEDURE sp_GetMemberWithBorrowSummary;
GO

CREATE PROCEDURE sp_GetMemberWithBorrowSummary
    @MemberId INT
AS
BEGIN
    SELECT 
        m.*,
        (SELECT COUNT(*) FROM BookBorrowRecords WHERE MemberId = m.Id) AS TotalBorrows,
        (SELECT COUNT(*) FROM BookBorrowRecords WHERE MemberId = m.Id AND IsReturned = 0) AS ActiveBorrows,
        (SELECT ISNULL(SUM(FineAmount), 0) FROM BookBorrowRecords WHERE MemberId = m.Id) AS TotalFines
    FROM Members m
    WHERE m.Id = @MemberId;
END
GO

-- Get Overdue Books Report
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_GetOverdueBooksReport')
    DROP PROCEDURE sp_GetOverdueBooksReport;
GO

CREATE PROCEDURE sp_GetOverdueBooksReport
AS
BEGIN
    SELECT 
        bbr.Id AS RecordId,
        b.Title AS BookTitle,
        b.Author AS BookAuthor,
        m.FirstName + ' ' + m.LastName AS MemberName,
        m.Email AS MemberEmail,
        bbr.BorrowDate,
        bbr.DueDate,
        DATEDIFF(DAY, bbr.DueDate, GETDATE()) AS DaysOverdue
    FROM BookBorrowRecords bbr
    INNER JOIN Books b ON bbr.BookId = b.Id
    INNER JOIN Members m ON bbr.MemberId = m.Id
    WHERE bbr.IsReturned = 0 AND bbr.DueDate < GETDATE()
    ORDER BY bbr.DueDate;
END
GO

PRINT 'Library Management System Database setup completed successfully!';
GO
