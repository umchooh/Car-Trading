USE [Car_Trading]
GO
/****** Object:  StoredProcedure [dbo].[ReadProductByAdmin]    Script Date: 2024-11-04 10:44:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReadProductByAdmin]
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
        SELECT * FROM [dbo].[Product] 
		JOIN [dbo].[PContent] 
		ON [dbo].[Product].ID = [dbo].[PContent].productID
		JOIN [dbo].[Users] 
		ON [dbo].[Product].userID = [dbo].[Users].userId
		WHERE [roletype] IN ('Dealer', 'Regular')
		ORDER BY [dbo].[Product].created_at DESC
		 
    END TRY
    BEGIN CATCH
        -- Handle error and return error message
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;

/*
EXEC ReadProductByAdmin 1


*/