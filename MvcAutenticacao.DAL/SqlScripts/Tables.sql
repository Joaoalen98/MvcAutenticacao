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

CREATE TABLE [UsersRoles] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_UsersRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] nvarchar(450) NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [UserRoleId] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuarios_UsersRoles_UserRoleId] FOREIGN KEY ([UserRoleId]) REFERENCES [UsersRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Usuarios_UserRoleId] ON [Usuarios] ([UserRoleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230211203156_Inicial', N'7.0.2');
GO

COMMIT;
GO

