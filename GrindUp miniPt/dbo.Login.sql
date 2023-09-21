CREATE TABLE [dbo].[Login] (
    [Utilizador] NVARCHAR (50) NOT NULL,
    [Senha]      NVARCHAR (50) NOT NULL,
    [Admin]      BIT           NULL,
    PRIMARY KEY CLUSTERED ([Utilizador] ASC)
);

