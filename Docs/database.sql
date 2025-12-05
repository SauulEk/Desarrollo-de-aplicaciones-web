CREATE DATABASE IF NOT EXISTS `docugen_db`;
USE `docugen_db`;

CREATE TABLE `Users` (
    `Id` INT AUTO_INCREMENT PRIMARY KEY,
    `Username` VARCHAR(255) NOT NULL,
    `Password` VARCHAR(255) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE `PdfTemplates` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `content` LONGTEXT NOT NULL -- LONGTEXT used for large HTML templates
) ENGINE=InnoDB;

CREATE TABLE `CvData` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `templateId` INT NOT NULL,
    `userId` INT NOT NULL,
    `Nombre` VARCHAR(255) NULL,
    `Ocupacion` VARCHAR(255) NULL,
    `Email` VARCHAR(255) NULL,
    `Telefono` VARCHAR(50) NULL,
    `Direccion` TEXT NULL,
    -- Foreign Keys
    CONSTRAINT `FK_CvData_PdfTemplates` FOREIGN KEY (`templateId`) REFERENCES `PdfTemplates`(`id`) ON DELETE CASCADE,
    CONSTRAINT `FK_CvData_Users` FOREIGN KEY (`userId`) REFERENCES `Users`(`Id`) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE `EducacionItems` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `CvDataId` INT NOT NULL,
    `Institucion` VARCHAR(255) NULL,
    `Fecha_Graduacion` VARCHAR(100) NULL,
    `Carrera` VARCHAR(255) NULL,
    CONSTRAINT `FK_EducacionItems_CvData` FOREIGN KEY (`CvDataId`) REFERENCES `CvData`(`id`) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE `TrabajoItems` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `CvDataId` INT NOT NULL,
    `Empresa` VARCHAR(255) NULL,
    `Fecha_Inicio` VARCHAR(100) NULL,
    `Fecha_Final` VARCHAR(100) NULL,
    `Puesto` VARCHAR(255) NULL,
    CONSTRAINT `FK_TrabajoItems_CvData` FOREIGN KEY (`CvDataId`) REFERENCES `CvData`(`id`) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE `HabilidadItems` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `CvDataId` INT NOT NULL,
    `Habilidad` VARCHAR(255) NULL,
    CONSTRAINT `FK_HabilidadItems_CvData` FOREIGN KEY (`CvDataId`) REFERENCES `CvData`(`id`) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE `InteresItems` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `CvDataId` INT NOT NULL,
    `Interes` VARCHAR(255) NULL,
    CONSTRAINT `FK_InteresItems_CvData` FOREIGN KEY (`CvDataId`) REFERENCES `CvData`(`id`) ON DELETE CASCADE
) ENGINE=InnoDB;
