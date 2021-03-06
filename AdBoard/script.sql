USE [AdBoard]
GO
/****** Object:  Table [dbo].[Ads]    Script Date: 25.07.2016 1:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](300) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Text] [text] NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[AdTypeId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdTypes]    Script Date: 25.07.2016 1:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Images]    Script Date: 25.07.2016 1:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LargeImage] [varchar](300) NOT NULL,
	[SmallImage] [varchar](300) NOT NULL,
	[AdId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25.07.2016 1:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.07.2016 1:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegDate] [datetime2](7) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Country] [varchar](100) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[Phone] [varchar](100) NOT NULL,
	[Cookies] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[IsBlock] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Ads] ON 

INSERT [dbo].[Ads] ([Id], [Title], [CreateDate], [Text], [IsPublic], [AdTypeId], [UserId]) VALUES (2044, N'AD', CAST(N'2016-07-23 16:56:18.5305119' AS DateTime2), N'AD', 1, 1, 3)
INSERT [dbo].[Ads] ([Id], [Title], [CreateDate], [Text], [IsPublic], [AdTypeId], [UserId]) VALUES (2045, N'ASD', CAST(N'2016-07-24 18:23:57.8511765' AS DateTime2), N'asd', 1, 1, 3)
SET IDENTITY_INSERT [dbo].[Ads] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [RegDate], [FirstName], [LastName], [Email], [Country], [City], [Phone], [Cookies], [Password], [IsBlock], [RoleId]) VALUES (3, CAST(N'2016-07-11 15:31:38.4364255' AS DateTime2), N'Артем', N'Акимов', N'stalcker25@rambler.ru', N'Россия', N'Саратов', N'stalcker25@rambler.ru', N'33bb9019-f1f2-44a1-9491-ef8d68f1283e', N'49f9fa31289ed1a40d2747a8e18599a8', 0, 2)
INSERT [dbo].[Users] ([Id], [RegDate], [FirstName], [LastName], [Email], [Country], [City], [Phone], [Cookies], [Password], [IsBlock], [RoleId]) VALUES (4, CAST(N'2016-07-08 00:00:00.0000000' AS DateTime2), N'Admin', N'Admin', N'a-zenit-a@rambler.ru.ru', N'Россия', N'Саратов', N'89868329673', N'fd', N'49f9fa31289ed1a40d2747a8e18599a8', 0, 1)
INSERT [dbo].[Users] ([Id], [RegDate], [FirstName], [LastName], [Email], [Country], [City], [Phone], [Cookies], [Password], [IsBlock], [RoleId]) VALUES (5, CAST(N'2016-07-14 15:23:42.3207733' AS DateTime2), N'Степан', N'Ильич', N'razonicky@gmail.ru', N'Россия', N'Саратов', N'88005553535', N'af539c07-9d01-4b92-bffd-a0fbaeba0c78', N'49f9fa31289ed1a40d2747a8e18599a8', 0, 2)
INSERT [dbo].[Users] ([Id], [RegDate], [FirstName], [LastName], [Email], [Country], [City], [Phone], [Cookies], [Password], [IsBlock], [RoleId]) VALUES (6, CAST(N'2016-07-14 20:02:53.8906020' AS DateTime2), N'Виктор', N'Борисов', N'qwert@qwerty.ru', N'Россия', N'Саратов', N'88005553535', N'a3374d26-8f9a-47aa-bb0b-039d725e1cf9', N'49f9fa31289ed1a40d2747a8e18599a8', 0, 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Ads]  WITH NOCHECK ADD  CONSTRAINT [FK_Ad_AdType] FOREIGN KEY([AdTypeId])
REFERENCES [dbo].[AdTypes] ([Id])
GO
ALTER TABLE [dbo].[Ads] NOCHECK CONSTRAINT [FK_Ad_AdType]
GO
ALTER TABLE [dbo].[Ads]  WITH CHECK ADD  CONSTRAINT [FK_Ad_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Ads] CHECK CONSTRAINT [FK_Ad_User]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Image_Ad] FOREIGN KEY([AdId])
REFERENCES [dbo].[Ads] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Image_Ad]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Roles]
GO
