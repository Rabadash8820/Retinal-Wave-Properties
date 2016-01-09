-- MySQL dump 10.13  Distrib 5.7.10, for Win64 (x86_64)
--
-- Host: localhost    Database: meadata
-- ------------------------------------------------------
-- Server version	5.7.10-log

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
-- Table structure for table `ages`
--

DROP TABLE IF EXISTS `ages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ages` (
  `Id` char(36) NOT NULL,
  `Value` float DEFAULT NULL COMMENT 'E.g., if something is 5.25 years old, then value would be 5.25',
  `AgeUnitId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `AgeUnit` (`AgeUnitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bursts`
--

DROP TABLE IF EXISTS `bursts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bursts` (
  `Id` char(36) NOT NULL,
  `CellId` char(36) DEFAULT NULL,
  `BurstNumber` smallint(6) DEFAULT '0' COMMENT 'Indicates the order of bursts on a single channel.  E.g., 2 for the second burst',
  `StartTimestamp` float DEFAULT '0' COMMENT 'Timestamp of the first spike in the burst',
  `EndTimestamp` float DEFAULT '0' COMMENT 'Timestamp of the last spike in the burst',
  `IsWaveAssociated` tinyint(4) DEFAULT '0' COMMENT 'Flag for whether this burst is wave-associated',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Burst` (`CellId`,`BurstNumber`),
  KEY `BurstNumber` (`BurstNumber`),
  KEY `WaveAssociated` (`IsWaveAssociated`),
  KEY `CellId` (`CellId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cell_flags`
--

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

--
-- Table structure for table `cells`
--

DROP TABLE IF EXISTS `cells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cells` (
  `Id` char(36) NOT NULL,
  `Name` varchar(15) DEFAULT NULL,
  `ChannelId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ChannelId` (`ChannelId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `channels`
--

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

--
-- Table structure for table `conditions`
--

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

--
-- Table structure for table `flags`
--

DROP TABLE IF EXISTS `flags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `flags` (
  `Id` char(36) NOT NULL,
  `Description` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `population_ages`
--

DROP TABLE IF EXISTS `population_ages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `population_ages` (
  `Id` char(36) NOT NULL,
  `PopulationId` char(36) DEFAULT NULL,
  `AgeId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `PopulationAge` (`PopulationId`,`AgeId`),
  KEY `PopulationId` (`PopulationId`),
  KEY `AgeId` (`AgeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `population_conditions`
--

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

--
-- Table structure for table `population_strains`
--

DROP TABLE IF EXISTS `population_strains`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `population_strains` (
  `Id` char(36) NOT NULL,
  `PopulationId` char(36) DEFAULT NULL,
  `StrainId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `PopulationStrain` (`PopulationId`,`StrainId`),
  KEY `PopulationId` (`PopulationId`),
  KEY `StrainId` (`StrainId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `population_tissue_types`
--

DROP TABLE IF EXISTS `population_tissue_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `population_tissue_types` (
  `Id` char(36) NOT NULL,
  `PopulationId` char(36) DEFAULT NULL,
  `TissueTypeId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `PopulationTissueType` (`PopulationId`,`TissueTypeId`),
  KEY `PopulationId` (`PopulationId`),
  KEY `TissueTypeId` (`TissueTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `populations`
--

DROP TABLE IF EXISTS `populations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `populations` (
  `Id` char(36) NOT NULL,
  `Name` varchar(25) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `project_populations`
--

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

--
-- Table structure for table `projects`
--

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

--
-- Table structure for table `recording_conditions`
--

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

--
-- Table structure for table `recording_files`
--

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

--
-- Table structure for table `recordings`
--

DROP TABLE IF EXISTS `recordings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recordings` (
  `Id` char(36) NOT NULL,
  `TissueId` char(36) DEFAULT NULL,
  `RecordingNumber` tinyint(4) DEFAULT '0' COMMENT 'Indicates the order of recordings of a single tissue preparation.  E.g., 2 for the second recording',
  `Duration` float DEFAULT '0' COMMENT 'The total duration of this recording, including all files.',
  `MeaRows` int(11) DEFAULT '8' COMMENT 'Number of rows on the MEA used to make this recording',
  `MeaColumns` int(11) DEFAULT '8' COMMENT 'Number of columns on the MEA used to make this recording',
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Recording` (`TissueId`,`RecordingNumber`),
  KEY `Duration` (`Duration`),
  KEY `TissueId` (`TissueId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `results`
--

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

--
-- Table structure for table `spikes`
--

DROP TABLE IF EXISTS `spikes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spikes` (
  `Id` char(36) NOT NULL,
  `CellId` char(36) DEFAULT NULL,
  `SpikeNumber` int(11) DEFAULT '0' COMMENT 'Indicates the order of spikes on a single channel.  E.g., 2 for the second spike',
  `Timestamp` float DEFAULT '0' COMMENT 'Time during the recording when this spike occurred',
  `BurstId` char(36) DEFAULT NULL COMMENT 'Id of the burst during which this spike occurred, if any',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Spike` (`CellId`,`SpikeNumber`),
  KEY `BurstId` (`BurstId`),
  KEY `SpikeNumber` (`SpikeNumber`),
  KEY `CellId` (`CellId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `strains`
--

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

--
-- Table structure for table `tissues`
--

DROP TABLE IF EXISTS `tissues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissues` (
  `Id` char(36) NOT NULL,
  `StrainId` char(36) DEFAULT NULL,
  `TissueTypeId` char(36) DEFAULT NULL,
  `AgeId` char(36) DEFAULT NULL,
  `Preparer` varchar(30) DEFAULT NULL,
  `DatePrepared` datetime DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  KEY `Strain` (`StrainId`),
  KEY `TissueType` (`TissueTypeId`),
  KEY `Age` (`AgeId`)
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

-- Dump completed on 2016-01-09  0:45:00
-- MySQL dump 10.13  Distrib 5.7.10, for Win64 (x86_64)
--
-- Host: localhost    Database: meadata
-- ------------------------------------------------------
-- Server version	5.7.10-log

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
-- Table structure for table `tissue_types`
--

DROP TABLE IF EXISTS `tissue_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tissue_types` (
  `Id` char(36) NOT NULL,
  `Name` varchar(55) DEFAULT NULL COMMENT 'Name of the tissue (as general as "brain" or as specific as "dorsal lateral geniculat nucleus")',
  `ParentId` char(36) DEFAULT NULL COMMENT 'If this tissue is part of a more general tissue',
  `IsSelectable` bit(1) DEFAULT NULL,
  `Comments` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `NaturalId` (`Name`,`ParentId`),
  KEY `ParentId` (`ParentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tissue_types`
--

LOCK TABLES `tissue_types` WRITE;
/*!40000 ALTER TABLE `tissue_types` DISABLE KEYS */;
INSERT INTO `tissue_types` VALUES ('007dfaf2-a75c-4bb4-afe6-b9c0ce602591','Brodmann area 26','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('00f24bd2-64cf-42ac-8f11-6d028214add2','Solitary nucleus','149bdebc-2aa2-40ce-8588-22300354e2f3','',NULL),('01d81914-7e16-4d9a-9ec5-f1936fd43679','Posterior inferior temporal cortex','8832d0cc-dd08-497f-878d-fce63aa17130','',NULL),('022f9765-9627-4eb3-a019-59dd75caabbe','Glossopharyngeal (IX)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('02cc8c1e-2694-4565-ab3a-e6a41e3dd457','Globose nucleus','f7599644-7a85-49b7-983b-ebcb73252415','',NULL),('043b00b2-0684-4e60-b032-217634e1f785','Trigeminal (V)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('04783442-9973-4766-9d83-e53b40fdef53','Substantia innominata','7ecd7ae0-5250-4ed2-b095-03499984fb90','',NULL),('052523e5-44ba-484c-880a-78dc145b4cac','Pedunculopontine nucleus','ad09e53d-8355-45ba-b6ee-18ff7a08c938','',NULL),('05579f6a-c2b8-40ab-830d-a0813c9890fa','Paratenial nucleus','7a58adb8-0af9-43e4-ac08-3eb7d69d5509','',NULL),('059247c2-3972-446d-95e0-faf6471196ce','Extreme capsule','c2144758-9f1b-4eda-8ba8-030ef0eee453','',NULL),('05ecb92d-ccbc-4b57-b326-3ba47eea51b7','Abducens nucleus (VI)','4f611531-614e-48c3-8799-af01098c1002','',NULL),('082806e2-866e-4de0-a71a-edb84c430b6b','Pars compacta','af2b6722-23b5-4d46-9b97-2c6345f370ed','',NULL),('092039ee-a437-4e3a-90a6-d8ff68694871','Nucleus lentiformis','43bc5117-40e7-4a48-9954-5743e3563caf','',NULL),('09a7f16c-6149-400e-b993-f65f126ceea2','CA area 4','a4c20349-7b88-49e1-b653-ef1ace16288c','',NULL),('0b53cc92-000d-44e1-ac43-83efefccab7b','Mammilary nucleus','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('0b75a10a-4bab-4a49-8a1e-e02cc948308c','Midbrain (mesencephalon)','eb684384-2b15-4fa6-820d-dacba61863ad','\0',NULL),('0bfbb4ad-3123-494f-b1b8-94787285a572','Inferior olivary nucleus','51b9e149-9183-4e7e-8cf7-d1ffdf782d32','',NULL),('0c125c7a-85a0-44d4-8b25-3be9f0426cf6','Brodmann area 11','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('0cdc82d6-2642-43af-a7ae-57e34de144c7','CA area 1','a4c20349-7b88-49e1-b653-ef1ace16288c','',NULL),('0cf1aeed-b388-4f49-a687-ff1c28a12840','Reuniens nucleus','7a58adb8-0af9-43e4-ac08-3eb7d69d5509','',NULL),('0d31d546-9bcb-4038-a738-35a753851380','Brodmann area 29','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('0d49fdbf-26c9-4ae8-ab70-54f4a86ad02e','Precuneus','2219aaaa-f899-4c99-9c53-b96678f6d370','',NULL),('0e3f09a5-311e-4a9a-a8dc-0ed551d65f82','Central medial nucleus','92fdaef5-59f7-4b6d-8d5c-6f793d165dae','',NULL),('0fb7b288-b7f2-4bc3-99e7-574f65dd0529','Cortices','68a75c61-5cbc-47d6-8f38-b6189bae25ef','\0',NULL),('0fe9416a-0651-46f3-856a-01374e202427','Abducens (VI)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('1042a1e8-fed9-4794-ad7e-22f4bbe4063d','Cranial nerves','33df3d69-4618-4bba-b302-28fdcd6759ba','\0',NULL),('10dc3524-a0fe-4e04-9a37-a734999ff5ca','Cortical nuclei','d519a7dd-6ce1-45ff-9ecb-4c198d2bbe17','',NULL),('118f8bf0-0c27-42ff-a282-25231403efe2','Lateral tuberal nuclei','2fdf3722-7d54-491b-9f7d-08fbd2817cd3','',NULL),('121997a7-9559-411d-aaf8-2792e97a4483','Uncus','648d17b8-76d9-4dc5-adcd-13a0dd2f826a','',NULL),('14574487-2210-4c2b-8fcd-9e9996039be5','Vestibulocochlear nuclei (VIII)','4f611531-614e-48c3-8799-af01098c1002','',NULL),('149bdebc-2aa2-40ce-8588-22300354e2f3','Medullary cranial nerve nuclei','ae98d55b-0381-44d0-915f-0005fba93b9c','\0',NULL),('15469b5c-83d5-45c2-a873-d4a415f14dac','Paraventricular nucleus','a8061fd5-d940-4c3d-a895-963eddcad71c','',NULL),('162b772c-525d-4386-8b54-2327aaedc6f2','Subfascicular nucleus','7a58adb8-0af9-43e4-ac08-3eb7d69d5509','',NULL),('179896d4-1988-42d0-9e68-f9ace6e19dce','Optic (II)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('17dcb9bb-2d32-47a6-8b79-aac4872cbe82','Lateral dorsal nucleus','a9168b2b-d744-45ab-8540-1605fdc39185','',NULL),('185419ef-a1d1-4c5e-92e0-f3a3390dd94b','Brodmann area 40','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('188996b6-4854-46de-be0b-13387dfa0b49','Brodmann area 27','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('19fd7819-1156-42b2-91c1-b54f8f1021b7','Thalamic nucleus','a28244a8-9a12-4ebb-a582-821ac78e7917','',NULL),('1a723408-1d7f-4d38-bcff-4ffcb86f0649','Cortices','2219aaaa-f899-4c99-9c53-b96678f6d370','\0',NULL),('1ae7a572-8c2f-4b15-91eb-8eb504330335','Middle frontal gyrus','75f454d7-5c14-44e1-82b4-90249a571f26','',NULL),('1b8bf5f4-fcb7-4c6f-a5c3-519f19c3741f','Olfactory tubercle','ee61d43d-296b-493e-be33-311685798df2','',NULL),('1c0f2c60-de60-49af-805c-30746affb907','Periventricular nucleus','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('1d0b7c30-8837-4690-b7b6-ba92531c75f6','Diagonal band of Broca','7ecd7ae0-5250-4ed2-b095-03499984fb90','',NULL),('1e073ec0-485a-4a80-96e3-9f7e812829f1','Brodmann area 3','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('1eb0a9c1-bd42-41f9-9ac5-0c2075a9361f','Rhomboidal nucleus','7a58adb8-0af9-43e4-ac08-3eb7d69d5509','',NULL),('1ff1d5a6-dc1b-44e3-b2d9-35074d298937','Red nucleus','6434b708-f842-4b87-aa15-f9a5c0743f6f','',NULL),('201c1695-7301-4194-8a24-45f6bb1372e4','Fastigial nucleus','f7599644-7a85-49b7-983b-ebcb73252415','',NULL),('219151c0-484d-47e8-a7a7-e950c69f6352','Metathalamus','ca2fc855-4e7c-4538-84f1-dabe4a49fffe','',NULL),('21cff2e3-3555-45d0-a2e6-8bbbd00d2412','Tuber cinereum','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('2219aaaa-f899-4c99-9c53-b96678f6d370','Parietal lobe','d8c601b4-09ec-4f1d-8a2a-9a69111b0760','\0',NULL),('226718b6-b535-4c30-a9b6-23e0d57ffd3c','External capsule','c2144758-9f1b-4eda-8ba8-030ef0eee453','',NULL),('228f4222-71ba-42e9-9e64-d7eb3922ec91','Hypothalamus','51a8f6e4-72f6-4a12-b3a5-9e968821a02e','',NULL),('23c25d90-2af8-4689-b7fa-8d94f742936d','Subcortical','55b76d8a-c89c-4fb0-9d4f-3ac9ed1f54d1','\0',NULL),('24cc6741-5d36-4e72-b833-c379327856c7','V4','cef74acb-d24b-4265-a8f1-b1d80bea4eb7','',NULL),('266b489a-e00b-4189-bdf5-f0f12c6940d1','Trochlear (IV)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('270f599e-f7b5-4c47-bd58-bd4df436fe03','Trochlear nucleus (IV)','8440be49-81d8-41ca-9f67-5af832f91b2e','',NULL),('2751a55d-ddb3-44d5-a431-41825d5e9e8d','Superior colliculi','4894e54f-367f-476e-83f2-7e3dec23814b','',NULL),('2780ee47-3d6b-40fa-9911-a11489d6f0fa','Pineal body','c766825a-efda-4ea1-ba16-082511c74823','',NULL),('291675b5-3079-47b5-bd20-51695bf119cd','Medial superior temporal area (MST)','c9c1b21c-0d9b-4519-9575-f2a7282b1665','',NULL),('2a40a16f-bd2e-4d42-96bf-8f335077a2a2','Anterior lobe','3aef86b7-463c-4b34-aa0a-c87c26a55165','',NULL),('2a75449c-2736-48cc-8d17-f7260451f4a4','Ventral lateral nucleus','71c0b03a-a9bb-471d-9e20-7fa0a2a2f4bc','',NULL),('2ac5e45e-662c-4123-b27c-f0ada2721e60','Brodmann area 19','f58eabe8-7f52-4184-a751-7ff1ea971aad','',NULL),('2bcdc2f4-209b-4cac-b21d-2a6f9f078a0d','Brodmann areas','689ef960-f59d-4894-b6b0-e6ed05823284','\0',NULL),('2f109e07-bcae-44bf-80a7-3a0dcaf633a9','Subthalamic nucleus','43bc5117-40e7-4a48-9954-5743e3563caf','',NULL),('2fa0663e-37f0-40ef-bd41-4ae9590170e0','Brodmann area 46','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('2fdf3722-7d54-491b-9f7d-08fbd2817cd3','Tuberal','228f4222-71ba-42e9-9e64-d7eb3922ec91','\0',NULL),('3088da79-3a2c-46b0-88c4-842eb6266ee9','Brodmann area 23','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('30d2362f-1416-436c-aa9d-1e05c62e027f','Emboliform nucleus','f7599644-7a85-49b7-983b-ebcb73252415','',NULL),('31b88c57-a56e-4ba8-ba5d-e5bc3e104b82','Subfornical organ','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('320f08a4-0826-4c2e-8383-9363a618c5f0','Central nucleus','d519a7dd-6ce1-45ff-9ecb-4c198d2bbe17','',NULL),('337fd6ab-4d06-4146-a050-5996cddd998e','Arcuate fasciculus','c2144758-9f1b-4eda-8ba8-030ef0eee453','',NULL),('33df3d69-4618-4bba-b302-28fdcd6759ba','Brainstem','f9238b86-6ec9-438d-ae23-9f0aafdf939f','\0',NULL),('34628487-7bc0-44d4-a14c-f96aaf713a74','Sensory nucleus of trigeminal nerve (V)','4f611531-614e-48c3-8799-af01098c1002','',NULL),('349252ea-8fb7-4896-972e-9ac3e943ae9a','Lateral preoptic nucleus','a8061fd5-d940-4c3d-a895-963eddcad71c','',NULL),('354e709e-9314-4111-a024-5852f145bded','Hippocampus','23c25d90-2af8-4689-b7fa-8d94f742936d','',NULL),('3551e497-9759-4606-ba6d-e9fe33e56156','Locus coeruleus','ad09e53d-8355-45ba-b6ee-18ff7a08c938','',NULL),('3552ba29-2cff-43a9-9b7d-cabfe7e75ece','Brodmann area 42','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('380f2774-cdab-4099-9c22-2c244bf77f9a','V3','cef74acb-d24b-4265-a8f1-b1d80bea4eb7','',NULL),('3a4d9dcc-69d7-437d-9080-77d6641f507e','Anterior cingulate','689ef960-f59d-4894-b6b0-e6ed05823284','',NULL),('3aef86b7-463c-4b34-aa0a-c87c26a55165','Cerebellar hemispheres','861a4c04-8e2a-40e3-94af-58475957e17b','\0',NULL),('3c3619a8-5972-4b94-8179-b9209ca46a7b','Apneustic center','a7556b8d-9603-4764-9235-45ccad946200','',NULL),('3cd938dc-b65e-462d-bcbd-409a2a1a7aed','Parafascicular nucleus','92fdaef5-59f7-4b6d-8d5c-6f793d165dae','',NULL),('3d89237c-7776-4097-9d28-3934eba81324','Pretectum','0b75a10a-4bab-4a49-8a1e-e02cc948308c','',NULL),('3e8f9a47-1a7e-42a5-965c-e999c812078d','Striatum','43bc5117-40e7-4a48-9954-5743e3563caf','',NULL),('3f26fc2c-1b4e-4554-9e88-ce9c8e29aa7e','Cerebellar peduncles','861a4c04-8e2a-40e3-94af-58475957e17b','\0',NULL),('3f3aaccb-d021-498c-ac15-f77217f30a0f','Subgenual area','689ef960-f59d-4894-b6b0-e6ed05823284','',NULL),('3f4904f0-03ef-42ad-a9b9-fc77f2995135','Brodmann area 38','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('3f6ef2fa-1d87-4381-a898-940048c44e9d','Supraoptic nucleus','a8061fd5-d940-4c3d-a895-963eddcad71c','',NULL),('3fa495bc-2560-4fdb-a4e1-fc1fe21db7cd','Ventral anterior nucleus','71c0b03a-a9bb-471d-9e20-7fa0a2a2f4bc','',NULL),('4043b35a-ccf2-4b14-b2f0-b36e311a7a65','Superior cerebellar peduncle','3f26fc2c-1b4e-4554-9e88-ce9c8e29aa7e','',NULL),('40c5d7b0-ed0d-449d-a1ea-cba6d3450a56','Gyri','c9c1b21c-0d9b-4519-9575-f2a7282b1665','\0',NULL),('40cb85f1-e279-4936-ad2b-590d21535172','Taenia thalami','c766825a-efda-4ea1-ba16-082511c74823','',NULL),('4107e1c2-c4d5-40ba-a53d-4aeae7bd69d4','Cuneus','68a5f2b0-d979-4ada-81ed-a0b2d6dfc253','',NULL),('4108eac5-45fb-46eb-a515-ecdc1111ec9b','Ventral posterior medial nucleus','71c0b03a-a9bb-471d-9e20-7fa0a2a2f4bc','',NULL),('43bc5117-40e7-4a48-9954-5743e3563caf','Basal ganglia','23c25d90-2af8-4689-b7fa-8d94f742936d','',NULL),('447c2f11-a412-48d1-b64a-113c1540cb5b','Parahippocampal gyrus','40c5d7b0-ed0d-449d-a1ea-cba6d3450a56','',NULL),('453fbbd0-1c20-4fe3-af69-bcaa9a9d760c','Primary motor cortex (precentral gyrus, M1)','0fb7b288-b7f2-4bc3-99e7-574f65dd0529','',NULL),('456578c5-d926-4e9b-ad9f-951748000bf8','Brodmann areas','c9c1b21c-0d9b-4519-9575-f2a7282b1665','\0',NULL),('4596b83e-7472-4545-ab02-216cd6675c58','Brodmann area 36','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('4652471f-4ea8-45aa-a136-66eea4423f91','Crus cerebri','4c2d772f-b3f4-4a6a-a255-78a290e0a75d','',NULL),('4894e54f-367f-476e-83f2-7e3dec23814b','Corpora quadrigemina','72dcdede-2330-4d8a-aba1-dfb561bb732b','',NULL),('4a2d8428-1029-4fc0-a087-2a5e28dd64d9','Lateral occipital gyrus','68a5f2b0-d979-4ada-81ed-a0b2d6dfc253','',NULL),('4c2d772f-b3f4-4a6a-a255-78a290e0a75d','Cerebral peduncle','0b75a10a-4bab-4a49-8a1e-e02cc948308c','',NULL),('4cf1febf-04bb-4397-bf4b-e3317152206a','Piriform cortex','648d17b8-76d9-4dc5-adcd-13a0dd2f826a','',NULL),('4eba31e2-6250-4c9c-9c27-ebcbca3a3748','Pituitary gland','51a8f6e4-72f6-4a12-b3a5-9e968821a02e','',NULL),('4f611531-614e-48c3-8799-af01098c1002','Pontine cranial nerve nuclei','65941dfb-caff-4835-93c6-e1b6cd1ab312','\0',NULL),('4f6f3ed4-dcf0-4f2f-bf09-d75df272864e','Oculomotor nucleus (III)','8440be49-81d8-41ca-9f67-5af832f91b2e','',NULL),('5052450b-7aaa-4e2c-8ca4-13567a6f9d19','V2','cef74acb-d24b-4265-a8f1-b1d80bea4eb7','',NULL),('51a8f6e4-72f6-4a12-b3a5-9e968821a02e','Diencephalon','96bbde80-a2ee-41ef-9bca-c263cd2ed976','\0',NULL),('51b9e149-9183-4e7e-8cf7-d1ffdf782d32','Olivary body','ae98d55b-0381-44d0-915f-0005fba93b9c','',NULL),('524597dd-e55d-480a-9c02-36e84498a1c0','Brodmann area 44','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('54ee5c39-6546-4734-ad4e-8f15d6d71a2d','Prefrontal cortex','0fb7b288-b7f2-4bc3-99e7-574f65dd0529','',NULL),('557265f4-a0aa-4d56-882f-a7c8444833d5','Brodmann area 5','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('55b76d8a-c89c-4fb0-9d4f-3ac9ed1f54d1','Telencephalon (cerebrum)','96bbde80-a2ee-41ef-9bca-c263cd2ed976','\0',NULL),('55e109f9-0890-43f2-a613-6315b86be715','Lateral nuclei','d519a7dd-6ce1-45ff-9ecb-4c198d2bbe17','',NULL),('5666d092-b811-4405-b23e-e73265343be9','Inferior salivatory nucleus','149bdebc-2aa2-40ce-8588-22300354e2f3','',NULL),('5717b099-696c-4ca0-beb5-f6749b2e7031','Posterior nucleus','8afbd7fe-4dd5-4a74-99f7-40a71be381b0','',NULL),('57b4aa8b-a4b4-4c3c-9e3d-6e7859682a69','Secondary auditory cortex (A1)','8832d0cc-dd08-497f-878d-fce63aa17130','',NULL),('5a5c8b9d-a700-4fc7-a5b8-51bc0421a1b2','Dorsal striatum','3e8f9a47-1a7e-42a5-965c-e999c812078d','',NULL),('5f1c7e9f-c5fc-434b-b019-8c0bddbefb0e','Ventral posterior lateral nucleus','71c0b03a-a9bb-471d-9e20-7fa0a2a2f4bc','',NULL),('609b5083-c099-414f-ad17-b31f9cb400ab','Putamen','5a5c8b9d-a700-4fc7-a5b8-51bc0421a1b2','',NULL),('6112214c-c96f-4858-b2da-0a5b958da36c','Tegmental pontine reticular nucleus','ad09e53d-8355-45ba-b6ee-18ff7a08c938','',NULL),('615bead9-80da-4aab-ae07-f0b59414284c','Pneumotaxic center','a7556b8d-9603-4764-9235-45ccad946200','',NULL),('61e52b4e-da8a-4e11-9c1d-537e70446f41','Inferior temporal gyrus','40c5d7b0-ed0d-449d-a1ea-cba6d3450a56','',NULL),('6207b498-f9f3-4465-8550-2f240d3f58cd','Dentate nucleus','f7599644-7a85-49b7-983b-ebcb73252415','',NULL),('63e36147-55d8-4ec7-b8f5-83faa29062f5','Medial nuclear group','ca2fc855-4e7c-4538-84f1-dabe4a49fffe','\0',NULL),('6434b708-f842-4b87-aa15-f9a5c0743f6f','Tegmentum','4c2d772f-b3f4-4a6a-a255-78a290e0a75d','',NULL),('648d17b8-76d9-4dc5-adcd-13a0dd2f826a','Rhinencephalon (paleopallium)','55b76d8a-c89c-4fb0-9d4f-3ac9ed1f54d1','\0',NULL),('65941dfb-caff-4835-93c6-e1b6cd1ab312','Pons','d02fe979-c23a-4701-806d-c1156a2035d9','',NULL),('65d7e88d-55d3-45d8-9a99-9afe89a8bb16','Nucleus ambiguus','149bdebc-2aa2-40ce-8588-22300354e2f3','',NULL),('689ef960-f59d-4894-b6b0-e6ed05823284','Cingulate cortex','d8c601b4-09ec-4f1d-8a2a-9a69111b0760','',NULL),('68a5f2b0-d979-4ada-81ed-a0b2d6dfc253','Occipital lobe','d8c601b4-09ec-4f1d-8a2a-9a69111b0760','\0',NULL),('68a75c61-5cbc-47d6-8f38-b6189bae25ef','Frontal lobe','d8c601b4-09ec-4f1d-8a2a-9a69111b0760','\0',NULL),('69b1324b-ea13-42db-bc3c-a34b3250d101','Brodmann area 6','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('6ae626d2-618e-43fb-9007-6735e3e46882','Posterior lobe','3aef86b7-463c-4b34-aa0a-c87c26a55165','',NULL),('6b16ef90-57f3-44a6-8812-51690a760c8b','Midbrain reticular formation','6434b708-f842-4b87-aa15-f9a5c0743f6f','',NULL),('6c25d9a0-1cc3-4a01-938b-45712b99f0ca','Brodmann area 8','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('6cc18b8c-301b-4857-9051-4f280ec007c6','Medial geniculate body','219151c0-484d-47e8-a7a7-e950c69f6352','',NULL),('6e0ecaa4-cd9e-414f-93ba-055a62b75477','Interpeduncular nucleus','4c2d772f-b3f4-4a6a-a255-78a290e0a75d','',NULL),('70e76b77-584b-4e34-ae3a-1bcb3f2c49ce','Anterior perforated substance','7ecd7ae0-5250-4ed2-b095-03499984fb90','',NULL),('7193cfad-10c0-49ab-8c52-81f1c5bdc4b2','Mammilary bodies','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('71c0b03a-a9bb-471d-9e20-7fa0a2a2f4bc','Ventral nuclear group','ca2fc855-4e7c-4538-84f1-dabe4a49fffe','\0',NULL),('72dcdede-2330-4d8a-aba1-dfb561bb732b','Tectum','0b75a10a-4bab-4a49-8a1e-e02cc948308c','',NULL),('73feb449-44d5-469e-a45a-5aaf99f37f96','Anterior nuclear group','ca2fc855-4e7c-4538-84f1-dabe4a49fffe','\0',NULL),('75e94547-1a45-46b7-8557-7adbef525423','Tuberomammillary nucleus','21cff2e3-3555-45d0-a2e6-8bbbd00d2412','',NULL),('75ea29c7-732b-4471-b2e1-6d94c05d7f65','Periaqueductal gray','6434b708-f842-4b87-aa15-f9a5c0743f6f','',NULL),('75f454d7-5c14-44e1-82b4-90249a571f26','Gyri','68a75c61-5cbc-47d6-8f38-b6189bae25ef','\0',NULL),('75fe596e-a526-4953-930f-c340c5fae3c3','Adenohypophysis','4eba31e2-6250-4c9c-9c27-ebcbca3a3748','',NULL),('781d18c5-eb85-4483-b0a6-81fb8d9442cb','Optic chiasm','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('7869bbb8-e48f-4a84-8e91-5eed3eeae832','Supplementary motor cortex','0fb7b288-b7f2-4bc3-99e7-574f65dd0529','',NULL),('7969404d-c80a-4e01-8f27-25ca7c8b22fd','Brodmann area 39','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('79f80668-599b-476a-814a-ec3cb29f6842','Motor nucleus of trigeminal nerve (V)','4f611531-614e-48c3-8799-af01098c1002','',NULL),('7a58adb8-0af9-43e4-ac08-3eb7d69d5509','Midline nuclear group','63e36147-55d8-4ec7-b8f5-83faa29062f5','\0',NULL),('7c64ff43-370a-467a-8165-96d2a11963bc','Superior salivatory nucleus','4f611531-614e-48c3-8799-af01098c1002','',NULL),('7c9bab52-9bf5-4ed4-b4b8-45081bb8c06f','Neurohypophysis','4eba31e2-6250-4c9c-9c27-ebcbca3a3748','',NULL),('7ecd7ae0-5250-4ed2-b095-03499984fb90','Basal forebrain','23c25d90-2af8-4689-b7fa-8d94f742936d','\0',NULL),('7ff21a54-6343-40d4-a253-9b5f0cec9580','Primary visual cortex (V1)','cef74acb-d24b-4265-a8f1-b1d80bea4eb7','',NULL),('81094fc5-4463-46ea-8c5d-db400423bc21','Brodmann area 31','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('83d494c8-6c80-495a-8287-32b77b043d63','Zona incerta','a28244a8-9a12-4ebb-a582-821ac78e7917','',NULL),('8440be49-81d8-41ca-9f67-5af832f91b2e','Mesencephalic cranial nerve nuclei','0b75a10a-4bab-4a49-8a1e-e02cc948308c','\0',NULL),('85938632-9ec1-4ef1-8afd-8bc9a4804e11','Facial nerve nucleus (VII)','4f611531-614e-48c3-8799-af01098c1002','',NULL),('85bea79e-fdbe-4256-94c4-c152a6ed9217','Habenular nuclei','c766825a-efda-4ea1-ba16-082511c74823','',NULL),('861a4c04-8e2a-40e3-94af-58475957e17b','Cerebellum','d02fe979-c23a-4701-806d-c1156a2035d9','',NULL),('874aef1f-d8ac-48fe-8c5a-cec7c32fd221','CA area 3','a4c20349-7b88-49e1-b653-ef1ace16288c','',NULL),('8832d0cc-dd08-497f-878d-fce63aa17130','Cortices','c9c1b21c-0d9b-4519-9575-f2a7282b1665','\0',NULL),('883d8c28-eb37-4a35-982d-1e5a0eb4db21','Basolateral nuclei','d519a7dd-6ce1-45ff-9ecb-4c198d2bbe17','',NULL),('89766b6c-eacb-452e-a237-57ee3304eada','Myelencephalon','f94a4e5a-a5f4-4bad-8e8d-938eda7ff5b3','\0',NULL),('8a60487a-c96b-4b2f-91d4-c04471bf6e81','Itermediate pituitary','4eba31e2-6250-4c9c-9c27-ebcbca3a3748','',NULL),('8afbd7fe-4dd5-4a74-99f7-40a71be381b0','Posterior','228f4222-71ba-42e9-9e64-d7eb3922ec91','\0',NULL),('8b585df5-6135-46b5-b341-f57f9492be9d','Central lateral nucleus','92fdaef5-59f7-4b6d-8d5c-6f793d165dae','',NULL),('8bd45320-aef2-4871-a30e-a6de50a2a9e8','Anterior commisure','648d17b8-76d9-4dc5-adcd-13a0dd2f826a','',NULL),('8c3718a8-58ba-4644-8329-aa854e228999','Arcuate nucleus','2fdf3722-7d54-491b-9f7d-08fbd2817cd3','',NULL),('8f512675-192e-46d7-9370-622688b236ea','Oculomotor (III)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('8ff2c69b-9218-4a9a-a17e-684a0421f035','Brodmann area 24','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('9008a39a-ce3c-48ab-9cf2-def5305a4821','Indusium griseum','689ef960-f59d-4894-b6b0-e6ed05823284','',NULL),('90b65817-df91-463d-aa40-0dda6fc193eb','Laterodorsal tegmental nucleus','ad09e53d-8355-45ba-b6ee-18ff7a08c938','',NULL),('913731c0-b04d-4b19-bf4d-de559e454a66','Medial septal nuclei','7ecd7ae0-5250-4ed2-b095-03499984fb90','',NULL),('92642535-e8b0-4f9e-b8ba-faae309ce0a0','Paracentral nucleus','92fdaef5-59f7-4b6d-8d5c-6f793d165dae','',NULL),('9278ad36-8a78-4f28-900e-06bdcddd40e7','Flocculonodular lobe','3aef86b7-463c-4b34-aa0a-c87c26a55165','',NULL),('92fdaef5-59f7-4b6d-8d5c-6f793d165dae','Intralaminar nuclear group','63e36147-55d8-4ec7-b8f5-83faa29062f5','\0',NULL),('9368450b-8a78-4969-b213-fd13310aabc9','Lateral nucleus','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('94dadca8-62b1-43c0-beab-02d991ae5b8e','Brodmann area 9','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('95df18ee-7eb1-4919-9e3e-914e2019406d','Terminal (0)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('96bbde80-a2ee-41ef-9bca-c263cd2ed976','Forebrain (prosencephalon)','eb684384-2b15-4fa6-820d-dacba61863ad','\0',NULL),('9700ccbc-5c43-49ba-bf06-09f0e22ca608','Medial nucleus','d519a7dd-6ce1-45ff-9ecb-4c198d2bbe17','',NULL),('97aba69e-4189-4715-8311-3b714439569e','Pulvinar','a9168b2b-d744-45ab-8540-1605fdc39185','',NULL),('98c6effc-719d-4931-a30a-9a9c0ebca861','Brodmann area 7','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('9914801c-3f9d-461b-af07-0a123d28b1da','Retrosplenial cortex','689ef960-f59d-4894-b6b0-e6ed05823284','',NULL),('9a7c0686-09c3-4923-8c58-513b95d396fd','Stria medullares','c766825a-efda-4ea1-ba16-082511c74823','',NULL),('9c6a42bf-1133-49b1-97a8-f7993f585981','Anteromedial nucleus','73feb449-44d5-469e-a45a-5aaf99f37f96','',NULL),('9e67f31e-ba01-408f-9eef-66fc511bfc98','Primary somatosensory cortex (postcentral gyrus, S1)','1a723408-1d7f-4d38-bcff-4ffcb86f0649','',NULL),('9e761451-fdf4-4b44-a13f-9ed1b8aa64ff','Brodmann area 47','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('9ee84d78-d5ba-485a-a7c5-d1fe7fd17f2b','Anterior hypothalamic nucleus','a8061fd5-d940-4c3d-a895-963eddcad71c','',NULL),('a0fbad4a-7349-42ea-bf02-f461747a85bd','Pituitary stalk','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('a15a3817-9e70-4133-91c6-a41d9bd5d9e0','Brodmann area 18','f58eabe8-7f52-4184-a751-7ff1ea971aad','',NULL),('a28244a8-9a12-4ebb-a582-821ac78e7917','Subthalamus','51a8f6e4-72f6-4a12-b3a5-9e968821a02e','',NULL),('a4c20349-7b88-49e1-b653-ef1ace16288c','Cornu ammonis','354e709e-9314-4111-a024-5852f145bded','',NULL),('a5abe526-a48d-4855-8819-ee1fd080625d','Brodmann area 1','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('a5b9af21-0bea-42b5-b5dd-4825007b6822','Respiratory center','ae98d55b-0381-44d0-915f-0005fba93b9c','',NULL),('a71cddb6-7640-4901-98f0-e7620e55a4ee','Basomedial nuclei','d519a7dd-6ce1-45ff-9ecb-4c198d2bbe17','',NULL),('a7556b8d-9603-4764-9235-45ccad946200','Respiratory centers','ad09e53d-8355-45ba-b6ee-18ff7a08c938','\0',NULL),('a7bf6dec-68e7-426c-9f97-0af2d71c430b','CA area 2','a4c20349-7b88-49e1-b653-ef1ace16288c','',NULL),('a8061fd5-d940-4c3d-a895-963eddcad71c','Anterior','228f4222-71ba-42e9-9e64-d7eb3922ec91','\0',NULL),('a88e6b4d-a601-4831-bac8-2176805e9388','Brodmann area 37','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('a8ed3c7e-81c5-485d-891a-e940e6d45fb9','Anterior olfactory nucleus','648d17b8-76d9-4dc5-adcd-13a0dd2f826a','',NULL),('a9168b2b-d744-45ab-8540-1605fdc39185','Lateral nuclear group','ca2fc855-4e7c-4538-84f1-dabe4a49fffe','\0',NULL),('a92b4f00-99e8-438b-9727-a3bfb77da8fc','Vestibulocochlear (VIII)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('a94e4942-07e8-4a8c-a334-bfcae91021dc','Middle temporal gyrus','40c5d7b0-ed0d-449d-a1ea-cba6d3450a56','',NULL),('ad09e53d-8355-45ba-b6ee-18ff7a08c938','Pontine tegmentum','65941dfb-caff-4835-93c6-e1b6cd1ab312','',NULL),('ad5706dd-8dd5-411f-8d2c-5b7f6f39ec67','Brodmann area 32','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('ae98d55b-0381-44d0-915f-0005fba93b9c','Medulla oblongata','89766b6c-eacb-452e-a237-57ee3304eada','',NULL),('aec6cb5a-e9c5-4c46-a439-8f7cbe7d801e','Brodmann area 34','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('af2b6722-23b5-4d46-9b97-2c6345f370ed','Substantia nigra','4c2d772f-b3f4-4a6a-a255-78a290e0a75d','',NULL),('af62d4fc-abc4-4741-ba84-6c4b41ee4e1b','Brodmann area 22','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('b0b129d2-024a-4978-ae51-92d74ef84895','Caudate nucleus','5a5c8b9d-a700-4fc7-a5b8-51bc0421a1b2','',NULL),('b3025898-fce9-433f-9d2f-07973959d1a5','Superior frontal gyrus','75f454d7-5c14-44e1-82b4-90249a571f26','',NULL),('b32156ff-26e0-461e-b634-a1c676972441','Cerebellar vermis','861a4c04-8e2a-40e3-94af-58475957e17b','',NULL),('b3b4f34f-323b-4d2e-a4f2-3573e6242f64','Ventral tegmental area','6434b708-f842-4b87-aa15-f9a5c0743f6f','',NULL),('b59117f7-4e8b-4e58-86f9-9567f7a638c2','Inferior frontal gyrus','75f454d7-5c14-44e1-82b4-90249a571f26','',NULL),('b6d6f03c-75a7-4d9b-989e-c89d3209a64f','Thalamic reticular nucleus','ca2fc855-4e7c-4538-84f1-dabe4a49fffe','',NULL),('b8f8014f-05bb-4019-9639-be1378634936','Medial dorsal nucleus','63e36147-55d8-4ec7-b8f5-83faa29062f5','',NULL),('b9275c4c-5f54-46e5-83a1-16976177e3ae','Anteroventral nucleus','73feb449-44d5-469e-a45a-5aaf99f37f96','',NULL),('b93f142c-922e-4cb8-83f9-b569d09d76b3','Inferior temporal cortex','8832d0cc-dd08-497f-878d-fce63aa17130','',NULL),('b9913fe7-677a-4918-8056-564f0d0978a8','Periventricular preoptic nucleus','a8061fd5-d940-4c3d-a895-963eddcad71c','',NULL),('ba2b3322-08ca-414a-a3cb-0e02afb51d5a','Globus pallidus','43bc5117-40e7-4a48-9954-5743e3563caf','',NULL),('baac3240-47a8-4bff-8bc5-613cf88e3537','Brodmann area 25','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('bcef2eb4-825b-42ad-84b2-49b73f682718','Brodmann area 2','c5c20f94-9bbc-47b5-9c90-045f8d669439','',NULL),('be107867-5829-42e2-b7bd-d1e4156ee00e','Anterodorsal nucleus','73feb449-44d5-469e-a45a-5aaf99f37f96','',NULL),('be202a67-89d7-42f4-8f82-3f5ba4c8f280','Hypoglossal (XII)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('c2144758-9f1b-4eda-8ba8-030ef0eee453','White matter','55b76d8a-c89c-4fb0-9d4f-3ac9ed1f54d1','\0',NULL),('c2c212bf-0f2c-4b30-b35b-db99625418f0','Primary auditory cortex (A1)','8832d0cc-dd08-497f-878d-fce63aa17130','',NULL),('c5c20f94-9bbc-47b5-9c90-045f8d669439','Brodmann areas','2219aaaa-f899-4c99-9c53-b96678f6d370','\0',NULL),('c63d7c30-b869-4022-9a3a-b9618ecb7300','Lateral posterior nucleus','a9168b2b-d744-45ab-8540-1605fdc39185','',NULL),('c766825a-efda-4ea1-ba16-082511c74823','Epithalamus','51a8f6e4-72f6-4a12-b3a5-9e968821a02e','',NULL),('c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','Brodmann areas','68a75c61-5cbc-47d6-8f38-b6189bae25ef','\0',NULL),('c7aa1a07-f00b-4a39-ac12-5257e87ad88b','Corona radiata','c2144758-9f1b-4eda-8ba8-030ef0eee453','',NULL),('c97afa80-9f7b-4c9e-937c-357ac6d0bc0c','Suprachiasmatic nucleus','a8061fd5-d940-4c3d-a895-963eddcad71c','',NULL),('c9c1b21c-0d9b-4519-9575-f2a7282b1665','Temporal lobe','d8c601b4-09ec-4f1d-8a2a-9a69111b0760','\0',NULL),('ca020447-7e1c-4f2c-bd2b-c676d44e8b31','Fusiform gyrus','40c5d7b0-ed0d-449d-a1ea-cba6d3450a56','',NULL),('ca2fc855-4e7c-4538-84f1-dabe4a49fffe','Thalamus','51a8f6e4-72f6-4a12-b3a5-9e968821a02e','',NULL),('cc651344-eba5-4670-85a7-406c7e1a4f56','Dorsal nucleus of vagus nerve','149bdebc-2aa2-40ce-8588-22300354e2f3','',NULL),('cc95088a-48d9-4deb-b665-c0c5a78e96f8','Brodmann area 20','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('cef74acb-d24b-4265-a8f1-b1d80bea4eb7','Cortices','68a5f2b0-d979-4ada-81ed-a0b2d6dfc253','\0',NULL),('d02fe979-c23a-4701-806d-c1156a2035d9','Metencephalon','f94a4e5a-a5f4-4bad-8e8d-938eda7ff5b3','\0',NULL),('d03748c2-c8a6-489a-a0e3-ba8a2402b761','Paramedian pontine reticular formation','65941dfb-caff-4835-93c6-e1b6cd1ab312','',NULL),('d0413c41-92fd-40e5-ad11-6e9826d13a9b','Tuberal region','228f4222-71ba-42e9-9e64-d7eb3922ec91','',NULL),('d0d18812-c495-4473-8a7a-ed8f16c6ac01','Inferior cerebellar peduncle','3f26fc2c-1b4e-4554-9e88-ce9c8e29aa7e','',NULL),('d177a2e3-a235-4587-aea4-250135db704d','Nucleus accumbens','ee61d43d-296b-493e-be33-311685798df2','',NULL),('d2374c88-46db-4557-a2a1-3ed758e8e4da','Uncinate fasciculus','c2144758-9f1b-4eda-8ba8-030ef0eee453','',NULL),('d519a7dd-6ce1-45ff-9ecb-4c198d2bbe17','Amygdala','23c25d90-2af8-4689-b7fa-8d94f742936d','',NULL),('d640e4a0-0b43-4bec-bfc8-a9a28017cd62','Internal capsule','c2144758-9f1b-4eda-8ba8-030ef0eee453','',NULL),('d6d1bdf6-4626-4f77-bca8-3c99d95288e3','Brodmann area 45','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('d774d397-00d4-4c50-af8b-7de5d1b79d64','Dentate gyrus','354e709e-9314-4111-a024-5852f145bded','',NULL),('d8015ca2-bcdb-4632-a0fb-752873e5e548','Tuberal nucleus','21cff2e3-3555-45d0-a2e6-8bbbd00d2412','',NULL),('d822fd30-8d7a-4640-bfd1-52d3922d1cdf','Dorsomedial hypothalamic nucleus','2fdf3722-7d54-491b-9f7d-08fbd2817cd3','',NULL),('d84cd3f7-074b-4e30-8745-f5f6123ccbcc','Middle cerebellar peduncle','3f26fc2c-1b4e-4554-9e88-ce9c8e29aa7e','',NULL),('d8c601b4-09ec-4f1d-8a2a-9a69111b0760','Cerebral cortex (neopallium)','55b76d8a-c89c-4fb0-9d4f-3ac9ed1f54d1','\0',NULL),('d989d991-1ad3-4b2d-b5b1-45408c06b1d0','Olfactory (I)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('db46009d-68e9-4133-ae92-18f7889ffa38','Brodmann area 12','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('db73a066-3c6c-4b74-8cf1-cdcf068babb3','Secondary somatosensory cortex (S2)','1a723408-1d7f-4d38-bcff-4ffcb86f0649','',NULL),('dc5adf96-7b9c-4456-b9fc-0ffe6afb3e6f','Superior olivary complex','65941dfb-caff-4835-93c6-e1b6cd1ab312','',NULL),('dd96a752-1292-4d93-ad3a-8ebc77da1832','Brodmann area 10','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('de0eb51f-b2e8-4c94-9b9b-e4ab1779a1e7','Superior temporal gyrus','40c5d7b0-ed0d-449d-a1ea-cba6d3450a56','',NULL),('df07e797-adc1-4742-bc3d-b2f0ad19f028','Brodmann area 41','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('dfae037b-15c7-48f3-99f3-a729c6466164','Lateral geniculate body','219151c0-484d-47e8-a7a7-e950c69f6352','',NULL),('e009ab72-7d85-4db6-a587-469d7a7a3172','Medullary pyramids','ae98d55b-0381-44d0-915f-0005fba93b9c','',NULL),('e06a4e4e-c681-4a1d-91e2-3a235a28f7da','Ventromedial nucleus','2fdf3722-7d54-491b-9f7d-08fbd2817cd3','',NULL),('e3d39ae8-4a5e-4f10-93b9-4f8b0c5421bc','Accessory (XI)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('e3e918d3-00a9-4048-b6d1-36d8c2135dff','Premotor cortex','0fb7b288-b7f2-4bc3-99e7-574f65dd0529','',NULL),('e45984f7-c074-48af-a401-7c27851820ec','V5 / MT','cef74acb-d24b-4265-a8f1-b1d80bea4eb7','',NULL),('e634d487-7668-44ba-b77e-5633e445b190','Medial preoptic nucleus','a8061fd5-d940-4c3d-a895-963eddcad71c','',NULL),('e70f678a-ac88-4d9a-8964-7eff1b8367a1','Vagus (X)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('e792d1ca-610b-45ca-a279-126dd9b91332','Centromedial nucleus','92fdaef5-59f7-4b6d-8d5c-6f793d165dae','',NULL),('eb684384-2b15-4fa6-820d-dacba61863ad','Brain',NULL,'\0',NULL),('ecc57b03-cec8-4914-9135-d17d06e007d9','Hypoglossal nucleus','149bdebc-2aa2-40ce-8588-22300354e2f3','',NULL),('ed7c597c-2bd5-42d9-9a8d-0e8d832fefd9','Pars reticulata','af2b6722-23b5-4d46-9b97-2c6345f370ed','',NULL),('eda804ae-7f89-4c85-a022-5a0cf73ed68c','Nucleus basalis','7ecd7ae0-5250-4ed2-b095-03499984fb90','',NULL),('ee61d43d-296b-493e-be33-311685798df2','Ventral striatum','3e8f9a47-1a7e-42a5-965c-e999c812078d','',NULL),('eea785cd-88d4-4928-8f3b-363fa7535c64','Brodmann area 35','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('f31897ff-61e0-493a-9789-d002db8de689','Inferior colliculi','4894e54f-367f-476e-83f2-7e3dec23814b','',NULL),('f375540b-7eb3-442c-a315-f44557ee24f8','Facial (VII)','1042a1e8-fed9-4794-ad7e-22f4bbe4063d','',NULL),('f3cd9eb3-ec76-4f57-b024-cb5f684b75d3','Brodmann area 33','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('f4d27edc-e2f3-4b82-bf0b-7451b89df976','Brodmann area 21','456578c5-d926-4e9b-ad9f-951748000bf8','',NULL),('f56e8e8e-237b-4edf-b659-6cba39949ae2','Brodmann area 17','f58eabe8-7f52-4184-a751-7ff1ea971aad','',NULL),('f58eabe8-7f52-4184-a751-7ff1ea971aad','Brodmann areas','68a5f2b0-d979-4ada-81ed-a0b2d6dfc253','\0',NULL),('f7599644-7a85-49b7-983b-ebcb73252415','Cerebellar nuclei','861a4c04-8e2a-40e3-94af-58475957e17b','\0',NULL),('f85e23ab-3c1a-47a2-b609-2de6f2ffd15a','Claustrum','23c25d90-2af8-4689-b7fa-8d94f742936d','',NULL),('f9238b86-6ec9-438d-ae23-9f0aafdf939f','Nerves',NULL,'\0',NULL),('f94a4e5a-a5f4-4bad-8e8d-938eda7ff5b3','Hindbrain (rhombencephalon)','eb684384-2b15-4fa6-820d-dacba61863ad','\0',NULL),('f9c6459e-99aa-4951-b71e-2d3ef3bef811','Posterior cingulate','689ef960-f59d-4894-b6b0-e6ed05823284','',NULL),('fd42bb65-6418-4d7f-a17a-fe8fac0bdb2f','Brodmann area 4','c78d94d2-7d9f-4ed1-9b6a-086f0dcc2274','',NULL),('fe1abc51-90ab-483e-8e0e-33081949ba06','Median preoptic nucleus','a8061fd5-d940-4c3d-a895-963eddcad71c','',NULL),('fe206c62-092e-4943-a315-5be41de51767','Olfactory bulb','648d17b8-76d9-4dc5-adcd-13a0dd2f826a','',NULL),('ffaad7fa-9f22-4833-960b-1bcfb2f3e9ac','Insular cortex','d8c601b4-09ec-4f1d-8a2a-9a69111b0760','',NULL),('ffc79cc0-cbf1-4f4c-98dd-e30f432adffb','Posterior parietal cortex','1a723408-1d7f-4d38-bcff-4ffcb86f0649','',NULL);
/*!40000 ALTER TABLE `tissue_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `model_organisms`
--

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

--
-- Dumping data for table `model_organisms`
--

LOCK TABLES `model_organisms` WRITE;
/*!40000 ALTER TABLE `model_organisms` DISABLE KEYS */;
/*!40000 ALTER TABLE `model_organisms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `age_units`
--

DROP TABLE IF EXISTS `age_units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `age_units` (
  `Id` char(36) NOT NULL,
  `Name` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `age_units`
--

LOCK TABLES `age_units` WRITE;
/*!40000 ALTER TABLE `age_units` DISABLE KEYS */;
/*!40000 ALTER TABLE `age_units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `result_types`
--

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

--
-- Dumping data for table `result_types`
--

LOCK TABLES `result_types` WRITE;
/*!40000 ALTER TABLE `result_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `result_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `version`
--

DROP TABLE IF EXISTS `version`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `version` (
  `Id` char(36) NOT NULL,
  `Version` varchar(15) DEFAULT NULL COMMENT 'A string for the db''s version number',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `version`
--

LOCK TABLES `version` WRITE;
/*!40000 ALTER TABLE `version` DISABLE KEYS */;
INSERT INTO `version` VALUES ('04e629c4-1e8e-4d49-b2d4-7b996467afb8','3.13');
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

-- Dump completed on 2016-01-09  0:45:01
