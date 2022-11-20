IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Jobs]') AND type in (N'U'))
BEGIN
create table Jobs
(
	ID int identity(1,1) primary key,
	JobCode varchar(10) not null,
	Title varchar(100) not null,
	Description varchar(100),
	LocationId int not null foreign key references Location(ID),
	DepartmentId int not null foreign key references Department(ID),
	PostedDate DateTime not null,
	ClosingDate DateTime not null
);
END

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
	create table Department
	(
		ID int identity(1,1) primary key,
		Title varchar(100) not null
	);
END

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
BEGIN
	create table Location
	(
		ID int identity(1,1) primary key,
		Title varchar(100) not null,
		City varchar(100) not null,
		State varchar(100) not null,
		Country varchar(100) not null,
		Zip int not null
	);
END