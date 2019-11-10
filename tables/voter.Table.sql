CREATE TABLE [dbo].[VOTER]
(
	[fname] VARCHAR(50) NOT NULL , 
    [lname] VARCHAR(50) NULL, 
    [fathername] VARCHAR(50) NULL, 
    [mothername] VARCHAR(50) NULL, 
    [phone] BIGINT NULL, 
    [address] VARCHAR(50) NULL, 
    [adharid] BIGINT NOT NULL, 
    [gender] VARCHAR(50) NULL, 
    [dob] NCHAR(50) NULL, 
    [image] IMAGE NULL, 
    [username] VARCHAR(50) NULL, 
    [password] VARCHAR(50) NULL, 
    PRIMARY KEY ([adharid])
)
