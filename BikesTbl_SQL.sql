USE [RentABike]
GO

/****** Object:  Table [dbo].[BikeTbl]    Script Date: 15-Dec-19 6:25:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BikeTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [varchar](10) NULL,
	[lastUpdate] [datetime] NULL,
	[latitude] [float] NULL,
	[longitude] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


