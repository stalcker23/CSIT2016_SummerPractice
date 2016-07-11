CREATE TABLE [AdBoard].[dbo].[Roles] (
	Id int not null identity primary key,
	RoleName varchar(30),
)

INSERT INTO [AdBoard].[dbo].[Roles] VALUES ('Admin')
INSERT INTO [AdBoard].[dbo].[Roles] VALUES ('User')

CREATE TABLE [AdBoard].[dbo].[Users] (
	Id int not null identity primary key,
	RegDate datetime2(7) not null,
	FirstName varchar(100) not null,
	LastName varchar(100) not null,
	Email varchar(100) not null,
	Country varchar(100) not null,
	City varchar(100) not null,
	Phone varchar(100) not null,
	Cookies varchar(100) not null,
	Password varchar(100) not null,
	IsBlock bit not null,
	RoleId int not null,
	CONSTRAINT FK_User_Roles FOREIGN KEY (RoleId) REFERENCES [AdBoard].[dbo].[Roles](Id),	
) 

INSERT INTO [AdBoard].[dbo].[Users] VALUES ('08.07.2016', 'Admin', 'Admin', 
			'a-zenit-a@rambler.ru.ru', 'Россия', 'Саратов', '89868329673' , 'fd', '49f9fa31289ed1a40d2747a8e18599a8', 0, 1)

CREATE TABLE [AdBoard].[dbo].[AdTypes] (
	Id int not null identity primary key,
	Type varchar(100) not null,
)

INSERT INTO [AdBoard].[dbo].[AdTypes] VALUES ('Продам')
INSERT INTO [AdBoard].[dbo].[AdTypes] VALUES ('Куплю')


CREATE TABLE [AdBoard].[dbo].[Ads] (
	Id int not null identity primary key,
	Title varchar(300) not null,
	CreateDate datetime2(7) not null,
	Text text not null,
	IsPublic bit not null,
	AdTypeId int not null,
	UserId int not null,
	CONSTRAINT FK_Ad_AdType FOREIGN KEY (AdTypeId) REFERENCES [AdBoard].[dbo].[AdTypes](Id),
	CONSTRAINT FK_Ad_User FOREIGN KEY (UserId) REFERENCES [AdBoard].[dbo].[Users](Id),
)

CREATE TABLE [AdBoard].[dbo].[Images] (
	Id int not null identity primary key,
	LargeImage varchar(300) not null,
	SmallImage varchar(300) not null,
	AdId int not null,
	CONSTRAINT FK_Image_Ad FOREIGN KEY (AdId) REFERENCES [AdBoard].[dbo].[Ads](Id),
)