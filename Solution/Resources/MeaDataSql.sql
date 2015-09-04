-- ********** DATABASE STRUCTURE ********** 
 

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
DROP TABLE IF EXISTS `age_units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `age_units` (
  `Id` char(36) NOT NULL,
  `Description` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `bursts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bursts` (
  `Id` char(36) NOT NULL,
  `CellId` char(36) DEFAULT NULL,
  `BurstNumber` smallint(6) DEFAULT '0' COMMENT 'Indicates the order of bursts on a single channel.  E.g., 2 for the second burst',
  `StartTimestamp` double DEFAULT '0' COMMENT 'Timestamp of the first spike in the burst',
  `EndTimestamp` double DEFAULT '0' COMMENT 'Timestamp of the last spike in the burst',
  `IsWaveAssociated` tinyint(4) DEFAULT '0' COMMENT 'Flag for whether this burst is wave-associated',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Burst` (`CellId`,`BurstNumber`),
  KEY `BurstNumber` (`BurstNumber`),
  KEY `WaveAssociated` (`IsWaveAssociated`),
  KEY `CellId` (`CellId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `cell_flags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cell_flags` (
  `Id` char(36) NOT NULL,
  `CellId` char(36) DEFAULT NULL,
  `FlagId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `CellFlag` (`CellId`,`FlagId`),
  KEY `FlagId` (`FlagId`),
  KEY `CellId` (`CellId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `cells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cells` (
  `Id` char(36) NOT NULL,
  `Identifier` varchar(15) DEFAULT NULL,
  `ChannelId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ChannelId` (`ChannelId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `channels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `channels` (
  `Id` char(36) NOT NULL,
  `RecordingId` char(36) DEFAULT NULL,
  `MeaRow` smallint(6) DEFAULT '0' COMMENT 'Which row of the MEA this channel is in',
  `MeaColumn` smallint(6) DEFAULT '0' COMMENT 'Which column of the MEA this channel is in',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Channel` (`RecordingId`,`MeaRow`,`MeaColumn`),
  KEY `ChannelRecording` (`RecordingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `conditions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conditions` (
  `Id` char(36) NOT NULL,
  `Name` varchar(15) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `flags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `flags` (
  `Id` char(36) NOT NULL,
  `Description` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `model_organisms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `model_organisms` (
  `Id` char(36) NOT NULL,
  `ScientificName` varchar(35) DEFAULT NULL,
  `CommonName` varchar(30) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `population_tissues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `population_tissues` (
  `Id` char(36) NOT NULL,
  `PopulationId` char(36) DEFAULT NULL,
  `TissueId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `PopulationPreparation` (`PopulationId`,`TissueId`),
  KEY `PopulationId` (`PopulationId`),
  KEY `TissueId` (`TissueId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `populations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `populations` (
  `Id` char(36) NOT NULL,
  `StrainId` char(36) DEFAULT NULL,
  `TissueId` char(36) DEFAULT NULL,
  `Age` double DEFAULT NULL COMMENT 'The age of the organism from which this preparation was made',
  `AgeUnitId` char(36) DEFAULT NULL COMMENT 'Unit for the age.  Could be embryonic days, postnatal days, years, etc.',
  `ConditionId` char(36) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Population` (`StrainId`,`TissueId`,`Age`,`AgeUnitId`),
  KEY `StrainId` (`StrainId`),
  KEY `TissueId` (`TissueId`),
  KEY `Age` (`AgeUnitId`,`Age`),
  KEY `Condition` (`ConditionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `project_populations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project_populations` (
  `Id` char(36) NOT NULL,
  `ProjectId` char(36) DEFAULT NULL,
  `PopulationId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ProjectPopulation` (`ProjectId`,`PopulationId`),
  KEY `ProjectId` (`ProjectId`),
  KEY `PopulationId` (`PopulationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projects` (
  `Id` char(36) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Name` varchar(25) DEFAULT NULL COMMENT 'Name of the project',
  `DateStarted` datetime DEFAULT NULL COMMENT 'Date when the project was started',
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `Project` (`Name`,`DateStarted`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `recording_files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recording_files` (
  `Id` char(36) NOT NULL,
  `RecordingId` char(36) DEFAULT NULL,
  `FileNumber` tinyint(4) DEFAULT NULL COMMENT 'Indicates the order of files for a single recording.  E.g., 2 for the second file',
  `FileDir` text COMMENT 'The fully qualified path, filename, and extension of this file',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `File` (`RecordingId`,`FileNumber`),
  KEY `RecordingId` (`RecordingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `recordings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recordings` (
  `Id` char(36) NOT NULL,
  `TissueId` char(36) DEFAULT NULL,
  `ConditionId` char(36) DEFAULT NULL,
  `RecordingNumber` tinyint(4) DEFAULT '0' COMMENT 'Indicates the order of recordings of a single tissue preparation.  E.g., 2 for the second recording',
  `Duration` double DEFAULT '0' COMMENT 'The total duration of this recording, including all files.',
  `MeaRows` int(11) DEFAULT '8' COMMENT 'Number of rows on the MEA used to make this recording',
  `MeaColumns` int(11) DEFAULT '8' COMMENT 'Number of columns on the MEA used to make this recording',
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Recording` (`TissueId`,`ConditionId`,`RecordingNumber`),
  KEY `Duration` (`Duration`),
  KEY `Condition` (`ConditionId`),
  KEY `TissueId` (`TissueId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `result_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `result_types` (
  `Id` char(36) NOT NULL,
  `Description` varchar(30) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `results`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `results` (
  `Id` char(36) NOT NULL,
  `CellId` char(36) DEFAULT NULL,
  `ResultTypeId` char(36) DEFAULT NULL,
  `Value` double DEFAULT NULL COMMENT 'Value of the result (kinda depends on what the result type is)',
  PRIMARY KEY (`Id`),
  KEY `ResultType_idx` (`ResultTypeId`),
  KEY `Cell_idx` (`CellId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `spikes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spikes` (
  `Id` char(36) NOT NULL,
  `CellId` char(36) DEFAULT NULL,
  `SpikeNumber` int(11) DEFAULT '0' COMMENT 'Indicates the order of spikes on a single channel.  E.g., 2 for the second spike',
  `Timestamp` double DEFAULT '0' COMMENT 'Time during the recording when this spike occurred',
  `BurstId` char(36) DEFAULT NULL COMMENT 'Id of the burst during which this spike occurred, if any',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Spike` (`CellId`,`SpikeNumber`),
  KEY `BurstId` (`BurstId`),
  KEY `SpikeNumber` (`SpikeNumber`),
  KEY `CellId` (`CellId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `strains`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `strains` (
  `Id` char(36) NOT NULL,
  `OrganismId` char(36) DEFAULT NULL,
  `Name` varchar(25) DEFAULT NULL COMMENT 'Name of the strain',
  `Breeder` varchar(35) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Strain` (`OrganismId`,`Name`),
  KEY `AcquiredFrom` (`Breeder`),
  KEY `OrganismId` (`OrganismId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `tissue_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissue_types` (
  `Id` char(36) NOT NULL,
  `Name` varchar(35) DEFAULT NULL COMMENT 'Name of the tissue (as general as "brain" or as specific as dorsal lateral geniculat nucleus)',
  `ParentId` char(36) DEFAULT NULL COMMENT 'If this tissue is part of a more general tissue',
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`Name`,`ParentId`),
  KEY `ParentId` (`ParentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `tissues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissues` (
  `Id` char(36) NOT NULL,
  `StrainId` char(36) DEFAULT NULL,
  `TissueTypeId` char(36) DEFAULT NULL,
  `Age` double DEFAULT NULL,
  `AgeUnitId` char(36) DEFAULT NULL,
  `DatePrepared` datetime DEFAULT NULL,
  `Preparer` varchar(30) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `Strain` (`StrainId`),
  KEY `TissueType` (`TissueTypeId`),
  KEY `Age` (`Age`,`AgeUnitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
DROP TABLE IF EXISTS `version`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `version` (
  `Id` char(36) NOT NULL,
  `Version` varchar(15) DEFAULT NULL COMMENT 'A string for the db''s version number',
  PRIMARY KEY (`Id`)
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

 
-- ********** DATA FROM SPECIFIC TABLES ********** 
 

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
DROP TABLE IF EXISTS `version`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `version` (
  `Id` char(36) NOT NULL,
  `Version` varchar(15) DEFAULT NULL COMMENT 'A string for the db''s version number',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `version` WRITE;
/*!40000 ALTER TABLE `version` DISABLE KEYS */;
INSERT INTO `version` VALUES ('04e629c4-1e8e-4d49-b2d4-7b996467afb8','3.9');
/*!40000 ALTER TABLE `version` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

