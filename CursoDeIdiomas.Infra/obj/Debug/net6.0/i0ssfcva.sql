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
GO

CREATE TABLE [Cursos] (
    [id] int NOT NULL,
    [name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([id])
);
GO

CREATE TABLE [tb_aluno] (
    [id] int NOT NULL IDENTITY,
    [nome] varchar(100) NOT NULL,
    [cpf] varchar(11) NOT NULL,
    [email] nvarchar(100) NOT NULL,
    [CriadoEm] datetime2 NOT NULL DEFAULT (getDate()),
    [AtualizadoEm] datetime2 NOT NULL DEFAULT (getDate()),
    CONSTRAINT [PK_tb_aluno] PRIMARY KEY ([id])
);
GO

CREATE TABLE [tb_turma] (
    [id] int NOT NULL IDENTITY,
    [numero] int NOT NULL,
    [AnoLetivo] datetime2 NOT NULL DEFAULT (getDate()),
    [CursoId] int NOT NULL,
    [CriadoEm] datetime2 NOT NULL DEFAULT (getDate()),
    [AtualizadoEm] datetime2 NOT NULL DEFAULT (getDate()),
    CONSTRAINT [PK_tb_turma] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_turma_Cursos_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Cursos] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [tb_matricula] (
    [AlunoId] int NOT NULL,
    [TurmaId] int NOT NULL,
    [numero] uniqueidentifier NOT NULL,
    [CriadoEm] datetime2 NOT NULL,
    [AtualizadoEm] datetime2 NOT NULL,
    CONSTRAINT [PK_tb_matricula] PRIMARY KEY ([TurmaId], [AlunoId]),
    CONSTRAINT [FK_tb_matricula_tb_aluno_AlunoId] FOREIGN KEY ([AlunoId]) REFERENCES [tb_aluno] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tb_matricula_tb_turma_TurmaId] FOREIGN KEY ([TurmaId]) REFERENCES [tb_turma] ([id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'name') AND [object_id] = OBJECT_ID(N'[Cursos]'))
    SET IDENTITY_INSERT [Cursos] ON;
INSERT INTO [Cursos] ([id], [name])
VALUES (1, N'Portugues'),
(2, N'Ingles'),
(3, N'Espanhol');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'name') AND [object_id] = OBJECT_ID(N'[Cursos]'))
    SET IDENTITY_INSERT [Cursos] OFF;
GO

CREATE INDEX [IX_tb_matricula_AlunoId] ON [tb_matricula] ([AlunoId]);
GO

CREATE INDEX [IX_tb_turma_CursoId] ON [tb_turma] ([CursoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221127063736_MyFirstMigration', N'7.0.0');
GO

COMMIT;
GO

