CREATE TABLE [dbo].[Account] (
    [AccoutID] INT             NOT NULL,
    [Number]   NVARCHAR (10)   NULL,
    [Balance]  NUMERIC (10, 2) NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccoutID] ASC)
);

