CREATE OR ALTER PROCEDURE GetShippers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Shipperid,
        Companyname
    FROM 
        Sales.Shippers;
END;
GO

-- Test Exec
EXEC GetShippers;