IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'IIS APPPOOL\Movie Rent')
BEGIN
    CREATE LOGIN [IIS APPPOOL\Movie Rent] 
      FROM WINDOWS WITH DEFAULT_DATABASE=[master], 
      DEFAULT_LANGUAGE=[us_english]
END
GO
CREATE USER [VideoCheckingWEBUser] 
  FOR LOGIN [IIS APPPOOL\Movie Rent]
GO
EXEC sp_addrolemember 'db_owner', 'VideoCheckingWEBUser'
GO