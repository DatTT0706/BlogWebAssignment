USE [master]
GO
/****** Object:  Database [PRN231_Blog]    Script Date: 7/23/2022 7:29:05 PM ******/
CREATE DATABASE [PRN231_Blog]
 



ALTER DATABASE [PRN231_Blog] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN231_Blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN231_Blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN231_Blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN231_Blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN231_Blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN231_Blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN231_Blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN231_Blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN231_Blog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN231_Blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN231_Blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN231_Blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN231_Blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN231_Blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN231_Blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN231_Blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN231_Blog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN231_Blog] SET  MULTI_USER 
GO
ALTER DATABASE [PRN231_Blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN231_Blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN231_Blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN231_Blog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN231_Blog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN231_Blog] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRN231_Blog', N'ON'
GO
ALTER DATABASE [PRN231_Blog] SET QUERY_STORE = OFF
GO
USE [PRN231_Blog]
GO
/****** Object:  Table [dbo].[category]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parentId] [int] NULL,
	[title] [nvarchar](150) NULL,
	[metaTitle] [nvarchar](150) NULL,
	[slug] [nvarchar](150) NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[authorId] [int] NULL,
	[parentId] [int] NULL,
	[title] [nvarchar](100) NULL,
	[metaTitle] [nvarchar](150) NULL,
	[slug] [nvarchar](150) NULL,
	[summary] [nvarchar](255) NULL,
	[published] [int] NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
	[publishedAt] [datetime] NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_category]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_category](
	[postId] [int] NULL,
	[categoryId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_comment]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_comment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[postId] [int] NULL,
	[parentId] [int] NULL,
	[title] [nvarchar](150) NULL,
	[published] [int] NULL,
	[createdAt] [datetime] NULL,
	[publishedAt] [datetime] NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_post_comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_meta]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_meta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[postId] [int] NULL,
	[key] [nvarchar](100) NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_post_meta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_tag]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_tag](
	[postId] [int] NULL,
	[tagId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tag]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tag](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[metaTitle] [nvarchar](150) NULL,
	[slug] [nvarchar](150) NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_tag] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 7/23/2022 7:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[middleName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[passwordHash] [nvarchar](50) NULL,
	[registeredAt] [datetime] NULL,
	[lastLogin] [datetime] NULL,
	[intro] [nvarchar](255) NULL,
	[proflie] [nvarchar](max) NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([id], [parentId], [title], [metaTitle], [slug], [content]) VALUES (1, 4, N'Music', N'Music', N'music', NULL)
INSERT [dbo].[category] ([id], [parentId], [title], [metaTitle], [slug], [content]) VALUES (2, NULL, N'Technology', N'Technology', N'technology', NULL)
INSERT [dbo].[category] ([id], [parentId], [title], [metaTitle], [slug], [content]) VALUES (3, NULL, N'Life Style', N'Life Style', N'life-style', NULL)
INSERT [dbo].[category] ([id], [parentId], [title], [metaTitle], [slug], [content]) VALUES (4, NULL, N'Entertainment', N'Entertainment', N'entertainment', NULL)
INSERT [dbo].[category] ([id], [parentId], [title], [metaTitle], [slug], [content]) VALUES (5, NULL, N'Education', N'Education', N'education', NULL)
INSERT [dbo].[category] ([id], [parentId], [title], [metaTitle], [slug], [content]) VALUES (6, NULL, N'Marketing', N'Marketing', N'marketing', NULL)
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[post] ON 

INSERT [dbo].[post] ([id], [authorId], [parentId], [title], [metaTitle], [slug], [summary], [published], [createdAt], [updatedAt], [publishedAt], [content]) VALUES (1, 4, NULL, N'REVIEW NHẸ CÁC NGÔN NGỮ, CÔNG NGHỆ, FRAMEWORK MÀ MÌNH ĐÃ VÀ ĐANG DÙNG KIẾM CƠM – PHẦN 1', N'REVIEW NHẸ CÁC NGÔN NGỮ, CÔNG NGHỆ, FRAMEWORK MÀ MÌNH ĐÃ VÀ ĐANG DÙNG KIẾM CƠM – PHẦN 1', N'review-ngon-ngu-cong-nghe-framework', N'CHUYỆN CODING, CHUYỆN NGHỀ NGHIỆP', NULL, CAST(N'2020-06-22T07:41:00.000' AS DateTime), NULL, CAST(N'2020-06-22T08:02:00.000' AS DateTime), N'Nhiều bạn hay hỏi mình code bằng ngôn ngữ gì, thích công nghệ gì. Anh em làm trong ngành ai cũng biết, đi làm một thời gian thì sẽ phải dụng khá nhiều ngôn ngữ/công nghệ, không thể nói vài dòng là hết được!')
INSERT [dbo].[post] ([id], [authorId], [parentId], [title], [metaTitle], [slug], [summary], [published], [createdAt], [updatedAt], [publishedAt], [content]) VALUES (2, 3, NULL, N'KHI CODE MÀ BÍ THÌ PHẢI LÀM SAO? 5 KINH NGHIỆM SIÊU HAY ĐỂ GIẢI QUYẾT VẤN ĐỀ', N'KHI CODE MÀ BÍ THÌ PHẢI LÀM SAO? 5 KINH NGHIỆM SIÊU HAY ĐỂ GIẢI QUYẾT VẤN ĐỀ', N'khi-code-ma-bi-thi-phai-lam-sao-5-kinh-nghiem-sieu-hay-de-giai-quyet-van-de', N'CHUYỆN CODING, CHUYỆN LINH TINH', NULL, CAST(N'2021-01-30T11:21:00.000' AS DateTime), NULL, CAST(N'2021-01-30T11:58:00.000' AS DateTime), N'Với những bạn đang bắt đầu học lập trình hoặc vừa mới đi làm, đôi khi các bạn sẽ bị… bí, không biết code hoặc giải quyết vấn đề như thế nào (Thật ra mình đi làm lâu rồi nhiều khi cũng bị).')
INSERT [dbo].[post] ([id], [authorId], [parentId], [title], [metaTitle], [slug], [summary], [published], [createdAt], [updatedAt], [publishedAt], [content]) VALUES (12, 1, NULL, N'Cái nhìn đúng và bản chất của Facebook Marketing & Facebook Ads', N'Cái nhìn đúng và bản chất của Facebook Marketing & Facebook Ads', N'series-toi-uu-quang-cao-facebook_bai-1-cai-nhin-dung-va-ban-chat-cua-facebook-marketing-facebook-ads', N'Một bài viết về Facebook Ads.', NULL, CAST(N'2022-02-26T16:02:00.000' AS DateTime), NULL, CAST(N'2022-02-26T17:15:00.000' AS DateTime), N'Marketing = Market + Ing. Là cách tạo ra 1 cái chợ.')
INSERT [dbo].[post] ([id], [authorId], [parentId], [title], [metaTitle], [slug], [summary], [published], [createdAt], [updatedAt], [publishedAt], [content]) VALUES (13, 4, NULL, N'DĂM BA CÁCH HACK SẬP 1 WEBSITE NÀO ĐÓ', N'DĂM BA CÁCH HACK SẬP 1 WEBSITE NÀO ĐÓ', N'dam-ba-cach-hack-sap-1-website-nao-do', N'Chia sẻ cá nhân', NULL, CAST(N'2017-10-09T21:00:00.000' AS DateTime), NULL, CAST(N'2017-10-09T21:38:00.000' AS DateTime), N'Đã bao giờ bạn thắc mắc làm sao hacker có thể hack sập 1 website chưa? Hack gồm những bước nào, tìm hiểu trang web ra sao? Làm sao để không bị phát hiện v..v.')
SET IDENTITY_INSERT [dbo].[post] OFF
GO
INSERT [dbo].[post_category] ([postId], [categoryId]) VALUES (1, 2)
INSERT [dbo].[post_category] ([postId], [categoryId]) VALUES (2, 2)
INSERT [dbo].[post_category] ([postId], [categoryId]) VALUES (13, 2)
INSERT [dbo].[post_category] ([postId], [categoryId]) VALUES (12, 6)
GO
SET IDENTITY_INSERT [dbo].[post_comment] ON 

INSERT [dbo].[post_comment] ([id], [postId], [parentId], [title], [published], [createdAt], [publishedAt], [content]) VALUES (1, 1, NULL, N'Hay, bổ ích', NULL, CAST(N'2022-07-11T00:00:00.000' AS DateTime), CAST(N'2022-07-11T10:00:00.000' AS DateTime), N'Bài viết hay, cung cấp nhiều thông tin bổ ích.')
INSERT [dbo].[post_comment] ([id], [postId], [parentId], [title], [published], [createdAt], [publishedAt], [content]) VALUES (2, 1, NULL, N'Hay', NULL, CAST(N'2022-07-12T00:00:00.000' AS DateTime), CAST(N'2022-07-12T21:11:00.000' AS DateTime), N'hi anh, hiện giờ anh làm ở đâu vậy ah')
INSERT [dbo].[post_comment] ([id], [postId], [parentId], [title], [published], [createdAt], [publishedAt], [content]) VALUES (3, 1, NULL, NULL, NULL, CAST(N'2022-07-12T00:00:00.000' AS DateTime), CAST(N'2022-07-12T11:02:00.000' AS DateTime), N'Mình cũng đã làm cơ bản với Angular 2 được nửa năm, cảm giác học nó hơi nhọc, đều do dự án đang làm lúc đấy nhảy ngang vào nên đọc code rối mù, còn Angular 1 nghe tên thôi chưa đc làm việc thì nó lên 2 bỏ hết viết lại nên cũng không rõ')
INSERT [dbo].[post_comment] ([id], [postId], [parentId], [title], [published], [createdAt], [publishedAt], [content]) VALUES (4, 13, NULL, NULL, NULL, CAST(N'2017-10-11T00:00:00.000' AS DateTime), CAST(N'2017-10-11T17:05:00.000' AS DateTime), N'Cháu chào chú, cháu năm nay lớp 11 và đang định bắt đầu học một ngôn ngữ lập trình nào đó, vì nó là sở thích, với cả kiến thức thì cũng không sợ bị thừa. Nhưng cháu đang phân vần gữa việc học C và HTML. Theo chú cháu nên học cái nào ạ.')
INSERT [dbo].[post_comment] ([id], [postId], [parentId], [title], [published], [createdAt], [publishedAt], [content]) VALUES (5, 13, 4, NULL, NULL, CAST(N'2017-10-11T19:18:00.000' AS DateTime), CAST(N'2017-10-11T19:21:00.000' AS DateTime), N'Cả 2 nhé em!')
SET IDENTITY_INSERT [dbo].[post_comment] OFF
GO
INSERT [dbo].[post_tag] ([postId], [tagId]) VALUES (1, 1)
INSERT [dbo].[post_tag] ([postId], [tagId]) VALUES (1, 2)
INSERT [dbo].[post_tag] ([postId], [tagId]) VALUES (1, 4)
INSERT [dbo].[post_tag] ([postId], [tagId]) VALUES (1, 5)
INSERT [dbo].[post_tag] ([postId], [tagId]) VALUES (2, 2)
INSERT [dbo].[post_tag] ([postId], [tagId]) VALUES (12, 3)
INSERT [dbo].[post_tag] ([postId], [tagId]) VALUES (13, 1)
INSERT [dbo].[post_tag] ([postId], [tagId]) VALUES (13, 2)
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([role_id], [role_name]) VALUES (1, N'Admin')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (2, N'Member')
SET IDENTITY_INSERT [dbo].[role] OFF
GO
SET IDENTITY_INSERT [dbo].[tag] ON 

INSERT [dbo].[tag] ([id], [title], [metaTitle], [slug], [content]) VALUES (1, N'Web Design', N'Web Design', N'web-design', NULL)
INSERT [dbo].[tag] ([id], [title], [metaTitle], [slug], [content]) VALUES (2, N'Software', N'Software', N'software', NULL)
INSERT [dbo].[tag] ([id], [title], [metaTitle], [slug], [content]) VALUES (3, N'Digital Marketing', N'Digital Marketing', N'digital-marketing', NULL)
INSERT [dbo].[tag] ([id], [title], [metaTitle], [slug], [content]) VALUES (4, N'Spring Boot', N'Spring Boot', N'spring-boot', NULL)
INSERT [dbo].[tag] ([id], [title], [metaTitle], [slug], [content]) VALUES (5, N'ASP.NET', N'ASP.NET', N'aspnet', NULL)
SET IDENTITY_INSERT [dbo].[tag] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [firstName], [middleName], [lastName], [mobile], [email], [passwordHash], [registeredAt], [lastLogin], [intro], [proflie], [role_id]) VALUES (1, N'Hải', N'Thế', N'Nguyễn', N'0964827582', N'hai@gmail.com', N'123', CAST(N'2017-02-06T00:00:00.000' AS DateTime), CAST(N'2022-06-22T00:00:00.000' AS DateTime), N'Sinh năm 2001, đang là sinh viên ĐH FPT', N'Tên: Nguyễn Thế Hải. Ngày Sinh: 24/01/2001. Đang học ĐH FPT', 2)
INSERT [dbo].[user] ([id], [firstName], [middleName], [lastName], [mobile], [email], [passwordHash], [registeredAt], [lastLogin], [intro], [proflie], [role_id]) VALUES (2, N'Kiên', N'Chí', N'Nguyễn', N'0382562678', N'kien@gmail.com', N'123', CAST(N'2014-10-27T00:00:00.000' AS DateTime), CAST(N'2022-07-10T00:00:00.000' AS DateTime), N'Front-end Developer tại Fsoft', N'Họ và tên: Nguyễn Chí Kiên. Sinh năm 2001. Nơi ở: Hoàn Kiếm, Hà Nội. Là Front-ent Developer tại Fsoft.', 2)
INSERT [dbo].[user] ([id], [firstName], [middleName], [lastName], [mobile], [email], [passwordHash], [registeredAt], [lastLogin], [intro], [proflie], [role_id]) VALUES (3, N'Thái', N'Quang', N'Phạm', N'0399648198', N'thai@gmail.com', N'123', CAST(N'2020-05-05T00:00:00.000' AS DateTime), CAST(N'2021-12-09T00:00:00.000' AS DateTime), N'Android Developer tại Fsoft', N'Phạm Quang Thái, 22 tuổi. Đang sống tại Hà Đông và là Android Developer tại Fsoft. Là 1 key member điều hành 500 nhân viên.', 1)
INSERT [dbo].[user] ([id], [firstName], [middleName], [lastName], [mobile], [email], [passwordHash], [registeredAt], [lastLogin], [intro], [proflie], [role_id]) VALUES (4, N'Đạt', N'Tất', N'Trần', N'0375839127', N'dat@gmail.com', N'123', CAST(N'2011-01-01T00:00:00.000' AS DateTime), CAST(N'2022-07-13T00:00:00.000' AS DateTime), N'Java Dev', N'Trần Tất Đạt. Date of Birth: ??/??/2001. Java Developer.', 1)
SET IDENTITY_INSERT [dbo].[user] OFF
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD  CONSTRAINT [FK_post_user] FOREIGN KEY([authorId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [FK_post_user]
GO
ALTER TABLE [dbo].[post_category]  WITH CHECK ADD  CONSTRAINT [FK_post_category_category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[post_category] CHECK CONSTRAINT [FK_post_category_category]
GO
ALTER TABLE [dbo].[post_category]  WITH CHECK ADD  CONSTRAINT [FK_post_category_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_category] CHECK CONSTRAINT [FK_post_category_post]
GO
ALTER TABLE [dbo].[post_comment]  WITH CHECK ADD  CONSTRAINT [FK_post_comment_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_comment] CHECK CONSTRAINT [FK_post_comment_post]
GO
ALTER TABLE [dbo].[post_meta]  WITH CHECK ADD  CONSTRAINT [FK_post_meta_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_meta] CHECK CONSTRAINT [FK_post_meta_post]
GO
ALTER TABLE [dbo].[post_tag]  WITH CHECK ADD  CONSTRAINT [FK_post_tag_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_tag] CHECK CONSTRAINT [FK_post_tag_post]
GO
ALTER TABLE [dbo].[post_tag]  WITH CHECK ADD  CONSTRAINT [FK_post_tag_tag] FOREIGN KEY([tagId])
REFERENCES [dbo].[tag] ([id])
GO
ALTER TABLE [dbo].[post_tag] CHECK CONSTRAINT [FK_post_tag_tag]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([role_id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO
USE [master]
GO
ALTER DATABASE [PRN231_Blog] SET  READ_WRITE 
GO
