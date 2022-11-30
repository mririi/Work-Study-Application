CREATE TABLE [dbo].[User] (
    [ID]            INT          IDENTITY (1, 1) NOT NULL,
    [email]         VARCHAR (30) NOT NULL,
    [password]      VARCHAR (30) NOT NULL,
	[IDEtudiant] INT NULL,
	[IDEntreprise] INT NULL,
	[IDUni] INT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [PK_User1] FOREIGN KEY ([IDEtudiant]) REFERENCES [dbo].[Etudiant] ([ID]),
	CONSTRAINT [PK_User2] FOREIGN KEY ([IDEntreprise]) REFERENCES [dbo].[Entreprise] ([ID]),
	CONSTRAINT [PK_User3] FOREIGN KEY ([IDUni]) REFERENCES [dbo].[Universite] ([ID]),
);


