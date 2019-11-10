CREATE TABLE [dbo].[adhardetails] (
    [fname]      VARCHAR (50) NULL,
    [lname]      VARCHAR (50) NULL,
    [fathername] VARCHAR (50) NULL,
    [mothername] VARCHAR (50) NULL,
    [phone]      INT          NULL,
    [address]    VARCHAR (50) NULL,
    [adharid]    INT          NOT NULL,
    [gender]     VARCHAR (50) NULL,
    [dob]        NCHAR(10) NULL,
    [image]      IMAGE        NULL,
    PRIMARY KEY CLUSTERED ([adharid] ASC)
);

