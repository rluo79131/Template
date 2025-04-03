CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (30) NOT NULL,
    [Gender]    VARCHAR (6)   NOT NULL,
    [Phone]     VARCHAR (10)  NOT NULL,
    [Email]     VARCHAR (50)  NOT NULL,
    [CreatedAt] DATETIME2 (7) NOT NULL,
    [UpdatedAt] DATETIME2 (7) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

