CREATE TABLE [dbo].[Clientes] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [Nome]               NVARCHAR (50) NULL,
    [Data_de_Nascimento] DATE NULL,
    [Telefone]           NVARCHAR (50) NULL,
    [Morada]             NVARCHAR (50) NULL,
    [Email]              NVARCHAR (50) NULL,
    [Foto]               IMAGE         NULL,
    [Peso]               INT           NULL,
    [Altura]             FLOAT (53)    NULL,
    [Genero]             NVARCHAR (50) NULL,
    [Senha]              NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

