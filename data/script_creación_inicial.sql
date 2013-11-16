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

IF OBJECT_ID('ClinicaTurbia.Medico_Especialidad', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Medico_Especialidad
GO

IF OBJECT_ID('ClinicaTurbia.Diagnostico', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Diagnostico
GO

IF OBJECT_ID('ClinicaTurbia.Turno', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Turno
GO

IF OBJECT_ID('ClinicaTurbia.Paciente', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Paciente
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

IF OBJECT_ID('ClinicaTurbia.Profesional_Dia_Horario', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Profesional_Dia_Horario
GO

IF OBJECT_ID('ClinicaTurbia.Medico', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Medico
GO

IF OBJECT_ID('ClinicaTurbia.Horario', 'U') IS NOT NULL
	DROP TABLE ClinicaTurbia.Horario
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

IF OBJECT_ID('ClinicaTurbia.INHABILITAR_ROL', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.INHABILITAR_ROL
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

IF OBJECT_ID('ClinicaTurbia.LISTADO_PACIENTES', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.LISTADO_PACIENTES
GO

IF OBJECT_ID('ClinicaTurbia.NUEVO_ROL', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.NUEVO_ROL
GO

IF OBJECT_ID('ClinicaTurbia.ELIMINAR_ROL', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.ELIMINAR_ROL
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

IF OBJECT_ID('ClinicaTurbia.CARGAR_HORARIOS_PROFESIONALES', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CARGAR_HORARIOS_PROFESIONALES
GO

IF OBJECT_ID('ClinicaTurbia.MODIFICAR_MEDICO','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.MODIFICAR_MEDICO
GO

IF OBJECT_ID('ClinicaTurbia.MIGRACION', 'P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.MIGRACION
GO

IF OBJECT_ID('ClinicaTurbia.CREAR_TURNO','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.CREAR_TURNO
GO

IF OBJECT_ID('ClinicaTurbia.TRAER_TODOS_MEDICOS','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.TRAER_TODOS_MEDICOS
GO

IF OBJECT_ID('ClinicaTurbia.TRAER_HORARIOS_MEDICO','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.TRAER_HORARIOS_MEDICO
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_ESPECIALIDAD','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_ESPECIALIDAD
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_NOMBRE','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_NOMBRE
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_POR_NOMBRE_MEDICO','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_POR_NOMBRE_MEDICO
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_DNI','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_DNI
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_DIRECCION','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_DIRECCION
GO

IF OBJECT_ID('ClinicaTurbia.DESHABILITAR_USUARIO','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.DESHABILITAR_USUARIO
GO

IF OBJECT_ID('ClinicaTurbia.AGREGAR_MEDICO','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.AGREGAR_MEDICO
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_APELLIDO','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_APELLIDO
GO

IF OBJECT_ID('ClinicaTurbia.BORRAR_MEDICO','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.BORRAR_MEDICO
GO

IF OBJECT_ID('ClinicaTurbia.TRAER_TURNOS_DE_MEDICO_PARA_FECHA','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.TRAER_TURNOS_DE_MEDICO_PARA_FECHA
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_APELLIDO_PACIENTES','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_APELLIDO_PACIENTES
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_DNI_PACIENTES','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_DNI_PACIENTES
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_NOMBRE_PACIENTES','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_NOMBRE_PACIENTES
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_X_DIRECCION_PACIENTES','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_X_DIRECCION_PACIENTES
GO

IF OBJECT_ID('ClinicaTurbia.FILTRAR_POR_PALABRACLAVE_PACIENTE','P') IS NOT NULL
	DROP PROCEDURE ClinicaTurbia.FILTRAR_POR_PALABRACLAVE_PACIENTE
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
	ROL_HABILITADO [bit] NOT NULL,
	ELIMINADO [bit]
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
	PAC_NUMERO_AFILIADO [int] NOT NULL IDENTITY(1, 100)
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
	TIPOESP_CODIGO [numeric] (18, 0) NOT NULL PRIMARY KEY, 
	TIPOESP_DESCRIPCION [varchar] (255)
);

CREATE TABLE ClinicaTurbia.Especialidad(
	ESP_CODIGO [numeric] (18, 0) NOT NULL PRIMARY KEY, 
	ESP_DESCRIPCION [varchar] (255),
	ESP_TIPOESP_CODIGO [numeric] (18, 0) FOREIGN KEY REFERENCES ClinicaTurbia.TipoEspecialidad(TIPOESP_CODIGO) NOT NULL
);

CREATE TABLE ClinicaTurbia.Horario(
	HOR_COD [int] PRIMARY KEY NOT NULL IDENTITY,
	HOR_NOMBRE [varchar] (255) NOT NULL,
	HOR_HORA_DESDE [varchar] (10) NOT NULL,
	HOR_HORA_HASTA [varchar] (10) NOT NULL
);

CREATE TABLE ClinicaTurbia.Profesional_Dia_Horario(
	PDH_PROF_COD [numeric] (18,0) NOT NULL FOREIGN KEY REFERENCES ClinicaTurbia.Medico(MED_DNI),
	PDH_HORARIO_COD [int] NOT NULL FOREIGN KEY REFERENCES ClinicaTurbia.Horario(HOR_COD),
	PDH_DIA [int] NOT NULL
);

CREATE TABLE ClinicaTurbia.Turno(
	TURN_NUMERO [numeric] (18,0) PRIMARY KEY IDENTITY,
	TURN_FECHA [datetime] NOT NULL,
	TURN_PROF_COD [numeric] (18,0) NOT NULL FOREIGN KEY REFERENCES ClinicaTurbia.Medico(MED_DNI),
	TURN_PAC_COD [numeric] (18,0) NOT NULL FOREIGN KEY REFERENCES ClinicaTurbia.Paciente(PAC_NUMDOC)
);

CREATE TABLE ClinicaTurbia.Diagnostico(
	DIAG_COD [numeric] (18,0) PRIMARY KEY IDENTITY,
	DIAG_TURN_NUMERO [numeric] (18,0) FOREIGN KEY REFERENCES ClinicaTurbia.Turno(TURN_NUMERO),
	DIAG_CONSULTA_SINTOMAS [varchar] (255),
	DIAG_CONSULTA_ENFERMEDADES [varchar] (255),
	DIAG_BONO_CONSULTA [numeric] (18,0),
	DIAG_BONO_FARMACIA [numeric] (18,0),
);

CREATE TABLE ClinicaTurbia.Medico_Especialidad(
	MEDESP_MED [numeric] (18,0) NOT NULL FOREIGN KEY REFERENCES ClinicaTurbia.Medico(MED_DNI),
	MEDESP_ESP [numeric] (18, 0) FOREIGN KEY REFERENCES ClinicaTurbia.Especialidad(ESP_CODIGO) NOT NULL
);

GO

--------------------------------------------------------
---------------    MIGRACION DE DATOS    ---------------
--------------------------------------------------------
CREATE PROCEDURE ClinicaTurbia.MIGRACION AS

INSERT INTO ClinicaTurbia.Rol(ROL_NOMBRE, ROL_HABILITADO) VALUES
	('Administrativo', 1), ('Afiliado', 1);
	
INSERT INTO ClinicaTurbia.Funcionalidad(FUN_NOMBRE) VALUES
	('ABM de Roles'), ('ABM de Afiliado'), ('ABM de Especialidad'), ('ABM de Profesional'),
	('Pedir Turno');

INSERT INTO ClinicaTurbia.Rol_Funcionalidad(ROL_ID, FUN_ID) VALUES
	(1,1), (2,1), (1,2), (2,2), (1,3), (2,3), (1,4), (2,4), (2,5);

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
	SELECT PAC_NUMDOC, '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 1, 1 FROM ClinicaTurbia.Paciente;
	
INSERT INTO ClinicaTurbia.Usuario(USUARIO_NOMBRE, USUARIO_PASSWORD, USUARIO_HABILITADO, USUARIO_PRIMER_LOGIN)
	VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 1, 0);

INSERT INTO ClinicaTurbia.Usuario_Rol(USUARIO_NOMBRE, ROL_ID)
	SELECT PAC_NUMDOC, 2 FROM ClinicaTurbia.Paciente;
	
INSERT INTO ClinicaTurbia.Usuario_Rol(USUARIO_NOMBRE, ROL_ID)
	VALUES ('admin', 1); 

INSERT INTO ClinicaTurbia.Horario(HOR_NOMBRE, HOR_HORA_DESDE, HOR_HORA_HASTA)
	VALUES ('Mañana', '07:00', '14:00'), ('Tarde', '13:00', '20:00'),
	('Part-Time Mañana', '08:00', '11:00'), ('Part-Time Tarde', '15:00', '18:00'),
	('Sabado Tarde', '11:00', '15:00'), ('Sabado Mañana', '08:00', '12:00');

SET IDENTITY_INSERT ClinicaTurbia.Turno ON;
INSERT INTO ClinicaTurbia.Turno(TURN_NUMERO, TURN_FECHA, TURN_PROF_COD, TURN_PAC_COD)
	SELECT DISTINCT Turno_Numero, Turno_Fecha, Medico_Dni, Paciente_Dni FROM GD2C2013.gd_esquema.Maestra
			WHERE DATEPART(DW, Turno_Fecha) != 7;
SET IDENTITY_INSERT ClinicaTurbia.Turno OFF;

INSERT INTO ClinicaTurbia.Diagnostico(DIAG_TURN_NUMERO, DIAG_CONSULTA_SINTOMAS, DIAG_CONSULTA_ENFERMEDADES,
		DIAG_BONO_CONSULTA, DIAG_BONO_FARMACIA)
	SELECT Turno_Numero, Consulta_Sintomas, Consulta_Enfermedades, Bono_Consulta_Numero, Bono_Farmacia_Numero
		FROM gd_esquema.Maestra 
		WHERE Consulta_Sintomas IS NOT NULL AND DATEPART(DW, Turno_Fecha) != 7
		ORDER BY Turno_Numero;
		
INSERT INTO ClinicaTurbia.Medico_Especialidad 
	SELECT Medico_Dni, Especialidad_Codigo FROM GD2C2013.gd_esquema.Maestra
	WHERE Medico_Dni IS NOT NULL
	GROUP BY Medico_Dni, Especialidad_Codigo
	ORDER BY Medico_Dni;

GO

CREATE PROCEDURE ClinicaTurbia.CARGAR_HORARIOS_PROFESIONALES AS	
	DECLARE @medDoc numeric (18, 0);
	DECLARE cursorProfs CURSOR FOR SELECT MED_DNI FROM ClinicaTurbia.Medico;
	OPEN cursorProfs;
	FETCH cursorProfs INTO @medDoc;
	WHILE @@FETCH_STATUS = 0
	BEGIN;
		INSERT INTO ClinicaTurbia.Profesional_Dia_Horario(PDH_PROF_COD, PDH_HORARIO_COD, PDH_DIA)
			VALUES (@medDoc, ROUND(RAND()*4+1, 0, 1), 1), (@medDoc, ROUND(RAND()*4+1, 0, 1), 2),
			(@medDoc, ROUND(RAND()*4+1, 0, 1), 3), (@medDoc, ROUND(RAND()*4+1, 0, 1), 4),
			(@medDoc, ROUND(RAND()*4+1, 0, 1), 5), (@medDoc, ROUND(RAND()*2+5, 0, 1), 6);
		FETCH NEXT FROM cursorProfs INTO @medDoc;
	END;
	CLOSE cursorProfs;
	DEALLOCATE cursorProfs;

GO

CREATE PROCEDURE ClinicaTurbia.INHABILITAR_ROL (@id numeric(18,0)) AS
	DELETE FROM ClinicaTurbia.Usuario_Rol WHERE ROL_ID=@id;
GO
	

--------------------------------------------------------
---------------- CONSULTA_PACIENTE  --------------------
--------------------------------------------------------

CREATE PROCEDURE ClinicaTurbia.LISTADO_PACIENTES AS
	SELECT DISTINCT PAC_NOMBRE AS 'Nombre', PAC_APELLIDO AS 'Apellido', CASE WHEN PAC_TIPO_DOCUMENTO IS NULL THEN 
		NULL ELSE TIDOC_NOMBRE END AS 'Tipo Documento', PAC_NUMDOC AS 'Documento', PAC_SEXO AS 'Sexo',
		PAC_FECHA_NACIMIENTO AS 'Fecha Nacimiento',	CASE WHEN PAC_ESTADO_CIVIL IS NULL THEN NULL ELSE
		ECIVIL_NOMBRE END AS 'Estado Civil', PAC_DIRECCION AS 'Direccion', PAC_TELEFONO AS 'Telefono',
		PAC_MAIL AS 'Mail', PAC_CANT_HIJOS AS 'Familiares a cargo', PLAN_DESCRIPCION AS 'Plan Medico',
		PAC_NUMERO_AFILIADO AS 'Numero Afiliado'
	FROM ClinicaTurbia.Paciente, ClinicaTurbia.PlanMedico, ClinicaTurbia.TipoDocumento, ClinicaTurbia.EstadoCivil 
	WHERE PAC_PLAN_MEDICO_CODIGO=PLAN_CODIGO
	AND (PAC_TIPO_DOCUMENTO=TIDOC_ID OR PAC_TIPO_DOCUMENTO IS NULL)
	AND (PAC_ESTADO_CIVIL=ECIVIL_ID OR PAC_ESTADO_CIVIL IS NULL)
	ORDER BY 'Apellido', 'Nombre'
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_POR_PALABRACLAVE_PACIENTE
	(@nombreParcial nvarchar(255)) 
	AS
	SELECT DISTINCT PAC_NOMBRE AS 'Nombre', PAC_APELLIDO AS 'Apellido', CASE WHEN PAC_TIPO_DOCUMENTO IS NULL THEN 
		NULL ELSE TIDOC_NOMBRE END AS 'Tipo Documento', PAC_NUMDOC AS 'Documento', PAC_SEXO AS 'Sexo',
		PAC_FECHA_NACIMIENTO AS 'Fecha Nacimiento',	CASE WHEN PAC_ESTADO_CIVIL IS NULL THEN NULL ELSE
		ECIVIL_NOMBRE END AS 'Estado Civil', PAC_DIRECCION AS 'Direccion', PAC_TELEFONO AS 'Telefono',
		PAC_MAIL AS 'Mail', PAC_CANT_HIJOS AS 'Familiares a cargo', PLAN_DESCRIPCION AS 'Plan Medico',
		PAC_NUMERO_AFILIADO AS 'Numero Afiliado'
	FROM ClinicaTurbia.Paciente, ClinicaTurbia.PlanMedico, ClinicaTurbia.TipoDocumento, ClinicaTurbia.EstadoCivil 
	WHERE (PAC_NOMBRE like @nombreParcial+'%' OR 
		  PAC_APELLIDO like @nombreParcial+'%' OR
		  PAC_NUMDOC like @nombreParcial+'%' OR
		  PAC_TELEFONO like @nombreParcial+'%' OR
		  PAC_DIRECCION like @nombreParcial+'%' OR
		  PAC_MAIL like @nombreParcial+'%' OR
		  PAC_FECHA_NACIMIENTO like @nombreParcial+'%')
	AND PAC_PLAN_MEDICO_CODIGO=PLAN_CODIGO
	AND (PAC_TIPO_DOCUMENTO=TIDOC_ID OR PAC_TIPO_DOCUMENTO IS NULL)
	AND (PAC_ESTADO_CIVIL=ECIVIL_ID OR PAC_ESTADO_CIVIL IS NULL)
	ORDER BY 'Apellido', 'Nombre'
	
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_DIRECCION_PACIENTES
	(@direccion nvarchar(255))
	AS
	SELECT DISTINCT PAC_NOMBRE AS 'Nombre', PAC_APELLIDO AS 'Apellido', CASE WHEN PAC_TIPO_DOCUMENTO IS NULL THEN 
		NULL ELSE TIDOC_NOMBRE END AS 'Tipo Documento', PAC_NUMDOC AS 'Documento', PAC_SEXO AS 'Sexo',
		PAC_FECHA_NACIMIENTO AS 'Fecha Nacimiento',	CASE WHEN PAC_ESTADO_CIVIL IS NULL THEN NULL ELSE
		ECIVIL_NOMBRE END AS 'Estado Civil', PAC_DIRECCION AS 'Direccion', PAC_TELEFONO AS 'Telefono',
		PAC_MAIL AS 'Mail', PAC_CANT_HIJOS AS 'Familiares a cargo', PLAN_DESCRIPCION AS 'Plan Medico',
		PAC_NUMERO_AFILIADO AS 'Numero Afiliado'
	FROM ClinicaTurbia.Paciente, ClinicaTurbia.PlanMedico, ClinicaTurbia.TipoDocumento, ClinicaTurbia.EstadoCivil 
	WHERE PAC_DIRECCION like @direccion+'%'
	AND PAC_PLAN_MEDICO_CODIGO=PLAN_CODIGO
	AND (PAC_TIPO_DOCUMENTO=TIDOC_ID OR PAC_TIPO_DOCUMENTO IS NULL)
	AND (PAC_ESTADO_CIVIL=ECIVIL_ID OR PAC_ESTADO_CIVIL IS NULL)
	ORDER BY 'Apellido', 'Nombre'
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_NOMBRE_PACIENTES
	(@nombre nvarchar(255))
	AS
	SELECT DISTINCT PAC_NOMBRE AS 'Nombre', PAC_APELLIDO AS 'Apellido', CASE WHEN PAC_TIPO_DOCUMENTO IS NULL THEN 
		NULL ELSE TIDOC_NOMBRE END AS 'Tipo Documento', PAC_NUMDOC AS 'Documento', PAC_SEXO AS 'Sexo',
		PAC_FECHA_NACIMIENTO AS 'Fecha Nacimiento',	CASE WHEN PAC_ESTADO_CIVIL IS NULL THEN NULL ELSE
		ECIVIL_NOMBRE END AS 'Estado Civil', PAC_DIRECCION AS 'Direccion', PAC_TELEFONO AS 'Telefono',
		PAC_MAIL AS 'Mail', PAC_CANT_HIJOS AS 'Familiares a cargo', PLAN_DESCRIPCION AS 'Plan Medico',
		PAC_NUMERO_AFILIADO AS 'Numero Afiliado'
	FROM ClinicaTurbia.Paciente, ClinicaTurbia.PlanMedico, ClinicaTurbia.TipoDocumento, ClinicaTurbia.EstadoCivil 
	WHERE PAC_NOMBRE like @nombre+'%'
	AND PAC_PLAN_MEDICO_CODIGO=PLAN_CODIGO
	AND (PAC_TIPO_DOCUMENTO=TIDOC_ID OR PAC_TIPO_DOCUMENTO IS NULL)
	AND (PAC_ESTADO_CIVIL=ECIVIL_ID OR PAC_ESTADO_CIVIL IS NULL)
	ORDER BY 'Apellido', 'Nombre'
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_DNI_PACIENTES
	(@dni nvarchar(255))
	AS
	SELECT DISTINCT PAC_NOMBRE AS 'Nombre', PAC_APELLIDO AS 'Apellido', CASE WHEN PAC_TIPO_DOCUMENTO IS NULL THEN 
		NULL ELSE TIDOC_NOMBRE END AS 'Tipo Documento', PAC_NUMDOC AS 'Documento', PAC_SEXO AS 'Sexo',
		PAC_FECHA_NACIMIENTO AS 'Fecha Nacimiento',	CASE WHEN PAC_ESTADO_CIVIL IS NULL THEN NULL ELSE
		ECIVIL_NOMBRE END AS 'Estado Civil', PAC_DIRECCION AS 'Direccion', PAC_TELEFONO AS 'Telefono',
		PAC_MAIL AS 'Mail', PAC_CANT_HIJOS AS 'Familiares a cargo', PLAN_DESCRIPCION AS 'Plan Medico',
		PAC_NUMERO_AFILIADO AS 'Numero Afiliado'
	FROM ClinicaTurbia.Paciente, ClinicaTurbia.PlanMedico, ClinicaTurbia.TipoDocumento, ClinicaTurbia.EstadoCivil 
	WHERE PAC_NUMDOC like @dni+'%'
	AND PAC_PLAN_MEDICO_CODIGO=PLAN_CODIGO
	AND (PAC_TIPO_DOCUMENTO=TIDOC_ID OR PAC_TIPO_DOCUMENTO IS NULL)
	AND (PAC_ESTADO_CIVIL=ECIVIL_ID OR PAC_ESTADO_CIVIL IS NULL)
	ORDER BY 'Apellido', 'Nombre'
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_APELLIDO_PACIENTES
	(@apellido nvarchar(255))
	AS
	SELECT DISTINCT PAC_NOMBRE AS 'Nombre', PAC_APELLIDO AS 'Apellido', CASE WHEN PAC_TIPO_DOCUMENTO IS NULL THEN 
		NULL ELSE TIDOC_NOMBRE END AS 'Tipo Documento', PAC_NUMDOC AS 'Documento', PAC_SEXO AS 'Sexo',
		PAC_FECHA_NACIMIENTO AS 'Fecha Nacimiento',	CASE WHEN PAC_ESTADO_CIVIL IS NULL THEN NULL ELSE
		ECIVIL_NOMBRE END AS 'Estado Civil', PAC_DIRECCION AS 'Direccion', PAC_TELEFONO AS 'Telefono',
		PAC_MAIL AS 'Mail', PAC_CANT_HIJOS AS 'Familiares a cargo', PLAN_DESCRIPCION AS 'Plan Medico',
		PAC_NUMERO_AFILIADO AS 'Numero Afiliado'
	FROM ClinicaTurbia.Paciente, ClinicaTurbia.PlanMedico, ClinicaTurbia.TipoDocumento, ClinicaTurbia.EstadoCivil 
	WHERE PAC_APELLIDO like @apellido+'%'
	AND PAC_PLAN_MEDICO_CODIGO=PLAN_CODIGO
	AND (PAC_TIPO_DOCUMENTO=TIDOC_ID OR PAC_TIPO_DOCUMENTO IS NULL)
	AND (PAC_ESTADO_CIVIL=ECIVIL_ID OR PAC_ESTADO_CIVIL IS NULL)
	ORDER BY 'Apellido', 'Nombre'
GO

--------------------------------------------------------
---------------- CONSULTA_MEDICOS  ---------------------
--------------------------------------------------------

CREATE PROCEDURE ClinicaTurbia.BORRAR_MEDICO
	(@dni int) AS
	DELETE FROM ClinicaTurbia.Medico 
	WHERE ClinicaTurbia.Medico.MED_DNI = @dni;
GO

CREATE PROCEDURE ClinicaTurbia.AGREGAR_MEDICO
	(@dni numeric,@nombre nvarchar(255),@apellido nvarchar(255),
	 @direccion nvarchar(255) = NULL, @telefono nvarchar(255) = NULL,
	 @mail nvarchar(255) = NULL, @fecha datetime) AS
	INSERT INTO ClinicaTurbia.Medico(MED_DNI,MED_NOMBRE,MED_APELLIDO,MED_DIRECCION,MED_TELEFONO,MED_MAIL,MED_FECHA_NACIMIENTO) 
	VALUES (@dni,@nombre,@apellido,@direccion,@telefono,@mail,@fecha);
		
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_DIRECCION
	(@direccion nvarchar(255))
	AS
	SELECT *
	FROM ClinicaTurbia.Medico as med
	WHERE med.MED_DIRECCION LIKE @direccion+'%';
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_ESPECIALIDAD
	(@esp numeric(18, 0)) AS
	SELECT MED_DNI, MED_NOMBRE, MED_APELLIDO FROM ClinicaTurbia.Medico_Especialidad, ClinicaTurbia.Medico
	WHERE MEDESP_ESP=@esp AND MED_DNI=MEDESP_MED;
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_NOMBRE
	(@nombre nvarchar(255))
	AS
	SELECT *
	FROM ClinicaTurbia.Medico as med
	where med.MED_NOMBRE LIKE @nombre+'%';
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_DNI
	(@dni nvarchar(255))
	AS
	SELECT *
	FROM ClinicaTurbia.Medico as med
	where med.MED_DNI LIKE @dni+'%';
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_X_APELLIDO
	(@apellido nvarchar(255))
	AS
	SELECT *
	FROM ClinicaTurbia.Medico as med
	where med.MED_APELLIDO LIKE @apellido+'%';
GO

CREATE PROCEDURE ClinicaTurbia.MODIFICAR_MEDICO
	(@dni numeric,@nombre nvarchar(255),@apellido nvarchar(255),
	 @direccion nvarchar(255) = NULL, @telefono nvarchar(255) = NULL,
	 @mail nvarchar(255) = NULL, @fecha datetime) AS
	UPDATE ClinicaTurbia.Medico SET 
		MED_DNI = @dni,MED_NOMBRE = @nombre,MED_APELLIDO = @apellido,
		MED_DIRECCION = @direccion,MED_TELEFONO = @telefono,MED_MAIL = @mail,
		MED_FECHA_NACIMIENTO = @fecha
		
		WHERE MED_DNI=@dni;
GO

CREATE PROCEDURE ClinicaTurbia.FILTRAR_POR_NOMBRE_MEDICO
	(@nombreParcial nvarchar(255)) 
	AS
	SELECT *  
	FROM ClinicaTurbia.Medico as m
	WHERE m.MED_NOMBRE like @nombreParcial+'%' OR 
		  m.MED_APELLIDO like @nombreParcial+'%' OR
		  m.MED_DNI like @nombreParcial+'%' OR
		  m.MED_TELEFONO like @nombreParcial+'%' OR
		  m.MED_DIRECCION like @nombreParcial+'%' OR
		  m.MED_MAIL like @nombreParcial+'%' OR
		  m.MED_FECHA_NACIMIENTO like @nombreParcial+'%'
GO

CREATE PROCEDURE ClinicaTurbia.TRAER_TODOS_MEDICOS
	AS
	SELECT * FROM ClinicaTurbia.Medico as medico
	WHERE medico.MED_DNI IS NOT NULL
	ORDER BY medico.MED_APELLIDO ASC;
GO

CREATE PROCEDURE ClinicaTurbia.TRAER_HORARIOS_MEDICO (@dni numeric(18,0), @dia int) AS
	SELECT HOR_HORA_DESDE, HOR_HORA_HASTA FROM ClinicaTurbia.Profesional_Dia_Horario, ClinicaTurbia.Horario
	WHERE PDH_PROF_COD=@dni AND PDH_DIA=@dia AND HOR_COD=PDH_HORARIO_COD;
GO

CREATE PROCEDURE ClinicaTurbia.TRAER_TURNOS_DE_MEDICO_PARA_FECHA
	(@dni numeric(18,0), @fecha datetime) AS
	SELECT TURN_FECHA FROM ClinicaTurbia.Turno 
	WHERE TURN_PROF_COD=@dni AND CAST(TURN_FECHA AS DATE)=CAST(@fecha AS DATE);
GO

CREATE PROCEDURE ClinicaTurbia.CREAR_TURNO (@med numeric(18,0), @pac numeric(18,0), @fecha datetime) AS
	INSERT INTO ClinicaTurbia.Turno(TURN_PROF_COD, TURN_FECHA, TURN_PAC_COD) 
		VALUES (@med, @fecha, @pac);
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

CREATE PROCEDURE ClinicaTurbia.DESHABILITAR_USUARIO
	(@usuario nvarchar(255)) AS
	UPDATE ClinicaTurbia.Usuario SET USUARIO_HABILITADO = 0
	WHERE USUARIO_NOMBRE = @usuario;
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
	SELECT * FROM ClinicaTurbia.Rol WHERE ELIMINADO IS NULL OR ELIMINADO!=1
GO

CREATE PROCEDURE ClinicaTurbia.LISTADO_PLAN_MEDICO AS
	SELECT PLAN_CODIGO, PLAN_DESCRIPCION FROM ClinicaTurbia.PlanMedico
GO

CREATE PROCEDURE ClinicaTurbia.LISTADO_ESPECIALIDAD AS
	SELECT ESP_CODIGO, ESP_DESCRIPCION, TIPOESP_DESCRIPCION FROM ClinicaTurbia.Especialidad,
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

CREATE PROCEDURE ClinicaTurbia.ELIMINAR_ROL 
	(@id int) AS
	UPDATE ClinicaTurbia.Rol SET ELIMINADO=1 WHERE ROL_ID=@id;
	DELETE FROM ClinicaTurbia.Usuario_Rol WHERE ROL_ID=@id;
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
EXEC ClinicaTurbia.CARGAR_HORARIOS_PROFESIONALES
