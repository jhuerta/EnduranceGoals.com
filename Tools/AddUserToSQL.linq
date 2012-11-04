<Query Kind="SQL">
  <Connection>
    <ID>e43a6c2d-191c-4c9a-9e4e-cffbd5521520</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>EnduranceGoals</Database>
  </Connection>
</Query>

select * from sports
select * from goals
select * from users
Venues venues 


USE MASTER
SELECT SYSTEM_USER
SELECT SUSER_ID('ASPNET')
sp_adduser 'BLACK_CUCUMBER\ASPNET'
sp_addLogin 'jhuerta', 'pass@word'
GO
sp_addsrvrolemember 'BLACK_CUCUMBER\ASPNET', 'sysadmin'
GO
USE endurancegoals
EXEC sp_adduser 'jhuerta'
exec sp_password @new = 'pass@word', @loginame = 'jhuerta'
EXEC sp_addrolemember N'db_owner', N'jhuerta'

exec sp_grantlogin 'BLACK_CUCUMBER\IUSR_BLACK_CUCUMBER'

EXEC sp_grantdbaccess 'BLACK_CUCUMBER\IUSR_BLACK_CUCUMBER'

CREATE USER [jhuerta] FOR LOGIN [jhuerta]
EXEC sp_addrolemember N'db_owner', N'jhuerta'