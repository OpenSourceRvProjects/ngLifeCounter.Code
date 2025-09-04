USE [NgLifeCounterDB]
GO
/****** Object:  Table [dbo].[CorrectLogin]    Script Date: 03/09/2025 09:32:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorrectLogin](
	[Id] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[IP_Address] [nvarchar](max) NOT NULL,
	[LoginDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventCounter]    Script Date: 03/09/2025 09:32:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventCounter](
	[Id] [uniqueidentifier] NOT NULL,
	[EventName] [nvarchar](max) NOT NULL,
	[StartDay] [int] NOT NULL,
	[StartMonth] [int] NOT NULL,
	[StartYear] [bigint] NOT NULL,
	[Hour] [int] NULL,
	[Minutes] [int] NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[PersonalProfileId] [uniqueidentifier] NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
	[CustomEventImageCollection] [nvarchar](max) NULL,
	[CustomMessage] [nvarchar](max) NULL,
	[RefreshMinutesTime] [int] NULL,
 CONSTRAINT [PK_EventCounter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalProfile]    Script Date: 03/09/2025 09:32:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalProfile](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName1] [nvarchar](max) NOT NULL,
	[LastName2] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Pohone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[DefaultPetPhotos] [nvarchar](max) NULL,
	[CreationDate] [datetime] NOT NULL,
	[CounterLimit] [int] NOT NULL,
	[RelapseLimit] [int] NOT NULL,
 CONSTRAINT [PK_PersonalProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relapses]    Script Date: 03/09/2025 09:32:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relapses](
	[Id] [uniqueidentifier] NOT NULL,
	[RelapseDay] [int] NOT NULL,
	[RelapseMonth] [int] NOT NULL,
	[RelapseYear] [bigint] NOT NULL,
	[RelapseHour] [int] NULL,
	[RelapseMinute] [int] NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[PersonalProfileID] [uniqueidentifier] NOT NULL,
	[EventCounterID] [uniqueidentifier] NOT NULL,
	[PreviousYear] [bigint] NOT NULL,
	[PreviousMonth] [bigint] NOT NULL,
	[PreviousDay] [bigint] NOT NULL,
	[PreviousHour] [bigint] NOT NULL,
	[PreviousMinutes] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[RelapseMessage] [nvarchar](max) NULL,
	[RelapseReason] [int] NULL,
 CONSTRAINT [PK_Relapses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResetLoginPassword]    Script Date: 03/09/2025 09:32:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResetLoginPassword](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SignUpRequests]    Script Date: 03/09/2025 09:32:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SignUpRequests](
	[Id] [uniqueidentifier] NOT NULL,
	[IP] [nvarchar](max) NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[RequestObject] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SignUpRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemMaintenance]    Script Date: 03/09/2025 09:32:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemMaintenance](
	[Id] [uniqueidentifier] NOT NULL,
	[IsOnMaintenance] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03/09/2025 09:32:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[AllowSysAdminAccess] [bit] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[IsSystemAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventCounter] ADD  DEFAULT ((0)) FOR [IsPublic]
GO
ALTER TABLE [dbo].[EventCounter] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[EventCounter] ADD  DEFAULT (NULL) FOR [RefreshMinutesTime]
GO
ALTER TABLE [dbo].[PersonalProfile] ADD  DEFAULT ((100)) FOR [CounterLimit]
GO
ALTER TABLE [dbo].[PersonalProfile] ADD  DEFAULT ((150)) FOR [RelapseLimit]
GO
ALTER TABLE [dbo].[SystemMaintenance] ADD  DEFAULT ((0)) FOR [IsOnMaintenance]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AllowSysAdminAccess]  DEFAULT ((0)) FOR [AllowSysAdminAccess]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsSystemAdmin]
GO
ALTER TABLE [dbo].[CorrectLogin]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[EventCounter]  WITH CHECK ADD FOREIGN KEY([PersonalProfileId])
REFERENCES [dbo].[PersonalProfile] ([Id])
GO
ALTER TABLE [dbo].[EventCounter]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PersonalProfile]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Relapses]  WITH CHECK ADD  CONSTRAINT [FK_EventCounterRelapses] FOREIGN KEY([EventCounterID])
REFERENCES [dbo].[EventCounter] ([Id])
GO
ALTER TABLE [dbo].[Relapses] CHECK CONSTRAINT [FK_EventCounterRelapses]
GO
ALTER TABLE [dbo].[Relapses]  WITH CHECK ADD  CONSTRAINT [FK_PersonalProfileRelapses] FOREIGN KEY([PersonalProfileID])
REFERENCES [dbo].[PersonalProfile] ([Id])
GO
ALTER TABLE [dbo].[Relapses] CHECK CONSTRAINT [FK_PersonalProfileRelapses]
GO
ALTER TABLE [dbo].[Relapses]  WITH CHECK ADD  CONSTRAINT [FK_UserRelapses] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Relapses] CHECK CONSTRAINT [FK_UserRelapses]
GO
ALTER TABLE [dbo].[ResetLoginPassword]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SignUpRequests]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SignUpRequests]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([Id])
GO
