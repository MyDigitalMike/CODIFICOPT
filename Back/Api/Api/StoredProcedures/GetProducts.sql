CREATE OR ALTER PROCEDURE GetProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Productid,
        Productname
    FROM 
        Production.Products;
END;
GO

-- Test Exec
EXEC GetProducts;
