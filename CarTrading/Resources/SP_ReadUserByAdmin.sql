USE [Car_Trading]
GO
/****** Object:  StoredProcedure [dbo].[ReadUserByAdmin]    Script Date: 2024-11-06 1:14:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ReadUserByAdmin]
    @adminID INT
AS
BEGIN
    BEGIN TRY
        -- Check if the admin exists and is an admin
        IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [userId] = @adminID AND [roletype] = 'Admin')
        BEGIN
            -- Return a message indicating the admin user is not valid
            SELECT 'Admin user not found or not valid.' AS Message;
            RETURN;
        END

        -- Retrieve users who are either Dealer or Regular
        SELECT * FROM [dbo].[Users] 
        WHERE [roletype] IN ('Dealer', 'Regular');
    END TRY
    BEGIN CATCH
        -- Handle error and return error message
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;

/*
EXEC ReadProductByUserID 6


*/