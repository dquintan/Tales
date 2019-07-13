CREATE TABLE [dbo].[Tale] (
    [Id]    UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR (MAX)   NOT NULL,
    [Date] DATETIME NULL, 
    [Country] NCHAR(10) NULL, 
    [Year] INT NULL, 
    [Century] INT NULL, 
    CONSTRAINT [PK_Tale] PRIMARY KEY CLUSTERED ([Id] ASC)
);

