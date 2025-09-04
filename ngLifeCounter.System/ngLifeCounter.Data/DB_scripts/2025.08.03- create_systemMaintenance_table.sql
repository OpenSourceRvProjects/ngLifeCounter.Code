CREATE TABLE SystemMaintenance (
	Id uniqueidentifier primary key not null,
	IsOnMaintenance bit not null default 0
)

insert into SystemMaintenance (ID) values (NEWID())