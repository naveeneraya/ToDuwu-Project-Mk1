CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [TaskName] NVARCHAR(50) NULL, 
    [TaskDescription] NTEXT NULL, 
    CONSTRAINT [FK_Task_ToUser] FOREIGN KEY (UserId) REFERENCES [User]([Id])
)
