USE [RentABike]
GO

/****** Object:  Table [dbo].[UserTbl]    Script Date: 28-Nov-19 8:33:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserTbl](
	[id] [int] NOT NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[longitude] [float] NULL,
	[latitude] [float] NULL,
 CONSTRAINT [PK_UserTbl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


