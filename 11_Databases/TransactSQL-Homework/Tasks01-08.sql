USE [master]

CREATE DATABASE [TSQLHomeworkDB]
GO

USE [TSQLHomeworkDB]

/* Task 01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and
	Accounts(Id(PK), PersonId(FK), Balance).*/
CREATE TABLE Persons(
	[PersonId] int IDENTITY,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[SSN] numeric(9) UNIQUE,
 	CONSTRAINT PK_Persons PRIMARY KEY([PersonId]),
	CHECK ([SSN] > 100000000)
)
GO

CREATE TABLE Accounts (
	[AccountId] int IDENTITY,
	[Balance] money NOT NULL, 
	[PersonId] int NOT NULL,
 	CONSTRAINT PK_Acounts PRIMARY KEY([AccountId]),
	CONSTRAINT FK_Acounts_Persons FOREIGN KEY ([PersonId]) REFERENCES Persons([PersonId])
)
GO

/* Insert few records for testing.*/
INSERT INTO Persons ([FirstName], [LastName], [SSN]) VALUES
	('Leonardo', 'DiCaprio', 100000001),
	('Tom', 'Cruse', 100000002),
	('Matthias', 'Schoenaerts', 100000003),
	('Milles', 'Teller', 100000004),
	('Keira', 'Knightley', 100000005),
	('Halle', 'Berry', 100000006),
	('Marion', 'Cotillard', 100000007),
	('Penelope', 'Cruz', 100000008)
GO

INSERT INTO Accounts ([Balance], [PersonId]) VALUES
	(100000, 1),
	(95000, 2),
	(75000, 3),
	(110000, 4),
	(55000,5),
	(175000, 6),
	(65000, 7),
	(80000, 8)
GO

/* Write a stored procedure that selects the full names of all persons.*/
CREATE PROC usp_SelectFullNameOfPersons
AS
  SELECT FirstName + ' ' + LastName AS FullName
  FROM Persons
GO

EXEC usp_SelectFullNameOfPersons
GO

/* Task 02 Create a stored procedure that accepts a number as a parameter and returns
	 all persons who have more money in their accounts than the supplied number.*/
CREATE PROC usp_SelectPersonsWithMinimumAmountOfMoney(@minAmountOfMoney money = 75000)
AS
  SELECT p.FirstName, p.LastName, a.Balance 
  FROM Persons p
  JOIN Accounts a ON a.PersonId = p.PersonId
  WHERE a.Balance > @minAmountOfMoney
  ORDER BY a.Balance DESC
GO

EXEC dbo.usp_SelectPersonsWithMinimumAmountOfMoney 100000
GO

EXEC dbo.usp_SelectPersonsWithMinimumAmountOfMoney
GO

/* Task 03 Create a function that accepts as parameters – sum, yearly interest rate and number of months.
	It should calculate and return the new sum.
	Write a SELECT to test whether the function works as expected.*/
CREATE FUNCTION ufn_CalcYearlyInterest(@sum money, @interestRate numeric(5, 3), @numberOfmoths int)
  RETURNS money
AS
BEGIN  
  RETURN @sum * (1 + ((@interestRate / 100.0) / 12.0) * @numberOfmoths)
END
GO

SELECT dbo.ufn_CalcYearlyInterest(1000, 10, 12) AS [$1000 after 12 months at 10%]
SELECT dbo.ufn_CalcYearlyInterest(1000, 10, 6) AS [$1000 after 6 months at 10%]
SELECT dbo.ufn_CalcYearlyInterest(1000, 12, 1) AS [$1000 after 1 month at 12%]
GO

/* Task 04 Create a stored procedure that uses the function from the previous example to give an interest 
	to a person's account for one month.
	It should take the AccountId and the interest rate as parameters.*/
CREATE PROC usp_UpdatePersonAccountWithInterestForOneMonth(@accountId int, @interestRate numeric(5,3))
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_CalcYearlyInterest(Balance, @interestRate, 1)
	WHERE AccountId = @accountId
GO

EXEC dbo.usp_UpdatePersonAccountWithInterestForOneMonth 1, 10
EXEC dbo.usp_UpdatePersonAccountWithInterestForOneMonth 4, 7.5
EXEC dbo.usp_UpdatePersonAccountWithInterestForOneMonth 8, 15.25

SELECT p.FirstName, p.LastName, a.Balance AS [Current Balance]
	FROM Persons p
	JOIN Accounts a ON a.PersonId = p.PersonId
	ORDER BY [Current Balance] DESC
GO

/* Task 05. Add two more stored procedures WithdrawMoney(AccountId, money) 
	and DepositMoney(AccountId, money) that operate in transactions.*/

CREATE PROC usp_WithdrawMoney(@accountId int, @moneyToWithraw money)
AS
	DECLARE @currentBalance money;
	SELECT @currentBalance = Balance 
	FROM Accounts
	WHERE AccountId = @accountId

	BEGIN TRAN
		UPDATE Accounts
		SET Balance -= @moneyToWithraw
		WHERE AccountId = @accountId

		IF(@moneyToWithraw < 0)
			BEGIN 
				RAISERROR('Cannot withdraw negative amount of money!', 10, 1)
				ROLLBACK  TRAN
				RETURN
			END
		ELSE IF(@currentBalance - @moneyToWithraw < 0) 
			BEGIN 
				RAISERROR('You do not have enought money!', 10, 1)
				ROLLBACK  TRAN
				RETURN
			END
		ELSE 
			COMMIT TRAN	
GO

/* Test withraw money Errors are displayed in Messages window */
EXEC dbo.usp_WithdrawMoney 1, -10000
EXEC dbo.usp_WithdrawMoney 4, 550000
EXEC dbo.usp_WithdrawMoney 8, 25000

SELECT p.FirstName, p.LastName, a.Balance AS [Current Balance]
	FROM Persons p
	JOIN Accounts a ON a.PersonId = p.PersonId
	ORDER BY [Current Balance] DESC
GO

/* Task 05 Part 2 */
CREATE PROC usp_DepositMoney(@accountId int, @moneyToDeposit money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance += @moneyToDeposit
		WHERE AccountId = @accountId

		IF(@moneyToDeposit < 0)
			BEGIN 
				RAISERROR('Cannot deposit negative amount of money!', 10, 1)
				ROLLBACK  TRAN
				RETURN
			END
		ELSE 
			COMMIT TRAN	
GO

/* Test deposit money Errors are displayed in Messages window */
EXEC dbo.usp_DepositMoney 1, -10000
EXEC dbo.usp_DepositMoney 4, 550000

SELECT p.FirstName, p.LastName, a.Balance AS [Current Balance]
	FROM Persons p
	JOIN Accounts a ON a.PersonId = p.PersonId
	ORDER BY [Current Balance] DESC
GO

/* Task 06 Create another table – Logs(LogID, AccountID, OldSum, NewSum).
	Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.*/
CREATE TABLE Logs(
	[LogId] int IDENTITY,
	[AccountId] int NOT NULL,
	[OldSum] money NOT NULL,
	[NewSum] money NOT NULL,
 	CONSTRAINT PK_Logs PRIMARY KEY([LogId]),	
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY ([AccountId]) REFERENCES Accounts([AccountId])
)
GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
    SELECT d.AccountId, d.Balance, i.Balance
    FROM Deleted d
        JOIN Inserted i ON d.AccountId = i.AccountId
GO

EXEC dbo.usp_WithdrawMoney 8, 15000
EXEC dbo.usp_WithdrawMoney 6, 20000
EXEC dbo.usp_WithdrawMoney 3, 35000
EXEC dbo.usp_DepositMoney 2, 150000
EXEC dbo.usp_DepositMoney 7, 75000

SELECT p.FirstName + ' ' + p.LastName AS [Full Name], l.OldSum, l.NewSum
	FROM Logs l
	JOIN Accounts a ON l.AccountId = a.AccountId
	JOIN Persons p ON p.PersonId = a.PersonId
	ORDER BY [Full Name]
GO

/* Task 07 Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) 
	and all town's names that are comprised of given set of letters.*/
USE [TelerikAcademy]
GO

CREATE FUNCTION ufn_CheckIfLettersAreContainedInName(@name nvarchar(50), @letters nvarchar(30))
  RETURNS bit
AS
BEGIN
	DECLARE @counter int = 1;
	SET @name = LOWER(@name);
	SET @letters = LOWER(@letters)
	WHILE (@counter <= LEN(@name))
		BEGIN		
		IF (CHARINDEX(SUBSTRING(@name, @counter, 1), @letters) = 0)
			RETURN 0
		SET @counter = @counter + 1
		END
	RETURN 1
END
GO

CREATE PROC dbo.usp_FindAllNamesWithLetters(@letters nvarchar(50))
AS
    DECLARE @valid bit = 0
    SELECT * FROM (
        SELECT FirstName FROM Employees
        UNION ALL
        SELECT LastName FROM Employees
        UNION ALL
        SELECT Name FROM Towns
        ) AS Temp(Name)

    WHERE
        1 = (SELECT dbo.ufn_CheckIfLettersAreContainedInName(Name, @letters))
GO

EXEC dbo.usp_FindAllNamesWithLetters 'oistmiahf'
GO

/* Task 08 Using database cursor write a T-SQL script that scans all employees and their addresses 
	and prints all pairs of employees that live in the same town.*/

DECLARE empCursor CURSOR READ_ONLY FOR
 
SELECT a.FirstName, a.LastName, t1.Name, b.FirstName, b.LastName
	FROM Employees a
	JOIN Addresses adr
	ON a.AddressID = adr.AddressID
	JOIN Towns t1
	ON adr.TownID = t1.TownID,
	 Employees b
	JOIN Addresses ad
	ON b.AddressID = ad.AddressID
	JOIN Towns t2
	ON ad.TownID = t2.TownID
	WHERE t1.Name = t2.Name AND a.EmployeeID <> b.EmployeeID
	ORDER BY a.FirstName, b.FirstName
 
OPEN empCursor
	DECLARE @firstName1 NVARCHAR(50)
	DECLARE @lastName1 NVARCHAR(50)
	DECLARE @town NVARCHAR(50)
	DECLARE @firstName2 NVARCHAR(50)
	DECLARE @lastName2 NVARCHAR(50)
	FETCH NEXT FROM empCursor
	        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2	 
	WHILE @@FETCH_STATUS = 0
	        BEGIN
	                PRINT @firstName1 + ' ' + @lastName1 +
	                        '     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
	                FETCH NEXT FROM empCursor
	                        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
	        END	 
CLOSE empCursor
DEALLOCATE empCursor
