CREATE TABLE [dbo].[DtClient] (
    [Id]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [Token]  NVARCHAR (MAX) NULL,
    [RawReq] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[DtFcmConfig] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ApiKey]     NVARCHAR (MAX) NULL,
    [AuthDomain] NVARCHAR (MAX) NULL,
    [SenderId]   NVARCHAR (MAX) NULL,
    [ServerKey]  NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO DtFcmConfig SELECT '','','',''