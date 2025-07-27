CREATE OR ALTER PROCEDURE SearchCustomers
    @CustomerName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Custid,
        CompanyName,
        ContactName,
        ContactTitle,
        Address,
        City,
        Region,
        PostalCode,
        Country,
        Phone,
        Fax
    FROM 
        Sales.Customers
    WHERE 
        CompanyName LIKE '%' + @CustomerName + '%';
END;
GO
