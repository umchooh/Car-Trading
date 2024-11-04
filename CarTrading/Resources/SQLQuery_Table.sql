-- Create Users
CREATE TABLE [dbo].[Users] (
    userId INT IDENTITY(1,1) PRIMARY KEY,         -- Unique identifier for each user
    username NVARCHAR(255) NOT NULL UNIQUE,      -- Unique username
    roletype NVARCHAR(255) NOT NULL,              -- User role (e.g., admin, customer)
    password VARBINARY(64) NOT NULL,              -- Hashed password
    salt UNIQUEIDENTIFIER NOT NULL,                -- Salt for password hashing
    email NVARCHAR(255) NOT NULL UNIQUE,          -- Unique email address
    created_at DATETIME NOT NULL DEFAULT GETDATE(),-- Date and time when the user was created
    updated_at DATETIME NOT NULL DEFAULT GETDATE()  -- Date and time when the user was last updated
);

SELECT * FROM Users;

--Create Product
CREATE TABLE Product(
	ID INT PRIMARY KEY IDENTITY(1,1),
	userID INT NOT NULL FOREIGN KEY REFERENCES Users(userId),
	pTitle NVARCHAR(255) NOT NULL,
	pDesc NVARCHAR(255) NOT NULL,
	pPrice NVARCHAR(255) NOT NULL,
	pLocation NVARCHAR(255) NOT NULL,
	postStatus NVARCHAR(255) NOT NULL,--TRADED AVAILABLE
	created_at datetime NOT NULL DEFAULT getDate(),--this will not be touch
	updated_at datetime NOT NULL DEFAULT getDate()-- adding on Stored procedure : updated_at = GETDATE()
);

Select * FROM Product;

--- Create PContent
CREATE TABLE PContent(
	pContentID INT PRIMARY KEY IDENTITY(1,1),
	productID INT NOT NULL FOREIGN KEY REFERENCES Product(ID),
	pColour NVARCHAR(255) NOT NULL,
	pMake NVARCHAR(255) NOT NULL,
	pModel NVARCHAR(255) NOT NULL,
	pYear NVARCHAR(255) NOT NULL,
	pMileage NVARCHAR(255) NOT NULL,
	pTransmission NVARCHAR(255) NOT NULL,
	pFuelType NVARCHAR(255) NOT NULL,
	pUrl NVARCHAR(255) NOT NULL, -- images -- assumed as one
	created_at datetime NOT NULL DEFAULT getDate(),
	updated_at datetime NOT NULL DEFAULT getDate(), 
);

Select * FROM PContent;

-- Create Transaction 
CREATE TABLE Transactions(
	transID INT PRIMARY KEY IDENTITY(1,1),
	productID INT NOT NULL FOREIGN KEY REFERENCES Product(ID),
	sellerID INT NOT NULL FOREIGN KEY REFERENCES Users(userId),
	buyerID INT NOT NULL FOREIGN KEY REFERENCES Users(userId),
	created_at datetime NOT NULL DEFAULT getDate(),
	updated_at datetime NOT NULL DEFAULT getDate()
);

select * From Transactions;