-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
----------------------TRABAJO PRACTICO GESTION DE DATOS------------------------------
--------------------------------ENTREGA 1--------------------------------------------
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------
--------------------------- ESQUEMA    ClinicaTurbia---------------------------------
-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------

USE [GD2C2013]
GO

IF OBJECT_ID('ClinicaTurbia.CREARTABLAS', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CREARTABLAS
GO

IF OBJECT_ID('ClinicaTurbia.Paciente', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Paciente
GO

IF OBJECT_ID('ClinicaTurbia.Usuario', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Usuario
GO

IF OBJECT_ID('ClinicaTurbia.CONSULTA_LOGIN', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CONSULTA_LOGIN
GO

IF OBJECT_ID('ClinicaTurbia.CREARPK', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CREARPK
GO

IF OBJECT_ID('ClinicaTurbia.MIGRACION', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.MIGRACION
GO

IF SCHEMA_ID('ClinicaTurbia') IS NOT NULL
	DROP SCHEMA [ClinicaTurbia]
GO

CREATE SCHEMA [ClinicaTurbia] AUTHORIZATION [gd]
GO

CREATE PROCEDURE ClinicaTurbia.CREARTABLAS AS

CREATE TABLE ClinicaTurbia.Paciente(
	PAC_DNI [numeric] (18,0) NOT NULL PRIMARY KEY,
	PAC_NOMBRE [nvarchar] (255) NOT NULL,
	PAC_APELLIDO [nvarchar] (255) NOT NULL,
	PAC_DIRECCION [nvarchar] (255) NOT NULL,
	PAC_TELEFONO [numeric](18, 0)  NOT NULL,
	PAC_MAIL [nvarchar] (255) NOT NULL,
	PAC_FECHA_NACIMIENTO [datetime] NOT NULL	 
);

CREATE TABLE ClinicaTurbia.Usuario(
	USUARIO_NOMBRE [numeric] (18,0) NOT NULL PRIMARY KEY,
	USUARIO_PASSWORD [nvarchar] (255) NOT NULL,
	USUARIO_HABILITADO [bit] NOT NULL
);

GO

CREATE PROCEDURE ClinicaTurbia.CREARPK AS
GO

CREATE PROCEDURE ClinicaTurbia.MIGRACION AS

--------------------------------------------------------
--------------------    PACIENTE    --------------------
--------------------------------------------------------
INSERT INTO ClinicaTurbia.Paciente(PAC_DNI, PAC_NOMBRE, PAC_APELLIDO, PAC_DIRECCION,
	PAC_TELEFONO, PAC_MAIL, PAC_FECHA_NACIMIENTO)
SELECT DISTINCT
	m.Paciente_Dni,
	m.Paciente_Nombre,
	m.Paciente_Apellido,
	m.Paciente_Direccion,
	m.Paciente_Telefono,
	m.Paciente_Mail,
	m.Paciente_Fecha_Nac
FROM gd_esquema.Maestra m;

--------------------------------------------------------
--------------------    USUARIO    --------------------
--------------------------------------------------------
INSERT INTO ClinicaTurbia.Usuario(USUARIO_NOMBRE, USUARIO_PASSWORD, USUARIO_HABILITADO)
	SELECT PAC_DNI, 1234, 1 FROM ClinicaTurbia.Paciente;
GO

CREATE PROCEDURE ClinicaTurbia.CONSULTA_LOGIN
	(@usuario nvarchar(255)) AS
	SELECT * FROM ClinicaTurbia.Usuario WHERE USUARIO_NOMBRE = @usuario 
GO


------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
------------------------------------------CARGAR------------------------------------
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------

EXEC ClinicaTurbia.CREARTABLAS
EXEC ClinicaTurbia.CREARPK
EXEC ClinicaTurbia.MIGRACION