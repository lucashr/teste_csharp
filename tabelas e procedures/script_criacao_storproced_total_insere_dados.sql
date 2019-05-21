USE [TESTE_NET]
GO

/****** Object:  StoredProcedure [dbo].[insereDados]    Script Date: 21/05/2019 11:55:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[insereDados] @textoDigitado varchar(250)
AS
insert into logDoSistema(textoDigitado) values(@textoDigitado)
GO


