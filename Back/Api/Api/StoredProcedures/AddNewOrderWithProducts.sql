-- Crear procedimiento para insertar una nueva orden y productos
CREATE TYPE OrderDetailsType AS TABLE
(
    Productid INT,
    Unitprice DECIMAL(10, 2),
    Qty INT,
    Discount DECIMAL(4, 2)
);
GO
CREATE OR ALTER PROCEDURE AddNewOrderWithProducts
    @Empid INT,
    @Shipperid INT,
    @Shipname NVARCHAR(100),
    @Shipaddress NVARCHAR(200),
    @Shipcity NVARCHAR(100),
    @Orderdate DATETIME,
    @Requireddate DATETIME,
    @Shippeddate DATETIME,
    @Freight DECIMAL(10, 2),
    @Shipcountry NVARCHAR(100),
	@OrderDetails OrderDetailsType READONLY
AS
BEGIN
    SET NOCOUNT ON;
	BEGIN TRY
		DECLARE @Orderid INT;
		-- Inset the new order in the Sales.Orders table
		INSERT INTO Sales.Orders (Empid, Shipperid, Shipname, Shipaddress, Shipcity, Orderdate, Requireddate, Shippeddate, Freight, Shipcountry)
		VALUES (@Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry);
		-- Get the ID of the order just created
		SET @Orderid = SCOPE_IDENTITY();
		-- Insert the details of the order in OrderDetails Table
		INSERT INTO Sales.OrderDetails (Orderid, Productid, Unitprice, Qty, Discount)
		SELECT @Orderid, Productid, Unitprice, Qty, Discount
		FROM @OrderDetails;

		SELECT @Orderid AS NewOrderId; -- Returns the id of the new order
	END TRY
    BEGIN CATCH
	     -- Manejo de errores
        SELECT ERROR_MESSAGE() AS ErrorMessage;
        RETURN -1;
    END CATCH
END;
GO


--How to Use
-- Declare a varible of the table using the type defined by the user
DECLARE @OrderDetails OrderDetailsType;
-- Insert the products in the type table
INSERT INTO @OrderDetails (Productid, Unitprice, Qty, Discount)
VALUES
    (1, 15.50, 2, 0.10), -- product 1
    (2, 25.00, 1, 0.00); -- product 2

-- exec the sp to add the order and products
EXEC AddNewOrderWithProducts
    @Empid = 1,
    @Shipperid = 2,
    @Shipname = 'Test Ship 2',
    @Shipaddress = '123 Test St 2',
    @Shipcity = 'Test City 2',
    @Orderdate = '2015/11/13',
    @Requireddate = '2015/12/13',
    @Shippeddate = NULL, -- Not send yet
    @Freight = 50.00,
    @Shipcountry = 'USA',
    @OrderDetails = @OrderDetails;