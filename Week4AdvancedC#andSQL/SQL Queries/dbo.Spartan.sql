CREATE TABLE [dbo].[SpartanTest] (
    [SpartanID] INT     NOT NULL IDENTITY,    
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName]  NVARCHAR(50) NOT NULL,
    [Age]       INT           NOT NULL,
    [Phone]     NVARCHAR(11) NULL,
    CONSTRAINT [PK_SpartanID] PRIMARY KEY CLUSTERED ([SpartanID] ASC)
);
