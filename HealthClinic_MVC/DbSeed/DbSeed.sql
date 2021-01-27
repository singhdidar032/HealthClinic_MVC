SET IDENTITY_INSERT [dbo].[Patient] ON
INSERT INTO [dbo].[Patient] ([Id], [Name], [MobileNumber]) VALUES (1, N'Jack Smith', N'0211254688')
INSERT INTO [dbo].[Patient] ([Id], [Name], [MobileNumber]) VALUES (2, N'Linda Shell', N'+64213568975')
INSERT INTO [dbo].[Patient] ([Id], [Name], [MobileNumber]) VALUES (3, N'Jesse Pinkman', N'+6422897556')
SET IDENTITY_INSERT [dbo].[Patient] OFF
SET IDENTITY_INSERT [dbo].[Doctor] ON
INSERT INTO [dbo].[Doctor] ([Id], [Name], [IsFullTime]) VALUES (1, N'Dr. Keef', 1)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [IsFullTime]) VALUES (2, N'Dr. Smith', 1)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [IsFullTime]) VALUES (3, N'Dr. hill', 0)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [IsFullTime]) VALUES (4, N'Dr. White', 0)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [IsFullTime]) VALUES (5, N'Dr. Walter', 1)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
SET IDENTITY_INSERT [dbo].[AppointmentReason] ON
INSERT INTO [dbo].[AppointmentReason] ([Id], [Option], [Price]) VALUES (1, N'Sore Throat', CAST(20.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[AppointmentReason] ([Id], [Option], [Price]) VALUES (2, N'Check up', CAST(10.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[AppointmentReason] ([Id], [Option], [Price]) VALUES (3, N'Mental Health', CAST(25.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[AppointmentReason] ([Id], [Option], [Price]) VALUES (4, N'X-Ray', CAST(30.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[AppointmentReason] ([Id], [Option], [Price]) VALUES (5, N'Physical Health', CAST(25.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[AppointmentReason] OFF
SET IDENTITY_INSERT [dbo].[Appointment] ON
INSERT INTO [dbo].[Appointment] ([Id], [PatientId], [DoctorId], [ReasonForAppointmentId], [AppDate]) VALUES (4, 1, 1, 1, N'2021-01-28 00:00:00')
INSERT INTO [dbo].[Appointment] ([Id], [PatientId], [DoctorId], [ReasonForAppointmentId], [AppDate]) VALUES (5, 3, 5, 2, N'2021-01-30 00:00:00')
INSERT INTO [dbo].[Appointment] ([Id], [PatientId], [DoctorId], [ReasonForAppointmentId], [AppDate]) VALUES (6, 2, 3, 3, N'2021-01-29 00:00:00')
SET IDENTITY_INSERT [dbo].[Appointment] OFF

