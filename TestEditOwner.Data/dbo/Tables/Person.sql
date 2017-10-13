CREATE TABLE [dbo].[Person] (
    [PersonID]   INT           NOT NULL,
    [FirstName]  NVARCHAR (50) NULL,
    [SecondName] NVARCHAR (50) NULL,
    [BirthDay]   DATE          NULL,
    [AccountID]  INT           NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonID] ASC),
    CONSTRAINT [FK_Person_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([AccoutID])
);

