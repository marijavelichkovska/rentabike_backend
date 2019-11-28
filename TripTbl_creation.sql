USE [RentABike]
GO

/****** Object:  Table [dbo].[TripTbl]    Script Date: 28-Nov-19 8:33:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TripTbl](
	[id] [int] NOT NULL,
	[status] [varchar](50) NULL,
	[startTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[cost] [int] NULL,
	[startLatitude] [float] NULL,
	[endLatitude] [float] NULL,
	[startLongitude] [float] NULL,
	[endLongitude] [float] NULL,
 CONSTRAINT [PK_TripTbl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


