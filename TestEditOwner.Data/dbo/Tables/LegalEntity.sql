CREATE TABLE [dbo].[LegalEntity] (
    [LegalEntityID] INT           NOT NULL,
    [Name]          NVARCHAR (50) NULL,
    [Type]          NVARCHAR (20) NULL,
    [AccountID]     INT           NULL,
    CONSTRAINT [PK_LegalEntity] PRIMARY KEY CLUSTERED ([LegalEntityID] ASC),
    CONSTRAINT [FK_LegalEntity_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([AccoutID])
);

