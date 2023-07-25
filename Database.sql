Create database InteliWeb;

use InteliWeb;

Create table RolUsuarios(										/*	Aqui van los roles de cada usuario	*/
	idRolUsuario int NOT NULL IDENTITY PRIMARY KEY,
	RolUsuario varchar(20) NOT NULL
);

Create table Usuarios(											/*	Aqui por obviedad van los usuarios del sistema	*/
	idUsuario int NOT NULL IDENTITY PRIMARY KEY,
	NombreUsuario varchar(50) NOT NULL,
	ApPatUsuario varchar(50) NOT NULL,
	ApMatUsuario varchar(50) NOT NULL,
	CorreUsuario varchar(100) NOT NULL,
	TelefonoUsuario varchar(10) NOT NULL,
	ContraUsuario varchar(20) NOT NULL,
	EmpresaUsuario varchar(50),
	idRolUsuario int NOT NULL,
	CONSTRAINT fk_RolUsuarios_Usuarios FOREIGN KEY (idRolUsuario) REFERENCES RolUsuarios(idRolUsuario)
);

Create table Contactos(
	idContacto int NOT NULL IDENTITY PRIMARY KEY,
	TelefonoContacto varchar(10),
	CorreoContacto varchar(100),
	UbicacionContacto varchar(100) NOT NULL,
	idUsuario int NOT NULL,
	CONSTRAINT fk_Usuarios_Contactos FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

Create table EstadoContrataciones(									/*	Aqui se pondra si esta ACTIVO o INACTIVO, al igual que podria ser PENDIENTE todo depende si lo pago el cliente o no		*/
	idEstadoContratacion int NOT NULL IDENTITY PRIMARY KEY,
	EstadoContratacion varchar(20) NOT NULL
);

Create table Contrataciones(
	idContratacion int NOT NULL IDENTITY PRIMARY KEY,
	FechaSolicitud date NOT NULL,
	FechaInicialContratacion date NOT NULL,
	FechaFinalContratacion date NOT NULL,
	MontoCotizacion varchar(20),
	MontoFinal varchar(20),
	Coomentarios text,
	idUsuario int NOT NULL,
	idServicio int NOT NULL,
	idEstadoContratacion int NOT NULL,
	CONSTRAINT fk_Usuarios_Contrataciones FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
	CONSTRAINT fk_Servicios_Contrataciones FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio),
	CONSTRAINT fk_EstadoContratacion_Contrataciones FOREIGN KEY (idEstadoContratacion) REFERENCES EstadoContrataciones(idEstadoContratacion)
);

Create table TipoReportes(
	idTipoReporte int NOT NULL IDENTITY PRIMARY KEY,
	TipoReporte varchar(30) NOT NULL,
);

Create table EstadoReportes(
	idEstadoReporte int NOT NULL IDENTITY PRIMARY KEY,
	EstadoReporte varchar(20) NOT NULL
);

Create table Reportes(
	idReporte int NOT NULL IDENTITY PRIMARY KEY,
	Reporte text NOT NULL,
	PruebaReporte varbinary(max),
	MimetypeReport varchar(30),
	NamePruebaReport varchar(30),
	PruebaSolucion varbinary(max) NOT NULL,
	MimetypeSoluct varchar(30) NOT NULL,
	NamePruebaSoluct varchar(30) NOT NULL,
	ComentariosSolucion text,
	FechaReporte datetime NOT NULL,
	idTipoReporte int NOT NULL,
	idUsuario int NOT NULL,
	idEstadoReporte int NOT NULL,
	idServicio int NOT NULL,
	CONSTRAINT fk_TipoReportes_Reportes FOREIGN KEY (idTipoReporte) REFERENCES TipoReportes(idTipoReporte),
	CONSTRAINT fk_Usuarios_Reportes FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
	CONSTRAINT fk_EstadoReportes_Reportes FOREIGN KEY (idEstadoReporte) REFERENCES EstadoReportes(idEstadoReporte),
	CONSTRAINT fk_Servicios_Reportes FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio)
);

Create table TipoArchivos(										/*	Aqui va el tipo de archivo que se esta subiendo para tener un conocimiento de que se esta subiendo	*/
	idTipoArchivo int NOT NULL IDENTITY PRIMARY KEY,
	TipoArchivo	varchar(30) NOT NULL
);

Create table Archivos(											/*	Aqui van los archivos que se vayan a subir en las publicaciones o incluso manuales de uso (IMAGENES, VIDEO, PDF's, XML) lo que sea hasta 2GB	*/
	idArchivo int NOT NULL IDENTITY PRIMARY KEY,
	ContenidoArchivo varbinary(max),
	MimeArchivo varchar(20) NOT NULL,
	NombreArchivo varchar(30) NOT NULL,
	FechaSubido datetime NOT NULL,
	idTipoArchivo int NOT NULL,
	idUsuario int NOT NULL,
	CONSTRAINT fk_TipoArchivos_Archivos FOREIGN KEY (idTipoArchivo) REFERENCES TipoArchivos(idTipoArchivo),
	CONSTRAINT fk_Usuarios_Archivos	FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

Create table TipoServicios(										/*	AQui va el tipo de servicio que se ofrece, SOFTWARE, SOPORTE, PRODUCTOS, CAPACITACION, etc.	*/
	idTipoServicio int NOT NULL IDENTITY PRIMARY KEY,
	TipoServicio varchar(50) NOT NULL
);

Create table Servicios(											/*	Aqui van los Servicios que se ofrecen, como INTELISOFT, INTELIPOST, INTELICLOUD, recopila el tipo de servicio y el estado de este par asignarselo a los usuarios clientes	*/
	idServicio int NOT NULL IDENTITY PRIMARY KEY,
	NombreServicio varchar(100) NOT NULL,
	PrecioServicio int NOT NULL,
	Ubicacion varchar(100),
	FechaRealizacion date,
	FechaTerminacion date,
	idUsuario int NOT NULL,
	idTipoServicio int NOT NULL,
	CONSTRAINT fk_Usuarios_Servicios FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
	CONSTRAINT fk_TipoServicios_Servicios FOREIGN KEY (idTipoServicio) REFERENCES TipoServicios(idTipoServicio)
);

Create table SeccionPublicaciones(
	idSeccionPublicacion int NOT NULL IDENTITY PRIMARY KEY,
	SeccionPublicacion varchar(20) NOT NULL
);

Create table TipoPublicaciones(
	idTipoPublicacion int NOT NULL IDENTITY PRIMARY KEY,
	TipoPublicacion varchar(20) NOT NULL
);

Create table Publicaciones(
	idPublicacion int NOT NULL IDENTITY PRIMARY KEY,
	FechaPublicacion datetime NOT NULL,
	TextoPublicado text NOT NULL,
	idArchivo int NOT NULL,
	idTipoPublicacion int NOT NULL,
	idSeccionPublicacion int NOT NULL,
	idUsuario int NOT NULL,
	idServicio int NOT NULL,
	CONSTRAINT fk_Archivos_Publicaciones FOREIGN KEY (idArchivo) REFERENCES Archivos(idArchivo),
	CONSTRAINT fk_TipoPublicaciones_Publicaciones FOREIGN KEY (idTipoPublicacion) REFERENCES TipoPublicaciones(idTipoPublicacion),
	CONSTRAINT fk_SeccionPublicaciones_Publicaciones FOREIGN KEY (idSeccionPublicacion) REFERENCES SeccionPublicaciones(idSeccionPublicacion),
	CONSTRAINT fk_Usuario_Publicaciones FOREIGN KEY (idUsuario)	REFERENCES Usuarios(idUsuario),
	CONSTRAINT fk_Servicio_Publicaciones FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio)
);


/* Scaffold-DbContext "Server=DESKTOP-HEQPAUL\MSSQLSERVER01; DataBase=InteliWeb;Integrated Security=true; Encrypt=false;" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir Models
*/
