-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: rojakjelah
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `dictionary_entry`
--

DROP TABLE IF EXISTS `dictionary_entry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dictionary_entry` (
  `dictionary_entry_id` int unsigned NOT NULL AUTO_INCREMENT,
  `slang_id` int unsigned NOT NULL,
  `translation_id` int unsigned NOT NULL,
  `example` varchar(100) DEFAULT NULL,
  `created_by` int unsigned DEFAULT NULL,
  `creation_date` datetime NOT NULL,
  `modified_by` int unsigned DEFAULT NULL,
  `modification_date` datetime NOT NULL,
  PRIMARY KEY (`dictionary_entry_id`),
  UNIQUE KEY `slang_translation_UNIQUE` (`slang_id`,`translation_id`),
  KEY `fk_dictionary_entry_slang_word_idx` (`slang_id`),
  KEY `fk_dictionary_entry_translation_word_idx` (`translation_id`),
  KEY `fk_dictionary_entry_createdby_users_idx` (`created_by`),
  KEY `fk_dictionaryentry_modifiedby_users_idx` (`modified_by`) /*!80000 INVISIBLE */,
  CONSTRAINT `fk_dictionaryentry_createdby_users` FOREIGN KEY (`created_by`) REFERENCES `users` (`user_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_dictionaryentry_modifiedby_users` FOREIGN KEY (`modified_by`) REFERENCES `users` (`user_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_dictionaryentry_slang_word` FOREIGN KEY (`slang_id`) REFERENCES `word` (`word_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_dictionaryentry_translation_word` FOREIGN KEY (`translation_id`) REFERENCES `word` (`word_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dictionary_entry`
--

LOCK TABLES `dictionary_entry` WRITE;
/*!40000 ALTER TABLE `dictionary_entry` DISABLE KEYS */;
INSERT INTO `dictionary_entry` VALUES (1,1,55,'Why are you so blur about this?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(2,2,56,'Rilek lah, nothing will happen.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(3,3,57,'Bos, I will get it done as soon as possible.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(4,3,58,'Bos, one nasi lemak!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(5,3,59,'Bos, one nasi lemak!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(6,4,115,'Aiyer, he so yellow one, let\'s stay away from him.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(7,4,116,'Bro, maybe you should stop playing dirty jokes with them, they think you very yellow.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(8,5,76,'Alamak, what do we do now?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(9,6,77,'Aduh, my leg hurts.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(10,6,78,'Aduh, my leg hurts.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(11,7,79,'Fuyoh! Uncle Roger is impressed.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(12,8,80,'Jom! Let\'s go there now.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(13,9,81,'Don\'t kacau the dog.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(14,10,83,'Ey, diam lah!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(15,10,84,'Eh, why this class so diam one?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(16,11,85,'That restaurant\'s food best giler if you want to eat nearby.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(17,11,86,'That restaurant\'s food best giler if you want to eat nearby.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(18,12,72,'Bungkus nasi lemak satu!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(19,13,87,'Anything you need, just roger me.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(20,14,89,'This movie is really syok.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(21,14,85,'This movie is really syok.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(22,15,90,'Ya! Poyo siol.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(23,16,91,'My friend is a mat salleh from Spain.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(24,16,92,'My friend is a mat salleh from Spain.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(25,17,93,'We can all kongsi money la.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(26,18,79,'Ey, gempak! I didn\'t know you can sing so well!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(27,19,94,'',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(28,20,95,'This budak is mantap.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(29,20,85,'This budak is mantap.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(30,21,96,'Pastu, how do we do this?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(31,22,70,'Let\'s lepak jom!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(32,23,97,'Huh? Potong stim lah you!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(33,23,98,'Huh? Potong stim lah you!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(34,24,99,'That lady driving gila wei.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(35,25,100,'Haiyo, these reckless drivers so bodoh one.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(36,25,101,'What is this bodoh doing?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(37,26,102,'Ntah, maybe it\'s over there?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(38,27,103,'That guy koyak already.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(39,27,104,'That guy koyak already.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(40,28,105,'Walao, Tom Hanks so sado in that movie!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(41,29,106,'Bosan lah. Let\'s do something else.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(42,30,107,'This meeting wayang only lah. You think they going to promote you meh?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(43,31,61,'Abang, can you get me a drink?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(44,31,62,'Abang, can you get me a drink?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(45,32,61,'Ey bang, can you get me a drink?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(46,32,62,'Ey bang, can you get me a drink?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(47,33,117,'The number of students in this class agak-agak 10 only.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(48,34,112,'This guy playing game also so toxic, make me geram only.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(49,35,114,'That university is in quite an ulu area, so keep that in mind if you want to study there.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(50,36,60,'Macha, where are you going?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(51,37,61,'Dei! Where are you going?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(52,37,62,'Dei! Where are you going?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(53,37,60,'Dei! Where are you going?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(54,38,63,'Elek, go ask someone else.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(55,39,64,'Can gostan some more!',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(56,40,65,'Why you bo jio?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(57,41,82,'Cincai lah. I\'m fine with anything you choose.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(58,42,66,'Abuden? What else could it be?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(59,43,67,'Chup! Where are we going to eat ah?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(60,44,68,'',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(61,44,69,'',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(62,45,91,'He is ang moh, but he has been living in Malaysia for 10 years already.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(63,46,70,'Let\'s yum cha when you\'re free?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(64,46,71,'Let\'s yum cha when you\'re free?',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(65,47,72,'I go tapau chicken rice.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(66,48,73,'I pokai already la.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(67,48,74,'I pokai already la.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(68,49,91,'My friend is a guai lou from America.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(69,49,92,'My friend is a guai lou from America.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(70,50,75,'Don\'t worry, I will kautim that problem for you.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(71,51,109,'I really hate that guy wei, he always so lan si one.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(72,52,110,'That aunty calls every guy leng zai, don\'t think too much.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(73,53,111,'He only likes to go there because got a lot of leng lui there.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09'),(74,54,113,'Yesterday\'s exam sup-sup sui, right? Confirm pass already.',1,'2022-12-02 21:23:09',1,'2022-12-02 21:23:09');
/*!40000 ALTER TABLE `dictionary_entry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `languages`
--

DROP TABLE IF EXISTS `languages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `languages` (
  `language_id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`language_id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `languages`
--

LOCK TABLES `languages` WRITE;
/*!40000 ALTER TABLE `languages` DISABLE KEYS */;
INSERT INTO `languages` VALUES (7,'Cantonese'),(1,'English'),(6,'Hokkien'),(2,'Malay'),(3,'Mandarin'),(5,'Maritime English'),(4,'Tamil');
/*!40000 ALTER TABLE `languages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report`
--

DROP TABLE IF EXISTS `report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `report` (
  `report_id` int unsigned NOT NULL AUTO_INCREMENT,
  `dictionary_entry_id` int unsigned DEFAULT NULL,
  `report_category_id` tinyint unsigned NOT NULL,
  `description` varchar(500) DEFAULT NULL,
  `report_status_id` tinyint unsigned NOT NULL,
  `created_by` int unsigned DEFAULT NULL,
  `creation_date` datetime NOT NULL,
  `modified_by` int unsigned DEFAULT NULL,
  `modification_date` datetime NOT NULL,
  PRIMARY KEY (`report_id`),
  KEY `fk_report_dictionaryentry_idx` (`dictionary_entry_id`),
  KEY `fk_report_reportcategory_idx` (`report_category_id`),
  KEY `fk_report_reportstatus_idx` (`report_status_id`),
  KEY `fk_report_createdby_users_idx` (`created_by`),
  KEY `fk_report_modifiedby_users_idx` (`modified_by`),
  CONSTRAINT `fk_report_createdby_users` FOREIGN KEY (`created_by`) REFERENCES `users` (`user_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_report_dictionaryentry` FOREIGN KEY (`dictionary_entry_id`) REFERENCES `dictionary_entry` (`dictionary_entry_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_report_modifiedby_users` FOREIGN KEY (`modified_by`) REFERENCES `users` (`user_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_report_reportcategory` FOREIGN KEY (`report_category_id`) REFERENCES `report_category` (`report_category_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_report_reportstatus` FOREIGN KEY (`report_status_id`) REFERENCES `report_status` (`report_status_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report`
--

LOCK TABLES `report` WRITE;
/*!40000 ALTER TABLE `report` DISABLE KEYS */;
/*!40000 ALTER TABLE `report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report_category`
--

DROP TABLE IF EXISTS `report_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `report_category` (
  `report_category_id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`report_category_id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report_category`
--

LOCK TABLES `report_category` WRITE;
/*!40000 ALTER TABLE `report_category` DISABLE KEYS */;
INSERT INTO `report_category` VALUES (1,'Duplicate entry'),(3,'Inappropriate or sensitive'),(2,'Incorrect entry'),(4,'Other');
/*!40000 ALTER TABLE `report_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report_status`
--

DROP TABLE IF EXISTS `report_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `report_status` (
  `report_status_id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`report_status_id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report_status`
--

LOCK TABLES `report_status` WRITE;
/*!40000 ALTER TABLE `report_status` DISABLE KEYS */;
INSERT INTO `report_status` VALUES (2,'Action Taken'),(3,'Closed'),(1,'Pending Review');
/*!40000 ALTER TABLE `report_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `role_id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`role_id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (2,'Admin'),(1,'System'),(3,'User');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `saved_translation`
--

DROP TABLE IF EXISTS `saved_translation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `saved_translation` (
  `saved_translation_id` int unsigned NOT NULL AUTO_INCREMENT,
  `created_by` int unsigned NOT NULL,
  `input` varchar(5000) NOT NULL,
  `output` varchar(5000) NOT NULL,
  `creation_date` datetime NOT NULL,
  PRIMARY KEY (`saved_translation_id`),
  KEY `fk_savedtranslation_users_idx` (`created_by`),
  CONSTRAINT `fk_savedtranslation_users` FOREIGN KEY (`created_by`) REFERENCES `users` (`user_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `saved_translation`
--

LOCK TABLES `saved_translation` WRITE;
/*!40000 ALTER TABLE `saved_translation` DISABLE KEYS */;
/*!40000 ALTER TABLE `saved_translation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suggestion`
--

DROP TABLE IF EXISTS `suggestion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suggestion` (
  `suggestion_id` int unsigned NOT NULL AUTO_INCREMENT,
  `slang` varchar(50) NOT NULL,
  `translation` varchar(50) NOT NULL,
  `example` varchar(100) DEFAULT NULL,
  `slang_language_id` tinyint unsigned NOT NULL,
  `suggestion_status_id` tinyint unsigned NOT NULL,
  `created_by` int unsigned DEFAULT NULL,
  `creation_date` datetime NOT NULL,
  `modified_by` int unsigned DEFAULT NULL,
  `modification_date` datetime NOT NULL,
  PRIMARY KEY (`suggestion_id`),
  KEY `fk_suggestion_languages_idx` (`slang_language_id`),
  KEY `fk_suggestion_createdby_users_idx` (`created_by`),
  KEY `fk_suggestion_suggestionstatus_idx` (`suggestion_status_id`),
  KEY `fk_suggestion_modifiedby_users_idx` (`modified_by`),
  CONSTRAINT `fk_suggestion_createdby_users` FOREIGN KEY (`created_by`) REFERENCES `users` (`user_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_suggestion_languages` FOREIGN KEY (`slang_language_id`) REFERENCES `languages` (`language_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_suggestion_modifiedby_users` FOREIGN KEY (`modified_by`) REFERENCES `users` (`user_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_suggestion_suggestionstatus` FOREIGN KEY (`suggestion_status_id`) REFERENCES `suggestion_status` (`suggestion_status_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suggestion`
--

LOCK TABLES `suggestion` WRITE;
/*!40000 ALTER TABLE `suggestion` DISABLE KEYS */;
/*!40000 ALTER TABLE `suggestion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suggestion_status`
--

DROP TABLE IF EXISTS `suggestion_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suggestion_status` (
  `suggestion_status_id` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`suggestion_status_id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suggestion_status`
--

LOCK TABLES `suggestion_status` WRITE;
/*!40000 ALTER TABLE `suggestion_status` DISABLE KEYS */;
INSERT INTO `suggestion_status` VALUES (2,'Accepted'),(1,'Pending Review'),(3,'Rejected');
/*!40000 ALTER TABLE `suggestion_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `password` char(48) DEFAULT NULL,
  `role_id` tinyint unsigned NOT NULL,
  `creation_date` datetime NOT NULL,
  `modification_date` datetime NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  KEY `fk_users_roles_idx` (`role_id`),
  CONSTRAINT `fk_users_roles` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'system','w2tqg8bEf2HiGtH8tjyMH0igMqvBMu6za9wQ8P6w8lvfPKpd',1,'2022-12-02 21:23:09','2022-12-02 21:23:09'),(2,'admin','zXdSrDMdhlKdYxR4tenGPwsVgvWvsO3DfpQzocpO5ZwfydQb',2,'2022-12-02 21:23:09','2022-12-02 21:23:09'),(3,'testuser','ZeHDKNDjqQ9C6Ca/vXLxRvOoZMAPJzdfzDWMRvLcDM4MHxjF',3,'2022-12-02 21:23:09','2022-12-02 21:23:09');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `word`
--

DROP TABLE IF EXISTS `word`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `word` (
  `word_id` int unsigned NOT NULL AUTO_INCREMENT,
  `word` varchar(50) NOT NULL,
  `language_id` tinyint unsigned NOT NULL,
  PRIMARY KEY (`word_id`),
  UNIQUE KEY `word_UNIQUE` (`word`),
  KEY `fk_word_languages_idx` (`language_id`),
  CONSTRAINT `fk_word_languages` FOREIGN KEY (`language_id`) REFERENCES `languages` (`language_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=118 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `word`
--

LOCK TABLES `word` WRITE;
/*!40000 ALTER TABLE `word` DISABLE KEYS */;
INSERT INTO `word` VALUES (1,'blur',1),(2,'rilek',1),(3,'bos',1),(4,'yellow',1),(5,'alamak',2),(6,'aduh',2),(7,'fuyoh',2),(8,'jom',2),(9,'kacau',2),(10,'diam',2),(11,'best giler',2),(12,'bungkus',2),(13,'roger',2),(14,'syok',2),(15,'poyo',2),(16,'mat salleh',2),(17,'kongsi',2),(18,'gempak',2),(19,'masyuk',2),(20,'mantap',2),(21,'pastu',2),(22,'lepak',2),(23,'potong stim',2),(24,'gila',2),(25,'bodoh',2),(26,'ntah',2),(27,'koyak',2),(28,'sado',2),(29,'bosan',2),(30,'wayang',2),(31,'abang',2),(32,'bang',2),(33,'agak-agak',2),(34,'geram',2),(35,'ulu',2),(36,'macha',4),(37,'dei',4),(38,'elek',4),(39,'gostan',5),(40,'bo jio',6),(41,'cincai',6),(42,'abuden',6),(43,'chup',6),(44,'chun',6),(45,'ang moh',6),(46,'yum cha',7),(47,'tapau',7),(48,'pokai',7),(49,'guai lou',7),(50,'kautim',7),(51,'lan si',7),(52,'leng zai',7),(53,'leng lui',7),(54,'sup-sup sui',7),(55,'clueless',1),(56,'relax',1),(57,'boss',1),(58,'sir',1),(59,'mister',1),(60,'dude',1),(61,'brother',1),(62,'bro',1),(63,'don\'t have',1),(64,'reverse',1),(65,'did not invite',1),(66,'obviously',1),(67,'wait',1),(68,'pretty',1),(69,'attractive',1),(70,'hang out',1),(71,'take a break',1),(72,'takeaway',1),(73,'no money',1),(74,'broke',1),(75,'settle',1),(76,'oh my',1),(77,'oh no',1),(78,'geez',1),(79,'wow',1),(80,'let\'s go',1),(81,'disturb',1),(82,'whatever',1),(83,'shut up',1),(84,'quiet',1),(85,'good',1),(86,'amazing',1),(87,'call',1),(88,'are you sure',1),(89,'pleasing',1),(90,'douchebag',1),(91,'caucasian',1),(92,'white person',1),(93,'share',1),(94,'rich',1),(95,'awesome',1),(96,'and then',1),(97,'killjoy',1),(98,'party pooper',1),(99,'crazy',1),(100,'stupid',1),(101,'idiot',1),(102,'i don\'t know',1),(103,'triggered',1),(104,'offended',1),(105,'muscular',1),(106,'boring',1),(107,'pretend',1),(108,'acting',1),(109,'arrogant',1),(110,'handsome guy',1),(111,'pretty girl',1),(112,'angry',1),(113,'easy',1),(114,'rural',1),(115,'dirty-minded',1),(116,'perverted',1),(117,'approximately',1);
/*!40000 ALTER TABLE `word` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-02 21:24:10
