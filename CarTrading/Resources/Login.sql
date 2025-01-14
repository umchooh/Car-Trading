USE [Car_Trading]
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 2024-10-29 2:37:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Login]
    @User_name NVARCHAR(255),
    @Password NVARCHAR(255),
    @Result INT OUTPUT,
	@UserID INT OUTPUT,
	@username NVARCHAR(50) OUTPUT,
    @RoleType NVARCHAR(50) OUTPUT -- Add this line
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StoredHashedPassword VARBINARY(64);
    DECLARE @StoredSalt UNIQUEIDENTIFIER;

	DECLARE @getUserID INT;
	DECLARE @getUserName VARCHAR(50);
	DECLARE @getUserRole VARCHAR(50);

    -- Retrieve the stored hashed password and salt for the given username
    SELECT @StoredHashedPassword = password, 
		@StoredSalt = salt, 
		@getUserRole = roletype,
		@getUserName = username, 
		@getUserID = userId
    FROM [dbo].[Users]
    WHERE username = @User_name;

    -- Check if user exists
    IF @StoredHashedPassword IS NULL
    BEGIN
        SET @Result = 0; -- User does not exist
        RETURN;
    END

    -- Hash the input password with the stored salt
    DECLARE @HashedPassword VARBINARY(64);
    SET @HashedPassword = HASHBYTES('SHA2_512', @Password + CAST(@StoredSalt AS NVARCHAR(36)));

    -- Compare the hashed password
    IF @StoredHashedPassword = @HashedPassword
    BEGIN
        SET @Result = 1; -- Login successful
		SET @RoleType = @getUserRole;
		SET @username = @getUserName; 
		SET @UserID = @getUserID;
    END
    ELSE
    BEGIN
        SET @Result = -1; -- Incorrect password
    END
END
/*

DECLARE @LoginResult INT;
DECLARE @userIDResult INT;
DECLARE @usernameResult VARCHAR(50);
DECLARE @roleTypeResult VARCHAR(50);

EXEC [dbo].[Login]
    @user_name = 'Choo123',       -- Replace with the actual username
    @Password = 'Choo@123',     -- Replace with the actual password
    @Result = @LoginResult OUTPUT,
	@UserID = @userIDResult OUTPUT,
	@username  = @usernameResult OUTPUT,
	@RoleType = @roleTypeResult OUTPUT

-- Check the result
SELECT @LoginResult; 
SELECT @userIDResult ;
SELECT @usernameResult ;
SELECT @roleTypeResult; 

*/