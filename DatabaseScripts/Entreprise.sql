CREATE TABLE [dbo].[Entreprise] (
    [ID]            INT          IDENTITY (1, 1) NOT NULL,
    [nom]      VARCHAR (30) NULL,
    [adresse]     VARCHAR (30) NULL,
	[IDUser] INT NOT NULL,
    CONSTRAINT [PK_Entreprise] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [PK_Entreprise1] FOREIGN KEY ([IDUser]) REFERENCES [dbo].[User] ([ID]),
);