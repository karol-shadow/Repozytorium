﻿CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(50) NULL, 
    [last_name] VARCHAR(50) NULL, 
    [address] VARCHAR(50) NULL
)