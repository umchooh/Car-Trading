USE [Car_Trading]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SignUp]
    @User_name NVARCHAR(255),
    @Role_type NVARCHAR(255),
    @Password NVARCHAR(255),
    @Email NVARCHAR(255),
    @result INT OUTPUT,
    @message NVARCHAR(255) OUTPUT,
	@UserID INT OUTPUT,
	@username NVARCHAR(50) OUTPUT,
    @RoleType NVARCHAR(50) OUTPUT
AS   
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE username = @User_name)
    BEGIN
        SET @result = 0; -- User already exists
        SET @message = 'Username already exists. Please choose a different username.';
        RETURN;
    END

    DECLARE @Salt UNIQUEIDENTIFIER = NEWID();
    DECLARE @HashedPassword VARBINARY(64);

	DECLARE @getUserID INT;
	/*
	DECLARE @getUserName VARCHAR(50);
	DECLARE @getUserRole VARCHAR(50);
	*/
    -- Hash the password with the salt
    SET @HashedPassword = HASHBYTES('SHA2_512', @Password + CAST(@Salt AS NVARCHAR(36)));

    BEGIN TRY
        INSERT INTO [dbo].[Users] 
        (username, roletype, password, salt, email, created_at, updated_at)
        VALUES 
        (@User_name, @Role_type, @HashedPassword, @Salt, @Email, GETDATE(), GETDATE());

        SET @result = 1; -- User created successfully
        SET @message = 'Sign-up Successful! Welcome to Car Trading.'
		SET @RoleType = @Role_type;
		SET @username = @User_name; 
		SET @UserID = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        SET @result = -1; -- Indicate an error occurred
        SET @message = 'An error occurred during sign-up: ' + ERROR_MESSAGE();
    END CATCH
END


/*

DECLARE @SignUpResult INT;
DECLARE @userIDResult INT;
DECLARE @usernameResult VARCHAR(55);
DECLARE @roleTypeResult VARCHAR(55);
DECLARE @messageResult VARCHAR(55);

EXEC [dbo].[SignUp]
    @user_name = 'Daniel12345',       
    @Password = 'Daniel@12345',
	@Role_type = 'Regular',
	@Email = 'Daniel@Test.com',
    @result = @SignUpResult OUTPUT,
	@UserID = @userIDResult OUTPUT,
	@username  = @usernameResult OUTPUT,
	@RoleType = @roleTypeResult OUTPUT,
	@message = @messageResult OUTPUT

-- Check the result
SELECT @SignUpResult AS Result; 
SELECT @userIDResult AS UserID ;
SELECT @usernameResult AS UserName ;
SELECT @roleTypeResult AS Role; 
SELECT @messageResult AS MSG;

*/