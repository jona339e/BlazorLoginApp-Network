Use master
GO
IF DB_ID('MyLoginSql') IS NOT NULL
	BEGIN
		ALTER DATABASE MyLoginSql SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		DROP DATABASE MyLoginSql
	END
GO
CREATE DATABASE MyLoginSql
GO

USE MyLoginSql
GO

Create Table MyLogin(
ID Int IDENTITY(1,1) NOT NULL PRIMARY KEY,
UserName nvarchar(30) not null unique,
[Password] nvarchar(16) not null
)

insert into MyLogin VALUES('Admin','Passw0rd')
insert into MyLogin VALUES('UserOne','qwerty')
insert into MyLogin VALUES('UserTwo','12345')
