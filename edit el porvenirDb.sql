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
  `Categorias` varchar(50) DEFAULT NULL,
  `Descripcion` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Antibioticos','Este es un antibiotico'),(2,'Analgesicos','Este es Un Analgesico');
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
  `Precio` float DEFAULT NULL,
  `Total` float DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Id_producto_Producto_idx` (`Id_Producto`),
  KEY `fk_factura_compra_Id_FacturaCompra` (`Id_FacturaCompra`),
  CONSTRAINT `fk_factura_compra_Id_FacturaCompra` FOREIGN KEY (`Id_FacturaCompra`) REFERENCES `factura_compra` (`Id`),
  CONSTRAINT `fk_Producto_Id_producto` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detallecompra`
--

LOCK TABLES `detallecompra` WRITE;
/*!40000 ALTER TABLE `detallecompra` DISABLE KEYS */;
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
  `Id_FacturaVenta` int NOT NULL,
  `Id_Producto` int NOT NULL,
  `Cantidad` int NOT NULL,
  `Precio` float NOT NULL,
  `Descuento` float NOT NULL,
  `IVA` int NOT NULL,
  `SubTotal` float NOT NULL,
  `Total` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `detalleventa_ibfk_1` (`Id_FacturaVenta`),
  KEY `fk_Id_Producto_Producto_idx` (`Id_Producto`),
  CONSTRAINT `detalleventa_ibfk_1` FOREIGN KEY (`Id_FacturaVenta`) REFERENCES `factura_venta` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Id_Producto_Producto` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleventa`
--

LOCK TABLES `detalleventa` WRITE;
/*!40000 ALTER TABLE `detalleventa` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (1,'Elmer David Laguna Matamoros','Administrador'),(9,'Jose Matias','Vendedor');
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
  `Fecha` date DEFAULT NULL,
  `No_Factura` varchar(50) DEFAULT NULL,
  `Id_Proveedor` int DEFAULT NULL,
  `Total` float DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  CONSTRAINT `factura_compra_ibfk_2` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_compra`
--

LOCK TABLES `factura_compra` WRITE;
/*!40000 ALTER TABLE `factura_compra` DISABLE KEYS */;
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
  `Fecha` date DEFAULT NULL,
  `No_Factura` int DEFAULT NULL,
  `Total_Factura` float NOT NULL,
  `Id_Cliente` int NOT NULL,
  `Id_Empleado` int NOT NULL,
  `Total_IVA` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  KEY `clientefkventa_idx` (`Id_Cliente`),
  CONSTRAINT `clientefkventa` FOREIGN KEY (`Id_Cliente`) REFERENCES `cliente` (`Id`),
  CONSTRAINT `factura_venta_ibfk_1` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_venta`
--

LOCK TABLES `factura_venta` WRITE;
/*!40000 ALTER TABLE `factura_venta` DISABLE KEYS */;
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
  `Precio_Compra` float DEFAULT NULL,
  `Precio_Venta` float DEFAULT NULL,
  `Descuento` float DEFAULT NULL,
  `Stock` int DEFAULT NULL,
  `Vencimiento` date DEFAULT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (1,'Amigdocaina',20,30,0,100,'2025-12-11',1,1,3),(2,'Acitromicina',10,15,0,100,'2025-08-04',1,1,1),(3,'Doxiciclina',25,32,2,100,'2025-10-12',1,2,1),(4,'Ibuprofeno',15,21,0,100,'2025-12-01',2,2,2),(5,'Aspirina ',8,12,0,100,'2025-05-05',2,3,3),(6,'Paracetamol ',5,8,0,100,'2025-11-11',2,3,2);
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
  `Direccion` text,
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador');
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'admin','admin123*',1,1);
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

-- Dump completed on 2024-09-24 22:40:55
