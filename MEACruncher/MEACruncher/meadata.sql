-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: localhost    Database: meadata_v3_0
-- ------------------------------------------------------
-- Server version	5.6.24-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `affiliations`
--

DROP TABLE IF EXISTS `affiliations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `affiliations` (
  `Id` char(36) NOT NULL,
  `ExperimenterId` char(36) NOT NULL,
  `OrganizationId` char(36) NOT NULL,
  `RoleId` char(36) NOT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ExperimenterId`,`OrganizationId`,`RoleId`,`StartDate`),
  KEY `ExperimenterId` (`ExperimenterId`),
  KEY `OrganizationId` (`OrganizationId`),
  KEY `Role` (`RoleId`),
  CONSTRAINT `Experiment` FOREIGN KEY (`ExperimenterId`) REFERENCES `experimenters` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `Organization` FOREIGN KEY (`OrganizationId`) REFERENCES `organizations` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `Role` FOREIGN KEY (`RoleId`) REFERENCES `organization_roles` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `affiliations`
--

LOCK TABLES `affiliations` WRITE;
/*!40000 ALTER TABLE `affiliations` DISABLE KEYS */;
/*!40000 ALTER TABLE `affiliations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bursts`
--

DROP TABLE IF EXISTS `bursts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bursts` (
  `Id` char(36) NOT NULL,
  `ChannelId` char(36) NOT NULL,
  `BurstNumber` smallint(6) NOT NULL DEFAULT '0',
  `StartTimestamp` double NOT NULL DEFAULT '0',
  `EndTimestamp` double NOT NULL DEFAULT '0',
  `IsWaveAssociated` bit(1) DEFAULT b'0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ChannelId`,`BurstNumber`),
  KEY `BurstNumber` (`BurstNumber`),
  KEY `RecordingId` (`ChannelId`),
  KEY `WaveAssociated` (`IsWaveAssociated`),
  CONSTRAINT `BurstChannel` FOREIGN KEY (`ChannelId`) REFERENCES `channels` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bursts`
--

LOCK TABLES `bursts` WRITE;
/*!40000 ALTER TABLE `bursts` DISABLE KEYS */;
/*!40000 ALTER TABLE `bursts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `channels`
--

DROP TABLE IF EXISTS `channels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `channels` (
  `Id` char(36) NOT NULL,
  `RecordingId` char(36) NOT NULL,
  `Description` varchar(25) DEFAULT NULL,
  `MeaRow` smallint(6) DEFAULT '0',
  `MeaColumn` smallint(6) DEFAULT '0',
  `HasMRGC` bit(1) DEFAULT NULL,
  `HasSingleCell` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`RecordingId`,`MeaRow`,`MeaColumn`),
  KEY `RecordingId` (`RecordingId`),
  CONSTRAINT `Recording` FOREIGN KEY (`RecordingId`) REFERENCES `recordings` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `channels`
--

LOCK TABLES `channels` WRITE;
/*!40000 ALTER TABLE `channels` DISABLE KEYS */;
/*!40000 ALTER TABLE `channels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conditions`
--

DROP TABLE IF EXISTS `conditions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conditions` (
  `Id` char(36) NOT NULL,
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conditions`
--

LOCK TABLES `conditions` WRITE;
/*!40000 ALTER TABLE `conditions` DISABLE KEYS */;
/*!40000 ALTER TABLE `conditions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `experimenters`
--

DROP TABLE IF EXISTS `experimenters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `experimenters` (
  `Id` char(36) NOT NULL,
  `FullName` varchar(75) NOT NULL,
  `WorkEmail` varchar(75) DEFAULT NULL,
  `WorkPhone` varchar(15) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `experimenters`
--

LOCK TABLES `experimenters` WRITE;
/*!40000 ALTER TABLE `experimenters` DISABLE KEYS */;
/*!40000 ALTER TABLE `experimenters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genotypes`
--

DROP TABLE IF EXISTS `genotypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `genotypes` (
  `Id` char(36) NOT NULL,
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genotypes`
--

LOCK TABLES `genotypes` WRITE;
/*!40000 ALTER TABLE `genotypes` DISABLE KEYS */;
/*!40000 ALTER TABLE `genotypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `model_organisms`
--

DROP TABLE IF EXISTS `model_organisms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `model_organisms` (
  `Id` char(36) NOT NULL,
  `ScientificName` varchar(75) NOT NULL,
  `CommonName` varchar(75) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ScientificName` (`ScientificName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `model_organisms`
--

LOCK TABLES `model_organisms` WRITE;
/*!40000 ALTER TABLE `model_organisms` DISABLE KEYS */;
/*!40000 ALTER TABLE `model_organisms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organization_roles`
--

DROP TABLE IF EXISTS `organization_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `organization_roles` (
  `Id` char(36) NOT NULL,
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organization_roles`
--

LOCK TABLES `organization_roles` WRITE;
/*!40000 ALTER TABLE `organization_roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `organization_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organization_types`
--

DROP TABLE IF EXISTS `organization_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `organization_types` (
  `Id` char(36) NOT NULL,
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organization_types`
--

LOCK TABLES `organization_types` WRITE;
/*!40000 ALTER TABLE `organization_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `organization_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizations`
--

DROP TABLE IF EXISTS `organizations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `organizations` (
  `Id` char(36) NOT NULL,
  `Title` varchar(50) NOT NULL,
  `TypeId` char(36) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `Type` (`TypeId`),
  CONSTRAINT `OrganizationType` FOREIGN KEY (`TypeId`) REFERENCES `organization_types` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizations`
--

LOCK TABLES `organizations` WRITE;
/*!40000 ALTER TABLE `organizations` DISABLE KEYS */;
/*!40000 ALTER TABLE `organizations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `populations`
--

DROP TABLE IF EXISTS `populations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `populations` (
  `Id` char(36) NOT NULL,
  `StrainId` char(36) DEFAULT NULL,
  `ConditionId` char(36) DEFAULT NULL,
  `TissueId` char(36) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `Strain_idx` (`StrainId`),
  KEY `Condition_idx` (`ConditionId`),
  KEY `Tissue_idx` (`TissueId`),
  CONSTRAINT `Condition` FOREIGN KEY (`ConditionId`) REFERENCES `conditions` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `Strain` FOREIGN KEY (`StrainId`) REFERENCES `strains` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `Tissue` FOREIGN KEY (`TissueId`) REFERENCES `tissues` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `populations`
--

LOCK TABLES `populations` WRITE;
/*!40000 ALTER TABLE `populations` DISABLE KEYS */;
/*!40000 ALTER TABLE `populations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_experimenters`
--

DROP TABLE IF EXISTS `project_experimenters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project_experimenters` (
  `Id` char(36) NOT NULL,
  `ProjectId` char(36) NOT NULL,
  `ExperimenterId` char(36) NOT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `IsManager` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ProjectId`,`ExperimenterId`,`StartDate`),
  KEY `ExperimenterId` (`ExperimenterId`),
  KEY `IsManager` (`IsManager`),
  KEY `ProjectId` (`ProjectId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project_experimenters`
--

LOCK TABLES `project_experimenters` WRITE;
/*!40000 ALTER TABLE `project_experimenters` DISABLE KEYS */;
/*!40000 ALTER TABLE `project_experimenters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_populations`
--

DROP TABLE IF EXISTS `project_populations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project_populations` (
  `Id` char(36) NOT NULL,
  `ProjectId` char(36) NOT NULL,
  `PopulationId` char(36) NOT NULL,
  `IsOriginal` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ProjectId`,`PopulationId`),
  KEY `IsReused` (`IsOriginal`),
  KEY `Project` (`ProjectId`),
  KEY `Recording` (`PopulationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project_populations`
--

LOCK TABLES `project_populations` WRITE;
/*!40000 ALTER TABLE `project_populations` DISABLE KEYS */;
/*!40000 ALTER TABLE `project_populations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projects` (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Title` varchar(50) NOT NULL,
  `DateStarted` datetime DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `NaturalId` (`Title`,`DateStarted`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` VALUES ('af2df9fd-8803-45d7-bcb8-68f7829d4af3','Project_2','2015-05-09 04:05:23','A new project for analyzing MEA data.');
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recordings`
--

DROP TABLE IF EXISTS `recordings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recordings` (
  `Id` char(36) NOT NULL,
  `FilePath` text NOT NULL,
  `TissuePreparationId` char(36) NOT NULL,
  `RecordingNumber` smallint(6) NOT NULL DEFAULT '0',
  `MeaRows` smallint(6) DEFAULT '8',
  `MeaColumns` smallint(6) DEFAULT '8',
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`TissuePreparationId`,`RecordingNumber`),
  CONSTRAINT `TissuePreparation` FOREIGN KEY (`TissuePreparationId`) REFERENCES `tissue_preparations` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recordings`
--

LOCK TABLES `recordings` WRITE;
/*!40000 ALTER TABLE `recordings` DISABLE KEYS */;
/*!40000 ALTER TABLE `recordings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `result_types`
--

DROP TABLE IF EXISTS `result_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `result_types` (
  `Id` char(36) NOT NULL,
  `Description` varchar(50) NOT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `result_types`
--

LOCK TABLES `result_types` WRITE;
/*!40000 ALTER TABLE `result_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `result_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `results`
--

DROP TABLE IF EXISTS `results`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `results` (
  `Id` char(36) NOT NULL,
  `PopulationId` char(36) NOT NULL,
  `ResultTypeId` char(36) NOT NULL,
  `Value` double NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Population_idx` (`PopulationId`),
  KEY `ResultType_idx` (`ResultTypeId`),
  CONSTRAINT `ResultPopulation` FOREIGN KEY (`PopulationId`) REFERENCES `populations` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `ResultType` FOREIGN KEY (`ResultTypeId`) REFERENCES `result_types` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `results`
--

LOCK TABLES `results` WRITE;
/*!40000 ALTER TABLE `results` DISABLE KEYS */;
/*!40000 ALTER TABLE `results` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spikes`
--

DROP TABLE IF EXISTS `spikes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spikes` (
  `Id` char(36) NOT NULL,
  `ChannelId` char(36) NOT NULL,
  `SpikeNumber` int(11) NOT NULL DEFAULT '0',
  `Timestamp` double NOT NULL DEFAULT '0',
  `BurstId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ChannelId`,`SpikeNumber`),
  KEY `BurstId` (`BurstId`),
  KEY `RecordingId` (`ChannelId`),
  KEY `SpikeNumber` (`SpikeNumber`),
  CONSTRAINT `Burst` FOREIGN KEY (`BurstId`) REFERENCES `bursts` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `SpikeChannel` FOREIGN KEY (`ChannelId`) REFERENCES `channels` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spikes`
--

LOCK TABLES `spikes` WRITE;
/*!40000 ALTER TABLE `spikes` DISABLE KEYS */;
/*!40000 ALTER TABLE `spikes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `strains`
--

DROP TABLE IF EXISTS `strains`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `strains` (
  `Id` char(36) NOT NULL,
  `OrganismId` char(36) NOT NULL,
  `GenotypeId` char(36) NOT NULL,
  `Description` varchar(25) NOT NULL,
  `BreederId` char(36) NOT NULL,
  `Comments` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`OrganismId`,`GenotypeId`,`BreederId`),
  KEY `AcquiredFrom` (`BreederId`),
  KEY `GenotypeId` (`GenotypeId`),
  KEY `OrganismId` (`OrganismId`),
  CONSTRAINT `Breeder` FOREIGN KEY (`BreederId`) REFERENCES `organizations` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `Genotype` FOREIGN KEY (`GenotypeId`) REFERENCES `genotypes` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `Organism` FOREIGN KEY (`OrganismId`) REFERENCES `model_organisms` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `strains`
--

LOCK TABLES `strains` WRITE;
/*!40000 ALTER TABLE `strains` DISABLE KEYS */;
/*!40000 ALTER TABLE `strains` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tissue_preparations`
--

DROP TABLE IF EXISTS `tissue_preparations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissue_preparations` (
  `Id` char(36) NOT NULL,
  `PopulationId` char(36) NOT NULL,
  `DatePrepared` datetime DEFAULT NULL,
  `PreparerId` char(36) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `Preparer` (`PreparerId`),
  KEY `StrainId` (`PopulationId`),
  CONSTRAINT `Preparer` FOREIGN KEY (`PreparerId`) REFERENCES `experimenters` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `TissuePopulation` FOREIGN KEY (`PopulationId`) REFERENCES `populations` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tissue_preparations`
--

LOCK TABLES `tissue_preparations` WRITE;
/*!40000 ALTER TABLE `tissue_preparations` DISABLE KEYS */;
/*!40000 ALTER TABLE `tissue_preparations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tissues`
--

DROP TABLE IF EXISTS `tissues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissues` (
  `Id` char(36) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `ParentId` char(36) DEFAULT NULL,
  `Comments` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`Description`,`ParentId`),
  KEY `Parent` (`ParentId`),
  CONSTRAINT `Parent` FOREIGN KEY (`ParentId`) REFERENCES `tissues` (`Id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tissues`
--

LOCK TABLES `tissues` WRITE;
/*!40000 ALTER TABLE `tissues` DISABLE KEYS */;
/*!40000 ALTER TABLE `tissues` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-11  3:23:50
