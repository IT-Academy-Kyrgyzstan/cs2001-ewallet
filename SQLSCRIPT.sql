USE  Ewallet
GO
CREATE TABLE Users
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL, 
	Password nvarchar(50) CHECK (DATALENGTH([Password]) >= (6)) NOT NULL,
	Login nvarchar(20) UNIQUE NOT NULL, 
	Created Date  NOT NULL CONSTRAINT DF_Users_created_date DEFAULT GETDATE()	
);
GO

CREATE TABLE Statuses
( 
	Id int PRIMARY KEY NOT NULL,
	Status nvarchar(10) NULL
);
GO

INSERT Statuses VALUES
	(1,'worked'),
	(2,'blocked'),
	(3,'frozen')
GO

CREATE TABLE CardAccounts
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	CardNumber nvarchar(6)CHECK (DATALENGTH(CardNumber) = (6)) NOT NULL,
	CardName nvarchar(20) NOT NULL, 
	UserId int NOT NULL,
	CardBalance Numeric(12,2) NULL,
	CreatedDate Date  NOT NULL CONSTRAINT DF_CardAccounts_created_date DEFAULT GETDATE(),
	EndDate date NOT NULL,
	StatusId int NOT NULL,
	CONSTRAINT FK_CardAccounts_To_Users FOREIGN KEY (UserId)  REFERENCES Users (Id),
	CONSTRAINT FK_CardAccounts_To_Statuses FOREIGN KEY (StatusId)  REFERENCES Statuses (Id)
);
GO

CREATE TABLE CardOrders
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	UserId int NOT NULL,
	OperatorId int NULL,
	NameCard nvarchar (30) NULL,
	Сurrency smallint NOT NULL,
	CardType smallint NOT NULL,
	Status smallint NOT NULL,
	Description nvarchar (100) NULL,
	CreatedDate Date NOT NULL,
	DecisionDate Date NULL,
	FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);
