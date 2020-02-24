USE [CommodityNavigator]
GO

/****** Object:  Table [dbo].[LookupType]    Script Date: 2/24/2020 12:30:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LookupType](
	[LookupTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](50) NULL,
	[ins_datetime] [datetime] NULL,
	[insertedBy] [int] NULL
) ON [PRIMARY]
GO

