USE [AMSC]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 21-Oct-20 11:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] NULL,
	[PostId] [int] NULL,
	[Comment] [nvarchar](500) NULL,
	[LikeCount] [int] NOT NULL,
	[DislikeCount] [int] NOT NULL,
	[CommentDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Post]    Script Date: 21-Oct-20 11:47:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Post](
	[PostID] [int] NULL,
	[PostName] [nvarchar](50) NULL,
	[PostDate] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Comment] ([CommentId], [PostId], [Comment], [LikeCount], [DislikeCount], [CommentDate]) VALUES (1, 1, N'Comment 1', 0, 0, NULL)
INSERT [dbo].[Comment] ([CommentId], [PostId], [Comment], [LikeCount], [DislikeCount], [CommentDate]) VALUES (2, 1, N'Comment 2', 0, 0, NULL)
INSERT [dbo].[Comment] ([CommentId], [PostId], [Comment], [LikeCount], [DislikeCount], [CommentDate]) VALUES (3, 1, N'Comment 3', 0, 0, NULL)
INSERT [dbo].[Comment] ([CommentId], [PostId], [Comment], [LikeCount], [DislikeCount], [CommentDate]) VALUES (4, 2, N'Comment 4', 0, 0, NULL)
INSERT [dbo].[Comment] ([CommentId], [PostId], [Comment], [LikeCount], [DislikeCount], [CommentDate]) VALUES (5, 2, N'Comment 5', 0, 0, NULL)
INSERT [dbo].[Comment] ([CommentId], [PostId], [Comment], [LikeCount], [DislikeCount], [CommentDate]) VALUES (6, 2, N'Comment 6', 0, 0, NULL)
INSERT [dbo].[Comment] ([CommentId], [PostId], [Comment], [LikeCount], [DislikeCount], [CommentDate]) VALUES (7, 2, N'Comment 7', 0, 0, NULL)
INSERT [dbo].[Comment] ([CommentId], [PostId], [Comment], [LikeCount], [DislikeCount], [CommentDate]) VALUES (8, 3, N'Comment 8 ', 0, 0, NULL)
GO
INSERT [dbo].[Table_Post] ([PostID], [PostName], [PostDate]) VALUES (1, N'Post 1', N'')
INSERT [dbo].[Table_Post] ([PostID], [PostName], [PostDate]) VALUES (2, N'Post 2', N'')
INSERT [dbo].[Table_Post] ([PostID], [PostName], [PostDate]) VALUES (3, N'Post 3', N'')
GO
