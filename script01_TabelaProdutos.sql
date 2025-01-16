IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_PRODUTOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Codigo] int NOT NULL,
    [Categoria_Id] int NOT NULL,
    [Image_Url] nvarchar(max) NULL,
    [Produto_Ativo] bit NOT NULL,
    [data_criacao] datetime2 NOT NULL,
    [data_ultimaAlteracao] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_PRODUTOS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Categoria_Id', N'Codigo', N'Image_Url', N'Nome', N'Produto_Ativo', N'data_criacao', N'data_ultimaAlteracao') AND [object_id] = OBJECT_ID(N'[TB_PRODUTOS]'))
    SET IDENTITY_INSERT [TB_PRODUTOS] ON;
INSERT INTO [TB_PRODUTOS] ([Id], [Categoria_Id], [Codigo], [Image_Url], [Nome], [Produto_Ativo], [data_criacao], [data_ultimaAlteracao])
VALUES (1, 1, 100001, N'camiseta_polo_Preta.com.br', N'Camisa Polo Branca', CAST(1 AS bit), '2025-01-15T00:00:00.0000000', '2025-01-15T00:00:00.0000000'),
(2, 1, 100001, N'camiseta_polo_Branca.com.br', N'Camisa Polo preto ', CAST(1 AS bit), '2025-01-15T00:00:00.0000000', '2025-01-15T00:00:00.0000000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Categoria_Id', N'Codigo', N'Image_Url', N'Nome', N'Produto_Ativo', N'data_criacao', N'data_ultimaAlteracao') AND [object_id] = OBJECT_ID(N'[TB_PRODUTOS]'))
    SET IDENTITY_INSERT [TB_PRODUTOS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250116184941_InitialCreate', N'9.0.1');

COMMIT;
GO

