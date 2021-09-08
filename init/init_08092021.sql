USE [GMapDB]
GO
/****** Object:  Table [dbo].[GMapMarkers]    Script Date: 08.09.2021 15:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GMapMarkers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Text] [nvarchar](50) NULL,
 CONSTRAINT [PK_GMapMarkers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GMapMarkers] ON 
GO
INSERT [dbo].[GMapMarkers] ([Id], [Latitude], [Longitude], [Text]) VALUES (4002, 54.982883922993445, 82.893905639648438, N'Marker1')
GO
INSERT [dbo].[GMapMarkers] ([Id], [Latitude], [Longitude], [Text]) VALUES (4003, 55.000069003474955, 82.92729377746582, N'Marker2')
GO
INSERT [dbo].[GMapMarkers] ([Id], [Latitude], [Longitude], [Text]) VALUES (4004, 55.05497249178238, 82.9193115234375, N'Marker4')
GO
INSERT [dbo].[GMapMarkers] ([Id], [Latitude], [Longitude], [Text]) VALUES (4005, 54.995293372816526, 82.913303375244141, N'Marker3')
GO
INSERT [dbo].[GMapMarkers] ([Id], [Latitude], [Longitude], [Text]) VALUES (4006, 55.038253588892523, 83.03741455078125, N'Marker5')
GO
SET IDENTITY_INSERT [dbo].[GMapMarkers] OFF
GO
