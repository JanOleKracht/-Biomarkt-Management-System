SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [Name], [Brand], [Category], [Price], [Invetory]) VALUES (1, N'Apple', N'GrannySmith', N'Fruit', 1.99, 10)
INSERT INTO [dbo].[Products] ([Id], [Name], [Brand], [Category], [Price], [Invetory]) VALUES (2, N'Orange', N'Valensina', N'Fruit', 2.49, 15)
INSERT INTO [dbo].[Products] ([Id], [Name], [Brand], [Category], [Price], [Invetory]) VALUES (3, N'Peach', N'GrannySmith', N'Fruit', 1.49, 12)
INSERT INTO [dbo].[Products] ([Id], [Name], [Brand], [Category], [Price], [Invetory]) VALUES (4, N'Pinapple', N'GrannySmith', N'Fruits', 3.49, 10)
SET IDENTITY_INSERT [dbo].[Products] OFF
