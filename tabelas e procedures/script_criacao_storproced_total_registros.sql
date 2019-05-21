USE [TESTE_NET]
GO

/****** Object:  StoredProcedure [dbo].[totRegistros]    Script Date: 21/05/2019 11:55:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[totRegistros]
AS
select count(*) from logDoSistema
GO


