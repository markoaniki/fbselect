-- MySQL dump 10.13  Distrib 8.0.17, for macos10.14 (x86_64)
--
-- Host: 127.0.0.1    Database: fbselect
-- ------------------------------------------------------
-- Server version	8.0.17

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
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admin` (
  `UserName` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `canRegister` bit(8) NOT NULL,
  `Info_ID` int(11) NOT NULL,
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID`),
  KEY `Info_ID` (`Info_ID`),
  CONSTRAINT `admin_ibfk_1` FOREIGN KEY (`Info_ID`) REFERENCES `info` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES ('admin','admin',_binary '',1,1),('adminnpc','adminnpc',_binary '',2,2);
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `info`
--

DROP TABLE IF EXISTS `info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `info` (
  `ID` int(255) NOT NULL AUTO_INCREMENT,
  `telefone` varchar(20) NOT NULL,
  `email` varchar(255) NOT NULL,
  `nome_responsavel` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `info`
--

LOCK TABLES `info` WRITE;
/*!40000 ALTER TABLE `info` DISABLE KEYS */;
INSERT INTO `info` VALUES (1,'85986085880','markocme2@hotmail.com','Marko Ido'),(2,'2656561561','g@hhdh.com','User2'),(3,'12312313','aluno@fb.edu.br','Joao');
/*!40000 ALTER TABLE `info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `MAX_SCORES` int(11) NOT NULL,
  `TENTATIVAS` int(11) NOT NULL,
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student` (
  `inscription` int(11) NOT NULL,
  `admin_ID` int(11) NOT NULL,
  `Info_ID` int(11) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `birthdate` varchar(45) DEFAULT NULL,
  `grade` varchar(45) DEFAULT NULL,
  `oldSchool` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (123,1,1,1,'Fulano','123123132','fulano@ffb.edu.br','01/01/2013','1','Colégio FB Júnior'),(124,1,2,2,'Fulano 2','22222222','Beltrano@ffb.edu.br','02/02/2014','2','Colégio FB Junior'),(123,2,4,4,'Pedro',NULL,NULL,'01/01/2000','Serie do aluno','Escola antiga'),(1234,2,5,8,'Joao',NULL,NULL,'01/01/2010','2','Escola anterior'),(1234,2,5,9,'zzzz',NULL,NULL,'01/01/2010','2','Escola anterior'),(1234,2,5,10,'yyyy',NULL,NULL,'01/01/2010','3','Escola anterior'),(1234,2,5,11,'aaaa',NULL,NULL,'01/01/2010','3','Escola anterior'),(1234,2,5,12,'asdadasdas',NULL,NULL,'01/01/2010','3','Escola anterior');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studentquestiontable`
--

DROP TABLE IF EXISTS `studentquestiontable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `studentquestiontable` (
  `STUDENT_ID` int(11) NOT NULL,
  `QUESTION_ID` int(11) NOT NULL,
  `Scores` int(11) NOT NULL,
  `Time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID`),
  KEY `STUDENT_ID` (`STUDENT_ID`),
  KEY `QUESTION_ID` (`QUESTION_ID`),
  CONSTRAINT `studentquestiontable_ibfk_1` FOREIGN KEY (`STUDENT_ID`) REFERENCES `student` (`id`),
  CONSTRAINT `studentquestiontable_ibfk_2` FOREIGN KEY (`QUESTION_ID`) REFERENCES `questions` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studentquestiontable`
--

LOCK TABLES `studentquestiontable` WRITE;
/*!40000 ALTER TABLE `studentquestiontable` DISABLE KEYS */;
/*!40000 ALTER TABLE `studentquestiontable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'fbselect'
--

--
-- Dumping routines for database 'fbselect'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-09-10 16:56:11
