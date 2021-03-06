USE [TraQuangLinh]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/20/2021 11:38:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/20/2021 11:38:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[UnitCost] [decimal](15, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [text] NULL,
	[Description] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[CategoryID] [varchar](50) NULL,
 CONSTRAINT [PK__Product__3214EC2711F9CC7B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 6/20/2021 11:38:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [fk_Product_Type] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [fk_Product_Type]
GO
