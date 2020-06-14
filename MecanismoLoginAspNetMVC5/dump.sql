-- CREATE DATABASE DB_ACESSO

USE DB_ACESSO

CREATE TABLE Usuario(	
	IdUsuario int IDENTITY NOT NULL,
	EmailUsuario varchar(100) NOT NULL,
    SenhaUsuario varchar(100) NOT NULL,    
	TipoUsuario char(1) NOT NULL, 
    SituacaoUsuario char(1) NOT NULL,
    AtualizaoUsuario datetime NOT NULL,		
	CONSTRAINT IdUsuario_PK PRIMARY KEY CLUSTERED (IdUsuario),		
    CONSTRAINT TipoUsuario_CK_01 CHECK (TipoUsuario = 'S' OR TipoUsuario = 'U'), -- Supervisor, usuário Final
	CONSTRAINT SituacaoUsuario_CK_01 CHECK (SituacaoUsuario = 'A' OR SituacaoUsuario = 'I' OR SituacaoUsuario = 'B'), -- Ativo, Inativo, Bloqueado	
);

INSERT INTO Usuario VALUES ('supervisor@supervisor.com','123456','S','A',GETDATE());
INSERT INTO Usuario VALUES ('usuario@comum.com','123456','U','A',GETDATE());

USE DB_ACESSO
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jacques de Lassau>
-- Create date: <14/06/2020>
-- Description:	<Consultar Usuario por e-mail e senha>
-- ============================================= 
CREATE PROCEDURE [dbo].[SP_AcessoUsuarioV1]	
	@EmailUsuario varchar(100),
	@SenhaUsuario varchar(100)
AS
BEGIN
	BEGIN TRAN 
	IF NOT EXISTS (Select EmailUsuario,SenhaUsuario From DB_ACESSO..Usuario With(nolock) Where EmailUsuario = @EmailUsuario And SenhaUsuario = @SenhaUsuario And SituacaoUsuario = 'A' And TipoUsuario = 'S')
	BEGIN			
		PRINT 'E-mail ou senha inválido.'
		ROLLBACK
	END	
	ELSE
	BEGIN
		Select EmailUsuario,SenhaUsuario From DB_ACESSO..Usuario With(nolock) Where EmailUsuario = @EmailUsuario And SenhaUsuario = @SenhaUsuario And SituacaoUsuario = 'A' And TipoUsuario = 'S'
		COMMIT
	END
END
GO