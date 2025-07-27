CREATE OR ALTER PROCEDURE GetEmployees
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Empid,
        CONCAT(Firstname, ' ', Lastname) AS FullName -- Concatenar Firstname y Lastname
    FROM 
        HR.Employees;
END;
GO

-- Test Exec
EXEC GetEmployees;