CREATE DATABASE SensitiveWordsDB;
GO

USE SensitiveWordsDB;
GO

CREATE TABLE SensitiveWords (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Word NVARCHAR(100) NOT NULL
);
GO
