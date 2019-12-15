USE [RentABike]
GO

/****** Object:  Table [dbo].[TripTbl]    Script Date: 15-Dec-19 6:50:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TripTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [varchar](50) NULL,
	[startTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[cost] [int] NULL,
	[startLatitude] [float] NULL,
	[endLatitude] [float] NULL,
	[startLongitude] [float] NULL,
	[endLongitude] [float] NULL,
	[Bike] [int] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TripTbl]  WITH CHECK ADD FOREIGN KEY([Bike])
REFERENCES [dbo].[BikeTbl] ([id])
GO

ALTER TABLE [dbo].[TripTbl]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTbl] ([id])
GO


