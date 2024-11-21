CREATE DATABASE  IF NOT EXISTS `el_porvenirdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `el_porvenirdb`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: el_porvenirdb
-- ------------------------------------------------------
-- Server version	8.0.35

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
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Antibioticos','Este es un antibiotico'),(2,'Analgesicos','Este es Un Analgesico'),(20,'anticonceptivos','anti embarazos'),(22,'Analgésico','Analgésico para el alivio del dolor y la fiebre.'),(23,'Antiinflamatorio','Antiinflamatorio para aliviar dolores musculares y articulares.'),(24,'Antibiótico','Antibiótico de amplio espectro contra infecciones bacterianas.'),(25,'Antiséptico','Antiséptico para la limpieza de heridas.'),(26,'Antipirético','Antipirético para reducir la fiebre.'),(27,'Antialérgico','Antialérgico que alivia síntomas de alergia.'),(28,'Antihistamínico','Antihistamínico que trata síntomas alérgicos.'),(29,'Antidepresivo','Antidepresivo utilizado en el tratamiento de la depresión.'),(30,'Antidiarreico','Antidiarreico que reduce la diarrea.'),(31,'Anticoagulante','Anticoagulante para prevenir coágulos sanguíneos.'),(32,'Laxante','Laxante para aliviar el estreñimiento.'),(33,'Antitusígeno','Antitusígeno que suprime la tos seca.'),(34,'Expectorante','Expectorante que facilita la expulsión de moco.'),(35,'Antihipertensivo','Antihipertensivo para controlar la presión alta.'),(36,'Broncodilatador','Broncodilatador que alivia el asma y facilita la respiración.'),(37,'Anticonceptivo','Método anticonceptivo que previene el embarazo.'),(38,'Corticoide','Corticoide que reduce la inflamación.'),(39,'Ansiolítico','Ansiolítico que alivia el estrés y la ansiedad.'),(40,'Antifúngico','Antifúngico para tratar infecciones por hongos.'),(41,'Antiviral','Antiviral que combate infecciones virales.'),(43,'vitaminicos','vitaminas'),(47,'categoria de prueva','es una prueva'),(48,'cat22','de prueva');
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
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Juan Perez','Esquina del gallo mas gallo 1 cuadra abajo',1111),(13,'anielka','qqqq',0),(15,'pedro mena','chinandega',7777777),(21,'cliente de prueba','chinsndega',4444444),(24,'Ramiro','chinandega',12345678),(25,'C/F','N/A',0),(26,'D.Prueva','san ,artin ',221233545);
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
  `Id_Producto` int DEFAULT NULL,
  `Cantidad` int DEFAULT NULL,
  `Precio` double DEFAULT NULL,
  `Total` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Id_producto_Producto_idx` (`Id_Producto`),
  KEY `fk_factura_compra_Id_FacturaCompra` (`Id_FacturaCompra`),
  CONSTRAINT `fk_factura_compra_Id_FacturaCompra` FOREIGN KEY (`Id_FacturaCompra`) REFERENCES `factura_compra` (`Id`),
  CONSTRAINT `fk_Producto_Id_producto` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detallecompra`
--

LOCK TABLES `detallecompra` WRITE;
/*!40000 ALTER TABLE `detallecompra` DISABLE KEYS */;
INSERT INTO `detallecompra` VALUES (1,13,NULL,50,20,1000),(2,14,9,4,10,40),(3,15,NULL,20,20,400),(4,16,NULL,30,40,1200),(5,17,12,10,6,60),(6,18,3,7,30,210);
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
  `Id_Producto` int DEFAULT NULL,
  `Cantidad` int NOT NULL,
  `Precio` double DEFAULT NULL,
  `Descuento` double DEFAULT NULL,
  `IVA` float NOT NULL,
  `SubTotal` double DEFAULT NULL,
  `Total` double DEFAULT NULL,
  `factura_venta_Id` int DEFAULT NULL,
  `Id_FacturaVenta` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Id_Producto_Producto_idx` (`Id_Producto`),
  KEY `ifactura_venta_Id_detalleventa` (`factura_venta_Id`),
  KEY `iId_FacturaVenta_detalleventa` (`Id_FacturaVenta`),
  CONSTRAINT `FK_detalleventa_factura_venta_Id` FOREIGN KEY (`factura_venta_Id`) REFERENCES `factura_venta` (`Id`),
  CONSTRAINT `FK_detalleventa_Id_FacturaVenta` FOREIGN KEY (`Id_FacturaVenta`) REFERENCES `factura_venta` (`Id`),
  CONSTRAINT `fk_Id_Producto_Producto` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleventa`
--

LOCK TABLES `detalleventa` WRITE;
/*!40000 ALTER TABLE `detalleventa` DISABLE KEYS */;
INSERT INTO `detalleventa` VALUES (1,17,2,30,1,9,60,69,NULL,NULL),(2,NULL,3,25,0,11.25,75,86.25,NULL,NULL),(3,17,2,30,1,9,60,69,18,NULL),(4,NULL,3,25,0,11.25,75,86.25,18,NULL),(5,17,3,30,1,13.5,90,103.5,NULL,NULL),(6,5,4,12,0,7.2,48,55.2,NULL,NULL),(7,17,3,30,1,13.5,90,103.5,19,NULL),(8,5,4,12,0,7.2,48,55.2,19,NULL),(9,20,10,30,0,45,300,345,NULL,NULL),(10,20,10,30,0,45,300,345,20,NULL),(11,12,7,60,1,63,420,483,NULL,NULL),(12,12,7,60,1,63,420,483,21,NULL),(13,19,12,18,5,32.4,216,248.4,NULL,NULL),(14,19,5,18,5,13.5,90,103.5,NULL,NULL),(15,19,5,18,5,13.5,90,103.5,22,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (1,'Elmer David Laguna Matamoros','Administrador'),(40,'bere','inventario'),(41,'donal','venta'),(42,'NuevoEmpleado','GerenteAdministrativo'),(43,'prueba','venta');
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
  `Id_Empleado` int DEFAULT NULL,
  `Fecha` datetime(6) DEFAULT NULL,
  `No_Factura` varchar(50) DEFAULT NULL,
  `Id_Proveedor` int DEFAULT NULL,
  `Total` double DEFAULT NULL,
  `Id_Laboratorio` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `iId_Proveedor_factura_compra` (`Id_Proveedor`),
  KEY `iId_Laboratorio_factura_compra` (`Id_Laboratorio`),
  CONSTRAINT `factura_compra_ibfk_2` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `FK_factura_compra_Id_Laboratorio` FOREIGN KEY (`Id_Laboratorio`) REFERENCES `laboratorio` (`Id`) ON DELETE SET NULL,
  CONSTRAINT `FK_factura_compra_Id_Proveedor` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_compra`
--

LOCK TABLES `factura_compra` WRITE;
/*!40000 ALTER TABLE `factura_compra` DISABLE KEYS */;
INSERT INTO `factura_compra` VALUES (8,NULL,'2024-10-05 00:00:00.000000','000001',1,275,1),(9,NULL,'2024-10-05 00:00:00.000000','000002',1,295,4),(10,NULL,'2024-10-05 00:00:00.000000','000003',3,200,1),(11,NULL,'2024-10-09 00:00:00.000000','000004',1,300,2),(12,NULL,'2024-10-25 00:00:00.000000','000005',1,200,1),(13,NULL,'2024-10-25 00:00:00.000000','000006',1,1000,2),(14,NULL,'2024-10-25 00:00:00.000000','000007',NULL,40,NULL),(15,NULL,'2024-11-04 00:00:00.000000','000008',NULL,400,NULL),(16,NULL,'2024-11-04 00:00:00.000000','000009',NULL,1200,NULL),(17,1,'2024-11-18 00:00:00.000000','000010',15,60,10),(18,1,'2024-11-19 00:00:00.000000','000011',15,210,10);
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
  `Id_Cliente` int DEFAULT NULL,
  `Id_Empleado` int DEFAULT NULL,
  `Total_IVA` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `clientefkventa_idx` (`Id_Cliente`),
  CONSTRAINT `clientefkventa` FOREIGN KEY (`Id_Cliente`) REFERENCES `cliente` (`Id`) ON DELETE SET NULL,
  CONSTRAINT `factura_venta_ibfk_1` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_venta`
--

LOCK TABLES `factura_venta` WRITE;
/*!40000 ALTER TABLE `factura_venta` DISABLE KEYS */;
INSERT INTO `factura_venta` VALUES (1,'2024-10-25 00:00:00.000000','1',69,15,1,9),(5,'2024-10-25 00:00:00.000000','5',667,NULL,1,87),(7,'2024-11-02 00:00:00.000000','7',207,15,1,27),(8,'2024-11-02 00:00:00.000000','8',138,NULL,1,18),(9,'2024-11-02 00:00:00.000000','9',46,13,1,6),(10,'2024-11-02 00:00:00.000000','10',172.5,15,1,22.5),(12,'2024-11-04 00:00:00.000000','10',460,21,1,60),(13,'2024-11-04 00:00:00.000000','10',46,21,1,6),(14,'2024-11-04 00:00:00.000000','10',46,NULL,NULL,6),(15,'2024-11-04 00:00:00.000000','10',460,NULL,1,60),(16,'2024-11-04 00:00:00.000000','10',115,NULL,1,15),(17,'2024-11-04 00:00:00.000000','10',115,NULL,1,15),(18,'2024-11-04 00:00:00.000000','10',155.25,24,1,20.25),(19,'2024-11-04 00:00:00.000000','10',158.7,24,41,20.7),(20,'2024-11-07 00:00:00.000000','10',345,24,41,45),(21,'2024-11-18 00:00:00.000000','10',483,25,1,63),(22,'2024-11-19 00:00:00.000000','10',103.5,25,1,13.5);
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
  `Id_Proveedor` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `iId_Proveedor_laboratorio` (`Id_Proveedor`),
  CONSTRAINT `FK_laboratorio_Id_Proveedor` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `laboratorio`
--

LOCK TABLES `laboratorio` WRITE;
/*!40000 ALTER TABLE `laboratorio` DISABLE KEYS */;
INSERT INTO `laboratorio` VALUES (1,'Laboratorio Divina','Carret De Circunvalacion Km 91; León; León',0,NULL),(2,'Bayer','Bo La Primavera Siemens 1c Al Norte',0,NULL),(3,'Laboratorios Ramos',' Km 6 Carretera Norte. Managua, Nicaragua',0,NULL),(4,'Laboratorio CEGUEL','Pista Juan Pablo II Edificio César Guerrero  Managua, Nicaragua',0,NULL),(9,'la familia','chinandega',123454678,NULL),(10,'lab.Madrid','España',12345678,NULL);
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
  `Id_Laboratorio` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Id_Categoria_categoria` (`Id_Categoria`),
  KEY `fk_Id_Proveedor_proveedor` (`Id_Proveedor`),
  KEY `fk_Id_Producto_Laboratorio_idx` (`Id_Laboratorio`),
  CONSTRAINT `fk_Id_Categoria_categoria` FOREIGN KEY (`Id_Categoria`) REFERENCES `categoria` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Id_Producto_Laboratorio` FOREIGN KEY (`Id_Laboratorio`) REFERENCES `laboratorio` (`Id`) ON DELETE SET NULL,
  CONSTRAINT `fk_Id_Proveedor_proveedor` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (1,'Amigdocaina',20,30,0,85,'2025-12-11 00:00:00.000000',1,1,3),(2,'Acitromicina',10,15,0,80,'2025-08-04 00:00:00.000000',1,1,1),(3,'Doxiciclina',25,32,2,97,'2025-10-12 00:00:00.000000',1,2,1),(4,'Ibuprofeno',15,21,0,98,'2025-12-01 00:00:00.000000',2,2,2),(5,'Aspirina ',8,12,0,88,'2025-05-05 00:00:00.000000',2,3,3),(6,'Paracetamol ',5,8,0,93,'2025-11-11 00:00:00.000000',2,3,2),(8,'Enteroguanil',25,35,0,85,'2024-12-30 00:00:00.000000',1,1,1),(9,'condones',20,30,0,90,'2024-12-30 00:00:00.000000',20,1,1),(12,'cefalexina',40,60,1,10,'2025-01-15 00:00:00.000000',1,1,1),(17,'medicamento de prueva',25,31,1,10,'2024-12-30 00:00:00.000000',47,13,9),(19,'otro med',10,18,5,14,'2026-12-31 00:00:00.000000',48,14,10),(20,'benzatina',25,30,0,10,'2026-12-30 00:00:00.000000',1,1,3),(21,'amigdocaina',25,35,1,10,'2026-11-12 00:00:00.000000',1,6,10);
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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'Antonio Velazque','Carret De Circunvalacion Km 91; León; León'),(2,'Jose Lopez','Bo La Primavera Siemens 1c Al N'),(3,'Matias Mell',' Km 6 Carretera Norte. Managua, Nicaragua'),(6,'Augusto Fonseca','Pista Juan Pablo II Edificio César Guerrero Managua, Nicaragua'),(7,'Jose Guerrero','managua'),(13,'proveedor de prueva','chinandega'),(14,'segunda prueva','leon'),(15,'para restore','barcelona');
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
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador'),(17,'Consulta'),(18,'Vendedor');
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
  `pass` varchar(255) DEFAULT NULL,
  `Id_Empleado` int NOT NULL,
  `Id_Rol` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `usuario_UNIQUE` (`usuario`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `Id_Rol` (`Id_Rol`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `usuario_ibfk_2` FOREIGN KEY (`Id_Rol`) REFERENCES `rol` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'elmer','$2a$11$bsYHtYakHfVedSmMtwYs/.gyMRX4wu7iE2/Yrd5SeLV.vr5emZj/u',1,1),(38,'bere1','$2a$11$377rQ7rjfSd0E5YdSR2aBeadw7S7tg9Vb9lrFqTRT76/jP29ajRA.',40,17),(39,'donal1','$2a$11$aSoJ1r/ws/YxwPPfEEM0xuP1cGXvLcIX9qGUVqmEFGzrx.vy.ynOa',41,18);
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

-- Dump completed on 2024-11-21 16:30:05
