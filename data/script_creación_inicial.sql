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

--------------------------------------------------------
----------    LIMPIEZA DE LA BASE DE DATOS    ----------
--------------------------------------------------------
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

IF OBJECT_ID('ClinicaTurbia.Usuario_Rol', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Usuario_Rol
GO

IF OBJECT_ID('ClinicaTurbia.Rol_Funcionalidad', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Rol_Funcionalidad
GO

IF OBJECT_ID('ClinicaTurbia.Usuario', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Usuario
GO

IF OBJECT_ID('ClinicaTurbia.Rol', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Rol
GO

IF OBJECT_ID('ClinicaTurbia.Funcionalidad', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Funcionalidad
GO

IF OBJECT_ID('ClinicaTurbia.CONSULTA_LOGIN', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CONSULTA_LOGIN
GO

IF OBJECT_ID('ClinicaTurbia.CONSULTA_ROLES', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CONSULTA_ROLES
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

IF OBJECT_ID('ClinicaTurbia.CONSULTA_FUNCIONALIDADES', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CONSULTA_FUNCIONALIDADES
GO

IF SCHEMA_ID('ClinicaTurbia') IS NOT NULL
	DROP SCHEMA [ClinicaTurbia]
GO

CREATE SCHEMA [ClinicaTurbia] AUTHORIZATION [gd]
GO

--------------------------------------------------------
---------------    CREACION DE TABLAS    ---------------
--------------------------------------------------------
CREATE PROCEDURE ClinicaTurbia.CREARTABLAS AS

----ROL----
CREATE TABLE ClinicaTurbia.Rol(
	ROL_ID [int] PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	ROL_NOMBRE [nvarchar] (255) NOT NULL
);

----FUNCIONALIDAD----
CREATE TABLE ClinicaTurbia.Funcionalidad(
	FUN_ID [int] PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	FUN_NOMBRE [nvarchar] (255) NOT NULL
);

----ROL_FUNCIONALIDAD----
CREATE TABLE ClinicaTurbia.Rol_Funcionalidad(
	ROL_ID [int] FOREIGN KEY REFERENCES ClinicaTurbia.Rol(ROL_ID) NOT NULL,
	FUN_ID [int] FOREIGN KEY REFERENCES ClinicaTurbia.Funcionalidad(FUN_ID) NOT NULL
);

----TIPO DOCUMENTO----
CREATE TABLE ClinicaTurbia.TipoDocumento(
	TIDOC_ID [int] PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	TIDOC_DESCRIPCION [nvarchar] (255) NOT NULL
);

----ESTADO CIVIL----
CREATE TABLE ClinicaTurbia.EstadoCivil(
	ECIVIL_ID [int] PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	ECIVIL_DESCRIPCION [nvarchar] (255) NOT NULL
);

----PACIENTE----
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

----MEDICO----
CREATE TABLE ClinicaTurbia.Medico(
	MED_DNI [numeric] (18,0) NOT NULL PRIMARY KEY,
	MED_NOMBRE [nvarchar] (255) NOT NULL,
	MED_APELLIDO [nvarchar] (255) NOT NULL,
	MED_DIRECCION [nvarchar] (255) NOT NULL,
	MED_TELEFONO [numeric](18, 0)  NOT NULL,
	MED_MAIL [nvarchar] (255) NOT NULL,
	MED_FECHA_NACIMIENTO [datetime] NOT NULL	 
);

----USUARIO----
CREATE TABLE ClinicaTurbia.Usuario(
	USUARIO_NOMBRE [nvarchar] (255) NOT NULL PRIMARY KEY,
	USUARIO_PASSWORD [nvarchar] (255) NOT NULL,
	USUARIO_HABILITADO [bit] NOT NULL
);

----USUARIO_ROL----
CREATE TABLE ClinicaTurbia.Usuario_Rol(
	USUARIO_NOMBRE [nvarchar] (255) FOREIGN KEY REFERENCES ClinicaTurbia.Usuario(USUARIO_NOMBRE) NOT NULL,
	ROL_ID [int] FOREIGN KEY REFERENCES ClinicaTurbia.Rol(ROL_ID) NOT NULL
);
	

GO

--------------------------------------------------------
---------------    MIGRACION DE DATOS    ---------------
--------------------------------------------------------
CREATE PROCEDURE ClinicaTurbia.MIGRACION AS

INSERT INTO ClinicaTurbia.Rol(ROL_NOMBRE) VALUES
	('Administrativo'), ('Afiliado'), ('Profesional');
	
INSERT INTO ClinicaTurbia.Funcionalidad(FUN_NOMBRE) VALUES
	('Funcionalidad 1'), ('Funcionalidad 2'), ('Funcionalidad 3');

INSERT INTO ClinicaTurbia.Rol_Funcionalidad(ROL_ID, FUN_ID) VALUES
	(1,1), (2,2), (3,3);

INSERT INTO ClinicaTurbia.TipoDocumento(TIDOC_DESCRIPCION) VALUES
	('Documento Nacional de Identidad'), ('Cédula de Identidad'),
	('Libreta de Enrolamiento'), ('Libreta Cívica');
	
INSERT INTO ClinicaTurbia.EstadoCivil(ECIVIL_DESCRIPCION) VALUES
	('Soltero/a'), ('Casado/a'), ('Viudo'), ('Concubinato'), ('Divorciado/a');

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

INSERT INTO ClinicaTurbia.Medico(MED_DNI, MED_NOMBRE, MED_APELLIDO, MED_DIRECCION,
	MED_TELEFONO, MED_MAIL, MED_FECHA_NACIMIENTO)
SELECT DISTINCT
	m.Medico_Dni,
	m.Medico_Nombre,
	m.Medico_Apellido,
	m.Medico_Direccion,
	m.Medico_Telefono,
	m.Medico_Mail,
	m.Medico_Fecha_Nac
FROM gd_esquema.Maestra m WHERE m.Medico_Dni IS NOT NULL;

INSERT INTO ClinicaTurbia.Usuario(USUARIO_NOMBRE, USUARIO_PASSWORD, USUARIO_HABILITADO)
	SELECT PAC_DNI, 1234, 1 FROM ClinicaTurbia.Paciente
	UNION
	SELECT MED_DNI, 1234, 1 FROM ClinicaTurbia.Medico;

INSERT INTO ClinicaTurbia.Usuario_Rol(USUARIO_NOMBRE, ROL_ID)
	SELECT PAC_DNI, 2 FROM ClinicaTurbia.Paciente
	UNION
	SELECT MED_DNI, 3 FROM ClinicaTurbia.Medico;

GO

--------------------------------------------------------
---------------------    LOGIN     ---------------------
--------------------------------------------------------
CREATE PROCEDURE ClinicaTurbia.CONSULTA_LOGIN
	(@usuario nvarchar(255)) AS
	SELECT * FROM ClinicaTurbia.Usuario WHERE USUARIO_NOMBRE = @usuario 
GO

CREATE PROCEDURE ClinicaTurbia.CONSULTA_ROLES
	(@usuario nvarchar(255)) AS
	SELECT R.ROL_NOMBRE FROM ClinicaTurbia.Rol R, ClinicaTurbia.Usuario_Rol UR
	WHERE UR.USUARIO_NOMBRE = @usuario AND R.ROL_ID = UR.ROL_ID
GO

CREATE PROCEDURE ClinicaTurbia.CONSULTA_FUNCIONALIDADES
	(@rol nvarchar(255)) AS
	SELECT F.FUN_NOMBRE FROM ClinicaTurbia.Rol R, ClinicaTurbia.Rol_Funcionalidad RF,
	ClinicaTurbia.Funcionalidad F WHERE 
	R.ROL_NOMBRE = @rol AND RF.ROL_ID = R.ROL_ID AND F.FUN_ID = RF.FUN_ID
GO


------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
------------------------------------------CARGAR------------------------------------
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------

EXEC ClinicaTurbia.CREARTABLAS
EXEC ClinicaTurbia.MIGRACION