-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: payroll
-- ------------------------------------------------------
-- Server version	8.0.20

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
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `idEmployee` int NOT NULL,
  `Employee_Number` int unsigned NOT NULL,
  `Last_Name` varchar(45) NOT NULL,
  `First_Name` varchar(45) NOT NULL,
  `SSN` decimal(10,0) DEFAULT NULL,
  `Pay_Rate` varchar(40) DEFAULT NULL,
  `Pay_Rates_idPay_Rates` int NOT NULL,
  `Vacation_Days` int DEFAULT NULL,
  `Paid To Date` decimal(2,0) DEFAULT NULL,
  `Paid_Last_Year` decimal(2,0) DEFAULT NULL,
  PRIMARY KEY (`Employee_Number`,`Pay_Rates_idPay_Rates`),
  UNIQUE KEY `Employee Number_UNIQUE` (`Employee_Number`),
  KEY `fk_Employee_Pay Rates` (`Pay_Rates_idPay_Rates`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (111,11,'phu','nguyen thanh',NULL,NULL,1,1,NULL,NULL),(112,12,'hoan','pham le',NULL,NULL,2,5,NULL,NULL),(113,13,'toi','nguyen van',NULL,NULL,3,4,NULL,NULL),(114,14,'ni','thi le',NULL,NULL,4,6,NULL,NULL),(115,15,'thuong','nguyen thi',NULL,NULL,5,2,NULL,NULL),(116,16,'duy','vo van',NULL,NULL,6,3,NULL,NULL);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pay_rates`
--

DROP TABLE IF EXISTS `pay_rates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pay_rates` (
  `idPay_Rates` int NOT NULL,
  `Pay_Rate_Name` varchar(40) DEFAULT NULL,
  `Value` decimal(10,0) DEFAULT NULL,
  `Tax_Percentage` decimal(10,0) DEFAULT NULL,
  `Pay_Type` int DEFAULT NULL,
  `Pay_Amount` decimal(10,0) DEFAULT NULL,
  `PT-Level C` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`idPay_Rates`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pay_rates`
--

LOCK TABLES `pay_rates` WRITE;
/*!40000 ALTER TABLE `pay_rates` DISABLE KEYS */;
INSERT INTO `pay_rates` VALUES (1,NULL,NULL,NULL,NULL,NULL,NULL),(2,NULL,NULL,NULL,NULL,NULL,NULL),(3,NULL,NULL,NULL,NULL,NULL,NULL),(4,NULL,NULL,NULL,NULL,NULL,NULL),(5,NULL,NULL,NULL,NULL,NULL,NULL),(6,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `pay_rates` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-30 23:59:15
