USE [RentABike]
GO

/****** Object:  Table [dbo].[PaymentsTbl]    Script Date: 15-Dec-19 6:49:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentsTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tripID] [int] NULL,
	[cardNum] [varchar](20) NULL,
	[cost] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PaymentsTbl]  WITH CHECK ADD FOREIGN KEY([tripID])
REFERENCES [dbo].[TripTbl] ([id])
GO


