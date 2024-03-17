/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.7.9-log : Database - datoseppinvpro
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`datoseppinvpro` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `datoseppinvpro`;

/*Table structure for table `autorizacionepp` */

DROP TABLE IF EXISTS `autorizacionepp`;

CREATE TABLE `autorizacionepp` (
  `idautorizacion` int(11) NOT NULL AUTO_INCREMENT,
  `fechaautorizacion` datetime DEFAULT CURRENT_TIMESTAMP,
  `idusuario` int(11) DEFAULT NULL,
  `idfactura` int(11) DEFAULT NULL,
  `idempleado` int(11) DEFAULT NULL,
  `idproducto` int(11) DEFAULT NULL,
  `fechavence` varchar(20) DEFAULT NULL,
  `codigoautorizacion` int(20) DEFAULT NULL,
  `observacion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idautorizacion`),
  KEY `idempleado` (`idempleado`),
  KEY `idproducto` (`idproducto`),
  KEY `idfactura` (`idfactura`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `autorizacionepp` */

/*Table structure for table `detallesfacturas` */

DROP TABLE IF EXISTS `detallesfacturas`;

CREATE TABLE `detallesfacturas` (
  `iddetallesfactura` int(11) NOT NULL AUTO_INCREMENT,
  `idfactura` int(11) NOT NULL,
  `idempleado` int(11) DEFAULT NULL,
  `idproducto` int(11) NOT NULL,
  `nombreepp` varchar(250) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `precio` decimal(10,2) NOT NULL DEFAULT '0.00',
  `subtotal` decimal(10,2) NOT NULL DEFAULT '0.00',
  `tiempovida` int(11) NOT NULL,
  `fechavence` varchar(15) DEFAULT NULL,
  `codigoaprovacion` int(11) DEFAULT '0',
  PRIMARY KEY (`iddetallesfactura`),
  KEY `idfatura` (`idfactura`),
  KEY `idproducto` (`nombreepp`),
  CONSTRAINT `detallesfacturas_ibfk_1` FOREIGN KEY (`idfactura`) REFERENCES `facturas` (`idfactura`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `detallesfacturas` */

/*Table structure for table `facturas` */

DROP TABLE IF EXISTS `facturas`;

CREATE TABLE `facturas` (
  `idfactura` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `idusuario` int(11) NOT NULL,
  `idempleado` int(11) NOT NULL,
  `Cedula` varchar(15) DEFAULT NULL,
  `OracleID` varchar(20) DEFAULT NULL,
  `NombreEmpleado` varchar(100) DEFAULT NULL,
  `AreaTrabajo` varchar(100) DEFAULT NULL,
  `NombrePO` varchar(50) DEFAULT NULL,
  `codigoaprovacion` int(20) DEFAULT '0',
  `observacion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idfactura`),
  KEY `idusuario` (`idusuario`),
  KEY `idempleado` (`idempleado`),
  KEY `idPO` (`NombrePO`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `facturas` */

/*Table structure for table `fecha` */

DROP TABLE IF EXISTS `fecha`;

CREATE TABLE `fecha` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fechainicio` timestamp NULL DEFAULT NULL,
  `fechafinal` timestamp NULL DEFAULT NULL,
  `idfactura` int(11) DEFAULT NULL,
  `codigoautorizacion` int(11) DEFAULT NULL,
  `nombrecategoria` varchar(20) DEFAULT NULL,
  `marca` varchar(30) DEFAULT NULL,
  `idempleado` int(11) DEFAULT NULL,
  `nombrearea` varchar(30) DEFAULT NULL,
  `idarea` int(10) DEFAULT NULL,
  `cargo` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `fecha` */

insert  into `fecha`(`id`,`fechainicio`,`fechafinal`,`idfactura`,`codigoautorizacion`,`nombrecategoria`,`marca`,`idempleado`,`nombrearea`,`idarea`,`cargo`) values (1,'2020-06-01 00:00:00','2020-09-03 23:59:59',1,83817872,'CAMISA','EJEMPLO',2425,'PRINCIPAL',3,'MODERADOR');

/*Table structure for table `po` */

DROP TABLE IF EXISTS `po`;

CREATE TABLE `po` (
  `idPO` int(11) NOT NULL AUTO_INCREMENT,
  `NombrePO` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idPO`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `po` */

insert  into `po`(`idPO`,`NombrePO`) values (1,'PERSONA ADMINISTRACTIVA'),(3,'FALTA_CAMBIAR');

/*Table structure for table `principal` */

DROP TABLE IF EXISTS `principal`;

CREATE TABLE `principal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombreempresa` varchar(100) DEFAULT NULL,
  `direccionempresa` varchar(255) DEFAULT NULL,
  `telefonoempresa` varchar(15) DEFAULT NULL,
  `correo` varchar(50) DEFAULT NULL,
  `correoaprobacion` varchar(50) DEFAULT NULL,
  `rnc` varchar(20) DEFAULT NULL,
  `urlconsulta` varchar(250) DEFAULT NULL,
  `urlsalida` varchar(250) DEFAULT NULL,
  `urlempleado` varchar(250) DEFAULT NULL,
  `impresora` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `principal` */

insert  into `principal`(`id`,`nombreempresa`,`direccionempresa`,`telefonoempresa`,`correo`,`correoaprobacion`,`rnc`,`urlconsulta`,`urlsalida`,`urlempleado`,`impresora`) values (1,'AGENCIA NAVARRO','C/ Basilio Gavilán, esq. Respaldo Antón, Sector la Yuca, Cotui, Prov. Sánchez Ramírez, R. D.','(809)240-1107','info@agencianavarro.com','hse@agencianavarro.com','-','http://navarrowindows.ddns.net/bprestservices/getwebcatalogpaginado.rsvc?incluircosto=si?pagina=1&rowsPorPagina=3000%20HTTP/1.1','http://navarrowindows.ddns.net/bprestservices/invsalida.rsvc','http://navarrowindows.ddns.net/bprestservices/empleado.rsvc?pagina=1&rowsPorPagina=1000 HTTP/1.1','');

/*Table structure for table `usuarios` */

DROP TABLE IF EXISTS `usuarios`;

CREATE TABLE `usuarios` (
  `idusuario` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `usuario` varchar(30) DEFAULT NULL,
  `clave` varchar(30) DEFAULT NULL,
  `cargo` varchar(30) DEFAULT NULL,
  `correo` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `usuarios` */

insert  into `usuarios`(`idusuario`,`nombre`,`apellido`,`usuario`,`clave`,`cargo`,`correo`) values (3,'VICTOR ALF','VARGAS','TECNOLOGIA','2525','ADMINISTRADOR','tecnologia@agencianavarro.com'),(5,'BIANKA ','NAVARRO','BIANKA','0229','ADMINISTRADOR','almacen@agencianavarro.com'),(6,'NAVARRO','NAVARRO','NAVARRO','NAVARRO',NULL,NULL);

/* Trigger structure for table `autorizacionepp` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `EnviarCorreo` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'localhost' */ /*!50003 TRIGGER `EnviarCorreo` BEFORE INSERT ON `autorizacionepp` FOR EACH ROW BEGIN


END */$$


DELIMITER ;

/* Function  structure for function  `ROW_VERSION` */

/*!50003 DROP FUNCTION IF EXISTS `ROW_VERSION` */;
DELIMITER $$

/*!50003 CREATE DEFINER=`victor`@`%` FUNCTION `ROW_VERSION`() RETURNS bigint(20) unsigned
    DETERMINISTIC
BEGIN

  REPLACE INTO versioning (ID, dummy) VALUES (NULL, 1);

  RETURN LAST_INSERT_ID();

END */$$
DELIMITER ;

/* Procedure structure for procedure `RegistrarAutorizacion` */

/*!50003 DROP PROCEDURE IF EXISTS  `RegistrarAutorizacion` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `RegistrarAutorizacion`(
	IN `_idusuario` INT,
	IN `_idempleado` INT,
	IN `_idproducto` INT,
	IN `_fechavence` VARCHAR(20),
	IN `_codigoautorizacion` INT,
	IN `_observacion` VARCHAR(250)
)
BEGIN

DECLARE noFactura INT;

SET noFactura=0;

START TRANSACTION;

SELECT MAX(facturas.idfactura) INTO noFactura FROM facturas;

SET noFactura=noFactura+1;
     

INSERT INTO autorizacionepp(idusuario,idfactura,idempleado,idproducto,fechavence,codigoautorizacion,observacion)
VALUES (_idusuario,noFactura,_idempleado,_idproducto,_fechavence,_codigoautorizacion,_observacion);

COMMIT;  
END */$$
DELIMITER ;

/* Procedure structure for procedure `RegistrarDetalleFactura` */

/*!50003 DROP PROCEDURE IF EXISTS  `RegistrarDetalleFactura` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `RegistrarDetalleFactura`(
	IN `_idempleado` INT,
	IN `_idproducto` INT,
	IN `_nombreepp` VARCHAR(150),
	IN `_cantidad` INT,
	IN `_precio` DECIMAL(10,2),
	IN `_subtotal` DECIMAL(10,2),
	IN `_tiempovida` INT,
	IN `_fechavence` DATE,
	IN `_codigoaprovacion` INT
)
BEGIN

DECLARE noFactura INT;

SET noFactura=0;

START TRANSACTION;

SELECT MAX(facturas.idfactura) INTO noFactura FROM facturas;
     
 INSERT INTO detallesfacturas(idfactura,idempleado, idproducto,nombreepp,cantidad,precio,subtotal,tiempovida,fechavence, codigoaprovacion)
             
VALUES (noFactura,_idempleado,_idproducto, _nombreepp,_cantidad,_precio,_subtotal,_tiempovida, _fechavence,_codigoaprovacion);   
        
        
          COMMIT;  
END */$$
DELIMITER ;

/* Procedure structure for procedure `RegistrarFactura` */

/*!50003 DROP PROCEDURE IF EXISTS  `RegistrarFactura` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `RegistrarFactura`(
	IN `_idusuario` INT,
	IN `_idempleado` INT,
	IN `_Cedula` VARCHAR(15),
	IN `_OracleID` VARCHAR(20),
	IN `_NombreEmpleado` VARCHAR(100),
	IN `_AreaTrabajo` VARCHAR(100),
	IN `_NombrePO` VARCHAR(50),
	IN `_codigoaprovacion` INT,
	IN `_observacion` VARCHAR(200)
)
BEGIN
START TRANSACTION;
INSERT INTO facturas(idusuario,idempleado,Cedula,OracleID,NombreEmpleado,AreaTrabajo,NombrePO,codigoaprovacion,observacion)
VALUES (_idusuario, _idempleado,_Cedula,_OracleID,_NombreEmpleado,_AreaTrabajo,_NombrePO,_codigoaprovacion,_observacion);     
        
 COMMIT;
   
        
END */$$
DELIMITER ;

/* Procedure structure for procedure `run_script` */

/*!50003 DROP PROCEDURE IF EXISTS  `run_script` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`victor`@`%` PROCEDURE `run_script`()
BEGIN

IF NOT EXISTS( (SELECT * FROM information_schema.COLUMNS WHERE TABLE_SCHEMA=DATABASE() AND COLUMN_NAME='RepositoryID' AND TABLE_NAME='ConnectionLog') ) THEN
    ALTER TABLE `ConnectionLog` ADD `RepositoryID` varchar(36) NULL;
END IF;

END */$$
DELIMITER ;

/* Procedure structure for procedure `ValidarFechaVence` */

/*!50003 DROP PROCEDURE IF EXISTS  `ValidarFechaVence` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `ValidarFechaVence`(
	IN `_idproducto` INT,
	IN `_idempleado` INT
)
BEGIN

select fechavence from detallesfacturas,facturas where detallesfacturas.idproducto=_idproducto 
and facturas.idempleado=_idempleado and detallesfacturas.idempleado=_idempleado 

order by detallesfacturas.iddetallesfactura DESC;

END */$$
DELIMITER ;

/* Procedure structure for procedure `ValidarItemAprovado` */

/*!50003 DROP PROCEDURE IF EXISTS  `ValidarItemAprovado` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `ValidarItemAprovado`(
	IN `_idproducto` INT,
	IN `_idempleado` INT
)
BEGIN

select autorizacionepp.codigoautorizacion,autorizacionepp.idproducto 
from autorizacionepp where autorizacionepp.idproducto=_idproducto 
and autorizacionepp.idempleado=_idempleado order by idautorizacion DESC;

END */$$
DELIMITER ;

/*Table structure for table `consultasdetallese` */

DROP TABLE IF EXISTS `consultasdetallese`;

/*!50001 DROP VIEW IF EXISTS `consultasdetallese` */;
/*!50001 DROP TABLE IF EXISTS `consultasdetallese` */;

/*!50001 CREATE TABLE  `consultasdetallese`(
 `iddetallesfactura` int(11) ,
 `idfactura` int(11) ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `cantidad` int(11) ,
 `tiempovida` int(11) ,
 `fechavence` varchar(15) 
)*/;

/*Table structure for table `consultasfacturae` */

DROP TABLE IF EXISTS `consultasfacturae`;

/*!50001 DROP VIEW IF EXISTS `consultasfacturae` */;
/*!50001 DROP TABLE IF EXISTS `consultasfacturae` */;

/*!50001 CREATE TABLE  `consultasfacturae`(
 `idfactura` int(11) ,
 `fecha` timestamp ,
 `codigoaprovacion` int(20) ,
 `observacion` varchar(255) ,
 `NombrePO` varchar(50) ,
 `Nombre` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `usuario` varchar(30) 
)*/;

/*Table structure for table `facturaepp` */

DROP TABLE IF EXISTS `facturaepp`;

/*!50001 DROP VIEW IF EXISTS `facturaepp` */;
/*!50001 DROP TABLE IF EXISTS `facturaepp` */;

/*!50001 CREATE TABLE  `facturaepp`(
 `idfactura` int(11) ,
 `nombre` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `fecha` timestamp ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `cantidad` int(11) ,
 `precio` decimal(10,2) ,
 `subtotal` decimal(10,2) ,
 `tiempovida` int(11) ,
 `fechavence` varchar(15) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `usuario` varchar(101) ,
 `codigoaprovacion` int(11) ,
 `observacion` varchar(255) ,
 `NombrePO` varchar(50) 
)*/;

/*Table structure for table `facturaeppfecha` */

DROP TABLE IF EXISTS `facturaeppfecha`;

/*!50001 DROP VIEW IF EXISTS `facturaeppfecha` */;
/*!50001 DROP TABLE IF EXISTS `facturaeppfecha` */;

/*!50001 CREATE TABLE  `facturaeppfecha`(
 `iddetallesfactura` int(11) ,
 `idfactura` int(11) ,
 `Nombre` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `fecha` timestamp ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `cantidad` int(11) ,
 `precio` decimal(10,2) ,
 `subtotal` decimal(10,2) ,
 `tiempovida` int(11) ,
 `fechavence` varchar(15) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `usuario` varchar(101) ,
 `fechainicio` timestamp ,
 `fechafinal` timestamp ,
 `codigoaprovacion` int(11) ,
 `NombrePO` varchar(50) 
)*/;

/*Table structure for table `facturaeppporempleado` */

DROP TABLE IF EXISTS `facturaeppporempleado`;

/*!50001 DROP VIEW IF EXISTS `facturaeppporempleado` */;
/*!50001 DROP TABLE IF EXISTS `facturaeppporempleado` */;

/*!50001 CREATE TABLE  `facturaeppporempleado`(
 `iddetallesfactura` int(11) ,
 `idfactura` int(11) ,
 `Nombre` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `fecha` timestamp ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `cantidad` int(11) ,
 `precio` decimal(10,2) ,
 `subtotal` decimal(10,2) ,
 `tiempovida` int(11) ,
 `fechavence` varchar(15) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `usuario` varchar(101) ,
 `fechainicio` timestamp ,
 `fechafinal` timestamp ,
 `codigoaprovacion` int(11) ,
 `NombrePO` varchar(50) 
)*/;

/*Table structure for table `facturaporarea` */

DROP TABLE IF EXISTS `facturaporarea`;

/*!50001 DROP VIEW IF EXISTS `facturaporarea` */;
/*!50001 DROP TABLE IF EXISTS `facturaporarea` */;

/*!50001 CREATE TABLE  `facturaporarea`(
 `idfactura` int(11) ,
 `Nombre` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `fecha` timestamp ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `cantidad` int(11) ,
 `precio` decimal(10,2) ,
 `subtotal` decimal(10,2) ,
 `tiempovida` int(11) ,
 `fechavence` varchar(15) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `fechainicio` timestamp ,
 `fechafinal` timestamp ,
 `codigoaprovacion` int(11) ,
 `NombrePO` varchar(50) 
)*/;

/*Table structure for table `reporteautorizacion` */

DROP TABLE IF EXISTS `reporteautorizacion`;

/*!50001 DROP VIEW IF EXISTS `reporteautorizacion` */;
/*!50001 DROP TABLE IF EXISTS `reporteautorizacion` */;

/*!50001 CREATE TABLE  `reporteautorizacion`(
 `NombreEmpleado` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `fechavence` varchar(20) ,
 `codigoautorizacion` int(20) ,
 `observacion` varchar(255) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `fechaautorizacion` datetime 
)*/;

/*Table structure for table `reporteautorizacionporarea` */

DROP TABLE IF EXISTS `reporteautorizacionporarea`;

/*!50001 DROP VIEW IF EXISTS `reporteautorizacionporarea` */;
/*!50001 DROP TABLE IF EXISTS `reporteautorizacionporarea` */;

/*!50001 CREATE TABLE  `reporteautorizacionporarea`(
 `NombreEmpleado` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `fechavence` varchar(20) ,
 `codigoautorizacion` int(20) ,
 `observacion` varchar(255) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `idautorizacion` int(11) ,
 `fechaautorizacion` datetime ,
 `fechainicio` timestamp ,
 `fechafinal` timestamp ,
 `nombrearea` varchar(30) 
)*/;

/*Table structure for table `reporteautorizacionporempleado` */

DROP TABLE IF EXISTS `reporteautorizacionporempleado`;

/*!50001 DROP VIEW IF EXISTS `reporteautorizacionporempleado` */;
/*!50001 DROP TABLE IF EXISTS `reporteautorizacionporempleado` */;

/*!50001 CREATE TABLE  `reporteautorizacionporempleado`(
 `idfactura` int(11) ,
 `nombre` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `fechavence` varchar(20) ,
 `codigoautorizacion` int(20) ,
 `observacion` varchar(255) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `idautorizacion` int(11) ,
 `fechaautorizacion` datetime ,
 `fechafinal` timestamp ,
 `fechainicio` timestamp 
)*/;

/*Table structure for table `reporteautorizacionporfecha` */

DROP TABLE IF EXISTS `reporteautorizacionporfecha`;

/*!50001 DROP VIEW IF EXISTS `reporteautorizacionporfecha` */;
/*!50001 DROP TABLE IF EXISTS `reporteautorizacionporfecha` */;

/*!50001 CREATE TABLE  `reporteautorizacionporfecha`(
 `nombre` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `fechavence` varchar(20) ,
 `codigoautorizacion` int(20) ,
 `observacion` varchar(255) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `fechaautorizacion` datetime ,
 `fechafinal` timestamp ,
 `fechainicio` timestamp ,
 `idautorizacion` int(11) 
)*/;

/*Table structure for table `reporteeppplano` */

DROP TABLE IF EXISTS `reporteeppplano`;

/*!50001 DROP VIEW IF EXISTS `reporteeppplano` */;
/*!50001 DROP TABLE IF EXISTS `reporteeppplano` */;

/*!50001 CREATE TABLE  `reporteeppplano`(
 `iddetallesfactura` int(11) ,
 `idfactura` int(11) ,
 `Nombre` varchar(100) ,
 `Cedula` varchar(15) ,
 `OracleID` varchar(20) ,
 `AreaTrabajo` varchar(100) ,
 `fecha` timestamp ,
 `idproducto` int(11) ,
 `nombreepp` varchar(250) ,
 `cantidad` int(11) ,
 `precio` decimal(10,2) ,
 `subtotal` decimal(10,2) ,
 `tiempovida` int(11) ,
 `fechavence` varchar(15) ,
 `nombreempresa` varchar(100) ,
 `direccionempresa` varchar(255) ,
 `telefonoempresa` varchar(15) ,
 `correo` varchar(50) ,
 `rnc` varchar(20) ,
 `usuario` varchar(101) ,
 `fechainicio` timestamp ,
 `fechafinal` timestamp ,
 `codigoaprovacion` int(11) ,
 `NombrePO` varchar(50) 
)*/;

/*View structure for view consultasdetallese */

/*!50001 DROP TABLE IF EXISTS `consultasdetallese` */;
/*!50001 DROP VIEW IF EXISTS `consultasdetallese` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `consultasdetallese` AS select `detallesfacturas`.`iddetallesfactura` AS `iddetallesfactura`,`detallesfacturas`.`idfactura` AS `idfactura`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`detallesfacturas`.`cantidad` AS `cantidad`,`detallesfacturas`.`tiempovida` AS `tiempovida`,`detallesfacturas`.`fechavence` AS `fechavence` from (`detallesfacturas` join `facturas`) where (`detallesfacturas`.`idfactura` = `facturas`.`idfactura`) */;

/*View structure for view consultasfacturae */

/*!50001 DROP TABLE IF EXISTS `consultasfacturae` */;
/*!50001 DROP VIEW IF EXISTS `consultasfacturae` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `consultasfacturae` AS select `facturas`.`idfactura` AS `idfactura`,`facturas`.`fecha` AS `fecha`,`facturas`.`codigoaprovacion` AS `codigoaprovacion`,`facturas`.`observacion` AS `observacion`,`facturas`.`NombrePO` AS `NombrePO`,`facturas`.`NombreEmpleado` AS `Nombre`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`usuarios`.`usuario` AS `usuario` from (`facturas` join `usuarios`) where (`facturas`.`idusuario` = `usuarios`.`idusuario`) */;

/*View structure for view facturaepp */

/*!50001 DROP TABLE IF EXISTS `facturaepp` */;
/*!50001 DROP VIEW IF EXISTS `facturaepp` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `facturaepp` AS select `detallesfacturas`.`idfactura` AS `idfactura`,`facturas`.`NombreEmpleado` AS `nombre`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`facturas`.`fecha` AS `fecha`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`detallesfacturas`.`cantidad` AS `cantidad`,`detallesfacturas`.`precio` AS `precio`,`detallesfacturas`.`subtotal` AS `subtotal`,`detallesfacturas`.`tiempovida` AS `tiempovida`,`detallesfacturas`.`fechavence` AS `fechavence`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,concat(`usuarios`.`nombre`,' ',`usuarios`.`apellido`) AS `usuario`,`detallesfacturas`.`codigoaprovacion` AS `codigoaprovacion`,`facturas`.`observacion` AS `observacion`,`facturas`.`NombrePO` AS `NombrePO` from ((((`detallesfacturas` join `facturas` on((`detallesfacturas`.`idfactura` = `facturas`.`idfactura`))) join `usuarios` on((`facturas`.`idusuario` = `usuarios`.`idusuario`))) join `fecha` on((`facturas`.`idfactura` = `fecha`.`idfactura`))) join `principal`) */;

/*View structure for view facturaeppfecha */

/*!50001 DROP TABLE IF EXISTS `facturaeppfecha` */;
/*!50001 DROP VIEW IF EXISTS `facturaeppfecha` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `facturaeppfecha` AS (select `detallesfacturas`.`iddetallesfactura` AS `iddetallesfactura`,`detallesfacturas`.`idfactura` AS `idfactura`,`facturas`.`NombreEmpleado` AS `Nombre`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`facturas`.`fecha` AS `fecha`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`detallesfacturas`.`cantidad` AS `cantidad`,`detallesfacturas`.`precio` AS `precio`,`detallesfacturas`.`subtotal` AS `subtotal`,`detallesfacturas`.`tiempovida` AS `tiempovida`,`detallesfacturas`.`fechavence` AS `fechavence`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,concat(`usuarios`.`nombre`,' ',`usuarios`.`apellido`) AS `usuario`,`fecha`.`fechainicio` AS `fechainicio`,`fecha`.`fechafinal` AS `fechafinal`,`detallesfacturas`.`codigoaprovacion` AS `codigoaprovacion`,`facturas`.`NombrePO` AS `NombrePO` from ((((`facturas` join `detallesfacturas`) join `usuarios`) join `principal`) join `fecha`) where ((`facturas`.`idempleado` = `detallesfacturas`.`idempleado`) and (`facturas`.`idfactura` = `detallesfacturas`.`idfactura`) and (`facturas`.`idusuario` = `usuarios`.`idusuario`) and (`facturas`.`fecha` between `fecha`.`fechainicio` and `fecha`.`fechafinal`))) */;

/*View structure for view facturaeppporempleado */

/*!50001 DROP TABLE IF EXISTS `facturaeppporempleado` */;
/*!50001 DROP VIEW IF EXISTS `facturaeppporempleado` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `facturaeppporempleado` AS (select `detallesfacturas`.`iddetallesfactura` AS `iddetallesfactura`,`detallesfacturas`.`idfactura` AS `idfactura`,`facturas`.`NombreEmpleado` AS `Nombre`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`facturas`.`fecha` AS `fecha`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`detallesfacturas`.`cantidad` AS `cantidad`,`detallesfacturas`.`precio` AS `precio`,`detallesfacturas`.`subtotal` AS `subtotal`,`detallesfacturas`.`tiempovida` AS `tiempovida`,`detallesfacturas`.`fechavence` AS `fechavence`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,concat(`usuarios`.`nombre`,' ',`usuarios`.`apellido`) AS `usuario`,`fecha`.`fechainicio` AS `fechainicio`,`fecha`.`fechafinal` AS `fechafinal`,`detallesfacturas`.`codigoaprovacion` AS `codigoaprovacion`,`facturas`.`NombrePO` AS `NombrePO` from ((((`facturas` join `detallesfacturas`) join `usuarios`) join `fecha`) join `principal`) where ((`facturas`.`idempleado` = `detallesfacturas`.`idempleado`) and (`facturas`.`idfactura` = `detallesfacturas`.`idfactura`) and (`facturas`.`idusuario` = `usuarios`.`idusuario`) and (`facturas`.`idempleado` = `fecha`.`idempleado`))) */;

/*View structure for view facturaporarea */

/*!50001 DROP TABLE IF EXISTS `facturaporarea` */;
/*!50001 DROP VIEW IF EXISTS `facturaporarea` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `facturaporarea` AS (select `detallesfacturas`.`idfactura` AS `idfactura`,`facturas`.`NombreEmpleado` AS `Nombre`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`facturas`.`fecha` AS `fecha`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`detallesfacturas`.`cantidad` AS `cantidad`,`detallesfacturas`.`precio` AS `precio`,`detallesfacturas`.`subtotal` AS `subtotal`,`detallesfacturas`.`tiempovida` AS `tiempovida`,`detallesfacturas`.`fechavence` AS `fechavence`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,`fecha`.`fechainicio` AS `fechainicio`,`fecha`.`fechafinal` AS `fechafinal`,`detallesfacturas`.`codigoaprovacion` AS `codigoaprovacion`,`facturas`.`NombrePO` AS `NombrePO` from (((`detallesfacturas` join `facturas` on(((`detallesfacturas`.`idfactura` = `facturas`.`idfactura`) and (`detallesfacturas`.`idempleado` = `facturas`.`idempleado`)))) join `principal`) join `fecha`) where (`facturas`.`fecha` between `fecha`.`fechainicio` and `fecha`.`fechafinal`)) */;

/*View structure for view reporteautorizacion */

/*!50001 DROP TABLE IF EXISTS `reporteautorizacion` */;
/*!50001 DROP VIEW IF EXISTS `reporteautorizacion` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporteautorizacion` AS select `facturas`.`NombreEmpleado` AS `NombreEmpleado`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`autorizacionepp`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`autorizacionepp`.`fechavence` AS `fechavence`,`autorizacionepp`.`codigoautorizacion` AS `codigoautorizacion`,`autorizacionepp`.`observacion` AS `observacion`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,`autorizacionepp`.`fechaautorizacion` AS `fechaautorizacion` from ((((`autorizacionepp` join `facturas` on(((`autorizacionepp`.`idempleado` = `facturas`.`idempleado`) and (`autorizacionepp`.`idfactura` = `facturas`.`idfactura`)))) join `detallesfacturas` on(((`autorizacionepp`.`idproducto` = `detallesfacturas`.`idproducto`) and (`autorizacionepp`.`idfactura` = `detallesfacturas`.`idfactura`) and (`facturas`.`idfactura` = `detallesfacturas`.`idfactura`)))) join `fecha` on((`autorizacionepp`.`codigoautorizacion` = `fecha`.`codigoautorizacion`))) join `principal`) order by `autorizacionepp`.`idautorizacion` desc */;

/*View structure for view reporteautorizacionporarea */

/*!50001 DROP TABLE IF EXISTS `reporteautorizacionporarea` */;
/*!50001 DROP VIEW IF EXISTS `reporteautorizacionporarea` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporteautorizacionporarea` AS select `facturas`.`NombreEmpleado` AS `NombreEmpleado`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`autorizacionepp`.`fechavence` AS `fechavence`,`autorizacionepp`.`codigoautorizacion` AS `codigoautorizacion`,`autorizacionepp`.`observacion` AS `observacion`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,`autorizacionepp`.`idautorizacion` AS `idautorizacion`,`autorizacionepp`.`fechaautorizacion` AS `fechaautorizacion`,`fecha`.`fechainicio` AS `fechainicio`,`fecha`.`fechafinal` AS `fechafinal`,`fecha`.`nombrearea` AS `nombrearea` from ((((`facturas` join `autorizacionepp` on(((`facturas`.`idempleado` = `autorizacionepp`.`idempleado`) and (`facturas`.`idfactura` = `autorizacionepp`.`idfactura`)))) join `detallesfacturas` on(((`autorizacionepp`.`idfactura` = `detallesfacturas`.`idfactura`) and (`autorizacionepp`.`idproducto` = `detallesfacturas`.`idproducto`) and (`autorizacionepp`.`idfactura` = `detallesfacturas`.`idfactura`)))) join `fecha` on((`facturas`.`AreaTrabajo` = `fecha`.`nombrearea`))) join `principal`) order by `autorizacionepp`.`idautorizacion` desc */;

/*View structure for view reporteautorizacionporempleado */

/*!50001 DROP TABLE IF EXISTS `reporteautorizacionporempleado` */;
/*!50001 DROP VIEW IF EXISTS `reporteautorizacionporempleado` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporteautorizacionporempleado` AS select `autorizacionepp`.`idfactura` AS `idfactura`,`facturas`.`NombreEmpleado` AS `nombre`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`autorizacionepp`.`fechavence` AS `fechavence`,`autorizacionepp`.`codigoautorizacion` AS `codigoautorizacion`,`autorizacionepp`.`observacion` AS `observacion`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,`autorizacionepp`.`idautorizacion` AS `idautorizacion`,`autorizacionepp`.`fechaautorizacion` AS `fechaautorizacion`,`fecha`.`fechafinal` AS `fechafinal`,`fecha`.`fechainicio` AS `fechainicio` from ((((`autorizacionepp` join `facturas` on(((`autorizacionepp`.`idempleado` = `facturas`.`idempleado`) and (`autorizacionepp`.`idfactura` = `facturas`.`idfactura`)))) join `detallesfacturas` on(((`autorizacionepp`.`idproducto` = `detallesfacturas`.`idproducto`) and (`autorizacionepp`.`idfactura` = `detallesfacturas`.`idfactura`)))) join `fecha` on((`autorizacionepp`.`idempleado` = `fecha`.`idempleado`))) join `principal`) where (`autorizacionepp`.`fechaautorizacion` between `fecha`.`fechainicio` and `fecha`.`fechafinal`) order by `autorizacionepp`.`idautorizacion` desc */;

/*View structure for view reporteautorizacionporfecha */

/*!50001 DROP TABLE IF EXISTS `reporteautorizacionporfecha` */;
/*!50001 DROP VIEW IF EXISTS `reporteautorizacionporfecha` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporteautorizacionporfecha` AS select `facturas`.`NombreEmpleado` AS `nombre`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`autorizacionepp`.`fechavence` AS `fechavence`,`autorizacionepp`.`codigoautorizacion` AS `codigoautorizacion`,`autorizacionepp`.`observacion` AS `observacion`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,`autorizacionepp`.`fechaautorizacion` AS `fechaautorizacion`,`fecha`.`fechafinal` AS `fechafinal`,`fecha`.`fechainicio` AS `fechainicio`,`autorizacionepp`.`idautorizacion` AS `idautorizacion` from ((((`autorizacionepp` join `facturas` on((`autorizacionepp`.`idempleado` = `facturas`.`idempleado`))) join `detallesfacturas` on(((`autorizacionepp`.`idproducto` = `detallesfacturas`.`idproducto`) and (`facturas`.`idfactura` = `detallesfacturas`.`idfactura`) and (`autorizacionepp`.`idfactura` = `detallesfacturas`.`idfactura`)))) join `principal`) join `fecha`) where (`autorizacionepp`.`fechaautorizacion` between `fecha`.`fechainicio` and `fecha`.`fechafinal`) order by `autorizacionepp`.`idautorizacion` desc */;

/*View structure for view reporteeppplano */

/*!50001 DROP TABLE IF EXISTS `reporteeppplano` */;
/*!50001 DROP VIEW IF EXISTS `reporteeppplano` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reporteeppplano` AS (select `detallesfacturas`.`iddetallesfactura` AS `iddetallesfactura`,`detallesfacturas`.`idfactura` AS `idfactura`,`facturas`.`NombreEmpleado` AS `Nombre`,`facturas`.`Cedula` AS `Cedula`,`facturas`.`OracleID` AS `OracleID`,`facturas`.`AreaTrabajo` AS `AreaTrabajo`,`facturas`.`fecha` AS `fecha`,`detallesfacturas`.`idproducto` AS `idproducto`,`detallesfacturas`.`nombreepp` AS `nombreepp`,`detallesfacturas`.`cantidad` AS `cantidad`,`detallesfacturas`.`precio` AS `precio`,`detallesfacturas`.`subtotal` AS `subtotal`,`detallesfacturas`.`tiempovida` AS `tiempovida`,`detallesfacturas`.`fechavence` AS `fechavence`,`principal`.`nombreempresa` AS `nombreempresa`,`principal`.`direccionempresa` AS `direccionempresa`,`principal`.`telefonoempresa` AS `telefonoempresa`,`principal`.`correo` AS `correo`,`principal`.`rnc` AS `rnc`,concat(`usuarios`.`nombre`,' ',`usuarios`.`apellido`) AS `usuario`,`fecha`.`fechainicio` AS `fechainicio`,`fecha`.`fechafinal` AS `fechafinal`,`detallesfacturas`.`codigoaprovacion` AS `codigoaprovacion`,`facturas`.`NombrePO` AS `NombrePO` from ((((`facturas` join `detallesfacturas`) join `usuarios`) join `principal`) join `fecha`) where ((`facturas`.`idempleado` = `detallesfacturas`.`idempleado`) and (`facturas`.`idfactura` = `detallesfacturas`.`idfactura`) and (`facturas`.`idusuario` = `usuarios`.`idusuario`) and (`facturas`.`fecha` between `fecha`.`fechainicio` and `fecha`.`fechafinal`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
