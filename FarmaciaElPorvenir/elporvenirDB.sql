CREATE DATABASE  IF NOT EXISTS `el_porvenirdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `el_porvenirdb`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: el_porvenirdb
-- ------------------------------------------------------
-- Server version	8.0.39

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
  `Categoria` varchar(50) DEFAULT NULL,
  `Descripcion` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Antibióticos','Medicamentos utilizados para tratar infecciones bacterianas.'),(2,'Analgésicos','Medicamentos que alivian el dolor sin causar pérdida de conciencia.'),(3,'Antiinflamatorios','Medicamentos que reducen la inflamación y alivian el dolor.'),(4,'Antihistamínicos','Medicamentos que tratan las reacciones alérgicas bloqueando la histamina.'),(5,'Antidepresivos','Medicamentos utilizados para tratar trastornos del estado de ánimo, como la depresión.'),(6,'Antipiréticos','Medicamentos que reducen la fiebre.'),(7,'Antifúngicos','Medicamentos que tratan infecciones causadas por hongos.'),(8,'Antivirales','Medicamentos que tratan infecciones virales.'),(9,'Broncodilatadores','Medicamentos que relajan los músculos de las vías respiratorias y mejoran la respiración.'),(10,'Diuréticos','Medicamentos que ayudan a eliminar el exceso de líquidos del cuerpo.'),(11,'Laxantes','Medicamentos que facilitan la evacuación intestinal.'),(12,'Anticoagulantes','Medicamentos que previenen la formación de coágulos sanguíneos.'),(13,'Antipsicóticos','Medicamentos utilizados para tratar trastornos psiquiátricos como la esquizofrenia.'),(14,'Inmunosupresores','Medicamentos que reducen la actividad del sistema inmunológico.'),(15,'Antiparasitarios','Medicamentos utilizados para tratar infecciones causadas por parásitos.'),(16,'Esteroides','Medicamentos que imitan los efectos de las hormonas producidas por las glándulas suprarrenales.');
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
  `Direccion` text,
  `Telefono` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Ana Martínez','Calle Falsa 123, Ciudad',12345678),(2,'Carlos Gómez','Avenida Siempre Viva 742, Ciudad',23456789),(3,'Marta Rodríguez','Plaza Mayor 10, Ciudad',34567890),(4,'Luis Fernández','Calle del Sol 45, Ciudad',45678901),(5,'Laura Pérez','Avenida de la Paz 30, Ciudad',56789012),(7,'hola mundo','mundo',1233);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (1,'Juan Pérez','Gerente de Ventas'),(2,'Lucía Fernández','Contadora'),(3,'Pedro Gómez','Desarrollador de Software'),(4,'Ana Ruiz','Asistente Administrativo'),(5,'Carlos Martínez','Representante de Servicio al Cliente');
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
  `Fecha` date DEFAULT NULL,
  `No_Factura` varchar(50) DEFAULT NULL,
  `Id_Proveedor` int DEFAULT NULL,
  `Id_Medicamento` int DEFAULT NULL,
  `Cantidad` int DEFAULT NULL,
  `Precio_Compra` float DEFAULT NULL,
  `Total` float DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Medicamento` (`Id_Medicamento`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `Id_Proveedor` (`Id_Proveedor`),
  CONSTRAINT `factura_compra_ibfk_1` FOREIGN KEY (`Id_Medicamento`) REFERENCES `medicamento` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_compra_ibfk_2` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_compra_ibfk_3` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_compra`
--

LOCK TABLES `factura_compra` WRITE;
/*!40000 ALTER TABLE `factura_compra` DISABLE KEYS */;
INSERT INTO `factura_compra` VALUES (1,1,'2024-08-01','FC001',1,1,50,12,600),(2,2,'2024-08-05','FC002',2,2,30,8.5,255),(3,3,'2024-08-10','FC003',3,3,20,5,100),(4,4,'2024-08-15','FC004',1,4,40,25,1000),(5,5,'2024-08-20','FC005',2,5,60,6,360);
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
  `Id_Empleado` int DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `No_Factura` varchar(50) DEFAULT NULL,
  `Id_Inventario` int DEFAULT NULL,
  `Cantidad` int DEFAULT NULL,
  `Precio` float DEFAULT NULL,
  `IVA` decimal(5,2) DEFAULT NULL,
  `Total` float DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `Id_Inventario` (`Id_Inventario`),
  CONSTRAINT `factura_venta_ibfk_1` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `factura_venta_ibfk_2` FOREIGN KEY (`Id_Inventario`) REFERENCES `inventario` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_venta`
--

LOCK TABLES `factura_venta` WRITE;
/*!40000 ALTER TABLE `factura_venta` DISABLE KEYS */;
INSERT INTO `factura_venta` VALUES (1,1,'2024-08-02','FV001',1,10,15.5,2.50,157),(2,2,'2024-08-06','FV002',2,5,10.75,1.50,56.25),(3,3,'2024-08-11','FV003',3,8,7.3,1.00,59.4),(4,4,'2024-08-16','FV004',4,12,25,3.50,318.5),(5,5,'2024-08-21','FV005',5,15,6.5,0.90,103.4);
/*!40000 ALTER TABLE `factura_venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventario`
--

DROP TABLE IF EXISTS `inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventario` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Medicamento` int DEFAULT NULL,
  `Stock` int DEFAULT NULL,
  `Precio_Compra` float DEFAULT NULL,
  `Precio_Venta` float DEFAULT NULL,
  `Fecha_Vencimiento` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Medicamento` (`Id_Medicamento`),
  CONSTRAINT `inventario_ibfk_1` FOREIGN KEY (`Id_Medicamento`) REFERENCES `medicamento` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventario`
--

LOCK TABLES `inventario` WRITE;
/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
INSERT INTO `inventario` VALUES (1,1,100,15.5,20,'2025-12-31'),(2,2,150,10.75,14,'2024-11-30'),(3,3,200,7.3,9,'2025-05-15'),(4,4,80,25,32,'2026-07-01'),(5,5,120,6.5,8,'2024-09-15'),(6,6,60,12,16,'2025-03-31'),(7,7,75,20,27,'2025-10-10'),(8,8,90,11,15,'2024-12-20'),(9,9,50,8.25,11,'2025-08-30'),(10,10,140,5,7,'2025-06-15'),(11,11,30,18,24,'2024-04-20'),(12,12,85,22.5,30,'2026-01-01'),(13,13,95,14,18,'2024-11-01'),(14,14,70,16,21,'2025-09-15'),(15,15,110,25,33,'2025-12-01'),(16,16,100,15.5,20,'2025-12-31'),(17,17,120,10.75,14,'2024-11-30'),(18,18,130,7.3,9,'2025-05-15'),(19,19,90,25,32,'2026-07-01'),(20,20,80,6.5,8,'2024-09-15');
/*!40000 ALTER TABLE `inventario` ENABLE KEYS */;
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
  `Direccion` text,
  `Telefono` int DEFAULT NULL,
  `Id_Proveedor` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Proveedor` (`Id_Proveedor`),
  CONSTRAINT `laboratorio_ibfk_1` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `laboratorio`
--

LOCK TABLES `laboratorio` WRITE;
/*!40000 ALTER TABLE `laboratorio` DISABLE KEYS */;
INSERT INTO `laboratorio` VALUES (1,'Laboratorio A','Calle de la Ciencia 100, Ciudad',12345678,1),(2,'Laboratorio B','Avenida de la Salud 200, Ciudad',23456789,2),(3,'Laboratorio C','Plaza de la Innovación 300, Ciudad',34567890,3),(4,'Laboratorio D','Calle de la Tecnología 400, Ciudad',45678901,1),(5,'Laboratorio E','Avenida de la Investigación 500, Ciudad',56789012,2);
/*!40000 ALTER TABLE `laboratorio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicamento`
--

DROP TABLE IF EXISTS `medicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicamento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  `Precio` float DEFAULT NULL,
  `Id_Categoria` int DEFAULT NULL,
  `Id_Laboratorio` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Categoria` (`Id_Categoria`),
  KEY `Id_Laboratorio` (`Id_Laboratorio`),
  CONSTRAINT `medicamento_ibfk_1` FOREIGN KEY (`Id_Categoria`) REFERENCES `categoria` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `medicamento_ibfk_2` FOREIGN KEY (`Id_Laboratorio`) REFERENCES `laboratorio` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicamento`
--

LOCK TABLES `medicamento` WRITE;
/*!40000 ALTER TABLE `medicamento` DISABLE KEYS */;
INSERT INTO `medicamento` VALUES (1,'Amoxicilina',NULL,1,1),(2,'Ibuprofeno',NULL,3,2),(3,'Loratadina',NULL,4,3),(4,'Sertralina',NULL,5,1),(5,'Paracetamol',NULL,3,4),(6,'Fluconazol',NULL,7,2),(7,'Oseltamivir',NULL,8,3),(8,'Salbutamol',NULL,9,1),(9,'Furosemida',NULL,10,2),(10,'Lactulosa',NULL,11,3),(11,'Warfarina',NULL,12,4),(12,'Risperidona',NULL,13,1),(13,'Azatioprina',NULL,14,2),(14,'Mebendazol',NULL,15,3),(15,'Prednisona',NULL,6,4),(16,'Ciprofloxacino',NULL,1,2),(17,'Naproxeno',NULL,3,3),(18,'Cetirizina',NULL,4,1),(19,'Duloxetina',NULL,5,2),(20,'Aspirina',NULL,3,3);
/*!40000 ALTER TABLE `medicamento` ENABLE KEYS */;
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
  `Direccion` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'Proveedor A','Calle de la Industria 50, Ciudad'),(2,'Proveedor B','Avenida Comercial 15, Ciudad'),(3,'Proveedor C','Plaza de los Negocios 20, Ciudad');
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
  `Rol` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Rol` (`Rol`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador'),(3,'Gerente'),(2,'Vendedor');
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
  `Id_Empleado` int DEFAULT NULL,
  `Id_Rol` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `Id_Rol` (`Id_Rol`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `usuario_ibfk_2` FOREIGN KEY (`Id_Rol`) REFERENCES `rol` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-04 10:57:16
