USE  Ewallet
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
	UserId int NULL,
	BardBalance Numeric(12,2) NULL,
	CreatedDate Date  NOT NULL CONSTRAINT DF_created_date DEFAULT GETDATE(),
	EndDate date NULL,
	StatusId int NOT NULL,
	CONSTRAINT FK_CardAccounts_To_Users FOREIGN KEY (UserId)  REFERENCES Users (Id),
	CONSTRAINT FK_CardAccounts_To_Statuses FOREIGN KEY (StatusId)  REFERENCES Statuses (Id)
);
