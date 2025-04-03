CREATE TABLE [dbo].[ApiErrorLogs] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Method]    VARCHAR (6)    NOT NULL,
    [Url]       VARCHAR (500)  NOT NULL,
    [Body]      NVARCHAR (MAX) NULL,
    [Message]   NVARCHAR (MAX) NOT NULL,
    [CreatedAt] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_ApiErrorLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

