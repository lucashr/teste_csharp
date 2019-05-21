USE [TESTE_NET]
GO

/****** Object:  Table [dbo].[logDoSistema]    Script Date: 21/05/2019 11:52:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[logDoSistema](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dataEHora] [datetime] NULL,
	[textoDigitado] [varchar](250) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[logDoSistema] ADD  DEFAULT (getdate()) FOR [dataEHora]
GO


