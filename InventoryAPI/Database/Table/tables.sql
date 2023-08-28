--table Wholesaler
CREATE TABLE tblWholesaler(
WholesalerId INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(200) NOT NULL,
Description NVARCHAR(MAX) NULL,
Email NVARCHAR(200) NOT NULL,
ContactNo NVARCHAR(20) NOT NULL,
ShopName NVARCHAR(100) NOT NULL
)
--table Categories
CREATE TABLE tblCategories(
CategoryId INT IDENTITY(1,1) PRIMARY KEY,
NAME NVARCHAR(MAX) NOT NULL
)
--table Products
CREATE TABLE tblProducts(
ProductId INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(100),
Description NVARCHAR(MAX),
CategoryId INT FOREIGN KEY REFERENCES dbo.tblCategories(CategoryId)
)
--table Product Prices
CREATE TABLE tblProductPrices(
PriceId INT IDENTITY(1,1) PRIMARY KEY,
ProductId INT FOREIGN KEY REFERENCES dbo.tblProducts (ProductId),
WholesalerId INT FOREIGN KEY REFERENCES dbo.tblWholesaler(WholesalerId),
Price DECIMAL,
DateUpdated DATETIME
)
-- table Stocks
CREATE TABLE tblStocks(
StockId INT IDENTITY(1,1) PRIMARY KEY,
ProductId INT FOREIGN KEY REFERENCES dbo.tblProducts (ProductId),
WholesalerId INT FOREIGN KEY REFERENCES dbo.tblWholesaler (WholesalerId),
StockQuantity INT
)


