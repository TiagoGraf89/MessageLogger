USE master
GO

IF EXISTS(select * from sys.databases where name = 'Cover')
    DROP DATABASE [Cover]
GO

CREATE DATABASE [Cover]
GO
USE [Cover]
GO

IF OBJECT_ID(N'token', N'U') IS NOT NULL
    DROP TABLE [token]
GO

IF OBJECT_ID(N'application', N'U') IS NOT NULL
    DROP TABLE [application]
GO

IF OBJECT_ID(N'log', N'U') IS NOT NULL
    DROP TABLE [log]
GO

IF OBJECT_ID(N'setting', N'U') IS NOT NULL
    DROP TABLE [setting]
GO


CREATE TABLE [application](
    application_id varchar(32) PRIMARY KEY NOT NULL,
    display_name   varchar(25) NOT NULL,
    secret         varchar(25) NOT NULL)
GO

CREATE TABLE [log](
    log_id         int           NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    logger         varchar(256)  NOT NULL,
    level          varchar(256)  NOT NULL,
    message        varchar(2048) NOT NULL,
    application_id varchar(32)   REFERENCES [application](application_id)
    ON UPDATE CASCADE ON DELETE CASCADE)
GO

CREATE TABLE [token](
    token_id        int				NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    token			varchar(256)	NOT NULL,
    createdon       datetime		NOT NULL,
    expireson		datetime		NOT NULL,
    application_id	varchar(32)   REFERENCES [application](application_id)
    ON UPDATE CASCADE ON DELETE CASCADE)
GO

CREATE TABLE [setting](
    settingsId      int				NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    token_expiry_minutes int not null
)
GO

INSERT INTO [setting] (token_expiry_minutes)
VALUES (60);
