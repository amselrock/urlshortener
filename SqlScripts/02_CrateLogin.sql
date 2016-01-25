USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [urlshortuser]    Script Date: 12/11/2015 17:34:47 ******/
CREATE LOGIN [urlshortuser] WITH PASSWORD=N'user1', DEFAULT_DATABASE=[rm.urlshortener.dbsql], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

--ALTER LOGIN [urlshortuser] DISABLE
--GO


