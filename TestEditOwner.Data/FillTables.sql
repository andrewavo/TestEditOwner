USE [Test1]
GO
INSERT [dbo].[Account] ([AccoutID], [Number], [Balance]) VALUES (1, N'5678', CAST(900.00 AS Numeric(10, 2)))
GO
INSERT [dbo].[Account] ([AccoutID], [Number], [Balance]) VALUES (2, N'7876', CAST(100.00 AS Numeric(10, 2)))
GO
INSERT [dbo].[Account] ([AccoutID], [Number], [Balance]) VALUES (3, N'7656', CAST(200.00 AS Numeric(10, 2)))
GO
INSERT [dbo].[LegalEntity] ([LegalEntityID], [Name], [Type], [AccountID]) VALUES (1, N'Рога и копыта', N'ЗАО', 2)
GO
INSERT [dbo].[Person] ([PersonID], [FirstName], [SecondName], [BirthDay], [AccountID]) VALUES (1, N'Андрей', N'Иванов', NULL, 1)
GO
INSERT [dbo].[Person] ([PersonID], [FirstName], [SecondName], [BirthDay], [AccountID]) VALUES (2, N'Сергей', N'Петров', NULL, 3)
GO
