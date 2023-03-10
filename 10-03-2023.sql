USE [master]
GO
/****** Object:  Database [MusicShop]    Script Date: 10.03.2023 22:33:18 ******/
DROP DATABASE [MusicShop]
GO
/****** Object:  Database [MusicShop]    Script Date: 10.03.2023 22:33:18 ******/
CREATE DATABASE [MusicShop]
GO
USE [MusicShop]
GO
/****** Object:  Table [dbo].[Sity]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sity](
	[SityID] [int] IDENTITY(1,1) NOT NULL,
	[SityName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Sity] PRIMARY KEY CLUSTERED 
(
	[SityID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[StockName] [nvarchar](50) NOT NULL,
	[StockAddress] [nvarchar](150) NOT NULL,
	[StockSityID] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationName] [nvarchar](100) NOT NULL,
	[OrganizationLogotip] [varbinary](max) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[OrganizationID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pounkt]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pounkt](
	[PounktID] [int] IDENTITY(1,1) NOT NULL,
	[PounktAddress] [nvarchar](150) NOT NULL,
	[PounktOrganizationID] [int] NULL,
	[PounktName] [nvarchar](150) NULL,
	[PounktSchedule] [nvarchar](50) NULL,
	[PounktStockID] [int] NULL,
 CONSTRAINT [PK_Pounkt] PRIMARY KEY CLUSTERED 
(
	[PounktID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SityPounkts]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SityPounkts]
AS
SELECT dbo.Pounkt.PounktID AS ID, dbo.Organization.OrganizationName AS Organization, dbo.Pounkt.PounktName AS Pounkt, dbo.Pounkt.PounktAddress AS Address, dbo.Stock.StockName AS Stock, dbo.Stock.StockAddress, 
                  dbo.Sity.SityName AS Sity, dbo.Organization.OrganizationID
FROM     dbo.Organization INNER JOIN
                  dbo.Pounkt ON dbo.Organization.OrganizationID = dbo.Pounkt.PounktOrganizationID INNER JOIN
                  dbo.Stock ON dbo.Pounkt.PounktStockID = dbo.Stock.StockID INNER JOIN
                  dbo.Sity ON dbo.Stock.StockSityID = dbo.Sity.SityID
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[PounktID] [int] NOT NULL,
	[ShopName] [nvarchar](150) NULL,
 CONSTRAINT [PK_Shop_1] PRIMARY KEY CLUSTERED 
(
	[PounktID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductInShop]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInShop](
	[ShopID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[QuantityInShop] [int] NULL,
 CONSTRAINT [PK_ProductInShop] PRIMARY KEY CLUSTERED 
(
	[ShopID] ASC,
	[ProductID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductArticle] [nchar](10) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductCost] [decimal](18, 2) NOT NULL,
	[ProductDiscount] [tinyint] NULL,
	[ProductManufactureID] [int] NOT NULL,
	[ProductCategoryID] [int] NOT NULL,
	[ProductDescription] [ntext] NULL,
	[ProductSupplierID] [int] NOT NULL,
	[ProductPhoto] [varbinary](max) NULL,
	[ProductSounds] [varbinary](max) NULL,
	[ProductParameters] [nvarchar](500) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ShopProducts]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ShopProducts]
AS
SELECT dbo.Product.ProductID AS ID, dbo.Product.ProductArticle AS Article, dbo.Product.ProductName AS Product, dbo.Product.ProductCost AS CostWithoutDiscount, dbo.Product.ProductDiscount AS Discount, 
                  dbo.Product.ProductCost - dbo.Product.ProductCost * dbo.Product.ProductDiscount / 100 AS CostWithDiscount, dbo.ProductInShop.QuantityInShop, dbo.Shop.ShopName AS Shop, dbo.Pounkt.PounktName AS Pounkt, 
                  dbo.Organization.OrganizationName AS Organization, dbo.Sity.SityName AS Sity, dbo.Pounkt.PounktAddress AS Address
FROM     dbo.ProductInShop INNER JOIN
                  dbo.Product ON dbo.ProductInShop.ProductID = dbo.Product.ProductID INNER JOIN
                  dbo.Shop ON dbo.ProductInShop.ShopID = dbo.Shop.PounktID INNER JOIN
                  dbo.Organization INNER JOIN
                  dbo.Pounkt ON dbo.Organization.OrganizationID = dbo.Pounkt.PounktOrganizationID ON dbo.Shop.PounktID = dbo.Pounkt.PounktID INNER JOIN
                  dbo.Stock ON dbo.Pounkt.PounktStockID = dbo.Stock.StockID INNER JOIN
                  dbo.Sity ON dbo.Stock.StockSityID = dbo.Sity.SityID
GO
/****** Object:  View [dbo].[RythmPounkts]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RythmPounkts]
AS
SELECT ID, Organization, Pounkt, Address, Stock, StockAddress, Sity
FROM     dbo.SityPounkts
WHERE  (OrganizationID = 13)
GO
/****** Object:  View [dbo].[RythmShop]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RythmShop]
AS
SELECT dbo.RythmPounkts.ID, dbo.Shop.ShopName AS Shop, dbo.RythmPounkts.Pounkt, dbo.RythmPounkts.Address, dbo.RythmPounkts.Stock, dbo.RythmPounkts.StockAddress, dbo.RythmPounkts.Organization, dbo.RythmPounkts.Sity
FROM     dbo.RythmPounkts INNER JOIN
                  dbo.Shop ON dbo.RythmPounkts.ID = dbo.Shop.PounktID
GO
/****** Object:  View [dbo].[ProductsInRythm]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProductsInRythm]
AS
SELECT dbo.Product.ProductID AS ID, dbo.Product.ProductArticle AS Article, dbo.Product.ProductName AS Product, dbo.Product.ProductCost AS CostWithoutDiscount, dbo.Product.ProductDiscount AS Discount, 
                  dbo.Product.ProductCost - dbo.Product.ProductCost * dbo.Product.ProductDiscount / 100 AS CostWithDiscount, dbo.ProductInShop.QuantityInShop, dbo.RythmShop.Shop, dbo.RythmShop.Pounkt, dbo.RythmShop.Address, 
                  dbo.RythmShop.Organization, dbo.RythmShop.Sity, dbo.ProductInShop.ShopID
FROM     dbo.ProductInShop INNER JOIN
                  dbo.RythmShop ON dbo.ProductInShop.ShopID = dbo.RythmShop.ID INNER JOIN
                  dbo.Product ON dbo.ProductInShop.ProductID = dbo.Product.ProductID
GO
/****** Object:  Table [dbo].[User]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserLogin] [nvarchar](100) NOT NULL,
	[UserPassword] [nvarchar](100) NULL,
	[ChatUser] [bit] NOT NULL,
	[Encription_Algorithm] [nvarchar](50) NULL,
	[UserBlocked] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UsersRoles]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UsersRoles]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UsersRoles]    Script Date: 16.02.2023 22:30:23 ******/
 

CREATE VIEW [dbo].[UsersRoles]
AS
SELECT [User].UserID As UserID, dbo.Role.RoleName AS Role, dbo.[User].UserLogin AS [User], dbo.[User].UserPassword AS Password, dbo.[User].ChatUser AS Chat
FROM     dbo.Role INNER JOIN
                  dbo.UserRole ON dbo.Role.RoleID = dbo.UserRole.RoleID INNER JOIN
                  dbo.[User] ON dbo.UserRole.UserID = dbo.[User].UserID
GO
/****** Object:  Table [dbo].[UserInitials]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInitials](
	[UserID] [int] NOT NULL,
	[UserFamily] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[UserSurName] [nvarchar](100) NULL,
	[UserFIO]  AS (Trim(((([UserFamily]+' ')+[UserName])+' ')+[UserSurName])),
 CONSTRAINT [PK_UserInitials] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserHanding]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserHanding]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserHanding]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserHanding]
AS
SELECT dbo.[User].UserID, dbo.[User].UserLogin, dbo.UserInitials.UserFIO
FROM     dbo.[User] INNER JOIN
                  dbo.UserInitials ON dbo.[User].UserID = dbo.UserInitials.UserID
GO
/****** Object:  Table [dbo].[UserTelefon]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTelefon](
	[TelefonID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Telefon] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserTelefon] PRIMARY KEY CLUSTERED 
(
	[TelefonID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserTelefons]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserTelefons]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserTelefons]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserTelefons]
AS
SELECT dbo.[User].UserLogin, dbo.UserTelefon.Telefon
FROM     dbo.[User] INNER JOIN
                  dbo.UserTelefon ON dbo.[User].UserID = dbo.UserTelefon.UserID
GO
/****** Object:  View [dbo].[UserInitialsTelefon]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserInitialsTelefon]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserInitialsTelefon]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserInitialsTelefon]
AS
SELECT dbo.[User].UserLogin, dbo.UserInitials.UserFIO, dbo.UserTelefon.Telefon
FROM     dbo.[User] INNER JOIN
                  dbo.UserInitials ON dbo.[User].UserID = dbo.UserInitials.UserID INNER JOIN
                  dbo.UserTelefon ON dbo.[User].UserID = dbo.UserTelefon.UserID
GO
/****** Object:  Table [dbo].[UserEmail]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEmail](
	[EmailID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserEmail] PRIMARY KEY CLUSTERED 
(
	[EmailID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserEmails]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserEmails]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserEmails]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserEmails]
AS
SELECT dbo.[User].UserLogin, dbo.UserEmail.Email
FROM     dbo.[User] INNER JOIN
                  dbo.UserEmail ON dbo.[User].UserID = dbo.UserEmail.UserID
GO
/****** Object:  View [dbo].[UserInitialsEmail]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserInitialsEmail]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserInitialsEmail]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserInitialsEmail]
AS
SELECT dbo.[User].UserLogin, dbo.UserInitials.UserFIO, dbo.UserEmail.Email
FROM     dbo.[User] INNER JOIN
                  dbo.UserEmail ON dbo.[User].UserID = dbo.UserEmail.UserID INNER JOIN
                  dbo.UserInitials ON dbo.[User].UserID = dbo.UserInitials.UserID
GO
/****** Object:  View [dbo].[UserData]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[UserData]    Script Date: 17.02.2023 14:55:52 ******/
 
/****** Object:  View [dbo].[UserData]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE VIEW [dbo].[UserData]
AS
SELECT dbo.[User].UserLogin, dbo.UserInitials.UserFIO, dbo.UserTelefon.Telefon, dbo.UserEmail.Email
FROM     dbo.[User] INNER JOIN
                  dbo.UserEmail ON dbo.[User].UserID = dbo.UserEmail.UserID INNER JOIN
                  dbo.UserInitials ON dbo.[User].UserID = dbo.UserInitials.UserID INNER JOIN
                  dbo.UserTelefon ON dbo.[User].UserID = dbo.UserTelefon.UserID
GO
/****** Object:  Table [dbo].[ProductSupplier]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProductSupplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductManufacture]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductManufacture](
	[ManufactureID] [int] IDENTITY(1,1) NOT NULL,
	[ManufactureName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProductManufacture] PRIMARY KEY CLUSTERED 
(
	[ManufactureID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Subcategorie] [bit] NOT NULL,
	[RootCategoryID] [int] NULL,
	[CategoryParametersName] [nvarchar](500) NULL,
	[CategoryFilterID] [int] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ProductData]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[ProductData]    Script Date: 17.02.2023 14:55:52 *****
***** Object:  View [dbo].[ProductData]    Script Date: 16.02.2023 22:30:23 ******/
CREATE VIEW [dbo].[ProductData]
AS
SELECT dbo.Product.ProductID AS ID, dbo.Product.ProductArticle AS Article, dbo.Product.ProductName AS Name, dbo.Product.ProductCost AS Cost, dbo.Product.ProductDiscount AS Discount, 
                  dbo.Product.ProductCost - dbo.Product.ProductCost * dbo.Product.ProductDiscount / 100 AS CostWithDiscount, dbo.Product.ProductDescription AS Description, dbo.Product.ProductParameters AS Parameters, 
                  dbo.Product.ProductPhoto AS Photo, dbo.Product.ProductSounds AS Sounds, dbo.ProductCategory.CategoryID, dbo.ProductCategory.CategoryName AS Category, dbo.ProductManufacture.ManufactureID, 
                  dbo.ProductManufacture.ManufactureName AS Manufacture, dbo.ProductSupplier.SupplierID, dbo.ProductSupplier.SupplierName AS Supplier
FROM     dbo.Product INNER JOIN
                  dbo.ProductCategory ON dbo.Product.ProductCategoryID = dbo.ProductCategory.CategoryID INNER JOIN
                  dbo.ProductManufacture ON dbo.Product.ProductManufactureID = dbo.ProductManufacture.ManufactureID INNER JOIN
                  dbo.ProductSupplier ON dbo.Product.ProductSupplierID = dbo.ProductSupplier.SupplierID
GO
/****** Object:  Table [dbo].[ProductInStock]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInStock](
	[StockID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[QuantityInStock] [int] NOT NULL,
 CONSTRAINT [PK_ProductInStock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC,
	[ProductID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[StockProduct]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StockProduct]
AS
SELECT dbo.Product.ProductID AS ID, dbo.Product.ProductArticle AS Article, dbo.Product.ProductName AS Product, dbo.Product.ProductCost AS CostWithoutDiscount, dbo.Product.ProductDiscount AS Discount, 
                  dbo.Product.ProductCost - dbo.Product.ProductCost * dbo.Product.ProductDiscount / 100 AS CostWithDiscount, dbo.ProductInStock.QuantityInStock, dbo.Stock.StockName AS Stock, dbo.Stock.StockAddress AS Address, 
                  dbo.Sity.SityName AS Sity
FROM     dbo.Product INNER JOIN
                  dbo.ProductInStock ON dbo.Product.ProductID = dbo.ProductInStock.ProductID INNER JOIN
                  dbo.Stock ON dbo.ProductInStock.StockID = dbo.Stock.StockID INNER JOIN
                  dbo.Sity ON dbo.Stock.StockSityID = dbo.Sity.SityID
GO
/****** Object:  View [dbo].[OrganizationStock]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OrganizationStock]
AS
SELECT dbo.Stock.StockID AS ID, dbo.Stock.StockName AS Stock, dbo.Stock.StockAddress, dbo.Organization.OrganizationName AS Organization, dbo.Organization.OrganizationID, dbo.Pounkt.PounktName AS Pounkt, dbo.Pounkt.PounktID, 
                  dbo.Pounkt.PounktAddress, dbo.Sity.SityName AS Sity
FROM     dbo.Organization INNER JOIN
                  dbo.Pounkt ON dbo.Organization.OrganizationID = dbo.Pounkt.PounktOrganizationID INNER JOIN
                  dbo.Stock ON dbo.Pounkt.PounktStockID = dbo.Stock.StockID INNER JOIN
                  dbo.Sity ON dbo.Stock.StockSityID = dbo.Sity.SityID
GO
/****** Object:  View [dbo].[RitmStock]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RitmStock]
AS
SELECT dbo.OrganizationStock.*
FROM     dbo.OrganizationStock
WHERE  (OrganizationID = 13)
GO
/****** Object:  Table [dbo].[PounktOfIssue]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PounktOfIssue](
	[PounktID] [int] NOT NULL,
	[PounktOfIssoueName] [nvarchar](150) NULL,
 CONSTRAINT [PK_PounktOfIssue_1] PRIMARY KEY CLUSTERED 
(
	[PounktID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RythmPounktOfIssue]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RythmPounktOfIssue]
AS
SELECT dbo.RitmStock.*, dbo.PounktOfIssue.PounktOfIssoueName AS PounktOfIssue
FROM     dbo.RitmStock INNER JOIN
                  dbo.PounktOfIssue ON dbo.RitmStock.PounktID = dbo.PounktOfIssue.PounktID AND dbo.RitmStock.PounktID = dbo.PounktOfIssue.PounktID
GO
/****** Object:  View [dbo].[CategoriesView]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CategoriesView]
AS
SELECT dbo.ProductCategory.*
FROM     dbo.ProductCategory
GO
/****** Object:  Table [dbo].[CategoryFilter]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryFilter](
	[CategoryFilterID] [int] IDENTITY(1,1) NOT NULL,
	[categoryFilterName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CategoryFilter] PRIMARY KEY CLUSTERED 
(
	[CategoryFilterID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FiltersOfCategories]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[FiltersOfCategories]
AS
SELECT TOP (100) PERCENT dbo.CategoryFilter.categoryFilterName AS Filter, dbo.ProductCategory.CategoryName AS category, dbo.ProductCategory.CategoryParametersName AS Parameters
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
ORDER BY Filter
GO
/****** Object:  View [dbo].[AssortimentsCategories]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AssortimentsCategories]
AS
SELECT dbo.CategoryFilter.categoryFilterName AS Filter, dbo.ProductCategory.CategoryName AS Category, dbo.ProductCategory.CategoryParametersName AS Parameters
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
WHERE  (dbo.CategoryFilter.CategoryFilterID = 1)
GO
/****** Object:  View [dbo].[GoodsCategories]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GoodsCategories]
AS
SELECT dbo.CategoryFilter.categoryFilterName AS Filter, dbo.ProductCategory.CategoryName AS Category, dbo.ProductCategory.CategoryParametersName AS Parameters
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
WHERE  (dbo.CategoryFilter.CategoryFilterID = 2)
GO
/****** Object:  View [dbo].[KitsCategories]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[KitsCategories]
AS
SELECT dbo.CategoryFilter.categoryFilterName AS Filter, dbo.ProductCategory.CategoryName AS Category, dbo.ProductCategory.CategoryParametersName AS Parameters
FROM     dbo.CategoryFilter INNER JOIN
                  dbo.ProductCategory ON dbo.CategoryFilter.CategoryFilterID = dbo.ProductCategory.CategoryFilterID
WHERE  (dbo.CategoryFilter.CategoryFilterID = 3)
GO
/****** Object:  Table [dbo].[ClientOrder]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientOrder](
	[OrderID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
 CONSTRAINT [PK_ClientOrder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CopyMessage]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CopyMessage](
	[IDMesaage] [int] NOT NULL,
	[IDRecipient] [int] NOT NULL,
	[CloseCopy] [bit] NOT NULL,
 CONSTRAINT [PK_CopyMessage] PRIMARY KEY CLUSTERED 
(
	[IDMesaage] ASC,
	[IDRecipient] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageText] [ntext] NULL,
	[MessageSender] [nvarchar](100) NULL,
	[MessageTopic] [nvarchar](450) NULL,
	[MessageDateTimeSent] [datetime] NOT NULL,
	[MessageDelayedSend] [bit] NOT NULL,
	[MessageDelayedTime] [datetime] NULL,
	[MessageStatusID] [int] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageRecipient]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageRecipient](
	[RecipientID] [int] NOT NULL,
	[MessageID] [int] NOT NULL,
 CONSTRAINT [PK_MessageRecipient] PRIMARY KEY CLUSTERED 
(
	[RecipientID] ASC,
	[MessageID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageRecipientsList]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageRecipientsList](
	[MessageID] [int] NOT NULL,
	[MessageRecipients] [nvarchar](max) NOT NULL,
	[MessageCopies] [nvarchar](max) NOT NULL,
	[MessageCloseCopies] [nvarchar](max) NULL,
 CONSTRAINT [PK_MessageRecipientsList] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageSender]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageSender](
	[MessageID] [int] NOT NULL,
	[SenderID] [int] NOT NULL,
 CONSTRAINT [PK_MessageSender] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageStatus]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MessageStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [int] NOT NULL,
	[OrderCostWithoutDiscount] [decimal](18, 2) NOT NULL,
	[OrderStatusID] [int] NOT NULL,
	[OrderDateCreate] [datetime] NULL,
	[OrderCostWithDiscount] [decimal](18, 2) NOT NULL,
	[OrderDateStatusChange] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderAttachment]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderAttachment](
	[OrderID] [int] NOT NULL,
	[MessageID] [int] NOT NULL,
 CONSTRAINT [PK_OrderAttachment] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[MessageID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInPounktOfIssue]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInPounktOfIssue](
	[OrderID] [int] NOT NULL,
	[PounktOfIssoeID] [int] NULL,
 CONSTRAINT [PK_OrderInPounktOfIssue] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInShop]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInShop](
	[OrderID] [int] NOT NULL,
	[OrderShopID] [int] NOT NULL,
 CONSTRAINT [PK_OrderInShop] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductCount] [int] NOT NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderSaleMan]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderSaleMan](
	[OrderSaleManID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK_OrderSaleMan_1] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttachment]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttachment](
	[ProductID] [int] NOT NULL,
	[MessageID] [int] NOT NULL,
 CONSTRAINT [PK_ProductAttachment] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[MessageID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserNikName]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserNikName](
	[UserID] [int] NOT NULL,
	[NikName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserNikName] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPsevdonim]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPsevdonim](
	[PsevdonimID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[PsevdonimName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserPsevdonim] PRIMARY KEY CLUSTERED 
(
	[PsevdonimID] ASC
)
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryFilter] ON 

INSERT [dbo].[CategoryFilter] ([CategoryFilterID], [categoryFilterName]) VALUES (1, N'Ассортименты')
INSERT [dbo].[CategoryFilter] ([CategoryFilterID], [categoryFilterName]) VALUES (2, N'Товары')
INSERT [dbo].[CategoryFilter] ([CategoryFilterID], [categoryFilterName]) VALUES (3, N'Наборы')
SET IDENTITY_INSERT [dbo].[CategoryFilter] OFF
GO
SET IDENTITY_INSERT [dbo].[MessageStatus] ON 

INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (1, N'Черновик')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (2, N'Исходящее')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (3, N'Отправленное')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (4, N'Полученное')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (5, N'Готовое к получению вложение')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (6, N'В процессе передачи вложений')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (7, N'Записывается')
INSERT [dbo].[MessageStatus] ([StatusID], [StatusName]) VALUES (8, N'Отложено')
SET IDENTITY_INSERT [dbo].[MessageStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (1, N'Создан')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (2, N'Принят')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (3, N'В пути')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (4, N'Ожидает получателя')
INSERT [dbo].[OrderStatus] ([StatusID], [StatusName]) VALUES (5, N'Получен')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (1, N'ООО "Лошадь-музыка"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (2, N'ОАО "Музыкальный магазин"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (3, N'ПАО "Гитарист"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (4, N'ЗАО "Всадник-гитарист"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (5, N'Холдинг "Павлин-гитара"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (6, N'НАО "Пеликан-гитара"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (7, N'ПАО "Страус-гитара"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (8, N'ПАО "Магнолия-гитара"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (9, N'ПАО "Гибискус-гитара"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (10, N'ПАО "Ипомея-гитара"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (11, N'НАО "Шиповник-гитара"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (12, N'ООО "Тюльпан-гитара"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (13, N'ООО "Ритм"', 0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080281028103012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F52A28A2BF1C39828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0029ACCAAA59982A8EA49AC9D63C416FA4FEECA996E1864463B7D4D70DA8EAF79AA49BAE25F901F9635E157F0AF4F099655C47BCF489495CF453AAE9C0E0DFDAFFDFE5FF1A55D4F4F760A97D6CCC7A0132FF8D795D15E97F61C3F998F94F5E1C8C8E41A2BCAEDB51BDB3FF8F7B99631E81B8FCAB6EC7C65790B05BC459D3B951B5BFC2B8EB64B5A1AC1DC5CA7754567D86B363A9002DE705FFE79B70DF956857933A73A6F966ACC414514540828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A7600A28A29005145140051451400514514005145140051451400564EB7ADC3A4420604972E3E48FF00A9F6AABE22F100D323FB3DB106E9875EBE58F5FAD7072CD24F2B4933B48EDD598E49AF6B2FCB1D5B54A9F0FE65243AE6E25BBB879E67DF239CB135151457D3C528AB22C28A28A60145145002AB32306525587208EA2BA8D17C572C72AC1A8BEF88F0253F797EBEA2B96A2B9F1186A75E3CB342DCF5EE08C83907BD2D73BE11BF375A5B5BBB12F6C768CFF74F4FEA3F015D157C5E228BA351D37D080A28A2B11051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E62718514514005145140051451400514514C02B1755F1259E98E62E67B81D6343F77EA6B2FC41E276477B3B07C11F2C930EDECBFE35C79249C9E49AF730394F3AE7ADB762944EAE7F1BCA5716F6488DEB23EEFD062B1EE7C45AADCB65AEE4403A2C5F2FF2ACBA2BDAA781C3D3F862BF32AC5DFED8D4BFE7FEE7FEFEB51FDB1A97FCFF00DCFF00DFD6AA5456DEC297F2AFB82C6DDAF8AF54B6C06956751DA55CFEA39AEB348F105AEADFBB03CAB81D6363D7E87BD79C5391DA3757462AEA72083820D71E272CA35A3EEAB3F21347AED15CDF87BC482FCADA5E10B723EE3F4127FF005EBA4AF95C461EA509F24D121451456020A28A2800A28A2800ACED63548F49B169DB0643F2C687F89BFC2B4090A0924003B9AF37F116A5FDA5AA3B236608FE48FD3DCFE3FE15E865D84FAC55D765B8D2B99B34D25C4CF34CE5E473B998F7A8E8A2BEC5249591A0514514C028A28A0028A28A0028A28A00E83C1D71E56B4623D268CAE3DC73FD0D77F5E57A5CFF0066D56D66CE02CAB9FA679FD2BD52BE5F3AA7CB594FBA22414514578A4851451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E6271851451400514514005145140056078AB537B0D384309DB2DC12B9EE17BD6FD79DF8AAFBED7AD3A29CA403CB1F5EFF00AF1F857A395D0F6D5D5F65A8D189451457D89A0514514005145140051451400E4768DD5D09565390457A5E89A90D4F4E498E3CD5F9641EFEB5E655D2F836E8C5A935B9276CA878F71CFF00207F3AF3734C3AAB41CBAC75264775451457C79014514500145148480327802981CE78C2FF00ECFA725AA36249DBE6C7F7475FD71FAD7095A1ADEA0752D5659C1FDD8F923FF747F9CFE359F5F6997E1FD85049EFBB345A0514515DA30A28A2800A28A2800A28A2800A28A2800AF57B1B91796105C2FF00CB440C7D8F715E515DA783350F32DE5B073F345F3C7FEE93C8FCFF009D78F9CD073A2A6BEC9323ABA28A2BE5480A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A28022B89D6DAD659DFEEC485CE3D866BC99DD9DD9D8E598E49F7AF40F16DC9834368D7ACCEA9D7B753FCBF5AF3EAFA7C9295A94AA772E21451457B65051451400514514005145140055FD1A716DAB5B4A4E1438C9F6EF5429412AC08EA2A671528B8BEA23D7A8ACFD1AF05F6950CD9CB05DADF515A15F07569BA73707BA330A28A2B300AABA810BA65D1620010B727E956AB93F186ACAB08D3616CBBE1A523B0EC2BAB074655AB46311A38CA28A2BEE0D028A28A0028A28A0028A28A0028A28A0028A28A002B6BC2B2B45E20800242C8195BDFE527F98158B5A1A1BECD72C8FFD3551F9F15862A3CD466BC9899E9F451457C29985145148028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A00E2FC6F719B8B5B61FC285CFE2703F91AE52B5BC4B3F9FAFDC9CE550841F80E7F5CD64D7DBE029FB3C3C23E468828A28AEB1851451400514514005145140051451401D1785B59FB15D7D9276FDC4A7827F85ABBDFA57905743A5F8B2EACD161B95FB444A300E70E3F1EF5E266596CAB4BDAD2DFA92D1DF515CAFFC26F6DFF3E72FFDF42B2756F155C6A1018218FECF137DFC364B0F4CD7974B2AC44E5692B21599A7AEF8A8465ED74E6CB7479C76FF0077FC6B8E666762CC4927924F7A4A2BE9B0D85A7878F2C11495828A28AE918514514005145140051451400514514005145140055AD31FCBD56CDFFBB3A1FF00C78555A7C2DB268DBFBAC0D4545783407AE514515F02F7320A28A2900514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E627185145140051451400514556D42636DA75D4C3EF471330FAE2AE11E692480F2FBB97CFBC9E6FF009E92337E66A1A28AFBD8AE58A48D028A28AA18514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145149EC07AFD14C85B7C31BFF7941A7D7C04B46CC828A28A900A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28ACBD7F56FEC6D37ED0AAAD2338440DD33C9FE95AD1A33AD515386EC695CD4A0918C9ACDD1B588758B3F353E59170244FEE9FF0A8FC49726D7C3D79229C314D831FED1C7F5AD9612A2C42C3CD5A57B05B5B1A514B1CF18922916443D190E45495C9F806679B45B92DD16E9947FDF2B59FA66AD3BFC429ED99CE1E5962653FDD50C47FE822BB65953F6B5A9C65FC357F52ADB9DE514515E39014514500145145001451450014514500145145547E24074D451457E98761CCD14515F989C61451450014514500158BE2A9C45E1F997386919517F3CFF206B6AB95F1BCDB6CED20C70F233E7FDD18FF00D9ABB3010E7C4C5798D6E715451457DB1A0514514005145140051451400514514005145140051451400514E44790E11198FA019A592292220491BA13D997140ECED71945145020A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A293D80F59B4FF8F383FEB9AFF2A9AAAE9ADBF4AB363FC5021FFC7455AAF82A8AD368C828A28ACC028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B0FC59A3CDADE86F6F6CC05C46E25881380C467E5FC4135B75CB6BFAFB4723D95A3636FCB2483AE7D057A196D3AD3C44654775A9D981C1D5C555E4A7FF000C73FE05BB7B2BCBD6BFDF6C888232B22904BE7D3DB07F3ADEF146A367A9E81716969700DC36D64CA90090C0D72CCE4F524FE3499AFADAD82855C4AC549BE656F4D0FAC870DD0DE726D9D0F86B55B4D174186D270ED7196790C6063713F5F4C0FC2A3379A2A7885B5C8ED27376576E0B8099C63763D71C560EEA5CD2780A4E73A9ADE5BEA744787F06B74DFCCEEADBC51613C81240F093DDB915B4195941520A9E4115E53BB9EB5BFE1DD70D9CDF65B86FF4773C31FE03FE15E463B258C60E743A743CDCC787A3083A986E9D0EE68A28AF9B3E4428A28A401451450014514500145145547E24074D451457E98761CCD14515F989C6145145001451450015C1F8CAE3CDD5A3801E218C647B9E7F962BBCAF30D767FB46B978F9CFEF4A8FF80F1FD2BD8C969F35772EC8A8EE67D14515F5458514514005145140055EBDD22EEC2DE29A740124E983D0FA1AAD6D1896EA18CE70CEAA7F3AECFC569BB4618CFCB2AE07E06B96B5670A908AEA7452A2A74E527D0E1E8A3A515D47385145140055FD2F4D7D42E3072B0AFDF6FE83DEA8AAB3B2A28CB31C002BB4B2B75B2B34817A8E58FAB77A0ECC1E1FDACEF2D913C10C36917976F188D7DBBFD69B384950A4A8AEA7B30CD56BED56CB4E5537772916EE80F24FE02A1B4D5EC35107EC9731C8C3F87A1FC8F35B4612B5EDA1EBB74D7B9F818BA9E9DF646F322C9858F43D54FA567575970AB2C6C8E32AC304572F3446199E33FC2715138DB53C7C5D154E578ECC8E8A28A839028A28A0028A28A0028A28A0028A28A0028A28A0028A28A181EA7A4FFC81AC7FEBDE3FFD0455CAA1A21DDA1D91FF00A62A3F4ABF5F075D35565EACCC28A28ACACC4145145166014514516601451451660145145166014514516601451451660145145166014500162028249EC282082410723B1A7CB2B5EC01451452B303335DD40E9FA6B3A1C4B27C89EDEF5E7ACD939EB5BBE2BBB69B53F2037C90AE31EE793FE7DAB85D7F5078156DE262ACE37311E95F6D9360F928AEF2D4FB9CBA30CBB01EDE6B57AFF923689A8DA68D7EF4883EAC2B833331EAC4D33CCF7AF7D60FCCC1F123E94FF13BA6BEB45FBD7317FDF62961BDB6B87D914C8EC3B035C1EFF7A74570F04C92A36194E45378456DC88711D4E74A50563D00D19A6EECA823BD15C07D7AD55CF43F0DEA3F6FD3155CE6683E46F71D8FF9F4AD9AF3FF0008DEFD9F59F218FC93A95FF810E47F9F7AF40ED5F159AE1D50C434B67A9F9BE7385587C5C94767AA0A28A2BCC3C90A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A28011982A9663800649AF2496432CCF21EACC58D7A56BD39B7D0AF1C75F2F6FFDF5F2FF005AF32AFA4C8E9DA329FC8B88514515EF1414514500145145005AD386ED52D07ACC9FFA10AEAFC61AACDA3E9115D40A8D2F9EAAA5C640E09FE9FAD72BA5FF00C85ACFFEBBA7F315BFE3EB69EF346B5B7B789E595EED42A20C93F23D70D6829E2A9C59EAE5ED28B6CC8D7444FA82DCC2311DCC493A8C63EF0ACCAE86FB41D5278AC047672129671237206182F22AA8F0B6B47FE5C5BFEFB5FF001AF42961EAA825CAFEE3CAC456A2AACAD25F7991456CFF00C229ADFF00CF91FF00BFA9FE34F1E11D68FF00CBA81F5917FC6B4FABD5FE57F718FD6297F32FBCA9A2C3E6DF8723E5886EFC7B7F9F6AD7D5F554D2B4D92E5B0587CA8A7F898F4A4B4D32E3490F1DCA8595F0701B3C76FEB5C978AE4B8D5359B6D2ECE379A55E1634192CCDCFF2C7EB57468B954E568F6E8D48D2C2F3AEA72D7D7B35EDCBCF3B9791CE49350C17735A4E934323248872AC2BD32CBE155B5959FDB7C47AAAC1185CBC71E1421E3AB9FCBA7E35627D2BE17448B035E45B9BE51225CBB1C9EE48E063DF8F5AF6952D2C78D2C646F7577E857D1B584D634C49B8132FCB2A83D1BD7F1A83534F99651DFE5349A30D0FC37E394B6B5BC8EFB49BEB72C8490FE5B0CE01C75FBBE9FC5ED5D75D5C78767B8818C5184DC7CC0508006D3CFE78FCEB86AE116BEF2474D4C73A94EDC8DE9BD8E0A8AF40DBE12F5B5FC8D1B7C25EB6BF91AC7EA5FDF5F79E67D77FB8FEE3CFEA9DFDFAD9A0E3748DD16BD2DBFE111552C7ECC4019E14D72D178AFC21A1A2DD5B69AD7DA84C3CC72C38849E4202DFDDE071E95A53C0A52BCA49AF235A78973DA2CE11F55BF2DC161EC12BB5BDF0C5DD97C3987C44F792FDB24D921876AEDF2DCE17DF3CA9FE95337C67B907E4D1A1C7BCC7FC2BB8F1378AA4D07C236BAD476C92BCE63FDD331006E5CF5AEDF6148D7DA55FE4FC4F0D4BED524655412B331C0023EFF956AEB3A5F89742BB8EDAF2090C9246245F29778C1F703AD75DA57C5BBCD4B5AB1B16D2A045B9B88E12C24625433019FD6BA2F883E33BAF08B69EB696D0CE6E44858CA4FCBB76E318FF0078D1EC6976FC05CF5BF97F13CAB4EB5D7F50D46D6D160B98C4F2AC7E635B9DAB938DC78E82B67C5BE1AD6BC3DA9C56D66F73A8C52441FCD8ED8F072410719F4FD6B63C3DF14B57D67C4561A7496564915C4CA8E555F217BE3E6AD7F883E3BD4BC29ACDB59D84169224B6E25633A3139DCC3B30F4A3D8D2EDF807356FE55F79E6420F121FF987DFFF00E02B7F857609E0ED45FC02758F32EFFB5776E1685147CBBF6E318CE71CD671F8C7E213FF002E7A67FDFA93FF008BAF419FC4B7C9F0BBFE122D908BE302C980A7664B85E99CF43EB4FD8D2EDF807356FE54795A689E2F73F2E9D73F8AA8AE9341F056B777A76A52EA51CB05C2478B54DC9F33E09FE7B6B9F7F8A5E2671C4F027FBB1FFF005EBD27E1F6BD7FADF83F51BFD426F32E229A44460B8DA046AC3F52697B1A3D857AFD91C4C5A2FC478A358E28AED11780A2E63007FE3D5D3784BC39E25BB92F0F892FB50B4454020D970A4B31CE4F19E981F9D79D1F889E2BFF00A0C49FF7ED3FF89AF49F851AFEABAF0D58EAB74F7221F27CBDCA06DCEFCF41EC2B3784C337F02FB87FBEF239E6D0BE240919566B82A0901BED4BCFBF5ADBF0EF85BC55733CDFDBDABDE5A4213F77E4CE1896F7AE3755F1478C0EB57D15B5EDEF94B7322A044E8031C0E95DEFC2DBDD72F63D55F5C92EA4DAD1087ED03A7DEDD8FD28FA9E1BF917DC4DEAF7460B7863E226F60BA96541E0FDABAD6C69DE10F13BE8D78FA86BD7516A433F668E39B74678E371F73C7B571DAAC9E3F7D5EF8DB7F6E791F6893CB11F99B76EE38C63B62BD0FC0BFDB6DE0CBD4D67ED8350F365119B9DDE66DD8BB719E7AE68FA9E1BFE7DAFB90B9A7FCC8E58785BE221FF0098A01FF6F47FC2B46DFC1BE307D366927F123C77A1BF7512B16461EEDDBF2ED5C5ADBFC45931F36BA3FDE79057A6E856DAD0F865756B7AD71FDACF05C0432B1F33710DB79EBE94FEA586FF009F6BEE173CBAC91CF2F83FC787AF88235FFB6EFF00FC4D5893C15E330B1F95E295662BF3876750A7DBAE7F4AE517C21E3D9FACD743FDFBA615E95F10F49D575DD16DADB467D9325C077225F2FE5DAC3AFD48A3EA587FF9F6BEE42551FF003A39CFF8433C73FF00432C5FF7F64FFE26B46EBC19AFFF00675B7D97C51722F07FAFF35CF967FDDC73F9D715FF000AFF00C727FE5E0FFE06FF00F5EBD1FC65A1EA1ABF852D34DD327D97113C7BDB7EDCAAA91D7EB8A7F52C3FFCFB5F7213A9FDF5F719361E0DF122DF426FFC5323DB06CC890B30661E809A9B50F076B2D7D235978B2E60B627291CB9765FC722B33C1DE04D6744F13DAEA37F78B2430EFCA6F2D9CA32FAFBD5CF1A7802EFC51E20FED087514823F2963D8C85BA679EB47D4B0FFF003ED7DC4FB65FCFF81734EF086A8826FB6F89EEAE772E23F2894D87D7EF1CD52FF84375F1D7C6B27FDF07FF008AAD2F01783E6F071BFF003AF12E45D08F1B50AEDDBBBDFF00DAAE4E7F839712DCC920D6620AEE580F20F193F5A3EA387FF9F6BEE0F6CBFE7E7E0751A5F84AFD6E1FED9E29BABB4D9C244C5083EBF78D526F0DDD46CCB2F8EE552A704165047FE3D57BC0DE096F07DDDD5C3DF2DC99E309811EDC60E7D6B0EFFE1225FEA9777ADAB327DA267976887EEEE6271D7DE9FD4687FCFB5F70BDAC7F9FF037F42D30DA6A89247E2D3A9481580B67915B3C75C039A6EB7A6A4DAA4924FE2F6D3642066D965550BC75C13557C2FF000E21F0CEBB06A89A8C93BC4ACBE5988283B948F5F7A7F8A3E1D5BF89F5C9353975196067454F2D630C06063D69FD52972F2F22B0FDBC6D6E7FC0B10F86D5F479265F155F48A32DF6C49C6C551D7DBB1A9341D2F4F98DC91E23BBD50228C8175B447D79F94FB7E95774DF0CC3A6F8326F0E0B879229629633315C11BF3DBF1ACBD27C216BE0FD1F5892D6E6495E7B6249718DA555B1FCEB9F1382A6A93E4A51B9A509C675631E77AF91574BD174A9EC52FB54BB26498960AF2F3B73819EE4F1D6BCA7C72B6D6FE2ABE86CDF75BA6CD8739FE053FCF35EABE19F0D4775145A85F1DC84E6284F4603B9FF000AF31F89E90278C2E27B4FF51222A92061432A85207E42AA8414609D923DDC75573AF2A54EA4A6A3BFF2AF2391DF46FF007A7DAE9F7B7B8305BBB29FE33C0FCEB417C31A8B7530AFD5CFF85692AB05BB32A581C4D557841B5E865EFA7441A599235196760A07D6B5D7C29747EFDCC23E9935A1A7F8712CEE92E269FCD2872AA17033EB594B1104B467750C971729AE68D91BDC0181D3B504F14DCD359B8AF33767DEFC287DB5C9B6BD86719CC6EAFF0091AF5ECF19F5AF1776E6BD734991A6D1AC5D8E59A0424FA9DA2BE7F8829AE584FE47C6712C13709FA9768A28AF973E4C28A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A00C1F174A23D05D7FE7AC8A9FF00B37F4AF3EAEDFC6D2634EB68FF00BD2EEFC94FF8D7115F5B93C6D86BF76CB8EC1451457AA505145140051451401734AE757B3FFAEC9FCEBA9F16EAB36896763A84088F243763E571C1063707F435CBE91CEB167FF5D97F9D745E36D3EE754D32CECAD137CD2DD80A09C7F0393FA0AE395FEBB4EC7A7825074A4AA6DD7D096EFC6777025B14B68499ADE398E73C1619C75AA87C77A876B6B5FC437F8D5997C1B7B72B681E7863115B4713752772AE0F6A962F01C4BCCD7EC7D963C7F5AF7A9AC7496A7CED77818D47CB6B143FE13AD4BFE7DED3FEF96FFE2A987C71AA1FF9676C3E887FC6B713C23A2DBFCD34B237FD749401521B1F0ADB0C95B53FF032FF00D4D6DECF15F6A76F99CFED30D7B285FE41A15F5B6AB04875211FDA26C63230303A63D2B95D33571A6FDB1F41B06D4F5ABE9A4F9C0E2DE20E55371F7DB9C71D467B574963A8E9112DD412C68226959E23B3E5DBDBE95CC5CFC50B5D26CEDECF44D30F96883699D76AB7A9183EB9E6B6C3DAD793D7B9DF5F9D7B918BB69A3DB632EEFC03E36D7A7371A9BC7E667A4D701B1F40B902A41F073552C33A95A2AF7CAB66B1AFBE28F8A2E246315E476D1B7448E1438FC5813505A6B9E39D6086B4BCD4A752DB731F099F43DABA3DC336B1096E92356E7E1EEB3E19961D5B7DBDD436B20964443860AA72783ED9AEFAFC6857D6CEF132A370BF2FCA6B91B7D0BC71358CC356D61ADAD1E260F1C92090818231C703F0356ED748BFBAD2ADEF151764912B8CB738C5455BAD231BDCAA16A97752AD9AEDD4EA7FE11DF0D5AF1712C67FEBADCEDFE4451BBC2367FF003E8DF9C9FE359307822E6682394DDC4A5D436304E334FF00F840EE7FE7F63FFBE0D72FEF57C3491C4FD95ED2AACB37BE25F0ADA880B5BC663132FCC906DDBEFD053A4B1F87FAD8123369FBA46000F3BCA627F307BD715E3BD024D0F4CB7792E124F365DA0018E80D72367E1DD6B538F7D969B732A76609807E84F5ADE8CA7F6E3A9D30A14F939A1369773D987823C083ADB5B1FADEBFFF00175BDABE97A35FE930D96A91C6D65195F2D5E5280103039041E95E207E1978B4FF00CC353FF0223FFE2ABD27C6DE1DD535DF0B5A58D9C48D711CA8CC19C28C0520F3F8D745DFF291CB1FF9FC5BB2F0F781ED750B696D20B5174B2AB4244EEC7783C63E6F5AD2F1327866592DCF8896D99943187CDCF4E33D3F0AF2FD03E1AF88EC75FD3EF2E22B758A0B8495F130270AC0D74FE3FF00066AFE27BCB292C5AD82C31B2B79B215E491ED46BFCA16A7D6A9AFA3FF00C208356B74D2A3B1FB7E4B45E5A36EC8073827D81AB3E25BCF0747A846BE21FB19BAF2814F3E22CDB327DBD775715E12F86FAE687E27B3D46EA5B330C3BF708E46279465FEEFBD68F8DFC05AAF89F5C8AF2DA7B64892DD62C48C7390CC7D3FDAA3DEFE50B505FF002F1FDE5B1A9FC314E5574DFC2DDBFF0089AEA66D4744B6F0AADD3B44346F294A80A76EC2463E5FA915E589F0735327E7D46DD47B2935DF5DF849EF3C1117878DEF965618E3694479FBB8ED9F6A7EFF00625BC3F5A8CA4BE38F0243F7258C638F96DDBFC2BA1D23C47A46A7A4DC5FE9D266D2066573E595C1550C78FA115E783E0B2E39D7CFFE027FF675D77873C1EBE1FF000EDE69435033ADC3BB197CADBB77205E9B8FA51FBCEC4FFB2FF3B21FF85A5E12FF009FA97FF01DBFC2B6F40F15693E2359DB4C959C40543EE8CAF5CE3AFD0D79F8F83B623EFEBEFF00842A3FF66AEAFC21E10B4F0B4776B6F7EF73F682A589006DDB9F4FAD3FDE760FF65FE6652BAF8ADA0DB5C4B0EC99DA366538423907E95B9E17F1758F8A61B892D11E31032AB07EF9FF00F5571F3FC2AD0A7B99667D6AE0348E5880D1F527E95D2F84FC2FA7F866DEE62B2BD92E16670CE5D978C0F6A5FBC0FF0065F339F9FE3269F0CF24634BB86DAC573E6015D5F853C57078AF4C96F62B77B711CC6228EC09E154E7FF001EFD2B8F6F875E105919A5D58124E70D70A3FAD757E17D2B44D16C66B6D26E639A2693CC7226DF86C01EBED45A7DC7CD85FE56720FF1A2DF9D9A4CA3FDE90575DA778B86A1E09B8F102DB6C68E295C444F1F267FC2B9FF00F8453E1BA31124F62581E73A911FFB3D7476965E1CB5F0CCB696AF6FFD9051C395B82CBB4E777CD9FAF7A2D3EE0A587FE4679F3FC67D473F269B6A3FDEDDFF00C5576FE3CF16DD78574CB6B9B382195A59BCB22607006D27B11E9587F61F8656FC86B33FF6F0CDFF00B3574BE25BEF0E43690FF6F79061327EEC4885BE6C7B7B5169771F3D1E94D9E707E336B7FF003E1A7FFDF2FF00FC55779E3FF155E786B45B5BBB148CCB2DC08DBCC1918DAC7FA56447E25F86E1D5121B22CC7007D818F3FF007CD743E22D77C39A6DB43FDB62178A473E5AC96FE6FCC075C60FAD2B3FE61F347FE7D338BF067C43D6B5CF1659D85E343F679049BC2A63384623F5147C43F1BEBBA2789DACF4DBB1041E4236DF2D5B939E7E606BA1D13C57E0CBDD5A1B6D2A1812EDB76C64B2D9D01279DBE99A935FF1AF86349D4CDB6A5034972115B22DC3F1DB9345BFBC529AE948CDF861E2AD5BC4126A8355BBFB408445E5FEED576E7767EE81E82B89D5BE21F8AADB57BEB68F55658E2B891147931F003103F86BD47C37E30D0F5D6B94D2E1963F24297DD104CE738E87D8D655EFC50F0CD95F5CDACD6B766586568DC881482CA707F8A95BFBC3F68FFE7C95FE17789758D766D53FB52EDEE16258FCBCA2AED27767A01E82B92D77C4DE308FC45A9DBDA5E5FF00911DDCA912C69C050E40EDE95E93E1AF1A693E237BA16104D17901779911573BB763A1FF0066B0352F8B1A6E9FA95D59FF0065CB23DBCCD116DC06E2AD827A5165FCC1CF3E948CDF016A9E2DBBF15DBAEA926A4F6451CBF9C8C133B4E3B53FC7571E334F155C0D1C6AFF0062D89B3ECD1B94CED19E83D6B63C37F1321F106B4BA7C7A5980323379865CF4F6DB507893E299F0FEB9369ABA48B8F2C29F33ED1B739507A6D3EB45A3FCC3BD6FF009F6BF035340935E93E1B5E0BC17835630DC797E72B097760ECC679F4C5739E17FF0084920D17C40FADA5F22B4082337208CE4B6719FA8AEA348F1A1D57C273EB5F611134492B087CDDD9D80F7C0AC2D3BC73378BF43D6A2934F5B61042AC0AC85B39CFB7B572E3153745F349AD8EBC0BADF5987EED6EBB1663D5A7B1F0BFDA65908B99D7ECF6A01FBB1AF0587F9F4AE3678A1B88FCB9A34913AE1C645696AB712DCDBD94C10ADAA44B0C67FDA50377EB5945EBCEA926DA5D8FD0F2DA14E109CDA579BD7CBCBFAEA480AA28550028E001DA8DD516EA6EEACAC7AEA492B226DD46EA87751BA8B0739297A633530B530B534889CC1DABD5BC2D2F9DE1AB17F442BF9123FA5791BBD7ACF84576F85AC07AA31FCD8D78BC4097D5A3EA7CA710B4E947D4DBA28A2BE3CF910A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A280390F1C9E2C07FD74FF00D96B8FAEB3C70F99ACA3EEAAEDF9E3FC2B93AFB2CAD5B0B12D6C1451457A05051451400514514017B4719D66CFFEBAAFF3AED758B3D52EE3B56D2258E2BA82E049BE4FBA176B29EDFED5719A20CEB5683FE9A0AEBFC42FADAE9F19D0439BA3300DB429F936B7F7B8EB8AE58FFBFD3BFE07751BFD5A76697AEDF32D4BA66BB70B187D6162C46A1FCB8872D8F98E78EF4DFF0084654AEEBDD5AFA503AE65DAB59F369FE29BCF27FD2CC3FB94DF9976FCFB46EFBBEF9A8C782AF6E1B75E6A4377A852FF00CC8AFA55792D29B7EACF9AA89464F9AA457A22F1B2F0A589DD23DB3B8EBBA6321FCB3487C4DE1EB1FF008F58413FF4C60DBFCF14C8FC11A746B99EEE6623D0AA8FEB4FFECCF0A5A712BC0587FCF498E7F2CD57EF92D146267FBA7BB948A569AED885BB7961626795A44CA02403DAB9CD17E23691068B0E9DA9D8487C989622022BAC9B700120FD2BA1BAB6D1DECA792DCC63EF188AB7D702BCFF0046F87DA86B91B5D89A282DCC8554BE72C0120F6F6A745CD3B68CF52AC684E1CF2BAF5FD0EC07C53F0E5932ADBD84DB7D6289571FCAA8DFFC638C922C34D6E3BCE7AFE46AD43F09346870F77A95C3AE0E7255055993C21F0FA08158CD6E841DDE61BC2491E841623F4AEBF7CF3FFD953D13679B6B7E38D735D8CC37170B1DB9EB142BB41FA9EBFF00EAAEDB4AD76FA3D06CA24946C5B755195CF18A2F7C2BE05BAB56FB05F471483700E975BB27DC13FCBD6ACF8685843E0282695A333CB0BA8CF241C902B1AB19EEA563D0A156838D953BEAB4B1B567A46BF358DBCB06B016378D591589F9463A74A90E8BE28038D5E33FF036FF00E26B988FC41AADB22C50DEC8B1A0DAA300E07E5530F15EB40FFC7E93F58D7FC2BCFF00AC505A3E6FBCE6A987AFCEEDCBF71A37DA6CB6AF0DFF008A2E925B2B525D3736E1BFB71DEB16FBE2F25B3F95A5E98AD129C0695F6E47FBA3A552F136B375AB6991C5A94C5AD229D249446A012B9C1FD09A8D7C0FA16AC826D37537556F9B0087C0FA75AECC3CD4A3FBBFC770F650493AFF0086C579FE2FF881E526282CA34ECA5198FE7BABB0F1778B752D37C2F6F7D68F1A4D23C609DB9E0A926B973F0C6C54FCFAC4807FD7203FAD749ABE8761A96890D85D5EBC70C650890328CE063BD747BE5296116CBF0391D0FE21788AFBC41636F35E0314B3AABA85ED9E6B5FE2178B75AD2F52B48AC2FE4811A12CC100E4EEA4D37C1DE1BB1D42DEE61D5A692789C32299E3C13F4DB5A3E20D1FC3BA95DC536A97BE54889B5479CAB919F714AD3EE3F69865B47F039BF06F8CFC41A878A2D6DAF3549A58183EE42060E1091DAA4F1DF8B75CB1F1235BD9EA9710422243B636C0CD6DE8DA6F846C7528E4D3EE6192EC6ED83ED019BA1CF1F4A9B584F06C97CD26ABF63FB56D00F9929071DB8CD1CB2EE1EDA8F4A7F81E6A7C65E246FF0098E5FF00E13B0AF42D7F5BD4A1F86D657315FDCA5CBC5016992560E49504FCC39AAE67F8750FF0589C7FB2CD5B97DA9F86E0D1216BC4B73A7154112B405D718F97E5C7A51CAFB8FDB43A527F71E49FF094F884FF00CC7754FF00C0B93FF8AAF47F0DEA57EFF0E6F679EF2E659CC73B2C924ACCDC29C609FA556FF849FC0901CC365031FF00A67658FE6A2BA0B4F11E9A7416BFB5B7916D511D846B185385CE703F0A397CC3DB3E94CF176D435493EFDDDE367D64635E8FF0BE5B9165A8997CD3991305F3E86AC9F8A161B7F77A6EA44F6CC4B8FF00D0AB5B43F168D6E19A44B39A111B05C48304D1CABB87B7A9FF003ECF1E9F4AD4E5BA94A69F78D976E442C7BFD2BD23E195A5E5969B7CB716B3425A6520488573F2FBD447E206B4EE443E1FDC33C665C56F687AFEABA8C32BDEE9AB6855804024DDB851CB10788ABFCABEF3CA97C1FE219D9B6697375EE557F99AF43F879A0EB1A2437EBA85A9844AC86306456CE3767A13ED503788FC744FC9A0DA28FF0069F3FF00B3D6BE85AAF88EE567FED8B3B5B7C6DF2BCACF3D739F98FB53E5890F115BFBA70137C3AF12CF7533AD94688CECCBBA74E99F635DEE95E1CD46DBC032E8D2F94B752452A7DFCA82D9C723EB5972CBE3B9E46D93E9F0AE78FBDD3F5AD9806BDFD80F0CD7D0FF0069323012AFDD0DCED3D3E9DA8E55D85F58ABFCD13865F855AF16F9AE2C40F6918FFECB5DDF8C3C293F89AD6D618EEE387C990B92CB9ED8AE77FB2BC74FF7FC496E3FDDCFFF00115B7E20B2D63528614D3B576B265625D95986E1F851CB1EC275EAFF003AFB8C3B3F84CF05CC33C9ACA1F2DD58AADBF5C1CE33BABA7F14F8461F12ADA2CD7C605B72C784CEEDDB7DFDAB9DB4F0DF8922BB8659FC57712223AB3C7BDF0C01E47DEABFE23D02EF5D7B7316AAF6C9106DC067E6CE3DFDA9F2AEC4FB69BDEA7E058D03E1FE97A1EA90DFC77D34B3461B682540E548FEB5635DF05681ACEA46FAFEE6E1252814859954607D56B0B44F050D2B568AFE4D4A49DE30C307BE411FD6AC6B1E09D375BD49AF6E6E6E959955711B281C7D54D16F225D47FF003F5FDC6FF873C3BA0E82F7074DB8791A50BE66E9C374CE3A7D6B32F3C2FE069AFAE66BB9E0FB4492B3CA1AFB69DC4E4F1BB8E69BA178574CF0F4B349693DD399942B79AEA7A7D14553BAF04787EE6F66BA9E49CC9348D23832A8192727B53B7913CFFF004F19D17872C7C2FA61B91A23C6C5B6F9BB662FEBB7F99AC9BBD47E1DC17D70D76966D706563297B567F9B3F37F09EF56345D1748D144DF6007F7B8DE4BEEE99C7F3AAB2F877C2924B24B35A5BB48CC59D8CCDC92727F8A8D7B215E2F79499A5A1EB7E0BBABF29A2C164B74B196262B1F2CEDE33F36D1EA2ABEB3E30F0869FAA4D0DFD9C72DE26DDEDF63563F7411F311E98A6E9565E1CB0BA76D3618639B66D628EC4EDC8F53F4A8350BFF000AC37D23DF7D9FED3C6F2C8C4F4E3F4A2EFC83961D1499BBA778A747B9D025D42D2DD92CE357664112A9F9473F2D65D9F8C749D7F4AD5E2D36D2487CBB66DC5A355CE55B1D3E9535A6B1A2FF00653CF6AF17D854316210E303EF718A8B4CD7741D485C45A7342C028126C8B6F073EC3DEB1C43FDDBF79237C34631AD197249D8C6F0F5F5ADC5BC9A3DFE3CA98EE89CFF000B7F4AC3F12DB4FE1F93CB7C36FF00F55263861EB5ADA5DE68A2D121BE8504F1920B15EBCD617C41D5A1BEBCB34B793CC8E288FCDEE4FF00F58572C29C6505CCF53EAABE371143133F631718CB7BED7EEBD4C34D7665E24457F71C1A90EBFE907FE3FF00FD6AC02DCD377D57B0A6FA111CDB1915653378EBCFDA15FC4D496DAD196E16391000C7008F5AE777D2893041A1D0A76D8A866D8A534DCAE76A5E9ACD5116A633D70247D83A9A03BD7B5787E210F8774E4E47FA3A139F5233FD6BC4A247B8B88E18C6E79182A8F526BDF234114491A8C2AA80057CEF114ED0843D59F2B9ED4BF2C47D14515F267CE0514514005145140051451551F8901D3514515FA61D8733451457E627185145140051451401C2F8D49FED784678FB38FF00D09AB9AAE8BC66D9D6A31FDD8147FE3CD5CED7DB65FF00EED0F4345B0514515D830A28A2800A28A2803474119D72D7FDFF00E86BB0D7B57D4346D3D25D3AD05D4F24A13CBD8CDC618E70BCF6AE47C3DFF21DB5FF0078FF00E826BD09E5BB8612F6968B73216036B4BB00EBCE706B9E9293CC29D9DBFA67573463839B924D5F66EC604FAA78A2731FD9ACDE2DD146CD887A315048F9BDC9AAED63E2FBA3FBC9A58C1FEECCA9FF00A09AEA249758603C9B5B34CA8CF993B1C1C72385F5AAEC9E237E0CDA747EEAAE4FEB5F4AE85FE29499F36EBA527CB18AFC4E70F83356B96DD7177113FEDBB31FE55623F01123F7B7E01FF663CFF5AD63A6F8824FBDAD2463D120151B787F557FBFE22B8FA2C78FFD9AA561A1FC8DFCC3EB13FE74BE460CBE1AB98F5092DA170D14781E6BF19E01E9F8D7332DAF8D648A4B2D3A62B670DC491A88E4446E1DB9C9C1C75FF0AEE44171A7EA0DA7BDFB3868BCEF3987CC4E76E39FA572B751EB167AD6A56FA56A8BE6E566486750432B0E581F5DD9F6AD29538C76563D19E22A4E115269D92B68734DF0E7C493CCAD2244779F9DCCA0EDFAFF00F5AAF5BFC28BF663F6AD4A08973C18D0BFF5145CEBDE3F807926DCEE4C9F363815B3F88F97F4AA2F178EB5B61F68B89634FEF975887FE3BCD6F68F633E6ACF79452352EFC19E1ED0ACE47D42FCCD3AA1651909BB8FEEE49AD4F0B69F612785EDDAE66DB204E9BC0C0233FD6B93BFD32CBC3D69235E5D7DBB559D0A460F44C8C679FE66BB336DA74FA1C31DBB059ADA055240C13B57B8FC2A2693E8BD0D294A4A37E67AF546BE8BE1DD2AE749B7BEBC9983480E43481578623FA55F363E12B4E4BDAB11EB397FD335C1411CD32AAC68EE71D1466AFC5A06AD37DCB09FFE04BB7F9D79CAB2BDA14D333AD45B9B72A8D2B9D26A37BE149F4CBAB344854CD1345BE3B5F9972319071DABC46C742BED42F65B7870A626DAEC4F02BD5E1F076AF2FDE8E38BFEBA3FF8669D73E0CD474A864BDB6D97121E658A20771C0EA3D7E95D34255A72F7E1644C2A52A316A12BB7DCE3E3F085EB44A26D76E5580C6D19207FE3D5B575A3FDAF424D324BC930AAAA65C7276FE3482EAE1D11C496F1EE5059257C329F422A432BBDB30FB5C0B27F795B20575E8473D5EE64D9782ED2CEF21B91752BBC4EAE32B8E47E35A5AAF87AC358BA49EEFCD2C89B0056C71927FAD565FB42CC8EFADC05036593E5E47A75A4BF2F34CAD0EBF15AA85C14050E4FAF268BC4AE6A8FED13E9FE18D2B4CBD4BBB6497CD4CE373E47231535EE81A5DFDE35D5CC2CF23000E4FA567DA0D9748F2788D2E00CFEEF31F3C557D46D2CEE6EE4924D7C459FF9661D38E28BA0F7DEF23593C35A227FCB846DFEF0CD684D6D6335A25BCD6D13C11E36A32F031C0AE25B47D11BFD66BAEDF4715A7A87F61DE58C305C6A388D486528FC9C0C7F5A2E8391BFB4FEE358DAE836FF00F2E96898FF006055D4BDB282C7721892D941E9F740EF5C41D33C28393A84C7FEDA1FF0ABCB7BE1D8B4B3A7FDA64683057BE704E7AE28E60F649EED9BEBE27D163E16FAD97E8D56AD35DB3BC0E6D6E1250870C50D709E4F8397AACEDF8BD6BE8D71E1F8239869EAE8320BEEDDCFA75A5ED3CC3D843B32F3F8F34A4FE391BFDD0BFE35774FF14DAEA36B2DC40B2848890DB80F4CFAD719E6F83D7A58CE7FEFBFFE2AB5B4BBFD0E3B39C59DB491C40FCE8DFC5C7D68F69E657B087F2B276F893A701F2C1767EA8BFF00C555FD1BC5F16B267F2A191045B7EFE39CE7FC2B941AAF8587FCC1653FF6CD7FF8AABBA66BFA0C3248B6D62F6BB977316500363F1A5ED3CCAF614FF9192DCFC49782E24892C376C72B932E338FC2B560F16CB3F875F54FB3056546611EFF0042475C572EDE20D137161A00662739216B513C43629A0B4C9A6A08C7CBF66E31F7B1E9F8D1ED3CC7EC21FC9F8945FE255F37DCB48D7FE079FE95B3E27F15DF69315B9B609990B03B867A62B9F3E29D3C7DDF0F5B8FC17FF89AD1D5BC516F098447630DCEE1BBE6C1DBFA52E75DCA5463FF003ECA361E3CD6AEB52B681DE1D924AAAD88FB13CD6878ABC57A9E9D770436922A868F7371EF546D3C5FBEEE28CE996F1233805876AB3ABF8B64B4BA1141690CC3602589E879E28E75DCAF66BFE7DA2BF877C4DACDF6B51477171234443165C1C74A4F116ADE211ADCD1D94D78B0A85DA220D8FBA29FA678B6EAEB508E196D618E36CE481CF4A8F55F16EA16DA8CB0DB47018D7182C993D051CCBB8F91F4822EF85AF7C40F7F37F68B5F18BCAF94CCAD8DD91EB593AD45E219B57BA30C57CF0973B0846C63DAACE99E34BA37446A21161DA70638CE43553B8F19EB0F33987CB48CB7C80C792051CD1EE3519FF2A37BC1F0EA56B6F75F6C8A646765DBE60C13C5729278775C96677FB0CDF3313C903FAD6EE93E2F9BECD7075290191798C04C6EE3A703FCE6B18F8B35FF00F9FBFF00C829FE14B9A1DC6955EC8DAF08691A9E9DAA4D35D5B3C48D0950491D772FF8555D67C33AB5FEB575711C4BB247CA92DDAA5D03C45A9DCDEC8B7B73BD04790362AF391E82B2EFBC47AC1BEB8F26F2458BCC6D8001C2E78ED4734076ADE4761A6691796DE14974D73189A48E451C9C65B38EDEF51785740BDD0DEE9AE2481BCE0A17CB627A67D40F5AC7B6F13C83C3B2ACB7521BFC32AE473C9E0E7DBFA53BC31ACDF4B25CFDB2EA49000BB779E9D6B0C4FB29526A5AA2E9AC429269A3A183458AE6EAE65B99B6247272A38E0F239AE67C62966668DB4F03CB89763E3904FAE7F2A86D6FE7BC6BA134AECE242464FF000F6FCBFAD39C060558641EA0D62A71869147D152C354C543DA54A97BADBA267285E8DE6B7BFB36D739D87F3A069F683FE58FEA6B6F6F13956535BBA30779A7C4AF2CAB1AF5638ADC1656A3FE58AD4B1C3144731C6AA7D454BAEADA1A4329A9CCB99AB168C94C67CF7A8C9A4EB5CA91EFB9E874DE07B1FB778A6D89194833337E1D3FF1EC57B25717F0EB48FB269526A122E25BA384CF641FE273F90AECEBE1B3BC42AD89696D1D0F90CCEB7B5AEEDD34168A28AF1CF3828A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A00E07C6431ADAFF00D715FE66B9EAE93C6A0FF6BC27B7D9C7FE84D5CDD7DB65EEF8687A1A2D828A28AEC185145140051451401A7E1EFF0090F5AFD5BFF4135D278BB5BBED0B468EE2C245491E75424A86E36B1EFF004AE73C39FF0021FB5FF817FE826B47E237FC8BB07FD7D2FF00E82F5C4E728E3A0E2EC7AB82A50A949C66AEAE453F8AF595316DBA03743139FDD2F564527B7A9AACDE28D65BADF3FE0AA3FA566DC7FCB0FF00AF787FF45AD455E92C4566B593FBCF22AE1E8AA924A2B7EC68B6BFAB3F5D42E07D1C8A8CEAFA99EBA8DD9FFB6CDFE354A8A5ED66FA93ECA0BA12C97534843CB348EE3F8998935CFF00891EE616B7D4ADA6749A2F90BA9E403FE4FE75B4FF0070D549912E6DDE094651C60D7561E6D599E9D28C674396C6341F10B59862D92791337F7D9307F4E2ABDE78F35CBB5DA934702E083E520C9FC4E7F4AC6BFB096CAE1A371C7F09F51555227760AAA493D00AF4D4DB5B9C1F57A69FC26A68F1C9A86B292CCED2107CC766392715D8C92B03F29233C71597A4D8FF00675A1DF8F3A4E5BDBDAAF47F3CCA3DEB8EA4EF2B9E8D382853D4F46B3F1858D86976D6B1DBCCEF144A84E02A92073DEA197C7B39FF0053631AFF00BEE5BFC2B90A2B99E3AB6C9D8F11E0E936DB47453F8D35697FD5B450FF00B899FE79ACE9F5ED56E0FCF7F38F647DA3F4ACEA2B19622ACB793348D0A71DA285726462EE4B31EA5B934DDABE83F2A5A2B2E67DCD44DABFDD146D5FEE8FCA968A2EC04DABFDD146D5FEE8FCA968A2EC04DABFDD1F951B57FBA3F2A5A28BB189B57FBA3F2A36AFF747E54B451760767E10B1B3B8D22579AD609584EC32F18638DAB5D0FF006569C3A585AFFDF95FF0AC6F057FC81A6FFAF86FFD056BA4AF8DC7D6A8B1124A4F7336CA7FD95A77FD03ED7FEFCAFF00852FF65E9C3A585AF3FF004C57FC2ADD15C9EDEAFF00330BB29FF6569DFF0040FB5FFBF2BFE147F6569DFF0040FB5FFBF2BFE15728A3DBD5FE6617653FECAD3BFE81F6BFF7E57FC28FECAD3BFE7C2D7FEFCAFF00855CA28F6F57F9985D94FF00B2B4EFFA07DAFF00DF95FF000A3FB2B4EFFA07DAFF00DF95FF000AB9451EDEAFF330BB29FF006569DFF40FB5FF00BF2BFE147F6569DFF3E16BFF007E57FC2AE5147B7ABFCCC2ECA7FD95A70FF970B5FF00BF2BFE147F6569DFF40FB5FF00BF2BFE15728A3DBD5FE6617653FECAD3BFE81F6BFF007E57FC28FECAD3BFE81F6BFF007E57FC2AE5147B7ABFCCC2ECA7FD95A77FD03ED7FEFCAFF851FD95A77FD03ED7FEFCAFF855CA28F6F57F9985D953FB2F4E1FF2E16BFF007E57FC293FB2B4EFF9F0B5FF00BF2BFE15728A3DBD5FE6617653FECAD3BFE81F6BFF007E57FC297FB2F4E1FF002E16BFF7E57FC2ADD147B7ABFCCC2ECC8D4FC3D617FA6DC5B25ADBC523A7C9224614AB76E40AF18BDB49ACAEA4B79D0A4B1B6D6535EFD5C978DB40B5BED3E4D44B7957102F2C07DF1E87FC6BDBC9B32953A9ECAA3BA97E67AB96E3BD84B927B33C8CD255F1A55E491B4B15BC92440E37A21233E94C3A5DE2C7E63DB4AA83F88A902BEBF9A37E5B9F47EDE9B574CA7456B5A787355BE884B6D652CB19380EA38FCE8BDF0F5FE9823FB6C3E4F999D9B8F5C75E9F5A4AAC1CF91357EDD4878AA4B792FBCC9ADCF0C787E5D7B544870CB6E9F34D20ECBE9F535B9A4FC3BBABC8A2B8BAB98E186450E02F2C54F35E8DA6E9969A4DA2DAD9C4238D7A9EEC7D49AF1731CE6952838517797E479D8CCCE118F2D2776588A28E08638624091C6A155474007415251457C5B6DBBB3E6DB6DDD8514514841451450014514500145145547E24074D451457E98761CCD14515F989C6145145001451450071FE384FF8F1902FF7D49FFBE71FD6B90AEFFC61019742DE3FE58CAAE7FF0041FF00D9AB80AFAFCA27CD864BB1A4760A28A2BD3185145140051451401ABE1BFF0090FDB7FC0BFF00416AD8F1C59CFA96990595AA6F9CCDE684DC0655460F5FF785657860675D88FA2B1FD2B47C64712D9FFBADFD2BCEA97FAE46DD11E9E1AA7B2A0E7E673B78116E9A389F7C7105895FFBC1405CFE95051457A09591E6CA5CD27261451453101191549FE5622AED56B94FE31F8D6F4656763AB0B52CF95952648E74D92A2BAF6C8A862B5B6B76DD0C2AADEBDEA634C26BAD37B1DAD2DC52D9AB364B9767F4AA80166C0AD5863F2A20BDFBD655A4946C61889DA36EE3E8A28AE23CF0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2803BBF057FC81A6FF00AF86FF00D056BA4AE6FC15FF002069BFEBE1BFF415AE92BE2B30FF00799FA99BDC28A28AE210514514005145140051451400514514005145140051451400514514005145140051451400550D6AC9F51D1AEED2360249632109E9BBA8FD6AFD15A53A92A73538EEB519CEF8334ABDD2343686FD552E2599A428AC0ED18000C8E3F873F8D5AF1469F71AA787EE6DAD4037070D18638DC410715B145744B1B56588FAC3DEF71F33BDCC6F0BE9D71A5F87ADAD6EB02E06E670A73B49627154FC5DE1BB8F10C7662DAE2385E1760DBC1C156C67A771815D2D14471B563887894FDEBBFC42EEF72386248208E18C6123508BF40315251457236E4EEC90A28A290051451400514514005145140051451551F8901D3514515FA61D8733451457E627185145140051451401475883ED3A3DE45B771313103DC723F515E5D5EBC402307A1AF26B984DBDD4D09EB1BB27E4715F4791D4F7650F995122A28A2BDF2C28A28A0028A28A00D0D12E92CF57B79A462B1E4AB1F623156FC4F7D1DDEA2890C8AF1C498CAF4C9EBFD2B128AC9D18BA8AA75355564A9BA7D028A28AD4C828A28A0029080460F4A5A284DA609B4CA535B30394195A8042EC7014D6A515BAAED2D51D2B1324B52BDBDB795F3372DFCAAC51456529393BB309CDC9DD8514515248514514005145140051451400514514005145140051451401DDF82BFE40D37FD7C37FE82B5D25627852DFECFA0C4C461A66690FF21FA015B75F118E9296226D77336145145720828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A003BD79BF89ADBECFAF5C606164C483F1EBFAE6BD22B8EF1BDA9DD6B7601C106263FAAFFECD5EAE4F5393116EE5477391A28A2BEB4B0A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AB5A6DA9BDD4ADEDF04879006C0FE1EFFA54CE4A31727D00F4CD3E2FB3E9D6B0F748954FE55668A2BE0A72E69393320A28A2A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A000F4ACBF10DB0BAD06E94E3289E6293DB6F3FCB23F1AD4A6BA2C91B230CAB02A47B56B467ECEA29AE83479151525C42D6D732C0FF7A37287F0351D7DE45DD268B0A28A298C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BB4F06E9A2381F50917E693E48B3D97B9FCFF0095725676CF7B790DB270D2385CFA7BD7AA410A5B5BC70463091A8551EC2BC5CE713C94D528EEFF002264C928A28AF972028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A00F3EF16DA7D9F5A6940F96740E3EBD0FF2FD6B06BB8F1A5A9974F82E5413E4BE1B1D8377FCC0FCEB87AFB3CB6AFB4C345F6D0D16C145145778C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00D9F0AA86F10DBE47DD0C7FF001D35E8D5E79E125CEBF11FEEA31FD2BD0EBE573A7FED0BD0890514515E392145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145547E24074D451457E98761CCD14515F989C614514500145145001451450057BDB55BDB19AD9F18950AE48CE0F63F81AF2A7468DD91D4AB29C107B1AF5DAF3DF15D87D93576954623B81BC7FBDFC5FE3F8D7BB9257B4DD27D752A261514515F4A585145140051451400514514005145749E1DF0E1BD22EEF108B61F710F1E67FF5AB1AF88850839CD88E6E8AF555D36C1142AD95B803FE990A5FECFB2FF9F3B7FF00BF4B5E47F6E43F945CC794D15EAADA6D83A956B2B720FF00D325AE67C43E1BB7B7B26BBB08D90C673220248DBEA2B6A19BD2AB3506AD70E6390A28A2BD72828A28A0028A28A0028A28A0028A28A0028A28A0028A28A00E8FC16B9D6A43FDD818FF00E3CB5DE5719E0AB597CFB8BC2B88B679609EE720FF004AECEBE4736929625DBA19CB70A28A2BCB1051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E62718514514005145140051451400562F89EC05EE8D2381FBC83F78A7D875FD3F956D521008C1E735AD0AAE954535D06790D15AFE21D20E977E7CB07ECD2FCD19F4F55FC2B22BEE68D58D5829C76658514515A0C28A28A0028A28A00D1D0ACBFB435AB7848CC6A7CC93FDD5FF001381F8D7A6E3030060572BE09B1D9673DFB8F9A76D887FD95EBFF8F67F2AEAEBE4F37AFED2BF22DA3A7CC890514515E492148402082320F506968A6079E7897471A65E092107ECD372BFECB775AC3AF53D4F4F8B53B17B594E3772AD8FBADD8D797CB13C133C320C3A31561E8457D6E578BF6F4B965F122D319451457A8505145140051451400514514005145140054F696935F5CA5BC0859D8FE5EE69904325CCC90C285E473B540EE6BD2346D1E1D22D762E1A76FF005927A9F41ED5C18FC6C70D0EF27B09BB172CED63B2B38ADA2FB91AEDFAFBD4F4515F1D29393E666614514548051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E62718514514005145140051451400514514014F53B08F52B092DA4E370CA363EEB7635E6777693D8DCBDBDC214917B7AFB8AF58ACED5B48B7D5ADBCB946D917FD5C8072A7FC2BD5CBB307877C92F85FE052763CC68ADFB9F086A704264430CD8FE18D8EEFD40AC49609A06DB345246DE8EA457D3D2C452ABF04AE55C8E8A28AD861525BDBCB77731DB423324AC157FC7F0EB51D76BE11D18C11FF694EB879171083D97FBDF8FF2FAD72E33131C3D2737BF4F513763A3B4B58ECECE1B68862389028A9E8A2BE2652729733330A28A2A4028A28A002B82F18588B6D516E50612E1727FDE1C1FE9FAD77B599AF69DFDA7A549128CCABF3C7FEF0EDF8F4AEFCBB11EC2BA93D9E8C68F33A29482AC55810C3820D257D9EE6814514500145145001451450014515D4F877C3667297B7C9FB9FBD1C47F8FDCFB7F3AC31189861E1CF316C5FF000A68BF66845FCEBFBE907EEC1FE15F5FA9AE9E8A2BE2F1388957A8E722370A28A2B0105145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451551F8901D3514515FA61D8733451457E62718514514005145140051451400514514005145140054734315C44D14D1AC88DD558645494552935AA6073773E0CB195CB4134B0E7F87EF28FEBFAD674DE08B81FEA6F237FF007D0AFF008D76B457753CCF130FB43BB38FD37C1CF15DAC9A84913C4A72238C93B8FBE474AEC3DA8EF456188C554C43BD460DDC28A28AE610514514005145140051451401CAF8A34012A49A85AAE255199507F10FEF0F7FF3F5E2ABD7AB8ED7BC2CCA5EEF4E4CA9E5E00391EEBFE15F4395E6292F6355FA32D3392A295D1918ABA9561D41183495F429A6AE8A0A28A2800A2B46C342D43524DF04388FA798E768FF00EBD765A4786ED74E45925559EE7AEF61C2FF00BA3FAD7062731A3416F77D84DD8C7F0F7865A475BCBF8F118E6385BF8BDDBDBDABB4A28AF96C562A7889F34C86EE145145728828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28AA8FC480E9A8A28AFD30EC399A28A2BF3138C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00A77FA5DA6A5185BA84311F75870C3F1AC73E0AD3C9389EE40F4DCBFE15D2515D34B175A92B424D21DCE6BFE10AB0FF009F8B9FCD7FC2AD5A78574CB470E6379D874F34E47E5D2B6E8AA963B112567261710000000600EC2968A2B944145145200A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0E668A28AFCC4E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2AA3F1203A6A28A2BF4C3B0FFD9)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (14, N'ОАО "Лошадь-ритм"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (15, N'ООО "Ритм-маркет"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (16, N'ООО "Орёл-музыка"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (17, N'ООО "Цветы-музыка"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (18, N'ООО "Музыка звёздного неба"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (19, N'ООО "Дуб-музыка"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (20, N'ООО "Лилейник-музыка"', NULL)
INSERT [dbo].[Organization] ([OrganizationID], [OrganizationName], [OrganizationLogotip]) VALUES (21, N'ООО "Юкка-музыка"', NULL)
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO
SET IDENTITY_INSERT [dbo].[Pounkt] ON 

INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (1, N'млврлорл', 13, N'Ритм', N'10:00-20:00', 1)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (2, N'плдклдукпдк', 13, N'Ритм', N'7:30-22:00', 1)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (3, N'олпоклоп', 13, N'Ритм', N'9:00-21:30', 2)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (4, N'hsughskgh', 1, N'Лошадь', N'7:00-23:00', 3)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (5, N'плоылоп', 1, N'Лошадь-экспресс', N'7:00-23:00', 1)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (6, N'мрамыломло', 5, N'Гитарные струны', N'10:00-23:00', 3)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (7, N'ашгрму', 14, N'Музыка всадника', N'8:30-22:30', 2)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (8, N'ыпышпекпо', 14, N'Лошадь-ритм', N'8:30-22:30', 4)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (9, N'аплорплокел', 13, N'Лошадь-ритм', N'8:30-22:30', 4)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (10, N'влрлвли', 13, N'Москва-ритм', N'8:30-21:30', 2)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (11, N'варподаы', 13, N'Новгород-Ритм', N'10:00-18:00', 6)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (12, N'влрлвли', 13, N'Новгород-ритм', N'9:00-21:00', 6)
INSERT [dbo].[Pounkt] ([PounktID], [PounktAddress], [PounktOrganizationID], [PounktName], [PounktSchedule], [PounktStockID]) VALUES (13, N'аплорплокел', 13, N'Новгород2-ритм', N'10:00-22:00', 7)
SET IDENTITY_INSERT [dbo].[Pounkt] OFF
GO
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (1, N'Ритм-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (2, N'Ритм-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (3, N'Лошадь-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (11, N'Новгород-заказ')
INSERT [dbo].[PounktOfIssue] ([PounktID], [PounktOfIssoueName]) VALUES (13, N'Новгород2-заказ')
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (1, N'1234      ', N'Гитара 123', CAST(8000.00 AS Decimal(18, 2)), 18, 2, 5, N'Гитара аккустическая, 6 металлических струн', 2, NULL, NULL, N'6;20;Метал;EADGBE;Нет')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (2, N'abcd      ', N'Гитара аккустическая 123', CAST(5000.00 AS Decimal(18, 2)), 50, 2, 27, N'Гитара аккустическая со встроенным звукоснимателем, 6 струн', 1, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (3, N'ab12      ', N'Гитара аккустическая 123', CAST(4000.00 AS Decimal(18, 2)), 4, 3, 27, N'Гитара аккустическая с местом под звукосниматель, 6 струн', 3, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (4, N'12345678  ', N'Гитара классическая 123', CAST(6000.00 AS Decimal(18, 2)), 10, 2, 28, N'Гитара классическая, 7 струн', 3, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (6, N'abcdefg   ', N'Гитара классическая abc', CAST(4800.00 AS Decimal(18, 2)), 20, 3, 28, N'Гитара классическая, 6 струн', 4, NULL, NULL, N'6;20;Нейлон;EADGBE;Нет')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (7, N'a1b2c3d4e5', N'Укулеле 123', CAST(3200.00 AS Decimal(18, 2)), 32, 4, 6, N'Укулеле со звукоснимателем, 4 нейлоновых струны', 5, NULL, NULL, N'4;20;Нейлон;GCEA;Звукосниматель;Тенор')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (8, N'vkdfdsfvk ', N'Укулеле 123', CAST(3500.00 AS Decimal(18, 2)), 2, 2, 6, N'Укулеле, 4 нейлоновых струны', 5, NULL, NULL, N'4;20;Нейлон;GCEA;Нет;Сопрано')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (9, N'gcjhgjhfg ', N'Укулеле abc', CAST(4230.45 AS Decimal(18, 2)), 0, 3, 6, N'Укулеле, 4 нейлоновых струны', 1, NULL, NULL, N'4;12;Нейлон;GCEA;Звукосниматель;Баритон')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (10, N'jkdskhgk  ', N'Укулеле abc', CAST(9800.00 AS Decimal(18, 2)), 1, 1, 6, N'Укулеле, 4 нейлоновых струны', 1, NULL, NULL, N'4;12;Нейлон;GCEA;Звукосниматель;Бас')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (11, N'dfkgbdfk  ', N'Электрогитара', CAST(9800.00 AS Decimal(18, 2)), 1, 1, 7, N'Электрогитара, 6 струн, 4 ручки регулировки звука, звукосниматель встроенный', 1, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (12, N'vkjdskvds ', N'Бас-гитара', CAST(9500.00 AS Decimal(18, 2)), 2, 1, 8, N'Бас-гитара, 5 струны, 4 ручки регулировки звука, звукосниматель встроенный', 1, NULL, NULL, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (13, N'врмловрм  ', N'Укулеле-концерт', CAST(9000.00 AS Decimal(18, 2)), 0, 2, 6, NULL, 3, NULL, NULL, N'4;20;Нейлон;GCEA;Место под звукосниматель;Концерт')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (16, N'вамрывлр  ', N'Укулеле-концерт', CAST(8500.00 AS Decimal(18, 2)), 20, 2, 6, N'Укулеле конецетная, 4 металлические струны, Наличие встроенного звукоснимателя', 1, NULL, NULL, N'4;25;Нейлон;GCEA;Звукосниматель;Концерт')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (20, N'вааапу1   ', N'Кападастр гитарный', CAST(141.00 AS Decimal(18, 2)), 24, 2, 36, N'Кападастр гитарный универсальный', 4, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (21, N'dfsbsdfbs ', N'Кападастр для укулеле', CAST(75.00 AS Decimal(18, 2)), 3, 4, 36, N'Кападастр укулельный универсальный', 4, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (22, N'vsdbsbgs  ', N'Кападастр для гитары и концертной укулеле', CAST(501.78 AS Decimal(18, 2)), 9, 1, 36, N'Кападастр раздвижной, подстраиваемый под гитару и под укулеле.
Идеально подходит как для аккустической гитары, так и для классической гитары, и даже для электрогитары и бас-гитары.
Также, подходит для укулеле любого типа.
Подходит, как для металлических, так и для нейлоновых струн.', 1, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (23, N'dfndfn    ', N'Кападастр бас-гитарный', CAST(600.00 AS Decimal(18, 2)), 14, 2, 36, N'Кападастр для бас-гитары. Может быть подстроен под электрогитару. Подходит под струны, как маленькой, так и большой толщины.
Не рекомендуется под нейлоновые струны.', 1, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (24, N'dsbsbsgb  ', N'Фортепиано', CAST(9970.98 AS Decimal(18, 2)), 21, 1, 3, N'Фортепиано стандартное.
Пидаль сустейна в наличии', 1, NULL, NULL, N'')
INSERT [dbo].[Product] ([ProductID], [ProductArticle], [ProductName], [ProductCost], [ProductDiscount], [ProductManufactureID], [ProductCategoryID], [ProductDescription], [ProductSupplierID], [ProductPhoto], [ProductSounds], [ProductParameters]) VALUES (25, N'kcbbdfvbd ', N'Пионино', CAST(9999.99 AS Decimal(18, 2)), 12, 3, 25, N'Пионино домашнее. Стандартного размера.
Красного цвета. 
Съёмная педаль сустейна. 
Встроенный съёмный звукосниматель.', 3, NULL, NULL, N'')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (1, N'Музыкальные инструменты', 0, 0, N'Цвет', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (2, N'Струнные', 1, 1, N'Количество струн; Количество ладов; Струнный материал; Строй; Наличие встроенного звукоснимателя или места под него', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (3, N'Клавишные', 1, 1, N'Количество клавиш; Количество встроенных звуков музыкальных инструментов', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (4, N'Духовые', 1, 1, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (5, N'Гитары', 1, 2, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (6, N'Укулеле', 1, 2, N'Вид', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (7, N'Электрогитары', 1, 5, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (8, N'Бас-гитары', 1, 5, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (9, N'Блок-флейты', 1, 4, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (10, N'Музыкальные пособия', 0, 0, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (11, N'Сборники песен', 1, 10, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (12, N'Музыкальные гаммы', 1, 10, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (13, N'Музыкальная аппаратура', 0, 0, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (14, N'Звуковые карты', 1, 13, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (15, N'Усилители', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (16, N'Звукосниматели', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (17, N'Микрофоны', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (18, N'Наушники', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (19, N'Колонки', 1, 13, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (20, N'Аксессуары', 0, 0, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (21, N'Ремни для гитары', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (22, N'Ремни для укулеле', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (23, N'Пидали сустейна для синтезатора', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (24, N'Синтезаторы', 1, 3, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (25, N'Пионино', 1, 3, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (26, N'Рояль', 1, 3, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (27, N'Аккустические гитары', 1, 5, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (28, N'Классические гитары', 1, 5, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (29, N'Запчасти от инструментов', 0, 0, N'          ', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (30, N'Струны для струнных инструментов', 1, 37, N'Количество струн в упаковке; Размер струн; Количество струн на инструменте; строй', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (31, N'Струны для гитары', 1, 30, N'          ', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (32, N'Струны для укулеле', 1, 30, N'          ', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (33, N'Струны для электрогитары', 1, 30, N'          ', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (34, N'Струны для бас-гитары', 1, 30, N'          ', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (35, N'Тюнеры', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (36, N'Кападастры', 1, 20, N'          ', 2)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (37, N'Запчасти для струнных инструментов', 1, 29, N'', 1)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (38, N'Ладовые порожки', 1, 37, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (39, N'Ладовые порожки для гитары', 1, 38, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (40, N'Ладлвые порожки для укулеле', 1, 38, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (41, N'Ладовые порожки для электрогитары', 1, 38, N'', 3)
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [Subcategorie], [RootCategoryID], [CategoryParametersName], [CategoryFilterID]) VALUES (42, N'Ладовые порожки для бас-гитары', 0, 0, N'', 3)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (1, 1, 33)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (1, 2, 14)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (1, 3, 14)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (1, 8, 90)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (1, 9, 90)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (1, 12, 25)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (1, 25, 51)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (2, 2, 2)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (2, 7, 150)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (2, 8, 80)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (2, 25, 120)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (4, 1, 45)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (4, 4, 13)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (4, 6, 5)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (9, 1, 8)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (9, 2, 9)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (9, 3, 10)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (9, 4, 15)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (9, 8, 100)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (9, 9, 80)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (9, 25, 24)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (10, 6, 50)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (10, 7, 45)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (10, 8, 85)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (10, 9, 80)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (10, 10, 10)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (10, 11, 10)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (10, 12, 20)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (10, 25, 33)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (12, 25, 36)
INSERT [dbo].[ProductInShop] ([ShopID], [ProductID], [QuantityInShop]) VALUES (13, 25, 24)
GO
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (1, 1, 50)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (1, 2, 40)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (1, 3, 15)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (1, 4, 5)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (1, 25, 15)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (2, 1, 5)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (2, 4, 12)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (2, 6, 5)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (2, 7, 14)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (2, 8, 15)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (2, 25, 63)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (3, 3, 45)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (3, 4, 34)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (3, 6, 50)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (3, 8, 150)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (3, 9, 50)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (3, 25, 42)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (4, 1, 40)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (4, 10, 30)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (4, 11, 50)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (4, 12, 40)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (4, 25, 42)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 1, 30)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 2, 14)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 3, 15)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 4, 25)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 6, 20)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 7, 30)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 8, 40)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 9, 35)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 10, 10)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 11, 13)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (5, 12, 45)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (6, 25, 30)
INSERT [dbo].[ProductInStock] ([StockID], [ProductID], [QuantityInStock]) VALUES (7, 25, 33)
GO
SET IDENTITY_INSERT [dbo].[ProductManufacture] ON 

INSERT [dbo].[ProductManufacture] ([ManufactureID], [ManufactureName]) VALUES (1, N'abc')
INSERT [dbo].[ProductManufacture] ([ManufactureID], [ManufactureName]) VALUES (2, N'bcd')
INSERT [dbo].[ProductManufacture] ([ManufactureID], [ManufactureName]) VALUES (3, N'cde')
INSERT [dbo].[ProductManufacture] ([ManufactureID], [ManufactureName]) VALUES (4, N'abcdef')
SET IDENTITY_INSERT [dbo].[ProductManufacture] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSupplier] ON 

INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (1, N'abcd')
INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (2, N'bcde')
INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (3, N'cdef')
INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (4, N'defg')
INSERT [dbo].[ProductSupplier] ([SupplierID], [SupplierName]) VALUES (5, N'abcdefg')
SET IDENTITY_INSERT [dbo].[ProductSupplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Клиент')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Директор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (4, N'Менеджер по складу')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (5, N'Менеджер по заказам')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (6, N'Оператор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (7, N'Продавец')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (1, N'Магазин-ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (2, N'ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (4, N'Лошадь-музыка')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (9, N'Лошадь-ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (10, N'Москва-ритм')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (12, N'Новгород-магазин')
INSERT [dbo].[Shop] ([PounktID], [ShopName]) VALUES (13, N'Новгород2-магазин')
GO
SET IDENTITY_INSERT [dbo].[Sity] ON 

INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (1, N'Санкт-Петербург')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (2, N'Москва')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (3, N'Сочи')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (4, N'Великий Новгород')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (5, N'Тверь')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (6, N'Псков')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (7, N'Торжок')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (8, N'Порхов')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (9, N'Кашин')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (10, N'Углич')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (11, N'Луга')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (12, N'Гатчина')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (13, N'Петергоф')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (14, N'Кронштадт')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (15, N'Выборг')
INSERT [dbo].[Sity] ([SityID], [SityName]) VALUES (16, N'Мшинская')
SET IDENTITY_INSERT [dbo].[Sity] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID]) VALUES (1, N'Питер-Склад', N'иьмивылаам', 1)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID]) VALUES (2, N'Москва-склад', N'фвыаорукора', 2)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID]) VALUES (3, N'Петербург-склад', N'аыыимрвыам', 1)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID]) VALUES (4, N'Сочи-склад', N'пшрпа', 3)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID]) VALUES (5, N'Выборг-склад', N'рмшнмк', 15)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID]) VALUES (6, N'Новгород-склад', N'ошдркыд', 4)
INSERT [dbo].[Stock] ([StockID], [StockName], [StockAddress], [StockSityID]) VALUES (7, N'Новгород2-склад', N'млоыотмловиаы', 4)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (1, N'anton', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (2, N'sidorov', N'password', 0, N'0.0', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (4, N'anton1', N'123', 1, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (5, N'sidorov1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (6, N'AntonSidorov', N'password', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (7, N'AntonSidorov1', N'', 1, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (8, N'a', N'passwords', 1, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (9, N'as', N'123', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (11, N'sajkjvadfs1', N'123', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (12, N'hsdhsghsh', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (18, N'Директор', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (19, N'SysAdmin', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (20, N'Cunsumer1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (21, N'Cunsumer2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (22, N'Cunsumer3', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (23, N'ManagerOrder1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (24, N'ManagerOrder2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (25, N'ManagerGoods1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (26, N'ManagerGoods2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (27, N'Operator1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (28, N'Operator2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (29, N'Operator3', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (30, N'Client1', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (31, N'Client2', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (32, N'Client3', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (33, N'Client4', N'', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (34, N'client5', N'1234', 0, N'0.0', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [ChatUser], [Encription_Algorithm], [UserBlocked]) VALUES (35, N'CSCASDC', N'', 0, N'0.0', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserEmail] ON 

INSERT [dbo].[UserEmail] ([EmailID], [UserID], [Email]) VALUES (1, 6, N'ab@cd.ef')
INSERT [dbo].[UserEmail] ([EmailID], [UserID], [Email]) VALUES (3, 7, N'A@MusicGamms.d')
INSERT [dbo].[UserEmail] ([EmailID], [UserID], [Email]) VALUES (4, 8, N'ab@cd.ef')
INSERT [dbo].[UserEmail] ([EmailID], [UserID], [Email]) VALUES (6, 6, N'abcd@efgh')
SET IDENTITY_INSERT [dbo].[UserEmail] OFF
GO
INSERT [dbo].[UserInitials] ([UserID], [UserFamily], [UserName], [UserSurName]) VALUES (6, N'Сидоров', N'Антон', N'Дмитриевич')
INSERT [dbo].[UserInitials] ([UserID], [UserFamily], [UserName], [UserSurName]) VALUES (7, N'Сидоров', N'Антон', N'')
GO
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (1, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (2, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (2, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (4, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (4, 3)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (4, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (4, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (5, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (5, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (5, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 3)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (6, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (7, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (8, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (9, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (12, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (18, 2)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (19, 3)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (20, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (21, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (22, 7)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (23, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (24, 5)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (25, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (26, 4)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (27, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (28, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (29, 6)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (30, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (31, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (32, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (33, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (34, 1)
INSERT [dbo].[UserRole] ([UserID], [RoleID]) VALUES (35, 1)
GO
SET IDENTITY_INSERT [dbo].[UserTelefon] ON 

INSERT [dbo].[UserTelefon] ([TelefonID], [UserID], [Telefon]) VALUES (1, 6, N'+7(123)456-78-90')
INSERT [dbo].[UserTelefon] ([TelefonID], [UserID], [Telefon]) VALUES (3, 7, N'+7(123)456-78-90')
INSERT [dbo].[UserTelefon] ([TelefonID], [UserID], [Telefon]) VALUES (6, 6, N'+7(123)456-78-95')
SET IDENTITY_INSERT [dbo].[UserTelefon] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Product]    Script Date: 10.03.2023 22:33:19 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [IX_Product] UNIQUE NONCLUSTERED 
(
	[ProductArticle] ASC
)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User]    Script Date: 10.03.2023 22:33:19 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [IX_User] UNIQUE NONCLUSTERED 
(
	[UserLogin] ASC
)
GO
/****** Object:  Index [IX_UserNikName]    Script Date: 10.03.2023 22:33:19 ******/
ALTER TABLE [dbo].[UserNikName] ADD  CONSTRAINT [IX_UserNikName] UNIQUE NONCLUSTERED 
(
	[UserID] ASC
)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserPsevdonim]    Script Date: 10.03.2023 22:33:19 ******/
ALTER TABLE [dbo].[UserPsevdonim] ADD  CONSTRAINT [IX_UserPsevdonim] UNIQUE NONCLUSTERED 
(
	[PsevdonimName] ASC
)
GO
ALTER TABLE [dbo].[CopyMessage] ADD  CONSTRAINT [DF_CopyMessage_CloseCopy]  DEFAULT ((0)) FOR [CloseCopy]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_MessageDateSent]  DEFAULT (getdate()) FOR [MessageDateTimeSent]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_MessageDelayedSend]  DEFAULT ((0)) FOR [MessageDelayedSend]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_MessageDelayedTime]  DEFAULT (getdate()) FOR [MessageDelayedTime]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_MessageStatusID]  DEFAULT ((2)) FOR [MessageStatusID]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderStatusID]  DEFAULT ((1)) FOR [OrderStatusID]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderDate]  DEFAULT (getdate()) FOR [OrderDateCreate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ProductDiscount]  DEFAULT ((0)) FOR [ProductDiscount]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_Subcategorie]  DEFAULT ((0)) FOR [Subcategorie]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_RootCategoryID]  DEFAULT ((0)) FOR [RootCategoryID]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_CategoryFilterID]  DEFAULT ((1)) FOR [CategoryFilterID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_ChatUser]  DEFAULT ((0)) FOR [ChatUser]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Encription_Algorithm]  DEFAULT ((0.0)) FOR [Encription_Algorithm]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UserBlocked]  DEFAULT ((0)) FOR [UserBlocked]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_RoleID]  DEFAULT ((1)) FOR [RoleID]
GO
ALTER TABLE [dbo].[ClientOrder]  WITH CHECK ADD  CONSTRAINT [FK_ClientOrder_OrderInPounktOfIssue] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientOrder] CHECK CONSTRAINT [FK_ClientOrder_OrderInPounktOfIssue]
GO
ALTER TABLE [dbo].[ClientOrder]  WITH CHECK ADD  CONSTRAINT [FK_ClientOrder_User] FOREIGN KEY([ClientID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientOrder] CHECK CONSTRAINT [FK_ClientOrder_User]
GO
ALTER TABLE [dbo].[CopyMessage]  WITH CHECK ADD  CONSTRAINT [FK_CopyMessage_Message] FOREIGN KEY([IDMesaage])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CopyMessage] CHECK CONSTRAINT [FK_CopyMessage_Message]
GO
ALTER TABLE [dbo].[CopyMessage]  WITH CHECK ADD  CONSTRAINT [FK_CopyMessage_User] FOREIGN KEY([IDRecipient])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CopyMessage] CHECK CONSTRAINT [FK_CopyMessage_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_MessageStatus] FOREIGN KEY([MessageStatusID])
REFERENCES [dbo].[MessageStatus] ([StatusID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_MessageStatus]
GO
ALTER TABLE [dbo].[MessageRecipient]  WITH CHECK ADD  CONSTRAINT [FK_MessageRecipient_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageRecipient] CHECK CONSTRAINT [FK_MessageRecipient_Message]
GO
ALTER TABLE [dbo].[MessageRecipient]  WITH CHECK ADD  CONSTRAINT [FK_MessageRecipient_User] FOREIGN KEY([RecipientID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageRecipient] CHECK CONSTRAINT [FK_MessageRecipient_User]
GO
ALTER TABLE [dbo].[MessageRecipientsList]  WITH CHECK ADD  CONSTRAINT [FK_MessageRecipientsList_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageRecipientsList] CHECK CONSTRAINT [FK_MessageRecipientsList_Message]
GO
ALTER TABLE [dbo].[MessageSender]  WITH CHECK ADD  CONSTRAINT [FK_MessageSender_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageSender] CHECK CONSTRAINT [FK_MessageSender_Message]
GO
ALTER TABLE [dbo].[MessageSender]  WITH CHECK ADD  CONSTRAINT [FK_MessageSender_User] FOREIGN KEY([SenderID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MessageSender] CHECK CONSTRAINT [FK_MessageSender_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[OrderStatus] ([StatusID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_OrderStatus]
GO
ALTER TABLE [dbo].[OrderAttachment]  WITH CHECK ADD  CONSTRAINT [FK_OrderAttachment_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderAttachment] CHECK CONSTRAINT [FK_OrderAttachment_Message]
GO
ALTER TABLE [dbo].[OrderAttachment]  WITH CHECK ADD  CONSTRAINT [FK_OrderAttachment_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderAttachment] CHECK CONSTRAINT [FK_OrderAttachment_Order]
GO
ALTER TABLE [dbo].[OrderInPounktOfIssue]  WITH CHECK ADD  CONSTRAINT [FK_OrderInPounktOfIssue_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderInPounktOfIssue] CHECK CONSTRAINT [FK_OrderInPounktOfIssue_Order]
GO
ALTER TABLE [dbo].[OrderInPounktOfIssue]  WITH CHECK ADD  CONSTRAINT [FK_OrderInPounktOfIssue_PounktOfIssue] FOREIGN KEY([PounktOfIssoeID])
REFERENCES [dbo].[PounktOfIssue] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderInPounktOfIssue] CHECK CONSTRAINT [FK_OrderInPounktOfIssue_PounktOfIssue]
GO
ALTER TABLE [dbo].[OrderInShop]  WITH CHECK ADD  CONSTRAINT [FK_OrderInShop_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderInShop] CHECK CONSTRAINT [FK_OrderInShop_Order]
GO
ALTER TABLE [dbo].[OrderInShop]  WITH CHECK ADD  CONSTRAINT [FK_OrderInShop_Shop] FOREIGN KEY([OrderShopID])
REFERENCES [dbo].[Shop] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderInShop] CHECK CONSTRAINT [FK_OrderInShop_Shop]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product]
GO
ALTER TABLE [dbo].[OrderSaleMan]  WITH CHECK ADD  CONSTRAINT [FK_OrderSaleMan_OrderInShop] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrderInShop] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderSaleMan] CHECK CONSTRAINT [FK_OrderSaleMan_OrderInShop]
GO
ALTER TABLE [dbo].[OrderSaleMan]  WITH CHECK ADD  CONSTRAINT [FK_OrderSaleMan_User] FOREIGN KEY([OrderSaleManID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderSaleMan] CHECK CONSTRAINT [FK_OrderSaleMan_User]
GO
ALTER TABLE [dbo].[Pounkt]  WITH CHECK ADD  CONSTRAINT [FK_Pounkt_Organization] FOREIGN KEY([PounktOrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pounkt] CHECK CONSTRAINT [FK_Pounkt_Organization]
GO
ALTER TABLE [dbo].[Pounkt]  WITH CHECK ADD  CONSTRAINT [FK_Pounkt_Stock] FOREIGN KEY([PounktStockID])
REFERENCES [dbo].[Stock] ([StockID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pounkt] CHECK CONSTRAINT [FK_Pounkt_Stock]
GO
ALTER TABLE [dbo].[PounktOfIssue]  WITH CHECK ADD  CONSTRAINT [FK_PounktOfIssue_Pounkt] FOREIGN KEY([PounktID])
REFERENCES [dbo].[Pounkt] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PounktOfIssue] CHECK CONSTRAINT [FK_PounktOfIssue_Pounkt]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[ProductCategory] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductManufacture] FOREIGN KEY([ProductManufactureID])
REFERENCES [dbo].[ProductManufacture] ([ManufactureID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductManufacture]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductSupplier] FOREIGN KEY([ProductSupplierID])
REFERENCES [dbo].[ProductSupplier] ([SupplierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductSupplier]
GO
ALTER TABLE [dbo].[ProductAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttachment_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([MessageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttachment] CHECK CONSTRAINT [FK_ProductAttachment_Message]
GO
ALTER TABLE [dbo].[ProductAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttachment_Product] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Product] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttachment] CHECK CONSTRAINT [FK_ProductAttachment_Product]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_CategoryFilter] FOREIGN KEY([CategoryFilterID])
REFERENCES [dbo].[CategoryFilter] ([CategoryFilterID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_CategoryFilter]
GO
ALTER TABLE [dbo].[ProductInShop]  WITH CHECK ADD  CONSTRAINT [FK_ProductInShop_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInShop] CHECK CONSTRAINT [FK_ProductInShop_Product]
GO
ALTER TABLE [dbo].[ProductInShop]  WITH CHECK ADD  CONSTRAINT [FK_ProductInShop_Shop] FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInShop] CHECK CONSTRAINT [FK_ProductInShop_Shop]
GO
ALTER TABLE [dbo].[ProductInStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductInStock_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInStock] CHECK CONSTRAINT [FK_ProductInStock_Product]
GO
ALTER TABLE [dbo].[ProductInStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductInStock_Stock] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInStock] CHECK CONSTRAINT [FK_ProductInStock_Stock]
GO
ALTER TABLE [dbo].[Shop]  WITH CHECK ADD  CONSTRAINT [FK_Shop_Pounkt] FOREIGN KEY([PounktID])
REFERENCES [dbo].[Pounkt] ([PounktID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shop] CHECK CONSTRAINT [FK_Shop_Pounkt]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Sity] FOREIGN KEY([StockSityID])
REFERENCES [dbo].[Sity] ([SityID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Sity]
GO
ALTER TABLE [dbo].[UserEmail]  WITH CHECK ADD  CONSTRAINT [FK_UserEmail_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserEmail] CHECK CONSTRAINT [FK_UserEmail_User]
GO
ALTER TABLE [dbo].[UserInitials]  WITH CHECK ADD  CONSTRAINT [FK_UserInitials_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInitials] CHECK CONSTRAINT [FK_UserInitials_User]
GO
ALTER TABLE [dbo].[UserNikName]  WITH CHECK ADD  CONSTRAINT [FK_UserNikName_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserNikName] CHECK CONSTRAINT [FK_UserNikName_User]
GO
ALTER TABLE [dbo].[UserPsevdonim]  WITH CHECK ADD  CONSTRAINT [FK_UserPsevdonim_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPsevdonim] CHECK CONSTRAINT [FK_UserPsevdonim_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
ALTER TABLE [dbo].[UserTelefon]  WITH CHECK ADD  CONSTRAINT [FK_UserTelefon_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTelefon] CHECK CONSTRAINT [FK_UserTelefon_User]
GO
/****** Object:  Trigger [dbo].[SubCategorieUpdate]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Trigger [dbo].[SubCategorieUpdate]    Script Date: 17.02.2023 14:55:53 ******/
 
/****** Object:  Trigger [dbo].[SubCategorieUpdate]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE TRIGGER [dbo].[SubCategorieUpdate]
ON [dbo].[ProductCategory]
AFTER INSERT, Update
AS 
BEGIN
	Declare @count int
	Select @count = Count(*) From ProductCategory where Subcategorie = 0 and RootCategoryID <> 0
	 if (@count > 0)
	 Update ProductCategory set RootCategoryID = 0 where Subcategorie = 0
	 Select @count = Count(*) From ProductCategory where RootCategoryID is null
	 if (@count > 0)
	 Update ProductCategory set RootCategoryID = 0 where RootCategoryID is null
	 Select @count = Count(*) From ProductCategory where RootCategoryID < 1 and Subcategorie = 1 
	 if (@count > 0)
	 Update ProductCategory set Subcategorie = 0 where RootCategoryID = 0
	 Select @count = Count(*) From ProductCategory where CategoryParametersName is null
	 if (@count > 0)
	 Update ProductCategory set CategoryParametersName = '' where CategoryParametersName is null


END
GO
ALTER TABLE [dbo].[ProductCategory] ENABLE TRIGGER [SubCategorieUpdate]
GO
/****** Object:  Trigger [dbo].[UserUpdate]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Trigger [dbo].[UserUpdate]    Script Date: 17.02.2023 14:55:53 ******/
 
/****** Object:  Trigger [dbo].[UserUpdate]    Script Date: 16.02.2023 22:30:23 ******/
 

CREATE TRIGGER [dbo].[UserUpdate]
   ON [dbo].[User]
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	Declare @count1 int
	Declare @count2 int
	Declare @count3 int
	Declare @count int
	Select @count1 = Count(*) from [User] where UserPassword is null and Encription_Algorithm <> '0.0'
	Select @count2 = Count(*) from [User] where UserPassword = '' and Encription_Algorithm <> '0.0'
	Select @count3 = Count(*) from [User] where Encription_Algorithm is null	
	set @count = @count1 + @count2 + @count3
	if(@count > 0)
	Update [User] set Encription_Algorithm = '0.0' where Encription_Algorithm is null or UserPassword is null and UserPassword = ''
	Select @count = Count(*) from [User] where UserPassword is null
	if(@count > 0)
	Update [User] set UserPassword = '' where UserPassword is null
END
GO
ALTER TABLE [dbo].[User] ENABLE TRIGGER [UserUpdate]
GO
/****** Object:  Trigger [dbo].[UserInitialsUpdate]    Script Date: 10.03.2023 22:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Trigger [dbo].[UserInitialsUpdate]    Script Date: 17.02.2023 14:55:53 ******/
 
/****** Object:  Trigger [dbo].[UserInitialsUpdate]    Script Date: 16.02.2023 22:30:23 ******/
 
CREATE TRIGGER [dbo].[UserInitialsUpdate] 
   ON  [dbo].[UserInitials]
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	Declare @count int
	Select @count = Count(*) from UserInitials where UserSurName is null
	if(@count > 0)
	Update UserInitials set UserSurName = '' where UserSurName is null
END
GO
ALTER TABLE [dbo].[UserInitials] ENABLE TRIGGER [UserInitialsUpdate]
GO
