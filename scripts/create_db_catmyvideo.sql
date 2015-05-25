USE [master]
GO

CREATE DATABASE [CatMyVideo]
GO

USE [CatMyVideo]
GO

CREATE TABLE [dbo].[T_Tags](
	[name] [nvarchar](20) PRIMARY KEY NOT NULL)
GO

CREATE TABLE [dbo].[T_Users](
	[id] [uniqueidentifier] ROWGUIDCOL PRIMARY KEY DEFAULT newsequentialid(),
	[nickname] [nvarchar](50) NOT NULL,
	[mail] [nvarchar](50) NOT NULL,
	[pass] [nvarchar](16) NOT NULL,
	[description] [nvarchar](144) NULL,
	[type] [int] NOT NULL)
GO

CREATE TABLE [dbo].[T_Videos](
	[id] [uniqueidentifier] ROWGUIDCOL PRIMARY KEY DEFAULT newsequentialid(),
	[title] [varchar](50) NOT NULL,
	[description] [varchar](144) NOT NULL,
	[upload_date] [datetime] NOT NULL,
	[view_count] [bigint] NOT NULL,
	[quality] [int] NOT NULL,
	[is_encoded] [bit] NOT NULL,
	[uploader] [uniqueidentifier] NOT NULL,
	CONSTRAINT [FK_Videos_Users] FOREIGN KEY([uploader])
	REFERENCES [dbo].[T_Users] ([id]))
GO

CREATE TABLE [dbo].[T_Comments](
	[id] [uniqueidentifier] ROWGUIDCOL PRIMARY KEY DEFAULT newsequentialid(),
	[message] [varchar](144) NOT NULL,
	[post_date] [datetime] NOT NULL,
	[author] [uniqueidentifier] NOT NULL,
	[video] [uniqueidentifier] NOT NULL,
	CONSTRAINT [FK_Comment_Users] FOREIGN KEY([author])
	REFERENCES [dbo].[T_Users] ([id]),
	CONSTRAINT [FK_Comment_Video] FOREIGN KEY([video])
	REFERENCES [dbo].[T_Videos] ([id])
	)
GO

CREATE TABLE [dbo].[T_VideosTags](
	[video] [uniqueidentifier] NOT NULL,
	[tag] [nvarchar](20) NOT NULL,
	CONSTRAINT [FK_VideosTags_Tags] FOREIGN KEY([tag])
	REFERENCES [dbo].[T_Tags] ([name]),
	CONSTRAINT [FK_VideosTags_Videos] FOREIGN KEY([video])
	REFERENCES [dbo].[T_Videos] ([id]))
GO