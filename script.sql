CREATE TABLE coffee
(
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[roast] [varchar](50) NOT NULL,
	[country] [varchar](50) NOT NULL,
	[image] [varchar](255) NULL,
	[review] [text] NOT NULL
)
INSERT INTO [coffee] VALUES (
 N'Café au Lait', N'Classic', 2.25, N'Medium', N'France', N'../Images/Coffee/Cafe-Au-Lait.jpg',
 N'A coffee beverage consisting strong or bold coffee (sometimes espresso) mixed with scalded milk in approximately a 1:1 ratio.')
INSERT INTO [coffee] VALUES (
 N'Caffè Americano', N'Espresso', 2.25, N'Medium', N'Italy', N'../Images/coffee/caffe_americano.jpg',
N'Similar in strength and taste to American-style brewed coffee, there are subtle differences achieved by pulling a fresh shot of espresso for the beverage base.')
INSERT INTO [coffee] VALUES (
 N'Peppermint White Chocolate Mocha', N'Espresso', 3.25, N'Medium', N'Italy', N'../Images/coffee/white-chocolate-peppermint-mocha.jpg',
N'Espresso with white chocolate and peppermint flavored syrups.
Topped with sweetened whipped cream and dark chocolate curls.')
INSERT INTO [coffee] VALUES (
 N'Irish Coffee', N'Alcoholic', 2.25, N'Dark', N'Ireland', N'../Images/coffee/irish coffee.jpg',
 N'A cocktail consisting of hot coffee, Irish whiskey, and sugar, stirred, and topped with thick cream. The coffee is drunk through the cream.')
