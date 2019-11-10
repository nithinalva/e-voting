CREATE TABLE [dbo].[Table]
(
	[fname] VARCHAR(50) NOT NULL , 
    [lname] VARCHAR(50) NULL, 
    [fathername] VARCHAR(50) NULL, 
    [mothername] VARCHAR(50) NULL, 
    [phone] INT NULL, 
    [address] VARCHAR(50) NULL, 
    [adharid] INT NOT NULL, 
    PRIMARY KEY ([adharid])
)
