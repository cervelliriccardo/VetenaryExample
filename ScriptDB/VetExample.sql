USE [master]
GO
/****** Object:  Database [VetExample]    Script Date: 11/04/2016 10:42:50 ******/
CREATE DATABASE [VetExample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VetExample', FILENAME = N'C:\Users\r.cervelli.somm\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\VetExample.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VetExample_log', FILENAME = N'C:\Users\r.cervelli.somm\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\VetExample.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VetExample] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VetExample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VetExample] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [VetExample] SET ANSI_NULLS ON 
GO
ALTER DATABASE [VetExample] SET ANSI_PADDING ON 
GO
ALTER DATABASE [VetExample] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [VetExample] SET ARITHABORT ON 
GO
ALTER DATABASE [VetExample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VetExample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VetExample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VetExample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VetExample] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [VetExample] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [VetExample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VetExample] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [VetExample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VetExample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VetExample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VetExample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VetExample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VetExample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VetExample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VetExample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VetExample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VetExample] SET RECOVERY FULL 
GO
ALTER DATABASE [VetExample] SET  MULTI_USER 
GO
ALTER DATABASE [VetExample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VetExample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VetExample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VetExample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [VetExample] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'VetExample', N'ON'
GO
ALTER DATABASE [VetExample] SET QUERY_STORE = OFF
GO
USE [VetExample]
GO
/****** Object:  User [VetExample]    Script Date: 11/04/2016 10:42:50 ******/
CREATE USER [VetExample] FOR LOGIN [VetExample] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[GetAnimalsByCustomer]    Script Date: 11/04/2016 10:42:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 07/03/2016
-- Description:	Get all the animals of a customers
-- =============================================
CREATE FUNCTION [dbo].[GetAnimalsByCustomer] 
(
	-- Add the parameters for the function here
	@CustomerId int
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(max)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = (Select 
		anim.ANIM_ID_PK as [ANIM_ID_PK], 
		anim.ANIM_NAME as [ANIM_NAME],
		anim.ANIM_CUST_ID as [ANIM_CUST_ID],
		anim.ANIM_ANMT_ID as [ANIM_ANMT_ID],
		anmt.ANMT_ID_PK as [AnimalType.ANMT_ID_PK],
		anmt.ANMT_DESCRIPTION as [AnimalType.ANMT_DESCRIPTION],
		anim.ANIM_BIRTHDATE as [ANIM_BIRTHDATE],
		convert(date,anim.ANIM_VALIDITYSTARTDATE) as [VALIDITYSTARTDATE],
		convert(date,anim.ANIM_VALIDITYENDDATE) as [VALIDITYENDDATE],
		convert(date,anim.ANIM_LASTMODIFIEDDATE) as [LASTMODIFIEDDATE],
		anim.ANIM_LASTMODIFIEDBY as [LASTMODIFIEDBY],
		json_query(dbo.GetUserJsonstring(anim.ANIM_LASTMODIFIEDBY)) as [lastModifiedByUser],
		convert(date,anim.ANIM_DELETEDDATE) as [DELETEDDATE],
		json_query([dbo].[GetTreatmentByAnimal](anim.ANIM_ID_PK)) as [Treatments]		
	  from ANIM_ANIMAL anim 
	  join ANMT_ANIMALTYPE anmt on anim.ANIM_ANMT_ID = anmt.ANMT_ID_PK 
	 where anim.ANIM_CUST_ID = @CustomerId 
	for json path, INCLUDE_NULL_VALUES);
	
	if (@Result is null) 
	Begin
		set @Result = '[]';
	End;
	RETURN @Result;
END

GO
/****** Object:  UserDefinedFunction [dbo].[GetTreatmentByAnimal]    Script Date: 11/04/2016 10:42:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 07/03/2016
-- Description:	Returns all the treatments for an animal
-- =============================================
CREATE FUNCTION [dbo].[GetTreatmentByAnimal] 
(
	-- Add the parameters for the function here
	@AnimalId int
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(max)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = (select 
	trea.TREA_ANIM_ID_PK				   as [TREA_ANIM_ID_PK],
			trea.TREA_TRET_ID_PK				   as [TREA_TRET_ID_PK],
			trea.TREA_TREATDATE_PK				   as [TREA_TREATDATE_PK],
			trea.TREA_PERFORMEDBY				   as [TREA_PERFORMEDBY],
			json_query(dbo.GetUserJsonstring(trea.TREA_PERFORMEDBY)) as [treatmentPerformedByUser],
			trea.TREA_NOTE						   as [TREA_NOTE],
			convert(date,trea.TREA_LASTMODIFIEDDATE)   as [LASTMODIFIEDDATE],
			trea.TREA_LASTMODIFIEDBY			   as [LASTMODIFIEDBY],
			json_query(dbo.GetUserJsonstring(trea.TREA_LASTMODIFIEDBY)) as [lastModifiedByUser],
			convert(date,trea.TREA_DELETEDDATE)				   as [DELETEDDATE],
			convert(date,trea.TREA_VALIDITYSTARTDATE)			   as [VALIDITYSTARTDATE],
			convert(date,trea.TREA_VALIDITYENDDATE)			   as [VALIDITYENDDATE],
			tret.TRET_ID_PK as [TreatmentType.TRET_ID_PK],
			tret.TRET_DESCRIPTION as [TreatmentType.TRET_DESCRIPTION]			 
			from TREA_TREATMENT trea join TRET_TREATMENTTYPE tret on trea.TREA_TRET_ID_PK = tret.TRET_ID_PK
			where trea.TREA_ANIM_ID_PK = @AnimalId
			for json path, INCLUDE_NULL_VALUES);
			
	if (@Result is null) 
	Begin
		set @Result = '[]';
	End;

	RETURN @Result

END

GO
/****** Object:  UserDefinedFunction [dbo].[GetUserJsonString]    Script Date: 11/04/2016 10:42:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		RIccardo Cervelli
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetUserJsonString] 
(
	-- Add the parameters for the function here
	@UserId int
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result nvarchar(max)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = (SELECT top 1 veuser.USER_ID_PK as [USER_ID_PK],
		   veuser.USER_USERNAME as [USER_USERNAME],
		   veuser.USER_PASSWORD as [USER_PASSWORD],
		   veuser.USER_NAME as [USER_NAME],
		   veuser.USER_SURNAME as [USER_SURNAME] 
	from USER_USER veuser
	where veuser.USER_ID_PK  =  @UserId
	for json path, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER );

	RETURN @Result;

END

GO
/****** Object:  Table [dbo].[ANIM_ANIMAL]    Script Date: 11/04/2016 10:42:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ANIM_ANIMAL](
	[ANIM_ID_PK] [int] IDENTITY(1,1) NOT NULL,
	[ANIM_CUST_ID] [int] NOT NULL,
	[ANIM_NAME] [nvarchar](20) NOT NULL,
	[ANIM_ANMT_ID] [int] NOT NULL,
	[ANIM_BIRTHDATE] [datetime] NULL,
	[ANIM_LASTMODIFIEDDATE] [datetime] NOT NULL,
	[ANIM_LASTMODIFIEDBY] [int] NOT NULL,
	[ANIM_DELETEDDATE] [datetime] NULL,
	[ANIM_VALIDITYSTARTDATE] [datetime] NULL,
	[ANIM_VALIDITYENDDATE] [datetime] NULL,
 CONSTRAINT [PK__ANIM_ANI__396E45012D670703] PRIMARY KEY CLUSTERED 
(
	[ANIM_ID_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ANMT_ANIMALTYPE]    Script Date: 11/04/2016 10:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ANMT_ANIMALTYPE](
	[ANMT_ID_PK] [int] IDENTITY(1,1) NOT NULL,
	[ANMT_DESCRIPTION] [nvarchar](25) NOT NULL,
	[ANMT_LASTMODIFIEDDATE] [datetime] NOT NULL,
	[ANMT_LASTMODIFIEDBY] [int] NOT NULL,
	[ANMT_DELETEDDATE] [datetime] NULL,
	[ANMT_VALIDITYSTARTDATE] [datetime] NULL,
	[ANMT_VALIDITYENDDATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ANMT_ID_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CUST_CUSTOMER]    Script Date: 11/04/2016 10:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUST_CUSTOMER](
	[CUST_ID_PK] [int] IDENTITY(1,1) NOT NULL,
	[CUST_NAME] [nvarchar](25) NOT NULL,
	[CUST_SURMANE] [nvarchar](25) NOT NULL,
	[CUST_TEL_NUM] [nvarchar](20) NULL,
	[CUST_LASTMODIFIEDDATE] [datetime] NOT NULL,
	[CUST_LASTMODIFIEDBY] [int] NOT NULL,
	[CUST_DELETEDDATE] [datetime] NULL,
	[CUST_VALIDITYSTARTDATE] [datetime] NULL,
	[CUST_VALIDITYENDDATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CUST_ID_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TREA_TREATMENT]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TREA_TREATMENT](
	[TREA_ANIM_ID_PK] [int] NOT NULL,
	[TREA_TRET_ID_PK] [int] NOT NULL,
	[TREA_TREATDATE_PK] [datetime] NOT NULL,
	[TREA_PERFORMEDBY] [int] NOT NULL,
	[TREA_NOTE] [nvarchar](500) NULL,
	[TREA_LASTMODIFIEDDATE] [datetime] NOT NULL,
	[TREA_LASTMODIFIEDBY] [int] NOT NULL,
	[TREA_DELETEDDATE] [datetime] NULL,
	[TREA_VALIDITYSTARTDATE] [datetime] NULL,
	[TREA_VALIDITYENDDATE] [datetime] NULL,
 CONSTRAINT [PK__TREA_TRE__1C0B4F3DF21287E5] PRIMARY KEY CLUSTERED 
(
	[TREA_ANIM_ID_PK] ASC,
	[TREA_TREATDATE_PK] ASC,
	[TREA_TRET_ID_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TRET_TREATMENTTYPE]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRET_TREATMENTTYPE](
	[TRET_ID_PK] [int] IDENTITY(1,1) NOT NULL,
	[TRET_DESCRIPTION] [nvarchar](50) NOT NULL,
	[TRET_LASTMODIFIEDDATE] [datetime] NOT NULL,
	[TRET_LASTMODIFIEDBY] [int] NOT NULL,
	[TRET_DELETEDDATE] [nchar](10) NULL,
	[TRET_VALIDITYSTARTDATE] [datetime] NULL,
	[TRET_VALIDITYENDDATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TRET_ID_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USER_USER]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_USER](
	[USER_ID_PK] [int] IDENTITY(1,1) NOT NULL,
	[USER_USERNAME] [nvarchar](15) NOT NULL,
	[USER_PASSWORD] [nvarchar](20) NULL,
	[USER_NAME] [nvarchar](25) NULL,
	[USER_SURNAME] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[USER_ID_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ANIM_ANIMAL] ADD  CONSTRAINT [DF__ANIM_ANIM__ANIM___173876EA]  DEFAULT (getdate()) FOR [ANIM_LASTMODIFIEDDATE]
GO
ALTER TABLE [dbo].[ANIM_ANIMAL] ADD  CONSTRAINT [DF__ANIM_ANIM__ANIM___21B6055D]  DEFAULT (getdate()) FOR [ANIM_VALIDITYSTARTDATE]
GO
ALTER TABLE [dbo].[ANMT_ANIMALTYPE] ADD  CONSTRAINT [DF_ANMT_ANIMALTYPE_ANMT_LASTMODIFIEDDATE]  DEFAULT (getdate()) FOR [ANMT_LASTMODIFIEDDATE]
GO
ALTER TABLE [dbo].[ANMT_ANIMALTYPE] ADD  CONSTRAINT [DF_ANMT_ANIMALTYPE_ANMT_LASTMODIFIEDBY]  DEFAULT ((1)) FOR [ANMT_LASTMODIFIEDBY]
GO
ALTER TABLE [dbo].[CUST_CUSTOMER] ADD  DEFAULT (getdate()) FOR [CUST_LASTMODIFIEDDATE]
GO
ALTER TABLE [dbo].[TREA_TREATMENT] ADD  CONSTRAINT [DF__TREA_TREA__TREA___276EDEB3]  DEFAULT (getdate()) FOR [TREA_LASTMODIFIEDDATE]
GO
ALTER TABLE [dbo].[TRET_TREATMENTTYPE] ADD  CONSTRAINT [DF_TRET_TREATMENTTYPE_TRET_LASTMODIFIEDDATE]  DEFAULT (getdate()) FOR [TRET_LASTMODIFIEDDATE]
GO
ALTER TABLE [dbo].[TRET_TREATMENTTYPE] ADD  CONSTRAINT [DF_TRET_TREATMENTTYPE_TRET_LASTMODIFIEDBY]  DEFAULT ((1)) FOR [TRET_LASTMODIFIEDBY]
GO
ALTER TABLE [dbo].[ANIM_ANIMAL]  WITH CHECK ADD  CONSTRAINT [FK_ANIM_ANMT] FOREIGN KEY([ANIM_ANMT_ID])
REFERENCES [dbo].[ANMT_ANIMALTYPE] ([ANMT_ID_PK])
GO
ALTER TABLE [dbo].[ANIM_ANIMAL] CHECK CONSTRAINT [FK_ANIM_ANMT]
GO
ALTER TABLE [dbo].[ANIM_ANIMAL]  WITH CHECK ADD  CONSTRAINT [FK_ANIM_CUST] FOREIGN KEY([ANIM_CUST_ID])
REFERENCES [dbo].[CUST_CUSTOMER] ([CUST_ID_PK])
GO
ALTER TABLE [dbo].[ANIM_ANIMAL] CHECK CONSTRAINT [FK_ANIM_CUST]
GO
ALTER TABLE [dbo].[ANIM_ANIMAL]  WITH CHECK ADD  CONSTRAINT [FK_ANIM_USER_MBY] FOREIGN KEY([ANIM_LASTMODIFIEDBY])
REFERENCES [dbo].[USER_USER] ([USER_ID_PK])
GO
ALTER TABLE [dbo].[ANIM_ANIMAL] CHECK CONSTRAINT [FK_ANIM_USER_MBY]
GO
ALTER TABLE [dbo].[ANMT_ANIMALTYPE]  WITH CHECK ADD  CONSTRAINT [FK_ANMT_USER_MBY] FOREIGN KEY([ANMT_LASTMODIFIEDBY])
REFERENCES [dbo].[USER_USER] ([USER_ID_PK])
GO
ALTER TABLE [dbo].[ANMT_ANIMALTYPE] CHECK CONSTRAINT [FK_ANMT_USER_MBY]
GO
ALTER TABLE [dbo].[CUST_CUSTOMER]  WITH CHECK ADD  CONSTRAINT [FK_CUST_USER_MBY] FOREIGN KEY([CUST_LASTMODIFIEDBY])
REFERENCES [dbo].[USER_USER] ([USER_ID_PK])
GO
ALTER TABLE [dbo].[CUST_CUSTOMER] CHECK CONSTRAINT [FK_CUST_USER_MBY]
GO
ALTER TABLE [dbo].[TREA_TREATMENT]  WITH CHECK ADD  CONSTRAINT [FK_TREA_ANIM] FOREIGN KEY([TREA_ANIM_ID_PK])
REFERENCES [dbo].[ANIM_ANIMAL] ([ANIM_ID_PK])
GO
ALTER TABLE [dbo].[TREA_TREATMENT] CHECK CONSTRAINT [FK_TREA_ANIM]
GO
ALTER TABLE [dbo].[TREA_TREATMENT]  WITH CHECK ADD  CONSTRAINT [FK_TREA_TREAT] FOREIGN KEY([TREA_TRET_ID_PK])
REFERENCES [dbo].[TRET_TREATMENTTYPE] ([TRET_ID_PK])
GO
ALTER TABLE [dbo].[TREA_TREATMENT] CHECK CONSTRAINT [FK_TREA_TREAT]
GO
ALTER TABLE [dbo].[TREA_TREATMENT]  WITH CHECK ADD  CONSTRAINT [FK_TREA_USER_MBY] FOREIGN KEY([TREA_LASTMODIFIEDBY])
REFERENCES [dbo].[USER_USER] ([USER_ID_PK])
GO
ALTER TABLE [dbo].[TREA_TREATMENT] CHECK CONSTRAINT [FK_TREA_USER_MBY]
GO
ALTER TABLE [dbo].[TREA_TREATMENT]  WITH CHECK ADD  CONSTRAINT [FK_TREA_USER_PBY] FOREIGN KEY([TREA_PERFORMEDBY])
REFERENCES [dbo].[USER_USER] ([USER_ID_PK])
GO
ALTER TABLE [dbo].[TREA_TREATMENT] CHECK CONSTRAINT [FK_TREA_USER_PBY]
GO
ALTER TABLE [dbo].[TRET_TREATMENTTYPE]  WITH CHECK ADD  CONSTRAINT [FK_TRET_USER_MBY] FOREIGN KEY([TRET_LASTMODIFIEDBY])
REFERENCES [dbo].[USER_USER] ([USER_ID_PK])
GO
ALTER TABLE [dbo].[TRET_TREATMENTTYPE] CHECK CONSTRAINT [FK_TRET_USER_MBY]
GO
/****** Object:  StoredProcedure [dbo].[ANIMAL_PR_D]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Delete an animal
-- =============================================
CREATE PROCEDURE [dbo].[ANIMAL_PR_D] 
	@ANIM_ID_PK_P int, 
	@ANIM_LASTMODIFIEDBY int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[ANIM_ANIMAL]
   SET [ANIM_LASTMODIFIEDDATE] = getdate()
      ,[ANIM_LASTMODIFIEDBY] = @ANIM_LASTMODIFIEDBY
      ,[ANIM_DELETEDDATE] = getdate()
 WHERE ANIM_ID_PK = @ANIM_ID_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[ANIMAL_PR_I]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Insert an animal
-- =============================================
CREATE PROCEDURE [dbo].[ANIMAL_PR_I] 
	@ANIM_CUST_ID_P int,
	@ANIM_NAME_P nvarchar(20),
	@ANIM_ANMT_ID_P int,
	@ANIM_BIRTHDATE_P datetime,
	@ANIM_LASTMODIFIEDBY_P int,
	@ANIM_VALIDITYSTARTDATE_P datetime,
	@ANIM_VALIDITYENDDATE_P datetime,
	@ANIM_ID_PK_P int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[ANIM_ANIMAL]
           ([ANIM_CUST_ID]
           ,[ANIM_NAME]
           ,[ANIM_ANMT_ID]
           ,[ANIM_BIRTHDATE]
           ,[ANIM_LASTMODIFIEDDATE]
           ,[ANIM_LASTMODIFIEDBY]
           ,[ANIM_VALIDITYSTARTDATE]
           ,[ANIM_VALIDITYENDDATE])
     VALUES
           (@ANIM_CUST_ID_P
           ,@ANIM_NAME_P
           ,@ANIM_ANMT_ID_P
           ,@ANIM_BIRTHDATE_P
		   ,getdate()
           ,@ANIM_LASTMODIFIEDBY_P
           ,@ANIM_VALIDITYSTARTDATE_P
           ,@ANIM_VALIDITYENDDATE_P);           
		   set @ANIM_ID_PK_P = SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[ANIMAL_PR_R]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Restore a deleted animal
-- =============================================
CREATE PROCEDURE [dbo].[ANIMAL_PR_R] 
	@ANIM_ID_PK_P int, 
	@ANIM_LASTMODIFIEDBY int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[ANIM_ANIMAL]
   SET [ANIM_LASTMODIFIEDDATE] = getdate()
      ,[ANIM_LASTMODIFIEDBY] = @ANIM_LASTMODIFIEDBY
      ,[ANIM_DELETEDDATE] = null
 WHERE ANIM_ID_PK = @ANIM_ID_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[ANIMAL_PR_U]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Update an animal
-- =============================================
CREATE PROCEDURE [dbo].[ANIMAL_PR_U] 
	@ANIM_ID_PK_P int, 
	@ANIM_CUST_ID_P int,
	@ANIM_NAME_P nvarchar(20),
	@ANIM_ANMT_ID_P int,
	@ANIM_BIRTHDATE_P datetime,
	@ANIM_LASTMODIFIEDBY_P int,
	@ANIM_DELETEDDATE_P datetime,
	@ANIM_VALIDITYSTARTDATE_P datetime,
	@ANIM_VALIDITYENDDATE_P datetime	
AS
BEGIN
	SET NOCOUNT ON;


UPDATE [dbo].[ANIM_ANIMAL]
   SET [ANIM_CUST_ID] = @ANIM_CUST_ID_P
      ,[ANIM_NAME] = @ANIM_NAME_P
      ,[ANIM_ANMT_ID] = @ANIM_ANMT_ID_P
      ,[ANIM_BIRTHDATE] = @ANIM_BIRTHDATE_P
      ,[ANIM_LASTMODIFIEDDATE] = getdate()
      ,[ANIM_LASTMODIFIEDBY] = @ANIM_LASTMODIFIEDBY_P
      ,[ANIM_DELETEDDATE] = @ANIM_DELETEDDATE_P
      ,[ANIM_VALIDITYSTARTDATE] = @ANIM_VALIDITYSTARTDATE_P
      ,[ANIM_VALIDITYENDDATE] = @ANIM_VALIDITYENDDATE_P
 WHERE ANIM_ID_PK = @ANIM_ID_PK_P;

END

GO
/****** Object:  StoredProcedure [dbo].[ANIMALTYPE_PR_D]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 01/04/2016
-- Description:	Delete an animal type
-- =============================================
CREATE PROCEDURE [dbo].[ANIMALTYPE_PR_D] 
	@ANMT_ID_PK_P int,
	@ANMT_LASTMODIFIEDBY_P int
AS
BEGIN
	SET NOCOUNT ON;

     UPDATE [dbo].[ANMT_ANIMALTYPE]
		SET [ANMT_LASTMODIFIEDDATE] = getdate()
			,[ANMT_LASTMODIFIEDBY] = @ANMT_LASTMODIFIEDBY_P
			,[ANMT_DELETEDDATE] = getdate()
	  WHERE	ANMT_ID_PK = @ANMT_ID_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[ANIMALTYPE_PR_I]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 01/04/2016
-- Description:	Insert an animal type
-- =============================================
CREATE PROCEDURE [dbo].[ANIMALTYPE_PR_I] 
	@ANMT_DESCRIPTION_P nvarchar(25),
	@ANMT_LASTMODIFIEDBY_P int,
	@ANMT_VALIDITYSTARTDATE_P datetime,
	@ANMT_VALIDITYENDDATE_P datetime,
	@ANMT_ID_PK_P int output
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ANMT_ANIMALTYPE]
           ([ANMT_DESCRIPTION]
           ,[ANMT_LASTMODIFIEDDATE]
           ,[ANMT_LASTMODIFIEDBY]
           ,[ANMT_VALIDITYSTARTDATE]
           ,[ANMT_VALIDITYENDDATE])
     VALUES
           (@ANMT_DESCRIPTION_P
           ,getdate()
           ,@ANMT_LASTMODIFIEDBY_P
           ,@ANMT_VALIDITYSTARTDATE_P
           ,@ANMT_VALIDITYENDDATE_P);
	set @ANMT_ID_PK_P = SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[ANIMALTYPE_PR_R]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 01/04/2016
-- Description:	Restore an animal type
-- =============================================
CREATE PROCEDURE [dbo].[ANIMALTYPE_PR_R] 
	@ANMT_ID_PK_P int,
	@ANMT_LASTMODIFIEDBY_P int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[ANMT_ANIMALTYPE]
	   SET [ANMT_LASTMODIFIEDDATE] = getdate()
		  ,[ANMT_LASTMODIFIEDBY] = @ANMT_LASTMODIFIEDBY_P
		  ,[ANMT_DELETEDDATE] = null
	 WHERE	ANMT_ID_PK = @ANMT_ID_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[ANIMALTYPE_PR_U]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 01/04/2016
-- Description:	Update an animal type
-- =============================================
CREATE PROCEDURE [dbo].[ANIMALTYPE_PR_U] 
	@ANMT_ID_PK_P int,
	@ANMT_DESCRIPTION_P nvarchar(25),
	@ANMT_LASTMODIFIEDBY_P int,
	@ANMT_VALIDITYSTARTDATE_P datetime,
	@ANMT_VALIDITYENDDATE_P datetime	
AS
BEGIN
	
    UPDATE [dbo].[ANMT_ANIMALTYPE]
	   SET [ANMT_DESCRIPTION] = @ANMT_DESCRIPTION_P
		  ,[ANMT_LASTMODIFIEDDATE] = getdate()
		  ,[ANMT_LASTMODIFIEDBY] = @ANMT_LASTMODIFIEDBY_P
		  ,[ANMT_VALIDITYSTARTDATE] = @ANMT_VALIDITYSTARTDATE_P
		  ,[ANMT_VALIDITYENDDATE] = @ANMT_VALIDITYENDDATE_P
	 WHERE ANMT_ID_PK = @ANMT_ID_PK_P; 
END

GO
/****** Object:  StoredProcedure [dbo].[CUSTOMER_PR_D]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Delete a customer
-- =============================================
CREATE PROCEDURE [dbo].[CUSTOMER_PR_D] 
	@CUST_ID_PK_P int,
	@CUST_LASTMODIFIEDBY_P int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[CUST_CUSTOMER]
   SET [CUST_LASTMODIFIEDDATE] = getdate()
      ,[CUST_LASTMODIFIEDBY] = @CUST_LASTMODIFIEDBY_P
      ,[CUST_DELETEDDATE] = getdate()
 WHERE CUST_ID_PK = @CUST_ID_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[CUSTOMER_PR_I]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Insert Customer
-- =============================================
CREATE PROCEDURE [dbo].[CUSTOMER_PR_I] 
	@CUST_NAME_P nvarchar(25), 
	@CUST_SURMANE_P nvarchar(25),
	@CUST_TEL_NUM_P nvarchar(20),
	@CUST_LASTMODIFIEDBY_P int,
	@CUST_VALIDITYSTARTDATE_P datetime,
	@CUST_VALIDITYENDDATE_P datetime,
	@CUST_ID_PK_P int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[CUST_CUSTOMER]
           ([CUST_NAME]
           ,[CUST_SURMANE]
           ,[CUST_TEL_NUM]
           ,[CUST_LASTMODIFIEDDATE]
           ,[CUST_LASTMODIFIEDBY]
           ,[CUST_VALIDITYSTARTDATE]
           ,[CUST_VALIDITYENDDATE])
     VALUES
           (@CUST_NAME_P
           ,@CUST_SURMANE_P
           ,@CUST_TEL_NUM_P
           ,getdate()
           ,@CUST_LASTMODIFIEDBY_P
           ,@CUST_VALIDITYSTARTDATE_P
           ,@CUST_VALIDITYENDDATE_P);
	set @CUST_ID_PK_P = SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[CUSTOMER_PR_R]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Restore a deleted customer
-- =============================================
CREATE PROCEDURE [dbo].[CUSTOMER_PR_R] 
	@CUST_ID_PK_P int,
	@CUST_LASTMODIFIEDBY_P int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[CUST_CUSTOMER]
   SET [CUST_LASTMODIFIEDDATE] = getdate()
      ,[CUST_LASTMODIFIEDBY] = @CUST_LASTMODIFIEDBY_P
      ,[CUST_DELETEDDATE] = null
 WHERE CUST_ID_PK = @CUST_ID_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[CUSTOMER_PR_U]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Update customer
-- =============================================
CREATE PROCEDURE [dbo].[CUSTOMER_PR_U] 
	@CUST_ID_PK_P int,
	@CUST_NAME_P nvarchar(25), 
	@CUST_SURMANE_P nvarchar(25),
	@CUST_TEL_NUM_P nvarchar(20),
	@CUST_LASTMODIFIEDBY_P int,
	@CUST_VALIDITYSTARTDATE_P datetime,
	@CUST_VALIDITYENDDATE_P datetime	
AS
BEGIN
	SET NOCOUNT ON;

UPDATE [dbo].[CUST_CUSTOMER]
   SET [CUST_NAME] = @CUST_NAME_P
      ,[CUST_SURMANE] = @CUST_SURMANE_P
      ,[CUST_TEL_NUM] = @CUST_TEL_NUM_P
      ,[CUST_LASTMODIFIEDDATE] = getdate()
      ,[CUST_LASTMODIFIEDBY] = @CUST_LASTMODIFIEDBY_P
      ,[CUST_VALIDITYSTARTDATE] = @CUST_VALIDITYSTARTDATE_P
      ,[CUST_VALIDITYENDDATE] = @CUST_VALIDITYENDDATE_P
 WHERE CUST_ID_PK = @CUST_ID_PK_P;

END

GO
/****** Object:  StoredProcedure [dbo].[GetAnimalTypes]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 24/03/2016
-- Description:	Return the animal types
-- =============================================
CREATE PROCEDURE [dbo].[GetAnimalTypes] 
	@justValid_p int = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [ANMT_ID_PK]
		  ,[ANMT_DESCRIPTION]
		  ,[ANMT_LASTMODIFIEDDATE] as LASTMODIFIEDDATE
		  ,[ANMT_LASTMODIFIEDBY] as LASTMODIFIEDBY
		  ,json_query(dbo.GetUserJsonstring(ANMT_LASTMODIFIEDBY)) as [lastModifiedByUser]
		  ,[ANMT_DELETEDDATE] as DELETEDDATE
		  ,[ANMT_VALIDITYSTARTDATE] as VALIDITYSTARTDATE
		  ,[ANMT_VALIDITYENDDATE] as VALIDITYENDDATE
	  FROM [dbo].[ANMT_ANIMALTYPE]
	  where ((@justValid_p = 0) OR (ANMT_DELETEDDATE IS NULL 
									and getdate() between ISNULL(ANMT_VALIDITYSTARTDATE, getdate()-1) 
													  and ISNULL(ANMT_VALIDITYENDDATE, getdate()+1)))
	  for json path, INCLUDE_NULL_VALUES;
END

GO
/****** Object:  StoredProcedure [dbo].[GetCustomersFull]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 07/03/2016
-- Description:	Get all customers with all animals and all treatments
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomersFull] 
	@justValid_p int = 0,
	@idCustomer_p int = -1
AS
BEGIN
	SET NOCOUNT ON;
	SET DATEFORMAT DMY;

    -- Insert statements for procedure here
	select cust.CUST_ID_PK as [CUST_ID_PK], 
		cust.CUST_NAME as [CUST_NAME], 
		cust.CUST_SURMANE as [CUST_SURMANE],
		cust.CUST_TEL_NUM as [CUST_TEL_NUM],
		convert(date,cust.CUST_VALIDITYSTARTDATE) as [VALIDITYSTARTDATE],
		convert(date,cust.CUST_VALIDITYENDDATE)		as [VALIDITYENDDATE],
		convert(date,cust.CUST_LASTMODIFIEDDATE)	as [LASTMODIFIEDDATE],
		cust.CUST_LASTMODIFIEDBY		as [LASTMODIFIEDBY],
		json_query(dbo.GetUserJsonstring(cust.CUST_LASTMODIFIEDBY)) as [lastModifiedByUser],    
		cust.CUST_DELETEDDATE	as [DELETEDDATE],
		json_query(dbo.GetAnimalsByCustomer(cust.CUST_ID_PK)) As [Animals]	
	from CUST_CUSTOMER cust	
	where (@justValid_p = 0 OR CUST_DELETEDDATE IS NULL)
	and (@idCustomer_p = -1 OR CUST_ID_PK = @idCustomer_p)
	for json path, INCLUDE_NULL_VALUES;
END

GO
/****** Object:  StoredProcedure [dbo].[GetTreatmentTypes]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 24/03/2016
-- Description:	Return treatments type
-- =============================================
CREATE PROCEDURE [dbo].[GetTreatmentTypes] 
	@justValid_p int = 0
AS
BEGIN
	SET NOCOUNT ON;

    SELECT [TRET_ID_PK]
		  ,[TRET_DESCRIPTION]
		  ,[TRET_LASTMODIFIEDDATE] as LASTMODIFIEDDATE
		  ,[TRET_LASTMODIFIEDBY] as LASTMODIFIEDBY
		  ,json_query(dbo.GetUserJsonstring(TRET_LASTMODIFIEDBY)) as [lastModifiedByUser]
		  ,[TRET_DELETEDDATE] as DELETEDDATE
		  ,[TRET_VALIDITYSTARTDATE] as VALIDITYSTARTDATE
		  ,[TRET_VALIDITYENDDATE] as VALIDITYENDDATE
      FROM [dbo].[TRET_TREATMENTTYPE]
	  where ((@justValid_p = 0) OR (TRET_DELETEDDATE IS NULL 
									and getdate() between ISNULL(TRET_VALIDITYSTARTDATE, getdate()-1) 
													  and ISNULL(TRET_VALIDITYENDDATE, getdate()+1)))
    for json path, INCLUDE_NULL_VALUES;

END

GO
/****** Object:  StoredProcedure [dbo].[TREATMENT_PR_D]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Delete a treatment
-- =============================================
CREATE PROCEDURE [dbo].[TREATMENT_PR_D] 
	@TREA_ANIM_ID_PK_P int,
	@TREA_TRET_ID_PK_P int,
	@TREA_TREATDATE_PK_P datetime,
	@TREA_LASTMODIFIEDBY_P int	
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[TREA_TREATMENT]
	   SET [TREA_LASTMODIFIEDDATE] = getdate()
		  ,[TREA_LASTMODIFIEDBY] = @TREA_LASTMODIFIEDBY_P
		  ,[TREA_DELETEDDATE] = getdate()
	 WHERE [TREA_ANIM_ID_PK] = @TREA_ANIM_ID_PK_P
		   and [TREA_TRET_ID_PK] = @TREA_TRET_ID_PK_P
		   and [TREA_TREATDATE_PK] = @TREA_TREATDATE_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[TREATMENT_PR_I]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Insert a treatment
-- =============================================
CREATE PROCEDURE [dbo].[TREATMENT_PR_I] 
	-- Add the parameters for the stored procedure here
	@TREA_ANIM_ID_PK_P int,
	@TREA_TRET_ID_PK_P int,
	@TREA_TREATDATE_PK_P datetime,
	@TREA_PERFORMEDBY_P int,
	@TREA_NOTE_P nvarchar(500),
	@TREA_LASTMODIFIEDBY_P int,
	@TREA_VALIDITYSTARTDATE_P datetime,
	@TREA_VALIDITYENDDATE_P datetime
AS
BEGIN
	SET NOCOUNT ON;
  
INSERT INTO [dbo].[TREA_TREATMENT]
           ([TREA_ANIM_ID_PK]
           ,[TREA_TRET_ID_PK]
           ,[TREA_TREATDATE_PK]
           ,[TREA_PERFORMEDBY]
           ,[TREA_NOTE]
           ,[TREA_LASTMODIFIEDDATE]
           ,[TREA_LASTMODIFIEDBY]
           ,[TREA_VALIDITYSTARTDATE]
           ,[TREA_VALIDITYENDDATE])
     VALUES
           (@TREA_ANIM_ID_PK_P 
           ,@TREA_TRET_ID_PK_P 
           ,@TREA_TREATDATE_PK_P 
           ,@TREA_PERFORMEDBY_P 
           ,@TREA_NOTE_P 
		   ,getdate()
           ,@TREA_LASTMODIFIEDBY_P 
           ,@TREA_VALIDITYSTARTDATE_P
           ,@TREA_VALIDITYENDDATE_P)
END

GO
/****** Object:  StoredProcedure [dbo].[TREATMENT_PR_R]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Restore a deleted treatment
-- =============================================
CREATE PROCEDURE [dbo].[TREATMENT_PR_R] 
	@TREA_ANIM_ID_PK_P int,
	@TREA_TRET_ID_PK_P int,
	@TREA_TREATDATE_PK_P datetime,
	@TREA_LASTMODIFIEDBY_P int	
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[TREA_TREATMENT]
	   SET [TREA_LASTMODIFIEDDATE] = getdate()
		  ,[TREA_LASTMODIFIEDBY] = @TREA_LASTMODIFIEDBY_P
		  ,[TREA_DELETEDDATE] = null
	 WHERE [TREA_ANIM_ID_PK] = @TREA_ANIM_ID_PK_P
		   and [TREA_TRET_ID_PK] = @TREA_TRET_ID_PK_P
		   and [TREA_TREATDATE_PK] = @TREA_TREATDATE_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[TREATMENT_PR_U]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 23/03/2016
-- Description:	Update a treatment
-- =============================================
CREATE PROCEDURE [dbo].[TREATMENT_PR_U] 
	@TREA_ANIM_ID_PK_P int,
	@TREA_TRET_ID_PK_P int,
	@TREA_TREATDATE_PK_P datetime,
	@TREA_NOTE_P nvarchar(500),
	@TREA_LASTMODIFIEDBY_P int,
	@TREA_DELETEDDATE_P datetime = null,
	@TREA_VALIDITYSTARTDATE_P datetime,
	@TREA_VALIDITYENDDATE_P datetime = null
AS
BEGIN
	SET NOCOUNT ON;

UPDATE [dbo].[TREA_TREATMENT]
   SET [TREA_NOTE] = @TREA_NOTE_P
      ,[TREA_LASTMODIFIEDDATE] = getdate()
      ,[TREA_LASTMODIFIEDBY] = @TREA_LASTMODIFIEDBY_P
	  ,[TREA_DELETEDDATE] = @TREA_DELETEDDATE_P
      ,[TREA_VALIDITYSTARTDATE] = @TREA_VALIDITYSTARTDATE_P
      ,[TREA_VALIDITYENDDATE] = @TREA_VALIDITYENDDATE_P
 WHERE [TREA_ANIM_ID_PK] = @TREA_ANIM_ID_PK_P
       and [TREA_TRET_ID_PK] = @TREA_TRET_ID_PK_P
       and [TREA_TREATDATE_PK] = @TREA_TREATDATE_PK_P;

END

GO
/****** Object:  StoredProcedure [dbo].[TREATMENTTYPE_PR_D]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 01/04/2016
-- Description:	Delete a treatment type
-- =============================================
CREATE PROCEDURE [dbo].[TREATMENTTYPE_PR_D] 
	@TRET_ID_PK_P int,
	@TRET_LASTMODIFIEDBY_P int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[TRET_TREATMENTTYPE]
   SET [TRET_LASTMODIFIEDDATE] = getdate()
      ,[TRET_LASTMODIFIEDBY] = @TRET_LASTMODIFIEDBY_P
      ,[TRET_DELETEDDATE] = getdate()
 WHERE TRET_ID_PK = @TRET_ID_PK_P;

END

GO
/****** Object:  StoredProcedure [dbo].[TREATMENTTYPE_PR_I]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 01/04/2016
-- Description:	Insert a treatment type
-- =============================================
CREATE PROCEDURE [dbo].[TREATMENTTYPE_PR_I] 
	@TRET_DESCRIPTION_P nvarchar(50),
	@TRET_LASTMODIFIEDBY_P int,
	@TRET_VALIDITYSTARTDATE_P datetime,
	@TRET_VALIDITYENDDATE_P datetime,
	@TRET_ID_PK_P int output
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [dbo].[TRET_TREATMENTTYPE]
           ([TRET_DESCRIPTION]
           ,[TRET_LASTMODIFIEDBY]
		   ,[TRET_LASTMODIFIEDDATE]
           ,[TRET_VALIDITYSTARTDATE]
           ,[TRET_VALIDITYENDDATE])
     VALUES
           (@TRET_DESCRIPTION_P,
            @TRET_LASTMODIFIEDBY_P,
			getdate(),
            @TRET_VALIDITYSTARTDATE_P,
            @TRET_VALIDITYENDDATE_P);   
	set @TRET_ID_PK_P = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[TREATMENTTYPE_PR_R]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 01/04/2016
-- Description:	Restore a treatment type
-- =============================================
CREATE PROCEDURE [dbo].[TREATMENTTYPE_PR_R] 
	@TRET_ID_PK_P int,
	@TRET_LASTMODIFIEDBY_P int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[TRET_TREATMENTTYPE]
	   SET [TRET_LASTMODIFIEDDATE] = getdate()
		  ,[TRET_LASTMODIFIEDBY] = @TRET_LASTMODIFIEDBY_P
		  ,[TRET_DELETEDDATE] = null
	 WHERE TRET_ID_PK = @TRET_ID_PK_P;
    
END

GO
/****** Object:  StoredProcedure [dbo].[TREATMENTTYPE_PR_U]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 01/04/2016
-- Description:	Update e treatment type
-- =============================================
CREATE PROCEDURE [dbo].[TREATMENTTYPE_PR_U] 
	@TRET_ID_PK_P int,
	@TRET_DESCRIPTION_P nvarchar(50),
	@TRET_LASTMODIFIEDBY_P int,
	@TRET_VALIDITYSTARTDATE_P datetime,
	@TRET_VALIDITYENDDATE_P datetime
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[TRET_TREATMENTTYPE]
   SET [TRET_DESCRIPTION] = @TRET_DESCRIPTION_P
      ,[TRET_LASTMODIFIEDDATE] = getdate()
      ,[TRET_LASTMODIFIEDBY] = @TRET_LASTMODIFIEDBY_P
      ,[TRET_VALIDITYSTARTDATE] = @TRET_VALIDITYSTARTDATE_P
      ,[TRET_VALIDITYENDDATE] = @TRET_VALIDITYENDDATE_P
 WHERE TRET_ID_PK = @TRET_ID_PK_P;
END

GO
/****** Object:  StoredProcedure [dbo].[USER_LOGIN_PR_S]    Script Date: 11/04/2016 10:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Riccardo Cervelli
-- Create date: 24/03/2016
-- Description:	Login
-- =============================================
CREATE PROCEDURE [dbo].[USER_LOGIN_PR_S] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(15), 
	@Password nvarchar(20)
AS
BEGIN
	
    SELECT top 1 [USER_ID_PK]
      ,[USER_USERNAME]
      ,[USER_PASSWORD]
      ,[USER_NAME]
      ,[USER_SURNAME]
  FROM [dbo].[USER_USER]
 WHERE [USER_USERNAME] = @UserName and  [USER_PASSWORD] = @Password;

END

GO
USE [master]
GO
ALTER DATABASE [VetExample] SET  READ_WRITE 
GO
