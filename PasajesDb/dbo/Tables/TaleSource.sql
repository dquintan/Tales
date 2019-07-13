CREATE TABLE [dbo].[TaleSource]
(
	[Id] UNIQUEIDENTIFIER NOT NULL , 
    [TaleId] UNIQUEIDENTIFIER NOT NULL, 
    [Url] NVARCHAR(MAX) NOT NULL, 
    [Priority] INT NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TaleSource_Tale] FOREIGN KEY ([TaleId]) REFERENCES [Tale]([Id])
)
