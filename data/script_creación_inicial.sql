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

IF OBJECT_ID('ClinicaTurbia.Paciente', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Paciente
GO

IF OBJECT_ID('ClinicaTurbia.Medico', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Medico
GO

IF OBJECT_ID('ClinicaTurbia.EstadoCivil', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.EstadoCivil
GO

IF OBJECT_ID('ClinicaTurbia.TipoDocumento', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.TipoDocumento
GO

IF OBJECT_ID('ClinicaTurbia.Usuario', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Usuario
GO

IF OBJECT_ID('ClinicaTurbia.CONSULTA_LOGIN', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CONSULTA_LOGIN
GO

IF OBJECT_ID('ClinicaTurbia.CREARTABLAS', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CREARTABLAS
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


CREATE TABLE ClinicaTurbia.TipoDocumento(
	TIDOC_ID [int] PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	TIDOC_DESCRIPCION [nvarchar] (255) NOT NULL
);

INSERT ClinicaTurbia.TipoDocumento(TIDOC_DESCRIPCION) VALUES
	('Documento Nacional de Identidad'), ('Cédula de Identidad'),
	('Libreta de Enrolamiento'), ('Libreta Cívica');
	
CREATE TABLE ClinicaTurbia.EstadoCivil(
	ECIVIL_ID [int] PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	ECIVIL_DESCRIPCION [nvarchar] (255) NOT NULL
);

INSERT ClinicaTurbia.EstadoCivil(ECIVIL_DESCRIPCION) VALUES
	('Soltero/a'), ('Casado/a'), ('Viudo'), ('Concubinato'), ('Divorciado/a');

CREATE TABLE ClinicaTurbia.Paciente(
	PAC_NOMBRE [nvarchar] (255) NOT NULL,
	PAC_APELLIDO [nvarchar] (255) NOT NULL,
	PAC_TIPO_DOCUMENTO [int] FOREIGN KEY REFERENCES ClinicaTurbia.TipoDocumento(TIDOC_ID),
	PAC_DNI [numeric] (18, 0) NOT NULL PRIMARY KEY,
	PAC_SEXO [char],
	PAC_FECHA_NACIMIENTO [datetime] NOT NULL,
	PAC_ESTADO_CIVIL [int] FOREIGN KEY REFERENCES ClinicaTurbia.EstadoCivil(ECIVIL_ID),
	PAC_DIRECCION [nvarchar] (255) NOT NULL,
	PAC_TELEFONO [numeric](18, 0)  NOT NULL,
	PAC_MAIL [nvarchar] (255) NOT NULL,
	PAC_CANT_HIJOS [numeric] (2, 0),
	PAC_PLAN_MEDICO [numeric] (10, 0),
	PAC_NUMERO_AFILIADO [numeric] (18, 0)
);

CREATE TABLE ClinicaTurbia.Medico(
	MED_DNI [numeric] (18,0) NOT NULL PRIMARY KEY,
	MED_NOMBRE [nvarchar] (255) NOT NULL,
	MED_APELLIDO [nvarchar] (255) NOT NULL,
	MED_DIRECCION [nvarchar] (255) NOT NULL,
	MED_TELEFONO [numeric](18, 0)  NOT NULL,
	MED_MAIL [nvarchar] (255) NOT NULL,
	MED_FECHA_NACIMIENTO [datetime] NOT NULL	 
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