
INSERT [dbo].[Tale] ([Id], [Title], [Date], [Country], [Year], [Century]) VALUES (N'd618e9e1-5ce2-4639-8511-017bfd72bfcc', N'Alejandro Dumas', NULL, N'Francia   ', 1802, 17)
GO
INSERT [dbo].[Tale] ([Id], [Title], [Date], [Country], [Year], [Century]) VALUES (N'0dcda0ca-70b0-4167-9f7c-397d558b8d57', N'Aníbal y las Guerras Púnicas', NULL, N'Tunez     ', -247, -3)
GO
INSERT [dbo].[TaleSource] ([Id], [TaleId], [Url], [Priority]) VALUES (N'aa5eaa2b-dc9a-47c1-8388-074c4828f5ac', N'd618e9e1-5ce2-4639-8511-017bfd72bfcc', N'https://www.youtube.com/watch?v=WUqJyeLKlO4', 3)
GO
INSERT [dbo].[TaleSource] ([Id], [TaleId], [Url], [Priority]) VALUES (N'6b371dae-eab4-4d65-a395-ac7038553361', N'0dcda0ca-70b0-4167-9f7c-397d558b8d57', N'https://www.youtube.com/watch?v=Td9lu1C93M0', 3)
GO

