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

IF OBJECT_ID('ClinicaTurbia.Especialidad', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Especialidad
GO

IF OBJECT_ID('ClinicaTurbia.TipoEspecialidad', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.TipoEspecialidad
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

IF OBJECT_ID('ClinicaTurbia.PlanMedico', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.PlanMedico
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

IF OBJECT_ID('ClinicaTurbia.CONSULTA_ROLES_POR_USUARIO', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CONSULTA_ROLES_POR_USUARIO
GO

IF OBJECT_ID('ClinicaTurbia.CONSULTA_FUNCIONALIDADES_POR_ROL', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CONSULTA_FUNCIONALIDADES_POR_ROL
GO

IF OBJECT_ID('ClinicaTurbia.LISTADO_FUNCIONALIDADES', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.LISTADO_FUNCIONALIDADES
GO

IF OBJECT_ID('ClinicaTurbia.LISTADO_ROLES', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.LISTADO_ROLES
GO

IF OBJECT_ID('ClinicaTurbia.LISTADO_PLAN_MEDICO', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.LISTADO_PLAN_MEDICO
GO

IF OBJECT_ID('ClinicaTurbia.LISTADO_ESPECIALIDAD', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.LISTADO_ESPECIALIDAD
GO

IF OBJECT_ID('ClinicaTurbia.LISTADO_TIPO_DOCUMENTO', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.LISTADO_TIPO_DOCUMENTO
GO

IF OBJECT_ID('ClinicaTurbia.LISTADO_ESTADO_CIVIL', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.LISTADO_ESTADO_CIVIL
GO

IF OBJECT_ID('ClinicaTurbia.NUEVO_ROL', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.NUEVO_ROL
GO

IF OBJECT_ID('ClinicaTurbia.MODIFICAR_ROL', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.MODIFICAR_ROL
GO

IF OBJECT_ID('ClinicaTurbia.MODIFICAR_FUNCIONES_ROL', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.MODIFICAR_FUNCIONES_ROL
GO

IF OBJECT_ID('ClinicaTurbia.EXISTE_AFILIADO', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.EXISTE_AFILIADO
GO

IF OBJECT_ID('ClinicaTurbia.CREAR_AFILIADO', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CREAR_AFILIADO
GO

IF OBJECT_ID('ClinicaTurbia.MODIFICAR_AFILIADO', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.MODIFICAR_AFILIADO
GO

IF OBJECT_ID('ClinicaTurbia.PRIMER_LOGIN_USUARIO', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.PRIMER_LOGIN_USUARIO
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

--------------------------------------------------------
---------------    CREACION DE TABLAS    ---------------
--------------------------------------------------------
CREATE PROCEDURE ClinicaTurbia.CREARTABLAS AS

----ROL----
CREATE TABLE ClinicaTurbia.Rol(
	ROL_ID [int] PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	ROL_NOMBRE [nvarchar] (255) NOT NULL,
	ROL_HABILITADO [bit] NOT NULL
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
	TIDOC_NOMBRE [nvarchar] (255) NOT NULL
);

----ESTADO CIVIL----
CREATE TABLE ClinicaTurbia.EstadoCivil(
	ECIVIL_ID [int] PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	ECIVIL_NOMBRE [nvarchar] (255) NOT NULL
);

----PLAN MEDICO----
CREATE TABLE ClinicaTurbia.PlanMedico(
	PLAN_CODIGO [int] NOT NULL PRIMARY KEY,
	PLAN_DESCRIPCION [nvarchar] (255),
	PLAN_PRECIO_BONO_CONSULTA [int] NOT NULL,
	PLAN_PRECIO_BONO_FARMACIA [int] NOT NULL
);	

----PACIENTE----
CREATE TABLE ClinicaTurbia.Paciente(
	PAC_NOMBRE [nvarchar] (255) NOT NULL,
	PAC_APELLIDO [nvarchar] (255) NOT NULL,
	PAC_TIPO_DOCUMENTO [int] FOREIGN KEY REFERENCES ClinicaTurbia.TipoDocumento(TIDOC_ID),
	PAC_NUMDOC [numeric] (18, 0) NOT NULL PRIMARY KEY,
	PAC_SEXO [char],
	PAC_FECHA_NACIMIENTO [datetime] NOT NULL,
	PAC_ESTADO_CIVIL [int] FOREIGN KEY REFERENCES ClinicaTurbia.EstadoCivil(ECIVIL_ID),
	PAC_DIRECCION [nvarchar] (255) NOT NULL,
	PAC_TELEFONO [numeric](18, 0),
	PAC_MAIL [nvarchar] (255) NOT NULL,
	PAC_CANT_HIJOS [numeric] (2, 0),
	PAC_PLAN_MEDICO_CODIGO [int] FOREIGN KEY REFERENCES ClinicaTurbia.PlanMedico(PLAN_CODIGO),
	PAC_NUMERO_AFILIADO [int] NOT NULL IDENTITY
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
	USUARIO_HABILITADO [bit] NOT NULL,
	USUARIO_PRIMER_LOGIN [bit] NOT NULL
);

----USUARIO_ROL----
CREATE TABLE ClinicaTurbia.Usuario_Rol(
	USUARIO_NOMBRE [nvarchar] (255) FOREIGN KEY REFERENCES ClinicaTurbia.Usuario(USUARIO_NOMBRE) NOT NULL,
	ROL_ID [int] FOREIGN KEY REFERENCES ClinicaTurbia.Rol(ROL_ID) NOT NULL
);

CREATE TABLE ClinicaTurbia.TipoEspecialidad(
	TIPOESP_CODIGO numeric(18, 0) NOT NULL PRIMARY KEY, 
	TIPOESP_DESCRIPCION varchar(255)
);

CREATE TABLE ClinicaTurbia.Especialidad(
	ESP_CODIGO numeric(18, 0) NOT NULL PRIMARY KEY, 
	ESP_DESCRIPCION varchar(255),
	ESP_TIPOESP_CODIGO numeric (18, 0) FOREIGN KEY REFERENCES ClinicaTurbia.TipoEspecialidad(TIPOESP_CODIGO) NOT NULL
);

GO

--------------------------------------------------------
---------------    MIGRACION DE DATOS    ---------------
--------------------------------------------------------
CREATE PROCEDURE ClinicaTurbia.MIGRACION AS

INSERT INTO ClinicaTurbia.Rol(ROL_NOMBRE, ROL_HABILITADO) VALUES
	('Administrativo', 1), ('Afiliado', 1), ('Profesional', 1);
	
INSERT INTO ClinicaTurbia.Funcionalidad(FUN_NOMBRE) VALUES
	('ABM de Roles'), ('ABM de Afiliado'), ('ABM de Especialidad'), ('Funcionalidad4'), ('Funcionalidad5');

INSERT INTO ClinicaTurbia.Rol_Funcionalidad(ROL_ID, FUN_ID) VALUES
	(1,1), (2,1), (3,1), (1,2), (2,2), (3,2), (1,3), (2,3), (3,3), (2,5), (3,4);

INSERT INTO ClinicaTurbia.TipoDocumento(TIDOC_NOMBRE) VALUES
	('Documento Nacional de Identidad'), ('Cédula de Identidad'),
	('Libreta de Enrolamiento'), ('Libreta Cívica');
	
INSERT INTO ClinicaTurbia.EstadoCivil(ECIVIL_NOMBRE) VALUES
	('Soltero/a'), ('Casado/a'), ('Viudo/a'), ('Concubinato'), ('Divorciado/a');
	
INSERT INTO ClinicaTurbia.TipoEspecialidad(TIPOESP_CODIGO, TIPOESP_DESCRIPCION)
	SELECT DISTINCT m.Tipo_Especialidad_Codigo, m.Tipo_Especialidad_Descripcion
	FROM gd_esquema.Maestra m WHERE m.Tipo_Especialidad_Codigo IS NOT NULL;
	
INSERT INTO ClinicaTurbia.Especialidad(ESP_CODIGO, ESP_DESCRIPCION, ESP_TIPOESP_CODIGO)
	SELECT DISTINCT m.Especialidad_Codigo, m.Especialidad_Descripcion, m.Tipo_Especialidad_Codigo 
	FROM gd_esquema.Maestra m WHERE m.Especialidad_Codigo IS NOT NULL;


INSERT INTO ClinicaTurbia.PlanMedico(PLAN_CODIGO, PLAN_DESCRIPCION,
	PLAN_PRECIO_BONO_CONSULTA, PLAN_PRECIO_BONO_FARMACIA)
	SELECT DISTINCT
		m.Plan_Med_Codigo,
		m.Plan_Med_Descripcion,
		m.Plan_Med_Precio_Bono_Consulta,
		m.Plan_Med_Precio_Bono_Farmacia
	FROM gd_esquema.Maestra m;

INSERT INTO ClinicaTurbia.Paciente(PAC_NUMDOC, PAC_NOMBRE, PAC_APELLIDO, PAC_DIRECCION,
	PAC_TELEFONO, PAC_MAIL, PAC_FECHA_NACIMIENTO, PAC_PLAN_MEDICO_CODIGO)
	SELECT DISTINCT
		m.Paciente_Dni,
		m.Paciente_Nombre,
		m.Paciente_Apellido,
		m.Paciente_Direccion,
		m.Paciente_Telefono,
		m.Paciente_Mail,
		m.Paciente_Fecha_Nac,
		M.Plan_Med_Codigo
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

INSERT INTO ClinicaTurbia.Usuario(USUARIO_NOMBRE, USUARIO_PASSWORD, USUARIO_HABILITADO, USUARIO_PRIMER_LOGIN)
	SELECT PAC_NUMDOC, 1234, 1, 1 FROM ClinicaTurbia.Paciente
	UNION
	SELECT MED_DNI, 1234, 1, 1 FROM ClinicaTurbia.Medico;
	
INSERT INTO ClinicaTurbia.Usuario(USUARIO_NOMBRE, USUARIO_PASSWORD, USUARIO_HABILITADO, USUARIO_PRIMER_LOGIN)
	VALUES ('admin', 'w23e', 1, 0);

INSERT INTO ClinicaTurbia.Usuario_Rol(USUARIO_NOMBRE, ROL_ID)
	SELECT PAC_NUMDOC, 2 FROM ClinicaTurbia.Paciente
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

CREATE PROCEDURE ClinicaTurbia.CONSULTA_ROLES_POR_USUARIO
	(@usuario nvarchar(255)) AS
	SELECT R.ROL_NOMBRE FROM ClinicaTurbia.Rol R, ClinicaTurbia.Usuario_Rol UR
	WHERE UR.USUARIO_NOMBRE = @usuario AND R.ROL_ID = UR.ROL_ID
GO

CREATE PROCEDURE ClinicaTurbia.CONSULTA_FUNCIONALIDADES_POR_ROL
	(@rol nvarchar(255)) AS
	SELECT F.FUN_NOMBRE FROM ClinicaTurbia.Rol R, ClinicaTurbia.Rol_Funcionalidad RF,
	ClinicaTurbia.Funcionalidad F WHERE 
	R.ROL_NOMBRE = @rol AND RF.ROL_ID = R.ROL_ID AND F.FUN_ID = RF.FUN_ID
GO

CREATE PROCEDURE ClinicaTurbia.LISTADO_FUNCIONALIDADES AS
	SELECT * FROM ClinicaTurbia.Funcionalidad
GO

CREATE PROCEDURE ClinicaTurbia.LISTADO_ROLES AS
	SELECT * FROM ClinicaTurbia.Rol
GO

CREATE PROCEDURE ClinicaTurbia.LISTADO_PLAN_MEDICO AS
	SELECT PLAN_CODIGO, PLAN_DESCRIPCION FROM ClinicaTurbia.PlanMedico
GO

CREATE PROCEDURE ClinicaTurbia.LISTADO_ESPECIALIDAD AS
	SELECT ESP_DESCRIPCION, TIPOESP_DESCRIPCION FROM ClinicaTurbia.Especialidad,
	ClinicaTurbia.TipoEspecialidad WHERE ESP_TIPOESP_CODIGO = TIPOESP_CODIGO
GO

CREATE PROCEDURE ClinicaTurbia.LISTADO_TIPO_DOCUMENTO AS
	SELECT * FROM ClinicaTurbia.TipoDocumento
GO

CREATE PROCEDURE ClinicaTurbia.LISTADO_ESTADO_CIVIL AS
	SELECT * FROM ClinicaTurbia.EstadoCivil
GO

CREATE PROCEDURE ClinicaTurbia.NUEVO_ROL
	(@nombre nvarchar(255), @habilitado bit) AS
	INSERT INTO ClinicaTurbia.Rol(ROL_NOMBRE, ROL_HABILITADO) OUTPUT Inserted.ROL_ID VALUES (@nombre, @habilitado)
GO

CREATE PROCEDURE ClinicaTurbia.MODIFICAR_ROL 
	(@nombre nvarchar(255), @habilitado bit, @id int) AS
	UPDATE ClinicaTurbia.Rol SET ROL_NOMBRE=@nombre, ROL_HABILITADO=@habilitado
		WHERE ROL_ID = @id;
GO

CREATE PROCEDURE ClinicaTurbia.MODIFICAR_FUNCIONES_ROL
	(@idRol int,@idFunc int, @agregar bit) AS
	BEGIN
	IF @agregar = 1
		BEGIN
		INSERT INTO ClinicaTurbia.Rol_Funcionalidad(ROL_ID, FUN_ID) VALUES (@idRol, @idFunc);
		END
	ELSE
		BEGIN
		DELETE FROM ClinicaTurbia.Rol_Funcionalidad WHERE ROL_ID = @idRol AND FUN_ID = @idFunc;
		END
	END	
GO

CREATE PROCEDURE ClinicaTurbia.EXISTE_AFILIADO 
	(@dni nvarchar(255)) AS
	SELECT PAC_NOMBRE, PAC_APELLIDO, PAC_TIPO_DOCUMENTO, PAC_NUMDOC, PAC_SEXO, PAC_FECHA_NACIMIENTO, 
		PAC_ESTADO_CIVIL, PAC_DIRECCION, PAC_TELEFONO, PAC_MAIL, PAC_CANT_HIJOS, PLAN_DESCRIPCION
	FROM ClinicaTurbia.Paciente, ClinicaTurbia.PlanMedico
	WHERE PAC_NUMDOC = @dni AND PAC_PLAN_MEDICO_CODIGO = PLAN_CODIGO
GO

CREATE PROCEDURE ClinicaTurbia.MODIFICAR_AFILIADO
	(@tiDoc int = NULL, @dire nvarchar(255) = NULL, @tel nvarchar(255) = NULL,
	@mail nvarchar(255) = NULL,	@sexo char = NULL, @estCivil int = NULL, @planMed int,
	@cantFam int = NULL, @numDoc nvarchar(255)) AS
	UPDATE ClinicaTurbia.Paciente SET PAC_TIPO_DOCUMENTO=@tiDoc, PAC_SEXO=@sexo,
		PAC_ESTADO_CIVIL=@estCivil, PAC_DIRECCION=@dire, PAC_TELEFONO=@tel,
		PAC_MAIL=@mail, PAC_CANT_HIJOS=@cantFam, PAC_PLAN_MEDICO_CODIGO=@planMed
		WHERE PAC_NUMDOC=@numDoc;
GO

CREATE PROCEDURE ClinicaTurbia.CREAR_AFILIADO
	(@nom nvarchar(255), @ape nvarchar(255), @fecha datetime, @tiDoc int = NULL,
		@dire nvarchar(255) = NULL, @tel nvarchar(255) = NULL,
		@mail nvarchar(255) = NULL, @sexo char = NULL, @estCivil int = NULL,
		@planMed int, @cantFam int = NULL, @numDoc nvarchar(255)) AS
	INSERT INTO ClinicaTurbia.Paciente(PAC_NOMBRE, PAC_APELLIDO, PAC_TIPO_DOCUMENTO,
		PAC_NUMDOC, PAC_SEXO, PAC_FECHA_NACIMIENTO, PAC_ESTADO_CIVIL, PAC_DIRECCION,
		PAC_TELEFONO, PAC_MAIL, PAC_CANT_HIJOS, PAC_PLAN_MEDICO_CODIGO) VALUES
		(@nom, @ape, @tiDoc, @numDoc, @sexo, @fecha, @estCivil, @dire, @tel,
		@mail, @cantFam, @planMed)
GO

CREATE PROCEDURE ClinicaTurbia.PRIMER_LOGIN_USUARIO (@numDoc nvarchar(255)) AS
	UPDATE ClinicaTurbia.Usuario SET USUARIO_PRIMER_LOGIN=0 WHERE USUARIO_NOMBRE=@numDoc;
GO
 
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
------------------------------------------CARGAR------------------------------------
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------

EXEC ClinicaTurbia.CREARTABLAS
EXEC ClinicaTurbia.MIGRACION