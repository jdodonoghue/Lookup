USE [CommodityNavigator]
GO

/****** Object:  Table [dbo].[Lookup]    Script Date: 2/24/2020 12:30:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lookup](
	[LookupID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NULL,
	[LookupType] [int] NULL,
	[ins_datetime] [datetime] NULL,
	[insertedBy] [int] NULL
) ON [PRIMARY]
GO

