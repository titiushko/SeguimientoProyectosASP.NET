USE [master]
RESTORE DATABASE [seguimiento_proyectos] FROM  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\Backup\seguimiento_proyectos.bak' WITH  FILE = 1,  NOUNLOAD,  STATS = 5
GO

-----------------------------------------------------------------------

USE [master]
GO
CREATE LOGIN [practica_asp_net] WITH PASSWORD=N'practica_asp_net', DEFAULT_DATABASE=[seguimiento_proyectos], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

/*
USE [master]
GO
CREATE USER [practica_asp_net] FOR LOGIN [practica_asp_net]
GO
*/

USE [seguimiento_proyectos]
GO
EXEC sp_addrolemember N'db_owner', N'practica_asp_net'
GO
EXEC sp_change_users_login 'update_one','practica_asp_net','practica_asp_net'
GO
