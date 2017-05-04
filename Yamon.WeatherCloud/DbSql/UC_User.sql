alter table UC_User add  Gender int
go
ALTER TABLE UC_User ADD  CONSTRAINT [DF_UC_UserGender]  DEFAULT (0) FOR [Gender]
GO

update UC_User set Gender=0
go