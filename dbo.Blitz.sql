CREATE TABLE [dbo].[Blitz] (
    [BlitzId]    INT                IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX)     NOT NULL,
    [Location]   NVARCHAR (MAX)     NOT NULL,
    [Date]       DATETIME           NOT NULL,
    [CreatedUtc] DATETIMEOFFSET (7) NOT NULL,
    [Url]        NVARCHAR (MAX)     NULL,
    CONSTRAINT [PK_dbo.Blitz] PRIMARY KEY CLUSTERED ([BlitzId] ASC)
);

