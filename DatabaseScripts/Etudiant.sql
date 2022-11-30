CREATE TABLE [dbo].[Etudiant] (
    [ID]            INT          IDENTITY (1, 1) NOT NULL,
    [nom]      VARCHAR (30) NULL,
    [prenom]     VARCHAR (30) NULL,
	[IDUser] INT NOT NULL,
    CONSTRAINT [PK_Etudiant] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [PK_Etudiant1] FOREIGN KEY ([IDUser]) REFERENCES [dbo].[User] ([ID]),
);

