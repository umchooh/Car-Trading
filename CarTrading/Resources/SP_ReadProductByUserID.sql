USE [Car_Trading]
GO
/****** Object:  StoredProcedure [dbo].[ReadProductByUserID]    Script Date: 2024-11-04 10:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ReadProductByUserID]
    @UserID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the user exists
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [UserID] = @UserID) 
    BEGIN
        -- Return a message indicating no user found
        SELECT 'User is not found.' AS Message;
        RETURN;
    END

    -- Check if products exist for the given user
    IF EXISTS (SELECT 1 FROM [dbo].[Product] WHERE [UserID] = @UserID)
    BEGIN
        -- Return all products for the user
        SELECT * FROM [dbo].[Product] 
		JOIN [dbo].[PContent] 
		ON [dbo].[Product].[ID] = [dbo].[PContent].productID  
		WHERE [UserID] = @UserID;
    END
    ELSE
    BEGIN
        -- Return a message indicating no products found
        SELECT 'No products found for this user.' AS Message;
    END
END;


EXEC ReadProductByUserID 6
