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
CREATE SCHEMA [ClinicaTurbia] AUTHORIZATION [gd]
GO

CREATE PROCEDURE ClinicaTurbia.CREARTABLAS AS

CREATE TABLE ClinicaTurbia.Paciente(
	dni [numeric] (18,0) NOT NULL,
	nombre [nvarchar] (255) NOT NULL,
	apellido [nvarchar] (255) NOT NULL,
	direccion [nvarchar] (255) NULL,
	telefono [numeric](18, 0)  NULL,
	mail [nvarchar] (255) NULL,
	fecha_nac [datetime] NOT NULL,
	 
);

GO

CREATE PROCEDURE ClinicaTurbia.CREARPK AS

ALTER TABLE ClinicaTurbia.Paciente ADD

PRIMARY KEY (dni);
GO

CREATE PROCEDURE ClinicaTurbia.MIGRACION AS
--------------------------------------------------------
--------------------    PACIENTE    --------------------
--------------------------------------------------------
INSERT INTO ClinicaTurbia.Paciente(dni,nombre,apellido,direccion,telefono,mail,fecha_nac)

SELECT  
m.Paciente_Dni,
m.Medico_Nombre,
m.Paciente_Apellido,
m.Paciente_Direccion,
m.Medico_Telefono,
m.Paciente_Mail,
m.Paciente_Fecha_Nac

FROM gd_esquema.Maestra m
GO

------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
------------------------------------------CARGAR------------------------------------
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------

EXEC ClinicaTurbia.CREARTABLAS
EXEC ClinicaTurbia.CREARPK
EXEC ClinicaTurbia.MIGRACION