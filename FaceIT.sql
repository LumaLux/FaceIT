-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jun 14, 2017 at 12:31 PM
-- Server version: 10.1.22-MariaDB
-- PHP Version: 7.1.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `FaceIT`
--
CREATE DATABASE IF NOT EXISTS `FaceIT` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `FaceIT`;

-- --------------------------------------------------------

--
-- Table structure for table `klas`
--

CREATE TABLE `klas` (
  `KlasNaam` varchar(50) NOT NULL,
  `Periode` int(1) NOT NULL,
  `AantalLeerlingen` int(3) NOT NULL,
  `AantalLessen` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `klas`
--

INSERT INTO `klas` (`KlasNaam`, `Periode`, `AantalLeerlingen`, `AantalLessen`) VALUES
('hoi', 5, 6, 9),
('Test', 1, 2, 3),
('TestNaam', 1, 2, 3);

-- --------------------------------------------------------

--
-- Table structure for table `leerling`
--

CREATE TABLE `leerling` (
  `ID` int(11) NOT NULL COMMENT 'Een auto increment uniek nummer voor een student (Primary Key)',
  `Folder` varchar(254) NOT NULL,
  `Aanwezig` int(11) NOT NULL COMMENT 'Hoeveel lessen de leerling aanwezig was',
  `Klas_KlasNaam` varchar(45) NOT NULL COMMENT '   Klas_KlasNaam  De naam van de klas waar de leerling in zit',
  `Klas_Periode` int(11) NOT NULL COMMENT 'De Periode waarin de Klas zit'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `leerling`
--

INSERT INTO `leerling` (`ID`, `Folder`, `Aanwezig`, `Klas_KlasNaam`, `Klas_Periode`) VALUES
(1, '01', 2, 'INF1E', 4),
(2, '', 1, 'INF1A', 4),
(3, '', 1, 'INF1B', 4),
(4, '', 1, 'testertje', 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `klas`
--
ALTER TABLE `klas`
  ADD PRIMARY KEY (`KlasNaam`,`Periode`);

--
-- Indexes for table `leerling`
--
ALTER TABLE `leerling`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `leerling`
--
ALTER TABLE `leerling`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Een auto increment uniek nummer voor een student (Primary Key)', AUTO_INCREMENT=5;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
