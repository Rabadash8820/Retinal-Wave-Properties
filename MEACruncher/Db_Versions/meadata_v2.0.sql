-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: localhost    Database: meadata_v2_0
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
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `ExperimenterId` binary(16) NOT NULL,
  `OrganizationId` binary(16) NOT NULL,
  `RoleId` binary(16) NOT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ExperimenterId`,`OrganizationId`,`RoleId`,`StartDate`),
  KEY `ExperimenterId` (`ExperimenterId`),
  KEY `OrganizationId` (`OrganizationId`),
  KEY `Role` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bursts`
--

DROP TABLE IF EXISTS `bursts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bursts` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `ChannelId` binary(16) NOT NULL,
  `BurstNumber` smallint(6) NOT NULL DEFAULT '0',
  `StartTimestamp` double NOT NULL DEFAULT '0',
  `EndTimestamp` double NOT NULL DEFAULT '0',
  `IsWaveAssociated` bit(1) DEFAULT b'0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ChannelId`,`BurstNumber`),
  KEY `BurstNumber` (`BurstNumber`),
  KEY `RecordingId` (`ChannelId`),
  KEY `WaveAssociated` (`IsWaveAssociated`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `channels`
--

DROP TABLE IF EXISTS `channels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `channels` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `RecordingId` binary(16) DEFAULT NULL,
  `Description` varchar(25) DEFAULT NULL,
  `MeaRow` smallint(6) DEFAULT '0',
  `MeaColumn` smallint(6) DEFAULT '0',
  `HasMRGC` bit(1) DEFAULT NULL,
  `HasSingleCell` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`RecordingId`,`MeaRow`,`MeaColumn`),
  KEY `RecordingId` (`RecordingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `conditions`
--

DROP TABLE IF EXISTS `conditions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conditions` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `experimenters`
--

DROP TABLE IF EXISTS `experimenters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `experimenters` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `FullName` varchar(75) NOT NULL,
  `WorkEmail` varchar(75) DEFAULT NULL,
  `WorkPhone` varchar(15) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `genotypes`
--

DROP TABLE IF EXISTS `genotypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `genotypes` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `model_organisms`
--

DROP TABLE IF EXISTS `model_organisms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `model_organisms` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `ScientificName` varchar(75) NOT NULL,
  `CommonName` varchar(75) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ScientificName` (`ScientificName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `organization_roles`
--

DROP TABLE IF EXISTS `organization_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `organization_roles` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `organization_types`
--

DROP TABLE IF EXISTS `organization_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `organization_types` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `Description` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `organizations`
--

DROP TABLE IF EXISTS `organizations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `organizations` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `Title` varchar(50) NOT NULL,
  `TypeId` binary(16) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `Type` (`TypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `project_experimenters`
--

DROP TABLE IF EXISTS `project_experimenters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project_experimenters` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `ProjectId` binary(16) NOT NULL,
  `ExperimenterId` binary(16) NOT NULL,
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
-- Table structure for table `project_recordings`
--

DROP TABLE IF EXISTS `project_recordings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project_recordings` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectId` binary(16) NOT NULL,
  `RecordingId` binary(16) NOT NULL,
  `IsOriginal` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ProjectId`,`RecordingId`),
  KEY `IsReused` (`IsOriginal`),
  KEY `Project` (`ProjectId`),
  KEY `Recording` (`RecordingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projects` (
  `Id` char(16) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Title` varchar(50) NOT NULL,
  `DateStarted` datetime DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `NaturalId` (`Title`,`DateStarted`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `recordings`
--

DROP TABLE IF EXISTS `recordings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recordings` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `FilePath` text NOT NULL,
  `TissueConditionId` binary(16) NOT NULL,
  `RecordingNumber` smallint(6) NOT NULL DEFAULT '0',
  `MeaRows` smallint(6) DEFAULT '0',
  `MeaColumns` smallint(6) DEFAULT '0',
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`TissueConditionId`,`RecordingNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `spikes`
--

DROP TABLE IF EXISTS `spikes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spikes` (
  `Id` binary(16) NOT NULL,
  `ChannelId` binary(16) NOT NULL,
  `SpikeNumber` int(11) NOT NULL DEFAULT '0',
  `Timestamp` double NOT NULL DEFAULT '0',
  `BurstId` binary(16) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`ChannelId`,`SpikeNumber`),
  KEY `BurstId` (`BurstId`),
  KEY `RecordingId` (`ChannelId`),
  KEY `SpikeNumber` (`SpikeNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `strains`
--

DROP TABLE IF EXISTS `strains`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `strains` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `OrganismId` binary(16) NOT NULL,
  `GenotypeId` binary(16) NOT NULL,
  `Description` varchar(25) NOT NULL,
  `BreederId` binary(16) DEFAULT NULL,
  `Comments` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`OrganismId`,`GenotypeId`,`BreederId`),
  KEY `AcquiredFrom` (`BreederId`),
  KEY `GenotypeId` (`GenotypeId`),
  KEY `OrganismId` (`OrganismId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tissue_conditions`
--

DROP TABLE IF EXISTS `tissue_conditions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissue_conditions` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `TissuePreparationId` binary(16) NOT NULL,
  `ConditionId` binary(16) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`TissuePreparationId`,`ConditionId`),
  KEY `ConditionId` (`ConditionId`),
  KEY `TissuePreparationId` (`TissuePreparationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tissue_preparations`
--

DROP TABLE IF EXISTS `tissue_preparations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissue_preparations` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `StrainId` binary(16) NOT NULL,
  `TissueId` binary(16) NOT NULL,
  `DatePrepared` datetime DEFAULT NULL,
  `PreparerId` binary(16) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `Preparer` (`PreparerId`),
  KEY `StrainId` (`StrainId`),
  KEY `Tissue` (`TissueId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tissues`
--

DROP TABLE IF EXISTS `tissues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissues` (
  `Id` binary(16) NOT NULL DEFAULT '\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0',
  `Description` varchar(255) NOT NULL,
  `ParentId` binary(16) DEFAULT NULL,
  `Comments` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`Description`,`ParentId`),
  KEY `Parent` (`ParentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-04-29  3:31:21
