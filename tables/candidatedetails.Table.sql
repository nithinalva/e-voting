CREATE TABLE [dbo].[candidatedetails]
(
	[fname] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [lname] VARCHAR(50) NULL, 
    [candidateid] BIGINT NULL, 
    [dob] NCHAR(60) NULL, 
    [address] VARCHAR(50) NULL, 
    [phone] BIGINT NULL, 
    [gender] VARCHAR(50) NULL, 
    [bloodgroup] VARCHAR(50) NULL, 
    [image] IMAGE NULL
)
