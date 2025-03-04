USE [Car_Trading]
GO
/****** Object:  StoredProcedure [dbo].[CreateProductByRegular]    Script Date: 2024-11-04 10:43:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[CreateProductByRegular]
    @userID INT,
    @pTitle NVARCHAR(255),
    @pDesc NVARCHAR(255),
    @pPrice NVARCHAR(255),
    @pLocation NVARCHAR(255),
    @pColour NVARCHAR(255), 
    @pMake NVARCHAR(255), 
    @pModel NVARCHAR(255), 
    @pYear NVARCHAR(255), 
    @pMileage NVARCHAR(255), 
    @pTransmission NVARCHAR(255), 
    @pFuelType NVARCHAR(255), 
    @pUrl NVARCHAR(255),
    @result INT OUTPUT,
    @message NVARCHAR(255) OUTPUT
AS
BEGIN
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [userId] = @userID AND [roletype] = 'Regular')
        BEGIN
            DECLARE @defaultPostStatus VARCHAR(55) = 'AVAILABLE';
            DECLARE @new_product_id INT;
            
            -- Insert into Product table
            INSERT INTO [dbo].[Product] (
                userID, pTitle, pDesc, pPrice, pLocation, postStatus, created_at, updated_at
            )
            VALUES (
                @userID, @pTitle, @pDesc, @pPrice, @pLocation, @defaultPostStatus, GETDATE(), GETDATE()
            );

            -- Retrieve ID of the newly inserted product
            SET @new_product_id = SCOPE_IDENTITY();

            -- Insert into PContent table
            INSERT INTO [dbo].[PContent] (
                productID, pColour, pMake, pModel, pYear, pMileage, pTransmission, pFuelType, pUrl, created_at, updated_at
            )
            VALUES (
                @new_product_id, @pColour, @pMake, @pModel, @pYear, @pMileage, @pTransmission, @pFuelType, @pUrl, GETDATE(), GETDATE()
            );

            -- Set success result and message
            SET @result = 1;
            SET @message = 'Product created successfully';
        END
        ELSE
        BEGIN
            SET @result = 0;
            SET @message = 'You do not have permission to create this post.';
            RAISERROR(@message, 16, 1);
        END
    END TRY
    BEGIN CATCH
        SET @result = 0;
        SET @message = ERROR_MESSAGE();
        RAISERROR(@message, 16, 1);
    END CATCH
END


-- EXEC CreateProduct (22,'2015, Fiat, Minivan, 18370$!','Location: Beaconsfield, color: blue, milage: 183740, transmission: manual, fuel: diesel.','18370','Beaconsfield','AVAILABLE','blue','Fiat','Minivan','2015','183740','manual','diesel','image_3.jpg')