-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Erstellungszeit: 13. Feb 2018 um 07:58
-- Server-Version: 10.1.13-MariaDB
-- PHP-Version: 5.5.35

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `sprachquali`
--
DROP DATABASE `sprachquali`;
CREATE DATABASE IF NOT EXISTS `sprachquali` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `sprachquali`;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `person`
--

DROP TABLE IF EXISTS `person`;
CREATE TABLE `person` (
  `persnr` varchar(5) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `vorname` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `person`
--

INSERT INTO `person` (`persnr`, `name`, `vorname`) VALUES
('0105', 'marder', 'monika'),
('0234', 'hund', 'hugo'),
('0325', 'Stier', 'Siegfried'),
('2345', 'Antilope', 'Anita');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `sprachen`
--

DROP TABLE IF EXISTS `sprachen`;
CREATE TABLE `sprachen` (
  `persnr` varchar(5) DEFAULT NULL,
  `sprache` varchar(50) DEFAULT NULL,
  `grad` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `sprachen`
--

INSERT INTO `sprachen` (`persnr`, `sprache`, `grad`) VALUES
('0105', 'englisch', 2),
('0105', 'russisch', 3),
('0234', 'französisch', 1),
('0325', 'spanisch', 3),
('0325', 'französisch', 3),
('0325', 'portugisisch', 2),
('2345', 'polnisch', 3);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`persnr`);

--
-- Indizes für die Tabelle `sprachen`
--
ALTER TABLE `sprachen`
  ADD KEY `persnr` (`persnr`);

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `sprachen`
--
ALTER TABLE `sprachen`
  ADD CONSTRAINT `sprachen_ibfk_1` FOREIGN KEY (`persnr`) REFERENCES `person` (`persnr`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
