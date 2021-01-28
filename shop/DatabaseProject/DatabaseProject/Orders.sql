CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [client_id] INT NULL, 
    [order_date] DATE NULL, 
    CONSTRAINT [FK_Orders_To_Client] FOREIGN KEY (client_id) REFERENCES Clients(id)
)
