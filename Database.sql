Create database InteliWeb;

use InteliWeb;

Create table RolUsuarios(										/*	Aqui van los roles de cada usuario	*/
	idRolUsuario int NOT NULL IDENTITY PRIMARY KEY,
	RolUsuario varchar(20) NOT NULL
);

Create table Usuarios(											/*	Aqui por obviedad van los usuarios del sistema	*/
	idUsuario int NOT NULL IDENTITY PRIMARY KEY,
	nombreUsuario varchar(50) NOT NULL,
	apPatUsuario varchar(50) NOT NULL,
	apMatUsuario varchar(50) NOT NULL,
	correUsuario varchar(100) NOT NULL,
	telefonoUsuario varchar(10) NOT NULL,
	idRolUsuario int NOT NULL,
	CONSTRAINT fk_RolUsuarios_Usuarios FOREIGN KEY (idRolUsuario) REFERENCES RolUsuarios(idRolUsuario)
);

Create table TipoArchivos(										/*	Aqui va el tipo de archivo que se esta subiendo para tener un conocimiento de que se esta subiendo	*/
	idTipoArchivo int NOT NULL IDENTITY PRIMARY KEY,
	tipoArchivo	varchar(30) NOT NULL
);

Create table Archivos(											/*	Aqui van los archivos que se vayan a subir en las publicaciones o incluso manuales de uso (IMAGENES, VIDEO, PDF's, XML) lo que sea hasta 2GB	*/
	idArchivo int NOT NULL IDENTITY PRIMARY KEY,
	contenidoArchivo varbinary(max) NOT NULL,
	fechaArchivo date NOT NULL,
	idTipoArchivo int NOT NULL,
	idUsuario int NOT NULL,
	CONSTRAINT fk_TipoArchivos_Archivos FOREIGN KEY (idTipoArchivo) REFERENCES TipoArchivos(idTipoArchivo),
	CONSTRAINT fk_Usuarios_Archivos	FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

Create table TextoPosts(										/*	Aqui va el texto que se vaya a poner en una publicacion		*/
	idTextoPost int NOT NULL IDENTITY PRIMARY KEY,
	contenidoTextoPost text NOT NULL,
	fechaTextoPost datetime NOT NULL,
	idUsuario int NOT NULL,
	CONSTRAINT fk_Usuarios_TextoPosts FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

Create table TipoServicios(										/*	AQui va el tipo de servicio que se ofrece, SOFTWARE, SOPORTE, PRODUCTOS, CAPACITACION, etc.	*/
	idTipoServicio int NOT NULL IDENTITY PRIMARY KEY,
	TipoServicio varchar(50) NOT NULL
);

Create table EstadoServicios(									/*	Aqui se pondra si esta ACTIVO o INACTIVO, al igual que podria ser PENDIENTE todo depende si lo pago el cliente o no		*/
	idEstadoServicio int NOT NULL IDENTITY PRIMARY KEY,
	EstadoServicio varchar(20) NOT NULL
);

Create table Servicios(											/*	Aqui van los Servicios que se ofrecen, como INTELISOFT, INTELIPOST, INTELICLOUD, recopila el tipo de servicio y el estado de este par asignarselo a los usuarios clientes	*/
	idServicio int NOT NULL IDENTITY PRIMARY KEY,
	NombreServicio varchar(100) NOT NULL,
	precioServicio int NOT NULL,
	idTipoServicio int NOT NULL,
	CONSTRAINT fk_TipoServicios_Servicios FOREIGN KEY (idTipoServicio) REFERENCES TipoServicios(idTipoServicio),
);

Create table Contrataciones(
	idContratacione int NOT NULL IDENTITY PRIMARY KEY,
	fechaInicialContratacion date NOT NULL,
	fechaFinalContratacion date NOT NULL,
	idUsuario int NOT NULL,
	idServicio int NOT NULL,
	idEstadoServicio int NOT NULL,
	CONSTRAINT fk_Usuarios_Contrataciones FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
	CONSTRAINT fk_Servicios_Contrataciones FOREIGN KEY (idServicio) REFERENCES Servicios(idServicio),
	CONSTRAINT fk_EstadoServicios_Contrataciones FOREIGN KEY (idEstadoServicio) REFERENCES EstadoServicios(idEstadoServicio)
);

/* Scaffold-DbContext "Server=DESKTOP-HEQPAUL\MSSQLSERVER01; DataBase=InteliWeb;Integrated Security=true; Encrypt=false;" Microsoft.EntityFrameworkCore.SqlServer
*/
