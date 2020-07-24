CREATE TABLE [dbo].[RepsAtBlitz] (
    [RepsId]   INT            IDENTITY (1, 1) NOT NULL,
    [RepName]  NVARCHAR (MAX) NULL,
    [RepId]    INT            NULL,
    [BlitzId]  INT            NULL,
    [Position] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.RepsAtBlitz] PRIMARY KEY CLUSTERED ([RepsId] ASC),
    CONSTRAINT [FK_dbo.RepsAtBlitz_dbo.Blitz_BlitzId] FOREIGN KEY ([BlitzId]) REFERENCES [dbo].[Blitz] ([BlitzId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.RepsAtBlitz_dbo.Rep_RepId] FOREIGN KEY ([RepId]) REFERENCES [dbo].[Rep] ([RepId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RepId]
    ON [dbo].[RepsAtBlitz]([RepId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BlitzId]
    ON [dbo].[RepsAtBlitz]([BlitzId] ASC);

