Create database FJMA20241103DB

use FJMA20241103DB

CREATE TABLE Autos (
    idAuto INT Identity PRIMARY KEY,
    marca VARCHAR(50),
    modelo VARCHAR(50),
    anio INT
);

-- Crear la tabla ComponenteCarro
CREATE TABLE ComponenteCarro ( 
    idComponente INT Identity PRIMARY KEY,
	idAuto INT,
    nombre VARCHAR(50),
    descripcion VARCHAR(255),
	foreign key (idAuto) references Autos(idAuto)
);
