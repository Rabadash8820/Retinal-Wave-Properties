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
DROP TABLE IF EXISTS `population_conditions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `population_conditions` (
  `Id` char(36) NOT NULL,
  `PopulationId` char(36) NOT NULL,
  `ConditionId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `PopulationCondition` (`PopulationId`,`ConditionId`),
  KEY `Population` (`PopulationId`),
  KEY `Condition` (`ConditionId`)
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
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Population` (`StrainId`,`TissueId`,`Age`,`AgeUnitId`),
  KEY `StrainId` (`StrainId`),
  KEY `TissueId` (`TissueId`),
  KEY `Age` (`AgeUnitId`,`Age`)
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
DROP TABLE IF EXISTS `recording_conditions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recording_conditions` (
  `Id` char(36) NOT NULL,
  `RecordingId` char(36) DEFAULT NULL,
  `ConditionId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RecordingCondition` (`RecordingId`,`ConditionId`),
  KEY `Recording` (`RecordingId`),
  KEY `Condition` (`ConditionId`)
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
  `RecordingNumber` tinyint(4) DEFAULT '0' COMMENT 'Indicates the order of recordings of a single tissue preparation.  E.g., 2 for the second recording',
  `Duration` double DEFAULT '0' COMMENT 'The total duration of this recording, including all files.',
  `MeaRows` int(11) DEFAULT '8' COMMENT 'Number of rows on the MEA used to make this recording',
  `MeaColumns` int(11) DEFAULT '8' COMMENT 'Number of columns on the MEA used to make this recording',
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Recording` (`TissueId`,`RecordingNumber`),
  KEY `Duration` (`Duration`),
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
  `Name` varchar(45) DEFAULT NULL COMMENT 'Name of the tissue (as general as "brain" or as specific as dorsal lateral geniculat nucleus)',
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
INSERT INTO `version` VALUES ('04e629c4-1e8e-4d49-b2d4-7b996467afb8','3.10');
/*!40000 ALTER TABLE `version` ENABLE KEYS */;
UNLOCK TABLES;
DROP TABLE IF EXISTS `tissue_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissue_types` (
  `Id` char(36) NOT NULL,
  `Name` varchar(45) DEFAULT NULL COMMENT 'Name of the tissue (as general as "brain" or as specific as dorsal lateral geniculat nucleus)',
  `ParentId` char(36) DEFAULT NULL COMMENT 'If this tissue is part of a more general tissue',
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`Name`,`ParentId`),
  KEY `ParentId` (`ParentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `tissue_types` WRITE;
/*!40000 ALTER TABLE `tissue_types` DISABLE KEYS */;
INSERT INTO `tissue_types` VALUES ('037d8fd0-5984-4512-954c-54243c67fa92','Cerebral peduncle','b74ff59b-0033-4526-9090-1746ca866028',NULL),('066503b9-7008-4a0c-81c7-7194c8b52bcf','Abducens nucleus','9f93468b-dfd3-4db1-8dca-09d9deb0efc9',NULL),('12272cbb-2f5b-4164-bb50-1bbd30ad30a3','Epithalamus','689e73ea-d1bb-48ad-9894-401832122c0b',NULL),('19646ffe-fe8f-41df-9d28-3653369a198d','Myelencephalon','e10ec6b0-f243-4405-857c-0e0c63600ab9',NULL),('1bf341fc-33e8-468c-b9aa-db02bc0e0d89','Pons','e4fd28bd-6a20-447b-82ee-bf2223708e43',NULL),('2c82b058-35b2-4f5d-907f-82102cde5522','Hypoglossal nucleus','3246be0a-cb50-410e-968b-e1eee1280e57',NULL),('3246be0a-cb50-410e-968b-e1eee1280e57','Medullary cranial nerve nuclei','f369c4ee-a459-49ff-a592-c85670b8a4ee',NULL),('338ff66d-adca-41fa-9129-284f228a172f','Forebrain (Prosencephalon)','9e349905-77d3-44dd-a86e-ba21b731bfb1',NULL),('38fb558a-13bb-425b-ad0a-02bd3ea15ccb','Trochlear nerve (IV)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('4536c324-038d-4200-8dc7-0b827f3414f6','Cranial nerves','d4e1e610-2a52-418f-a8db-704b238530b4',NULL),('47e091f0-210e-4f6a-9cb1-b99cb897ec35','Abducens nerve (VI)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('495b3543-38fe-452c-bc27-865926457bcf','Pretectum','b74ff59b-0033-4526-9090-1746ca866028',NULL),('49cbcc8a-813a-4fbe-8229-fb6ad516d33e','Hypothalamus','689e73ea-d1bb-48ad-9894-401832122c0b',NULL),('4ca028a2-c2a8-4ba6-8a69-395d49eee653','Vestibulocochlear nerve (VIII)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('4ebb2387-12d5-44fd-b783-b921d35add8b','Claustrum','b9e5d3c4-dbe4-4ace-bd63-0b4fdd903e1d',NULL),('559aea15-ab78-4f81-96d1-2d450bfe2c79','Vagus nerve (X)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('57589fcf-a474-4593-8d52-8baecdc8dfc9','Tectum','b74ff59b-0033-4526-9090-1746ca866028',NULL),('57ac8507-9eb4-4ccc-8539-4590e4033884','Optic nerve (II)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('642ea284-3b6c-4fe4-8493-82dd0ff79589','Inferior salivatory nucleus','3246be0a-cb50-410e-968b-e1eee1280e57',NULL),('66286a72-15f8-414e-a408-f9bbbbd821fe','Amygdala','b9e5d3c4-dbe4-4ace-bd63-0b4fdd903e1d',NULL),('66ce0d8b-d12e-4ba0-821f-d19c006d2e83','Olfactory nerve (I)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('689e73ea-d1bb-48ad-9894-401832122c0b','Diencephalon','338ff66d-adca-41fa-9129-284f228a172f',NULL),('6f411096-efd5-49b0-ac08-793e9bbfb4b8','Terminal nerve (0)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('710234c2-fa1e-40ae-b0d7-ff1cf09afbf2','Nucleus ambiguus','3246be0a-cb50-410e-968b-e1eee1280e57',NULL),('72ff7d6e-36b2-4be9-87d4-e967a8f380c9','Subthalamus','689e73ea-d1bb-48ad-9894-401832122c0b',NULL),('759108f1-3fb8-4b95-9c2c-6d20061228d6','Trigeminal nerve (V)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('77c4d602-1357-4599-82a3-0312e944fea5','Superior salivatory nucleus','9f93468b-dfd3-4db1-8dca-09d9deb0efc9',NULL),('7813dc7e-6199-4659-b945-5fc7e379dff1','Glossopharyngeal nerve (IX)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('7901adfd-81e5-456f-a094-7b287c3d52a9','Vestibulocochlear nuclei','9f93468b-dfd3-4db1-8dca-09d9deb0efc9',NULL),('7f8b2789-c191-41af-a11d-e53b0fd09f8f','Basal ganglia','b9e5d3c4-dbe4-4ace-bd63-0b4fdd903e1d',NULL),('876387fd-cf3f-4643-8c42-2e9511e583c1','Oculomotor nerve (III)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('8a512bcf-e9cf-41c0-a96f-059259c567a3','Olivary body','f369c4ee-a459-49ff-a592-c85670b8a4ee',NULL),('8b7b4dde-5e84-4489-b8f7-90903d34ee4c','Hypoglossal nerve (XII)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('8eae79ff-a7e1-4729-a01e-a4621639e90d','Mesencephalic cranial nerve nuclei','b74ff59b-0033-4526-9090-1746ca866028',NULL),('8f580a33-3d16-4550-b693-428732f0ffb4','Respiratory center','f369c4ee-a459-49ff-a592-c85670b8a4ee',NULL),('99968b3f-7987-4081-9f39-902efee49211','Pontine (chief) nucleus of trigeminal nerve','9f93468b-dfd3-4db1-8dca-09d9deb0efc9',NULL),('9e349905-77d3-44dd-a86e-ba21b731bfb1','Brain',NULL,NULL),('9f93468b-dfd3-4db1-8dca-09d9deb0efc9','Pontine cranial nerve nuclei','1bf341fc-33e8-468c-b9aa-db02bc0e0d89',NULL),('a340c64a-7163-4749-ba4a-44c8a008cecf','Pontine tegmentum','1bf341fc-33e8-468c-b9aa-db02bc0e0d89',NULL),('b74ff59b-0033-4526-9090-1746ca866028','Midbrain (Mesencephalon)','9e349905-77d3-44dd-a86e-ba21b731bfb1',NULL),('b9e5d3c4-dbe4-4ace-bd63-0b4fdd903e1d','Telencephalon','338ff66d-adca-41fa-9129-284f228a172f',NULL),('bac6a63e-4791-4f2e-8c87-dd68546372d4','Pituitary gland','689e73ea-d1bb-48ad-9894-401832122c0b',NULL),('c80de6da-0dc3-4458-bd3d-f30ae948bd3a','Accessory nerve (XI)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('c906cbdd-7cd9-463b-b8d2-ca26dfe34be9','Motor nucleus of trigeminal nerve','9f93468b-dfd3-4db1-8dca-09d9deb0efc9',NULL),('c9250811-ec62-4f2a-be39-4cb81da597bb','Basal forebrain','b9e5d3c4-dbe4-4ace-bd63-0b4fdd903e1d',NULL),('d2cef671-1f8e-401b-91e8-6f6c16f12b0a','Cerebellum','e4fd28bd-6a20-447b-82ee-bf2223708e43',NULL),('d37560ba-08e1-4d4d-8c48-f538bed090ff','Rhinencephalon (paleopallium)','b9e5d3c4-dbe4-4ace-bd63-0b4fdd903e1d',NULL),('d4e1e610-2a52-418f-a8db-704b238530b4','Nerves',NULL,NULL),('d932d727-c9fc-4071-a966-1f20e3370ad3','Facial nerve nucleus','9f93468b-dfd3-4db1-8dca-09d9deb0efc9',NULL),('e10ec6b0-f243-4405-857c-0e0c63600ab9','Hindbrain (Rhombencephalon)','9e349905-77d3-44dd-a86e-ba21b731bfb1',NULL),('e16b3f09-9bac-4465-9b59-af36b167bc3c','Cerebral cortex (neopallium)','b9e5d3c4-dbe4-4ace-bd63-0b4fdd903e1d',NULL),('e4fd28bd-6a20-447b-82ee-bf2223708e43','Metencephalon','e10ec6b0-f243-4405-857c-0e0c63600ab9',NULL),('f272e925-63a7-4b60-8f30-c3449bab503f','Facial nerve (VII)','4536c324-038d-4200-8dc7-0b827f3414f6',NULL),('f2cfcf33-ecb3-4c3b-9951-8b07a2cf27c2','Dorsal nucleus of vagus nerve','3246be0a-cb50-410e-968b-e1eee1280e57',NULL),('f30888b3-1ccd-4f99-a4d8-994c520e606c','Hippocampus','b9e5d3c4-dbe4-4ace-bd63-0b4fdd903e1d',NULL),('f369c4ee-a459-49ff-a592-c85670b8a4ee','Medulla oblongata','19646ffe-fe8f-41df-9d28-3653369a198d',NULL),('f802356e-4fc8-40ed-b125-6b1b328234de','Thalamus','689e73ea-d1bb-48ad-9894-401832122c0b',NULL),('fcd8ae1a-22ca-4913-95af-cff5fdbbe96c','Solitary nucleus','3246be0a-cb50-410e-968b-e1eee1280e57',NULL);
/*!40000 ALTER TABLE `tissue_types` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

