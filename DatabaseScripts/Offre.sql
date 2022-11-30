CREATE TABLE [dbo].[Offre] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [description] VARCHAR (300) NOT NULL,
    [pour]        VARCHAR (30) NOT NULL,
    [IDUser]      INT          NULL,
    CONSTRAINT [PK_Offre] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [PK_Offre1] FOREIGN KEY ([IDUser]) REFERENCES [dbo].[User] ([ID])
);

