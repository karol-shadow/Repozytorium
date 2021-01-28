CREATE TABLE [dbo].[Orders_details]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [order_id] INT NULL, 
    [product_id] INT NULL, 
    [amount] INT NULL, 
    CONSTRAINT FK_Orders_details_To_Orders FOREIGN KEY (order_id) REFERENCES Orders(id), 
    CONSTRAINT FK_Orders_details_To_Products FOREIGN KEY (product_id) REFERENCES Products(id)
)
