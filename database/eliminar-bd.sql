USE [master]
GO
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'seguimiento_proyectos'
GO

ALTER DATABASE [seguimiento_proyectos] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

DROP DATABASE [seguimiento_proyectos]
GO

-----------------------------------------------------------------------

USE [master]
GO

DROP LOGIN [practica_asp_net]
GO
