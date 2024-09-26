CREATE DATABASE  IF NOT EXISTS `el_porvenirdb`;
USE `el_porvenirdb`;
--
-- Table structure for table `categoria`
--
DROP TABLE IF EXISTS `categoria`;
CREATE TABLE `categoria` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Categorias` varchar(50) DEFAULT NULL,
  `Descripcion` longtext,
  PRIMARY KEY (`Id`)
);
--
-- Dumping data for table `categoria`
--
INSERT INTO `categoria` VALUES (1,'Antibioticos','Este es un antibiotico'),(2,'Analgesicos','Este es Un Analgesico');
--
-- Table structure for table `cliente`
--
DROP TABLE IF EXISTS `cliente`;
CREATE TABLE `cliente` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre_Completo` varchar(50) DEFAULT NULL,
  `Direccion` longtext,
  `Telefono` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
);
--
-- Dumping data for table `cliente`
--
INSERT INTO `cliente` VALUES (1,'Juan Perez','Esquina del gallo mas gallo 1 cuadra abajo',1111),(2,'Pedro Lopez','De los semaforos 1 Cuadra al Este',-1111),(12,'N/A','N/A',0);
--
-- Table structure for table `detallecompra`
--
DROP TABLE IF EXISTS `detallecompra`;
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
);
-- Table structure for table `detalleventa`
--
DROP TABLE IF EXISTS `detalleventa`;
CREATE TABLE `detalleventa` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Producto` int NOT NULL,
  `Cantidad` int NOT NULL,
  `Precio` double DEFAULT NULL,
  `Descuento` double DEFAULT NULL,
  `IVA` int NOT NULL,
  `SubTotal` double DEFAULT NULL,
  `Total` double DEFAULT NULL,
  `factura_venta_Id` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Id_Producto_Producto_idx` (`Id_Producto`),
  KEY `ifactura_venta_Id_detalleventa` (`factura_venta_Id`),
  CONSTRAINT `FK_detalleventa_factura_venta_Id` FOREIGN KEY (`factura_venta_Id`) REFERENCES `factura_venta` (`Id`),
  CONSTRAINT `fk_Id_Producto_Producto` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id`)
);
--
-- Table structure for table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
CREATE TABLE `empleado` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre_Completo` varchar(50) DEFAULT NULL,
  `Cargo` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
);
--
-- Dumping data for table `empleado`
--
INSERT INTO `empleado` VALUES (1,'Elmer David Laguna Matamoros','Administrador'),(9,'Jose Matias','Vendedor');
--
-- Table structure for table `factura_compra`
--
DROP TABLE IF EXISTS `factura_compra`;
CREATE TABLE `factura_compra` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Empleado` int NOT NULL,
  `Fecha` datetime(6) DEFAULT NULL,
  `No_Factura` varchar(50) DEFAULT NULL,
  `Id_Proveedor` int DEFAULT NULL,
  `Total` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Empleado` (`Id_Empleado`),
  CONSTRAINT `factura_compra_ibfk_2` FOREIGN KEY (`Id_Empleado`) REFERENCES `empleado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
);
--
-- Table structure for table `factura_venta`
--
DROP TABLE IF EXISTS `factura_venta`;
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
);
--
-- Table structure for table `laboratorio`
--
DROP TABLE IF EXISTS `laboratorio`;
CREATE TABLE `laboratorio` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  `Direccion` longtext,
  `Telefono` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
);
--
-- Dumping data for table `laboratorio`
--
INSERT INTO `laboratorio` VALUES (1,'Laboratorio Divina','Esta es la direccion del labortario A',0),(2,'Bayer','Esta es la direccion del labortario B',0),(3,'Laboratorios Ramos','Esta es la direccion del labortario C',0),(4,'Laboratorio CEGUEL','Esta es la direccion del labortario C',0);
--
-- Table structure for table `producto`
--
DROP TABLE IF EXISTS `producto`;
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
);
--
-- Dumping data for table `producto`
--
INSERT INTO `producto` VALUES (1,'Amigdocaina',20,30,0,100,'2025-12-11 00:00:00.000000',1,1,3),(2,'Acitromicina',10,15,0,100,'2025-08-04 00:00:00.000000',1,1,1),(3,'Doxiciclina',25,32,2,100,'2025-10-12 00:00:00.000000',1,2,1),(4,'Ibuprofeno',15,21,0,100,'2025-12-01 00:00:00.000000',2,2,2),(5,'Aspirina ',8,12,0,100,'2025-05-05 00:00:00.000000',2,3,3),(6,'Paracetamol ',5,8,0,100,'2025-11-11 00:00:00.000000',2,3,2);
--
-- Table structure for table `proveedor`
--
DROP TABLE IF EXISTS `proveedor`;
CREATE TABLE `proveedor` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  `Direccion` longtext,
  PRIMARY KEY (`Id`)
);
--
-- Dumping data for table `proveedor`
--
INSERT INTO `proveedor` VALUES (1,'Proveedor A','Esta es la direcccion del proveedor'),(2,'Proveedor B','Esta es la direccion del proveedor B'),(3,'Proveedor C','Esta es la direccion del proveedor C');
--
-- Table structure for table `rol`
--
DROP TABLE IF EXISTS `rol`;
CREATE TABLE `rol` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre_Rol` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Rol` (`Nombre_Rol`)
);
--
-- Dumping data for table `rol`
--
INSERT INTO `rol` VALUES (1,'Administrador');
--
-- Table structure for table `usuario`
--
DROP TABLE IF EXISTS `usuario`;
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
);
--
-- Dumping data for table `usuario`
--
INSERT INTO `usuario` VALUES (1,'admin','admin123*',1,1);