
IF NOT EXISTS (SELECT [schema_id] FROM [sys].[schemas] WHERE [name] = '$(LayIMSchema)')
BEGIN
    EXEC (N'CREATE SCHEMA [$(LayIMSchema)]');
END

CREATE TABLE [$(LayIMSchema)].[user](
	[pk_id] [bigint] IDENTITY(100000,1) NOT NULL,
	[login_name] [varchar](20) NOT NULL,
	[login_pwd] [varchar](64) NOT NULL,
	[create_at] [datetime] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[pk_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
