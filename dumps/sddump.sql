-- MySQL dump 10.13  Distrib 8.0.32, for Linux (x86_64)
--
-- Host: localhost    Database: studentdormitory
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `iduser` int unsigned NOT NULL AUTO_INCREMENT,
  `login` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `admin` tinyint NOT NULL,
  PRIMARY KEY (`iduser`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin',1),(2,'user1','user1',0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `инвентарь`
--

DROP TABLE IF EXISTS `инвентарь`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `инвентарь` (
  `idинвентаря` int unsigned NOT NULL AUTO_INCREMENT,
  `наименование` varchar(45) DEFAULT NULL,
  `idкомнаты` int unsigned DEFAULT NULL,
  `кол-во на комнату` int unsigned DEFAULT NULL,
  `дата установки/выдачи` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idинвентаря`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `инвентарь`
--

LOCK TABLES `инвентарь` WRITE;
/*!40000 ALTER TABLE `инвентарь` DISABLE KEYS */;
/*!40000 ALTER TABLE `инвентарь` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `комнаты`
--

DROP TABLE IF EXISTS `комнаты`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `комнаты` (
  `idкомнаты` int unsigned NOT NULL AUTO_INCREMENT,
  `количество мест` int DEFAULT NULL,
  `жилая площадь` float DEFAULT NULL,
  PRIMARY KEY (`idкомнаты`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `комнаты`
--

LOCK TABLES `комнаты` WRITE;
/*!40000 ALTER TABLE `комнаты` DISABLE KEYS */;
/*!40000 ALTER TABLE `комнаты` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `нарушения`
--

DROP TABLE IF EXISTS `нарушения`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `нарушения` (
  `idнарушения` int unsigned NOT NULL AUTO_INCREMENT,
  `нарушение` varchar(45) DEFAULT NULL,
  `дата происшествия` datetime DEFAULT NULL,
  `idкомнаты` int unsigned DEFAULT NULL,
  `idстудента` int unsigned DEFAULT NULL,
  PRIMARY KEY (`idнарушения`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `нарушения`
--

LOCK TABLES `нарушения` WRITE;
/*!40000 ALTER TABLE `нарушения` DISABLE KEYS */;
/*!40000 ALTER TABLE `нарушения` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `студенты`
--

DROP TABLE IF EXISTS `студенты`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `студенты` (
  `idстудента` int unsigned NOT NULL AUTO_INCREMENT,
  `имя` varchar(45) NOT NULL,
  `фамилия` varchar(45) NOT NULL,
  `idкомнаты` int unsigned DEFAULT NULL,
  `пол` varchar(45) DEFAULT NULL,
  `группа` varchar(45) DEFAULT NULL,
  `дата заселения` date DEFAULT NULL,
  PRIMARY KEY (`idстудента`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `студенты`
--

LOCK TABLES `студенты` WRITE;
/*!40000 ALTER TABLE `студенты` DISABLE KEYS */;
/*!40000 ALTER TABLE `студенты` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-23  3:05:52
