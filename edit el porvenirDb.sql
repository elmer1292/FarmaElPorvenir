CREATE DATABASE  IF NOT EXISTS `el_porvenirdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `el_porvenirdb`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: el_porvenirdb
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Categorias` varchar(50) DEFAULT NULL,
  `Descripcion` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Antibioticos','Este es un antibiotico'),(2,'Analgesicos','Este es Un Analgesico'),(18,'digestivos','vergas estomacales');
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre_Completo` varchar(50) DEFAULT NULL,
  `Direccion` longtext,
  `Telefono` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Juan Perez','Esquina del gallo mas gallo 1 cuadra abajo',1111),(2,'Pedro Lopez','De los semaforos 1 Cuadra al Este',-1111),(12,'N/A','N/A',0);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detallecompra`
--

DROP TABLE IF EXISTS `detallecompra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detallecompra` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_FacturaCompra` int NOT NULL,
  `Id_Producto` int NOT NULL,
  `Cantidad` int DEFAULT NULL,
  `Precio` double DEFAULT NULL,
  `Total` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Id_producto_Producto_idx` (`Id_Producto`),
  KEY `fk_factura_compra_Id_FacturaCompra` (`Id_FacturaCompra`),
  CONSTRAINT `fk_factura_compra_Id_FacturaCompra` FOREIGN KEY (`Id_FacturaCompra`) REFERENCES `factura_compra` (`Id`),
  CONSTRAINT `fk_Producto_Id_producto` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detallecompra`
--

LOCK TABLES `detallecompra` WRITE;
/*!40000 ALTER TABLE `detallecompra` DISABLE KEYS */;
INSERT INTO `detallecompra` VALUES (1,8,1,1,30,30),(2,8,1,20,12,240),(3,9,5,1,12,12),(4,9,3,3,32,96),(5,10,15,20,25,500),(6,11,15,20,20,400),(7,12,15,20,20,400),(8,12,15,5,20,100),(9,13,15,20,30,600),(10,14,6,20,5,100),(11,15,8,90,10,900);
/*!40000 ALTER TABLE `detallecompra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalleventa`
--

DROP TABLE IF EXISTS `detalleventa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalleventa` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Producto` int NOT NULL,
  `Cantidad` int NOT NULL,
  `Precio` double DEFAULT NULL,
  `Descuento` double DEFAULT NULL,
  `IVA` float NOT NULL,
  `SubTotal` double DEFAULT NULL,
  `Total` double DEFAULT NULL,
  `factura_venta_Id` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Id_Producto_Producto_idx` (`Id_Producto`),
  KEY `ifactura_venta_Id_detalleventa` (`factura_venta_Id`),
  CONSTRAINT `FK_detalleventa_factura_venta_Id` FOREIGN KEY (`factura_venta_Id`) REFERENCES `factura_venta` (`Id`),
  CONSTRAINT `fk_Id_Producto_Producto` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleventa`
--

LOCK TABLES `detalleventa` WRITE;
/*!40000 ALTER TABLE `detalleventa` DISABLE KEYS */;
INSERT INTO `detalleventa` VALUES (1,15,10,25,0,37.5,250,287.5,NULL),(2,15,10,25,0,37.5,250,287.5,1),(5,15,20,25,0,75,500,575,NULL),(6,15,20,25,0,75,500,575,2),(7,1,2,30,0,15,60,60,1),(8,2,1,15,0,5,15,15,1),(9,3,1,32,2,10,30,30,2),(10,5,12,12,0,21.6,144,165.6,NULL),(11,5,12,12,0,21.6,144,165.6,5),(12,4,23,21,0,72.45,483,555.45,NULL),(13,4,23,21,0,72.45,483,555.45,6);
/*!40000 ALTER TABLE `detalleventa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleado` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre_Completo` varchar(50) DEFAULT NULL,
  `Cargo` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (1,'Elmer David Laguna Matamoros','Administrador'),(9,'Jose Matias','Vendedor'),(10,'Hola','Bodeguero'),(19,'tt','t');
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura_compra`
--

DROP TABLE IF EXISTS `factura_compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura_compra` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Empleado` int NOT NULL,
  `Fecha` datetime(6) DEFAULT NULL,
  `No_Factura` varchar(50) DEFAULT NULL,
  `Id_Proveedor` int DEFAULT NULL,
  `Total` double DEFAULT NULL,
  `Id_Laboratorio` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `factura_compra_Id_Proveedor_idx` (`Id_Proveedor`),
  KEY `factura_compra_Id_Laboratorio_idx` (`Id_Laboratorio`),
  CONSTRAINT `factura_compra_ibfk_2` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_compra_Id_Laboratorio` FOREIGN KEY (`Id_Laboratorio`) REFERENCES `laboratorio` (`Id`),
  CONSTRAINT `factura_compra_Id_Proveedor` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_compra`
--

LOCK TABLES `factura_compra` WRITE;
/*!40000 ALTER TABLE `factura_compra` DISABLE KEYS */;
INSERT INTO `factura_compra` VALUES (8,1,'2024-10-04 00:00:00.000000','000001',1,270,1),(9,1,'2024-10-05 00:00:00.000000','000002',1,108,3),(10,1,'2024-10-09 00:00:00.000000','000003',1,500,4),(11,9,'2024-10-09 00:00:00.000000','000004',1,400,2),(12,9,'2024-10-09 00:00:00.000000','000005',2,500,2),(13,9,'2024-10-09 00:00:00.000000','000006',3,600,4),(14,10,'2024-10-09 00:00:00.000000','000007',3,100,2),(15,10,'2024-10-09 00:00:00.000000','000008',1,900,3);
/*!40000 ALTER TABLE `factura_compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura_venta`
--

DROP TABLE IF EXISTS `factura_venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura_venta` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Fecha` datetime(6) DEFAULT NULL,
  `No_Factura` varchar(50) DEFAULT NULL,
  `Total_Factura` double DEFAULT NULL,
  `Id_Cliente` int NOT NULL,
  `Id_Empleado` int NOT NULL,
  `Total_IVA` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `clientefkventa_idx` (`Id_Cliente`),
  CONSTRAINT `clientefkventa` FOREIGN KEY (`Id_Cliente`) REFERENCES `cliente` (`Id`),
  CONSTRAINT `factura_venta_ibfk_1` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_venta`
--

LOCK TABLES `factura_venta` WRITE;
/*!40000 ALTER TABLE `factura_venta` DISABLE KEYS */;
INSERT INTO `factura_venta` VALUES (1,'2024-10-24 00:00:00.000000','000001',287.5,12,9,37.5),(2,'2024-10-24 00:00:00.000000','000002',575,12,9,75),(3,'2024-10-24 00:08:50.000000','FV-001',100,1,1,15),(4,'2024-10-24 00:08:50.000000','FV-002',200,2,1,30),(5,'2024-10-24 00:00:00.000000','000001',165.6,12,9,21.6),(6,'2024-10-24 00:00:00.000000','000001',555.45,2,19,72.45);
/*!40000 ALTER TABLE `factura_venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `laboratorio`
--

DROP TABLE IF EXISTS `laboratorio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `laboratorio` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  `Direccion` longtext,
  `Telefono` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `laboratorio`
--

LOCK TABLES `laboratorio` WRITE;
/*!40000 ALTER TABLE `laboratorio` DISABLE KEYS */;
INSERT INTO `laboratorio` VALUES (1,'Laboratorio Divina','Esta es la direccion del labortario A',0),(2,'Bayer','Esta es la direccion del labortario B',0),(3,'Laboratorios Ramos','Esta es la direccion del labortario C',0),(4,'Laboratorio CEGUEL','Esta es la direccion del labortario C',0);
/*!40000 ALTER TABLE `laboratorio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producto` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Medicamento` varchar(50) DEFAULT NULL,
  `Precio_Compra` double DEFAULT NULL,
  `Precio_Venta` double DEFAULT NULL,
  `Descuento` double DEFAULT NULL,
  `Stock` int DEFAULT NULL,
  `Vencimiento` datetime(6) DEFAULT NULL,
  `Id_Categoria` int NOT NULL,
  `Id_Proveedor` int NOT NULL,
  `Id_Laboratorio` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Id_Categoria_categoria` (`Id_Categoria`),
  KEY `fk_Id_Proveedor_proveedor` (`Id_Proveedor`),
  KEY `fk_Id_Producto_Laboratorio_idx` (`Id_Laboratorio`),
  CONSTRAINT `fk_Id_Categoria_categoria` FOREIGN KEY (`Id_Categoria`) REFERENCES `categoria` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Id_Producto_Laboratorio` FOREIGN KEY (`Id_Laboratorio`) REFERENCES `laboratorio` (`Id`),
  CONSTRAINT `fk_Id_Proveedor_proveedor` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (1,'Amigdocaina',20,30,0,100,'2025-12-11 00:00:00.000000',1,1,3),(2,'Acitromicina',10,15,0,100,'2025-08-04 00:00:00.000000',1,1,1),(3,'Doxiciclina',25,32,2,100,'2025-10-12 00:00:00.000000',1,2,1),(4,'Ibuprofeno',15,21,0,77,'2025-12-01 00:00:00.000000',2,2,2),(5,'Aspirina ',8,12,0,88,'2025-05-05 00:00:00.000000',2,3,3),(6,'Paracetamol ',5,8,0,120,'2025-11-11 00:00:00.000000',2,3,2),(7,'digestomen',50,75,2,100,'2024-12-12 00:00:00.000000',18,2,1),(8,'acitromicina',10,15,0,100,'2024-10-12 00:00:00.000000',1,1,1),(9,'Amigdocaina',20,30,0,10,'2024-10-12 00:00:00.000000',1,2,1),(15,'anara',20,25,0,10,'2024-10-03 00:00:00.000000',18,1,3);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedor` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  `Direccion` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'Proveedor A','Esta es la direcccion del proveedor'),(2,'Proveedor B','Esta es la direccion del proveedor B'),(3,'Proveedor C','Esta es la direccion del proveedor C');
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rol` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre_Rol` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Rol` (`Nombre_Rol`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador'),(18,'Consulta'),(17,'Vendedor');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(50) DEFAULT NULL,
  `pass` varchar(50) DEFAULT NULL,
  `Id_Empleado` int NOT NULL,
  `Id_Rol` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `usuario_UNIQUE` (`usuario`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `Id_Rol` (`Id_Rol`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `usuario_ibfk_2` FOREIGN KEY (`Id_Rol`) REFERENCES `rol` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'admin','admin',1,1),(14,'venta','venta',9,17),(15,'bodega','bodega',10,18),(16,'t','t',19,17);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'el_porvenirdb'
--

--
-- Dumping routines for database 'el_porvenirdb'
--
/*!50003 DROP PROCEDURE IF EXISTS `ProductosVendidosUltimos7Dias` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProductosVendidosUltimos7Dias`()
BEGIN
    SELECT p.Medicamento, dv.Cantidad, dv.Precio, dv.Total
    FROM detalleventa dv
    INNER JOIN producto p ON dv.Id_Producto = p.Id
    INNER JOIN factura_venta fv ON dv.factura_venta_Id = fv.Id
    WHERE fv.Fecha >= DATE_SUB(CURDATE(), INTERVAL 7 DAY);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `VendedoresYVentasTotalesUltimos7Dias` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `VendedoresYVentasTotalesUltimos7Dias`()
BEGIN
    SELECT e.Nombre_Completo AS Vendedor, SUM(fv.Total_Factura) AS Total_Ventas
    FROM factura_venta fv
    INNER JOIN empleado e ON fv.Id_Empleado = e.Id
    WHERE fv.Fecha >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
    GROUP BY e.Nombre_Completo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-24  0:50:09
