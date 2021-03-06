USE [master]
GO
/****** Object:  Database [PNG]    Script Date: 11/9/2020 11:30:43 PM ******/
CREATE DATABASE [PNG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PNG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PNG.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PNG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PNG_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PNG] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PNG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PNG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PNG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PNG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PNG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PNG] SET ARITHABORT OFF 
GO
ALTER DATABASE [PNG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PNG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PNG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PNG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PNG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PNG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PNG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PNG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PNG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PNG] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PNG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PNG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PNG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PNG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PNG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PNG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PNG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PNG] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PNG] SET  MULTI_USER 
GO
ALTER DATABASE [PNG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PNG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PNG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PNG] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PNG] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PNG]
GO
/****** Object:  Table [dbo].[tblAccount]    Script Date: 11/9/2020 11:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAccount](
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[statusID] [int] NOT NULL,
	[roleId] [int] NOT NULL,
 CONSTRAINT [PK__tblAccou__AB6E61659AED57BC] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 11/9/2020 11:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[categoryId] [uniqueidentifier] NOT NULL CONSTRAINT [DF__tblCatego__categ__1CF15040]  DEFAULT (newid()),
	[categoryName] [nvarchar](50) NOT NULL,
	[statusId] [int] NOT NULL,
 CONSTRAINT [PK__tblCateg__23CAF1D8E8A63AF9] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 11/9/2020 11:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOrder](
	[orderId] [uniqueidentifier] NOT NULL CONSTRAINT [DF__tblOrder__orderI__1FCDBCEB]  DEFAULT (newsequentialid()),
	[email] [varchar](50) NOT NULL,
	[totalPrice] [float] NOT NULL,
	[paymentType] [varchar](50) NOT NULL,
	[statusId] [int] NOT NULL,
	[orderDate] [datetime] NULL CONSTRAINT [DF__tblOrder__orderD__20C1E124]  DEFAULT (getdate()),
	[phone] [nvarchar](50) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__tblOrder__0809335D4F5DB124] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOrderDetail]    Script Date: 11/9/2020 11:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrderDetail](
	[orderDetailId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[orderId] [uniqueidentifier] NOT NULL,
	[productId] [uniqueidentifier] NOT NULL,
	[price] [float] NOT NULL,
	[quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[orderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 11/9/2020 11:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[productId] [uniqueidentifier] NOT NULL CONSTRAINT [DF__tblProduc__produ__286302EC]  DEFAULT (newid()),
	[productName] [nvarchar](max) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
	[categoryId] [uniqueidentifier] NOT NULL,
	[description] [nvarchar](max) NULL CONSTRAINT [DF_tblProduct_description]  DEFAULT (NULL),
	[image] [nvarchar](max) NOT NULL,
	[statusId] [int] NOT NULL,
 CONSTRAINT [PK__tblProdu__2D10D16A0BDEE660] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblRole]    Script Date: 11/9/2020 11:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRole](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblStatus]    Script Date: 11/9/2020 11:30:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblStatus](
	[statusId] [int] IDENTITY(1,1) NOT NULL,
	[statusName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblAccount] ([email], [password], [userName], [statusID], [roleId]) VALUES (N'hungnvse140996@fpt.edu.vn', N'123456', N'Tran Khanh Hung', 1, 2)
INSERT [dbo].[tblAccount] ([email], [password], [userName], [statusID], [roleId]) VALUES (N'nghungg0811@gmail.com', N'123456', N'Nguyen Van Hung', 1, 1)
INSERT [dbo].[tblCategory] ([categoryId], [categoryName], [statusId]) VALUES (N'772c77f4-aa6c-41ac-a576-5dd15463f522', N'Trang sức bạc', 4)
INSERT [dbo].[tblCategory] ([categoryId], [categoryName], [statusId]) VALUES (N'826a3bd5-8a9e-4f2e-a95e-7b28c35501aa', N'Trang sức vàng', 3)
INSERT [dbo].[tblCategory] ([categoryId], [categoryName], [statusId]) VALUES (N'baa8bd26-8893-4f18-acd2-ee32e7dc9b12', N'Đồng hồ', 3)
INSERT [dbo].[tblOrder] ([orderId], [email], [totalPrice], [paymentType], [statusId], [orderDate], [phone], [address], [name]) VALUES (N'59e1c6ef-a122-eb11-8e68-feca528028a6', N'hungnvse140996@fpt.edu.vn', 750, N'Cash', 5, CAST(N'2020-11-09 22:40:48.277' AS DateTime), N'0945513672', N'Buon Ma Thuot City', N'Tran Khanh Hung')
INSERT [dbo].[tblOrder] ([orderId], [email], [totalPrice], [paymentType], [statusId], [orderDate], [phone], [address], [name]) VALUES (N'e3845739-a222-eb11-8e68-feca528028a6', N'hungnvse140996@fpt.edu.vn', 310, N'Cash', 5, CAST(N'2020-11-09 22:42:51.700' AS DateTime), N'0909231232', N'Buon Ma Thuot City', N'Nguyen Van Hung')
INSERT [dbo].[tblOrderDetail] ([orderDetailId], [orderId], [productId], [price], [quantity]) VALUES (N'3d340074-f753-45ab-b9f6-26c9155bcad9', N'59e1c6ef-a122-eb11-8e68-feca528028a6', N'8d17d0d2-64a2-4f9e-880b-de24cef1e8b9', 100, 3)
INSERT [dbo].[tblOrderDetail] ([orderDetailId], [orderId], [productId], [price], [quantity]) VALUES (N'1d8acad5-0373-4ccf-8957-2abea267db71', N'59e1c6ef-a122-eb11-8e68-feca528028a6', N'e381d178-0338-4f13-b436-60dc2b206de3', 225, 2)
INSERT [dbo].[tblOrderDetail] ([orderDetailId], [orderId], [productId], [price], [quantity]) VALUES (N'2c0ef3f3-73ef-4838-afa7-abb6605f9a7d', N'e3845739-a222-eb11-8e68-feca528028a6', N'bfb9debf-b571-4230-814f-adcdd875ccaf', 155, 2)
INSERT [dbo].[tblProduct] ([productId], [productName], [quantity], [price], [categoryId], [description], [image], [statusId]) VALUES (N'4721312b-5384-456b-aa05-385ede371461', N'Dây chuyền Vàng 18K PNJ dây đan kiểu chữ cong 0000Y000283', 100, 210, N'826a3bd5-8a9e-4f2e-a95e-7b28c35501aa', N'', N'gd0000y000283-day-chuyen-vang-18k-pnj-day-dan-kieu-chu-cong.png', 3)
INSERT [dbo].[tblProduct] ([productId], [productName], [quantity], [price], [categoryId], [description], [image], [statusId]) VALUES (N'e381d178-0338-4f13-b436-60dc2b206de3', N'Nhẫn cưới Kim cương Vàng 18K PNJ Chung Đôi DD00Y000527', 98, 225, N'826a3bd5-8a9e-4f2e-a95e-7b28c35501aa', NULL, N'gndrya01732.5a0-nhan-cuoi-kim-cuong-pnj-chung-doi-vang-18k.png', 3)
INSERT [dbo].[tblProduct] ([productId], [productName], [quantity], [price], [categoryId], [description], [image], [statusId]) VALUES (N'70e03ac1-b1a0-41be-a71c-6dbc51b63abf', N'Nhẫn bạc đính đá PNJSilver XM00K000088', 2000, 3000, N'772c77f4-aa6c-41ac-a576-5dd15463f522', N'', N'snxm00k000088-nhan-bac-dinh-da-pnjsilver01.png', 3)
INSERT [dbo].[tblProduct] ([productId], [productName], [quantity], [price], [categoryId], [description], [image], [statusId]) VALUES (N'df698c8e-6036-4fe9-9015-9f50b5a417d3', N'Đồng Hồ Orient Nam FUNG2001D0 Dây Thép Không Gỉ 42mm', 100, 140, N'baa8bd26-8893-4f18-acd2-ee32e7dc9b12', N'', N'Đồng_Hồ_Orient_Nam_FUNG2001D0_Dây_Thép_Không_Gỉ_42mm_-_1.jpg', 3)
INSERT [dbo].[tblProduct] ([productId], [productName], [quantity], [price], [categoryId], [description], [image], [statusId]) VALUES (N'311052a2-100e-4c00-8b7f-ab2bc044cdcd', N'Đồng Hồ Casio Nữ LTP-E143DBL-5ADR Dây Da 30mm', 100, 120, N'baa8bd26-8893-4f18-acd2-ee32e7dc9b12', N'', N'LTP-E143DBL-5ADR_Desktop_1.jpg', 3)
INSERT [dbo].[tblProduct] ([productId], [productName], [quantity], [price], [categoryId], [description], [image], [statusId]) VALUES (N'bfb9debf-b571-4230-814f-adcdd875ccaf', N'Đồng Hồ Fossil Nữ ES4650 Dây Da 28mm', 98, 155, N'baa8bd26-8893-4f18-acd2-ee32e7dc9b12', N'', N'ES4650_Desktop_1.jpg', 3)
INSERT [dbo].[tblProduct] ([productId], [productName], [quantity], [price], [categoryId], [description], [image], [statusId]) VALUES (N'8d17d0d2-64a2-4f9e-880b-de24cef1e8b9', N'Đồng Hồ Fossil Nam FS5536 Dây Nhựa 44mm', 97, 100, N'baa8bd26-8893-4f18-acd2-ee32e7dc9b12', N'', N'dong-ho-nam-day-cao-su-fossil-fs5536.png', 3)
SET IDENTITY_INSERT [dbo].[tblRole] ON 

INSERT [dbo].[tblRole] ([roleId], [roleName]) VALUES (1, N'Admin')
INSERT [dbo].[tblRole] ([roleId], [roleName]) VALUES (2, N'Member')
SET IDENTITY_INSERT [dbo].[tblRole] OFF
SET IDENTITY_INSERT [dbo].[tblStatus] ON 

INSERT [dbo].[tblStatus] ([statusId], [statusName]) VALUES (1, N'Active')
INSERT [dbo].[tblStatus] ([statusId], [statusName]) VALUES (2, N'Deactive')
INSERT [dbo].[tblStatus] ([statusId], [statusName]) VALUES (3, N'Available')
INSERT [dbo].[tblStatus] ([statusId], [statusName]) VALUES (4, N'Unavailable')
INSERT [dbo].[tblStatus] ([statusId], [statusName]) VALUES (5, N'Not Yet Paid')
INSERT [dbo].[tblStatus] ([statusId], [statusName]) VALUES (6, N'Paid')
INSERT [dbo].[tblStatus] ([statusId], [statusName]) VALUES (7, N'Cancel')
SET IDENTITY_INSERT [dbo].[tblStatus] OFF
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK__tblAccoun__roleI__2B3F6F97] FOREIGN KEY([roleId])
REFERENCES [dbo].[tblRole] ([roleId])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK__tblAccoun__roleI__2B3F6F97]
GO
ALTER TABLE [dbo].[tblAccount]  WITH CHECK ADD  CONSTRAINT [FK__tblAccoun__statu__2D27B809] FOREIGN KEY([statusID])
REFERENCES [dbo].[tblStatus] ([statusId])
GO
ALTER TABLE [dbo].[tblAccount] CHECK CONSTRAINT [FK__tblAccoun__statu__2D27B809]
GO
ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD  CONSTRAINT [FK__tblCatego__statu__31EC6D26] FOREIGN KEY([statusId])
REFERENCES [dbo].[tblStatus] ([statusId])
GO
ALTER TABLE [dbo].[tblCategory] CHECK CONSTRAINT [FK__tblCatego__statu__31EC6D26]
GO
ALTER TABLE [dbo].[tblOrder]  WITH CHECK ADD  CONSTRAINT [FK__tblOrder__email__2C3393D0] FOREIGN KEY([email])
REFERENCES [dbo].[tblAccount] ([email])
GO
ALTER TABLE [dbo].[tblOrder] CHECK CONSTRAINT [FK__tblOrder__email__2C3393D0]
GO
ALTER TABLE [dbo].[tblOrder]  WITH CHECK ADD  CONSTRAINT [FK__tblOrder__status__2E1BDC42] FOREIGN KEY([statusId])
REFERENCES [dbo].[tblStatus] ([statusId])
GO
ALTER TABLE [dbo].[tblOrder] CHECK CONSTRAINT [FK__tblOrder__status__2E1BDC42]
GO
ALTER TABLE [dbo].[tblOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__tblOrderD__order__2F10007B] FOREIGN KEY([orderId])
REFERENCES [dbo].[tblOrder] ([orderId])
GO
ALTER TABLE [dbo].[tblOrderDetail] CHECK CONSTRAINT [FK__tblOrderD__order__2F10007B]
GO
ALTER TABLE [dbo].[tblOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__tblOrderD__produ__300424B4] FOREIGN KEY([productId])
REFERENCES [dbo].[tblProduct] ([productId])
GO
ALTER TABLE [dbo].[tblOrderDetail] CHECK CONSTRAINT [FK__tblOrderD__produ__300424B4]
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK__tblProduc__categ__32E0915F] FOREIGN KEY([categoryId])
REFERENCES [dbo].[tblCategory] ([categoryId])
GO
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK__tblProduc__categ__32E0915F]
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK__tblProduc__statu__30F848ED] FOREIGN KEY([statusId])
REFERENCES [dbo].[tblStatus] ([statusId])
GO
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK__tblProduc__statu__30F848ED]
GO
USE [master]
GO
ALTER DATABASE [PNG] SET  READ_WRITE 
GO
