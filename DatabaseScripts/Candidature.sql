CREATE TABLE [dbo].[Candidature] (
    [ID]           INT          IDENTITY (1, 1) NOT NULL,
	accepte INT Default 0,
    [IDUser]   INT          NOT NULL,
    [IDOffre]        INT          NOT NULL,
    CONSTRAINT [PK_Candidature] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [PK_Candidature1] FOREIGN KEY ([IDUser]) REFERENCES [dbo].[User] ([ID]),
    CONSTRAINT [PK_Candidature2] FOREIGN KEY ([IDOffre]) REFERENCES [dbo].[Offre] ([ID])
);

