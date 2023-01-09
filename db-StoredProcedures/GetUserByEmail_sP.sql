SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByEmail](@email NVARCHAR(50))
AS
BEGIN
    SELECT * FROM [User]
    WHERE Email = @email
END
GO
