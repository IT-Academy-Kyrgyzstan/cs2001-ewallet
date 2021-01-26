USE  Ewallet

CREATE TABLE Users
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL, 
	Password nvarchar(50) CHECK (DATALENGTH([Password]) >= (6)) NOT NULL,
	Login nvarchar(20) UNIQUE NOT NULL, 
	Created Date  NOT NULL CONSTRAINT DF_created_date DEFAULT GETDATE()	
);