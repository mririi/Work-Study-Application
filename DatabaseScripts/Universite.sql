CREATE TABLE [dbo].[Universite] (
    [ID]            INT          IDENTITY (1, 1) NOT NULL,
    [nom]      VARCHAR (30) NULL,
    [adresse]     VARCHAR (30) NULL,
	[IDUser] INT NOT NULL,
    CONSTRAINT [PK_Universite] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [PK_Universite1] FOREIGN KEY ([IDUser]) REFERENCES [dbo].[User] ([ID]),
);