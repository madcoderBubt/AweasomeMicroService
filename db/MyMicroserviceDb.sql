CREATE Database [MyMicroServiceDb]
Go

USE [MyMicroServiceDb]
GO
/****** Object:  User [dbuser]    Script Date: 9/18/2022 4:33:03 AM ******/
CREATE USER [dbuser] FOR LOGIN [dbuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [dbuser]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [dbuser]
GO
/****** Object:  Table [dbo].[BookRents]    Script Date: 9/18/2022 4:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[ReaderId] [int] NOT NULL,
	[GivenBy] [int] NULL,
	[GivenDate] [datetime] NULL,
	[IsReturned] [bit] NULL,
	[ReturnDate] [datetime] NULL,
	[ReturnedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 9/18/2022 4:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[BookType] [int] NULL,
	[BookStatus] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[AddedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/18/2022 4:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[PassCode] [nvarchar](50) NULL,
	[JoinDate] [datetime] NULL,
	[UserStatus] [int] NULL,
	[UserType] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Description], [BookType], [BookStatus], [CreatedDate], [AddedBy]) VALUES (1, N'Harray Potter', N'J. K. Rowling', N'A popular comics based on magical beings hidden in our world.', 0, 1, CAST(N'2022-09-08T17:59:31.427' AS DateTime), 1002)
GO
INSERT [dbo].[Books] ([BookId], [Title], [Author], [Description], [BookType], [BookStatus], [CreatedDate], [AddedBy]) VALUES (2, N'Discreet Math', N'Unknown', N'Math is crazy.', 1, 1, CAST(N'2022-09-08T18:06:23.523' AS DateTime), 1002)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [UserName], [PassCode], [JoinDate], [UserStatus], [UserType]) VALUES (1, N'shbsovon', N'1234', CAST(N'2022-09-02T17:30:28.473' AS DateTime), 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [UserName], [PassCode], [JoinDate], [UserStatus], [UserType]) VALUES (2, N'Jonh', N'doe123', CAST(N'2022-09-04T15:22:16.450' AS DateTime), 1, 1)
GO
INSERT [dbo].[Users] ([UserId], [UserName], [PassCode], [JoinDate], [UserStatus], [UserType]) VALUES (3, N'Justin', N'sfx159', CAST(N'2022-09-04T15:28:46.697' AS DateTime), 0, 2)
GO
INSERT [dbo].[Users] ([UserId], [UserName], [PassCode], [JoinDate], [UserStatus], [UserType]) VALUES (1002, N'Wong', N'librarian', CAST(N'2022-09-08T17:21:50.027' AS DateTime), 1, 3)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
