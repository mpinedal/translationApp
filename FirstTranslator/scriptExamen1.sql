create database Translation;

USE [Translation]
GO
/****** Object:  Table [dbo].[TBL_RECORDS]    Script Date: 6/24/2019 11:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_RECORDS](
	[GUID] [nvarchar](100) NOT NULL,
	[Date] [nvarchar](100) NULL,
	[Source] [nvarchar](100) NULL,
	[Target] [nvarchar](100) NULL,
	[OriginalPhrase] [nvarchar](500) NULL,
	[Translation] [nvarchar](500) NULL,
	[Popularity] [int] NULL,
	[User] [nvarchar](500) NULL,
 CONSTRAINT [PK_TBL_History] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_USERS]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_USERS](
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_WORDS]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_WORDS](
	[GUID] [nvarchar](100) NOT NULL,
	[TranslatedWord] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Source] [nvarchar](50) NULL,
	[Target] [nvarchar](50) NULL,
	[Translation] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TBL_RECORDS] ([GUID], [Date], [Source], [Target], [OriginalPhrase], [Translation], [Popularity], [User]) VALUES (N'9fb0acc6-ef33-4bed-9e89-be562256f503', N'06 / 24 / 2019 22: 29:55', N'spanish', N'english', N'mi nombre es pikachu', N'my name is pikachu ', 34, N'milton')
INSERT [dbo].[TBL_RECORDS] ([GUID], [Date], [Source], [Target], [OriginalPhrase], [Translation], [Popularity], [User]) VALUES (N'ad50e569-9071-4cff-b108-92fbd32a3eea', N'06 / 24 / 2019 22: 43:13', N'spanish', N'english', N'mi nombre es mesa', N'my name is table ', 37, N'ney')
INSERT [dbo].[TBL_USERS] ([UserName], [Password]) VALUES (N'bbg', N'bbg')
INSERT [dbo].[TBL_USERS] ([UserName], [Password]) VALUES (N'milton', N'milton')
INSERT [dbo].[TBL_USERS] ([UserName], [Password]) VALUES (N'ney', N'ney')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'0c8ba311-168b-4e9e-80cb-e352627c8ba3', N'mango', 1, N'japanese', N'spanish', N'mango')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'0c8f8db9-d740-49c8-ab58-dfc2225c4451', N'manzana', 2, N'spanish', N'english', N'apple')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'11eebcb5-b576-4df1-b7ee-01d13ea2a887', N'computadora', 1, N'spanish', N'english', N'computer')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'24c8d3e4-7f2b-43e8-82e9-0a9844d937e8', N'oso', 1, N'spanish', N'english', N'bear')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'39095bf6-a2c5-4f22-a95d-70eb216aeb58', N'caja', 1, N'spanish', N'english', N'box')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'60009ee0-298a-49b1-88ce-9f8c6990667a', N'sol', 1, N'spanish', N'english', N'sun')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'60ce71c6-cd29-4739-b780-2033b5f2bc58', N'bulto', 1, N'spanish', N'english', N'bag')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'62118f81-5020-43e3-a93f-9f3df3b96b59', N'your', 1, N'english', N'spanish', N'tu')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'8165b5c4-d4da-4ac3-822c-9764cab53767', N'es', 12, N'spanish', N'english', N'is')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'97bf92b8-cebb-4043-9811-01239761d58f', N'televisor', 2, N'spanish', N'japanese', N'terebi')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'a0532050-a63f-4b03-9be1-b8f7a3bb269c', N'un', 1, N'spanish', N'english', N'a')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'a62a65a5-7419-43cc-a361-c55176631685', N'apple', 1, N'english', N'spanish', N'manzana')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'abb75756-c5e6-4222-b13f-8844abffe425', N'mi', 9, N'spanish', N'english', N'my')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'ae80b127-6265-44b1-8b7e-0da005ea4f5f', N'nombre', 15, N'spanish', N'english', N'name')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'b67c2fd7-d806-43a8-b38b-0134ff512da1', N'father', 1, N'english', N'spanish', N'padre')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'c9830643-fade-4248-b1a0-6a957e82fc3c', N'i', 1, N'english', N'spanish', N'yo')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'd3a1a98b-881e-495b-ad91-a7596c520d66', N'oceano', 1, N'spanish', N'english', N'ocean')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'd7b48ab4-a226-4a6c-bb03-fc5479e0b71f', N'esto', 1, N'spanish', N'english', N'this')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'e2453d57-c5e4-4985-a73a-04593f4dc2e5', N'pikachu', 1, N'spanish', N'english', N'pikachu')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'e6c2bce3-4f24-4df7-b018-174bcd7d9c13', N'luna', 2, N'spanish', N'english', N'moon')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'f2a795d6-28d4-4fa0-a8c8-4fe72f116aa1', N'am', 1, N'english', N'spanish', N'soy')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'f42aa435-8eea-468e-9b2f-6bcb02b7f2ec', N'manzana', 1, N'spanish', N'japanese', N'ringo')
INSERT [dbo].[TBL_WORDS] ([GUID], [TranslatedWord], [Quantity], [Source], [Target], [Translation]) VALUES (N'f54d241b-fdf6-4912-84d5-35ac95a6dedd', N'mesa', 1, N'spanish', N'english', N'table')
/****** Object:  StoredProcedure [dbo].[CREATE_RECORD_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--INSERT EN  Records
CREATE PROCEDURE [dbo].[CREATE_RECORD_PR]
	@P_GUID nvarchar(100),
	@P_Date nvarchar(100),
	@P_Source nvarchar(100),
	@P_Target nvarchar(100),
	@P_OriginalPhrase nvarchar(500),
	@P_Translation nvarchar(500),
	@P_Popularity int,
	@P_User nvarchar(100)

AS
	INSERT INTO [dbo].[TBL_RECORDS] VALUES(@P_GUID,@P_Date,@P_Source,@P_Target,@P_OriginalPhrase,@P_Translation,@P_Popularity,@P_User);
GO
/****** Object:  StoredProcedure [dbo].[CREATE_USER_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREATE_USER_PR]
	@P_UserName nvarchar(100),
	@P_Password nvarchar(50)

AS
	INSERT INTO [dbo].[TBL_USERS] VALUES(@P_UserName,@P_Password);
GO
/****** Object:  StoredProcedure [dbo].[CREATE_WORD_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREATE_WORD_PR]
	@P_GUID nvarchar(100),
	@P_TranslatedWord nvarchar(100),
	@P_Quantity int,
	@P_Source nvarchar(50),
	@P_Target nvarchar(50),
	@P_Translation nvarchar(100)
AS
	INSERT INTO [dbo].[TBL_WORDS] VALUES(@P_GUID,@P_TranslatedWord,@P_Quantity,@P_Source,@P_Target,@P_Translation);
GO
/****** Object:  StoredProcedure [dbo].[DEL_USER_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DEL_USER_PR]
	@P_UserName nvarchar(100)
AS
	DELETE FROM [TBL_USERS] WHERE UserName=@P_UserName;
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[DEL_WORD_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DEL_WORD_PR]
	@P_TranslatedWord nvarchar(100)
AS
	DELETE FROM [TBL_WORDS] WHERE TranslatedWord=@P_TranslatedWord;
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_RECORDS_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_ALL_RECORDS_PR]
AS
	SELECT [GUID], [Date],[Source], [Target], [OriginalPhrase], [Translation], [Popularity], [User] FROM [TBL_RECORDS];
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_USERS_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_ALL_USERS_PR]
AS
	SELECT [UserName], [Password] FROM [TBL_USERS];
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_WORDS_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--RETRIEVE ALL Words **
CREATE PROCEDURE [dbo].[RET_ALL_WORDS_PR]
AS
	SELECT GUID, TranslatedWord, [Quantity], [Source], [Target], [Translation] FROM [TBL_WORDS];
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[RET_USER_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_USER_PR]
	@P_UserName nvarchar(100)
AS
	SELECT  [UserName], [Password] FROM [TBL_USERS] WHERE Username=@P_UserName;
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[RET_WORD_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_WORD_PR]
	@P_TranslatedWord nvarchar(100),
		@P_Source nvarchar(50),
	@P_Target nvarchar(50)
AS
	SELECT  [GUID], TranslatedWord, Quantity, [Source], [Target], [Translation] FROM [TBL_WORDS] WHERE TranslatedWord=@P_TranslatedWord and [Source] = @P_Source and [Target] = @P_Target;
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[UPD_USER_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--UPDATE USERS
CREATE PROCEDURE [dbo].[UPD_USER_PR]
	@P_UserName nvarchar(100),
	@P_Password nvarchar(100)
AS
	UPDATE [dbo].[TBL_USERS] SET [UserName]=@P_UserName, [Password] = @P_Password WHERE UserName=@P_UserName;
GO
/****** Object:  StoredProcedure [dbo].[UPD_WORD_PR]    Script Date: 6/24/2019 11:46:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPD_WORD_PR]
	@P_GUID nvarchar(100),
	@P_TranslatedWord nvarchar(100),
	@P_Quantity int,
	@P_Source nvarchar(50),
	@P_Target nvarchar(50),
	@P_Translation nvarchar(100)
	
AS
	UPDATE [dbo].[TBL_WORDS] SET [GUID]=@P_GUID, TranslatedWord = @P_TranslatedWord, Quantity = @P_Quantity,[Source]= @P_Source, [Target] = @P_Target, [Translation] = @P_Translation   WHERE TranslatedWord=@P_TranslatedWord and [Source] = @P_Source and [Target] = @P_Target;

GO
