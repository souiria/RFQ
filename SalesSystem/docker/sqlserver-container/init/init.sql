USE [master];
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'testdb')
BEGIN
    CREATE DATABASE [testdb] ;
END
GO

IF NOT EXISTS (SELECT * FROM sys.sql_logins WHERE name = 'dbdevusr')
BEGIN
    CREATE LOGIN [dbdevusr] WITH PASSWORD = 'OwnhjKZqZMCY0vL', CHECK_POLICY = OFF;
    ALTER SERVER ROLE [sysadmin] ADD MEMBER [dbdevusr];
END
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'testdb')
BEGIN
	USE [testdb];
	ALTER AUTHORIZATION ON database::testdb TO [dbdevusr];
END
GO