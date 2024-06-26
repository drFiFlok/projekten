CREATE DATABASE  IF NOT EXISTS `bc_database` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bc_database`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: bc_database
-- ------------------------------------------------------
-- Server version	8.4.0

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
-- Table structure for table `bcdb`
--

DROP TABLE IF EXISTS `bcdb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bcdb` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Company` varchar(75) DEFAULT NULL,
  `Firstname` varchar(45) DEFAULT NULL,
  `Lastname` varchar(45) DEFAULT NULL,
  `Title` varchar(15) DEFAULT NULL,
  `Email` varchar(75) DEFAULT NULL,
  `Website` varchar(45) DEFAULT NULL,
  `Workphone` varchar(45) DEFAULT NULL,
  `Mobilephone` varchar(45) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `Zipcode` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `Comments` longtext,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bcdb`
--

LOCK TABLES `bcdb` WRITE;
/*!40000 ALTER TABLE `bcdb` DISABLE KEYS */;
INSERT INTO `bcdb` VALUES (1,'Prohibeosssss','Peder','Thornstrom','PP','xxxt@prohibeo.com','www.prohibeo.com','555-123456','555-987654','7 Jalan Desa Kiara,\nKiaramas Sutera,\nMont Kiara,','5','Kuala Lumpur','Malaysia','No comments yet'),(5,'J Doe Management','John','Doe','CEO','jd@jdm.com','www.jdm.com','555-445566','555-776655','Lower Big Valley','45678','Small Town','Another Country','1 comment'),(18,'TrustIT','Desmond','Smith','CTO','ds@TrustIt.com','www.TrustIt.com','555-235467','555-879623','Street 1','90000','Major City','Trastland','So far just this comment'),(19,'Weather Station','Chris','Storm','HR Manager','Chris.Storm@WeatherStation.org','www.WeatherStation.org','555-909090','555-808080','Autum Roads','123456','Winter City','Winterland','-2°C'),(22,'Malaysia Food','Richard','Ng','Mr','rn@MFood.com','www.MFood.com.my','555-192837','555-384756','7 Jalan Food street','60000','TTDI','Malaysia','Out of food'),(24,'Travel the World','Stan','Buck','Traveler','go@TTW.net','www.ttw.net','555-674589','555-127644','66 New World Street','666666','New City','EU','No comments yet.'),(27,'Beer Company','Tiger','Carlsberg','Taster','TC@BC.io','www.bc.io','555-019283','555-785634','5 New Road','129845','New Town','New Country','Heineken');
/*!40000 ALTER TABLE `bcdb` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-26 23:25:10
