CREATE TABLE [dbo].[CONTESTINGCANDIDATES] (
    [candidateid] BIGINT       NOT NULL,
    [fname]       VARCHAR (50) NULL,
    [lname]       VARCHAR (50) NULL,
    [house]       VARCHAR(50)        NULL,
    [image] IMAGE NULL, 
    CONSTRAINT [PK_CONTESTINGCANDIDATES] PRIMARY KEY CLUSTERED ([candidateid] ASC),
    CONSTRAINT [FK(candidateid)] FOREIGN KEY ([candidateid]) REFERENCES [dbo].[candidatedetails] ([candidateid])
);

