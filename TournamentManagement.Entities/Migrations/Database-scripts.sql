IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory]
    (
        [MigrationId] NVARCHAR(150) NOT NULL,
        [ProductVersion] NVARCHAR(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Team]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [Coach] VARCHAR(50) NOT NULL,
    [Captain] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Team] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Tournament]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [StartDate] DATE NOT NULL,
    [Location] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Tournament] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Registration]
(
    [Id] INT NOT NULL IDENTITY,
    [TournamentId] INT NOT NULL,
    [TeamId] INT NOT NULL,
    [Amount] DECIMAL(8, 2) NOT NULL,
    CONSTRAINT [PK_Registration] PRIMARY KEY ([Id]),
    CONSTRAINT [FK__Registrat__TeamI__38996AB5] FOREIGN KEY ([TeamId]) REFERENCES [Team] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK__Registrat__Tourn__398D8EEE] FOREIGN KEY ([TournamentId]) REFERENCES [Tournament] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Registration_TeamId] ON [Registration] ([TeamId]);

GO

CREATE INDEX [IX_Registration_TournamentId] ON [Registration] ([TournamentId]);

GO

INSERT INTO [__EFMigrationsHistory]
    ([MigrationId], [ProductVersion])
VALUES
    (N'20191114050142_ProjectMigration', N'3.0.0');

GO