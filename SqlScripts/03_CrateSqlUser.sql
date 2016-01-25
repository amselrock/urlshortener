USE [rm.urlshortener.dbsql]
GO

/****** Object:  User [kpmg]    Script Date: 11/12/2015 8:19:30 PM ******/
CREATE USER [urlshortuser] FOR LOGIN [urlshortuser] WITH DEFAULT_SCHEMA=[dbo]
GO

EXEC sp_addrolemember 'db_datareader', 'urlshortuser';
EXEC sp_addrolemember 'db_datawriter', 'urlshortuser';
Grant Execute on Schema :: dbo TO [urlshortuser];