-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 13 sep 2023 om 13:18
-- Serverversie: 10.4.24-MariaDB
-- PHP-versie: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `zero_hero`
--
CREATE DATABASE IF NOT EXISTS `zero_hero` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `zero_hero`;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `password_reset_tokens`
--

DROP TABLE IF EXISTS `password_reset_tokens`;
CREATE TABLE `password_reset_tokens` (
  `id` int(10) NOT NULL,
  `email` varchar(255) NOT NULL,
  `token` int(10) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` int(10) NOT NULL,
  `username` varchar(255) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(50) NOT NULL,
  `points` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`id`, `username`, `hash`, `salt`, `points`) VALUES
(1, 'dsadsadsad', '$5$rounds=5000$steamedhamsdsads$Bvw5aAknv.1wHBeCqiTPms5Ks3dMUVKhj670LeBhcRD', '$5$rounds=5000$steamedhamsdsadsadsad$', 0),
(2, 'X', '$5$rounds=5000$steamedhams$KRaxREhYX4K9X8sbjvEHOJNSd9Wp/o6ds0La0x8egc0', '$5$rounds=5000$steamedhams$', 0),
(3, 'qwertyui', '$5$rounds=5000$steamedhamsqwert$AO2Uamoblw.EWoQhkmiGt9zV46LmHucdrZAD7Ru1pz2', '$5$rounds=5000$steamedhamsqwertyui$', 0),
(4, 'PepijnNeger', '$5$rounds=5000$steamedhamsPepij$rumD0c2IJi5LZcKABsReWoTAWJOV0br4XYxxRkTlGB.', '$5$rounds=5000$steamedhamsPepijnNeger$', 9999),
(5, 'f.ahmed@rocmondriaan.nl', '$5$rounds=5000$steamedhamsf.ahm$fbtWuMZPUcXqyiYKZ0xbjfJKCvt8N1LrYeN1fB0YpZ.', '$5$rounds=5000$steamedhamsf.ahmed@rocmondriaan.nl$', 0);

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `password_reset_tokens`
--
ALTER TABLE `password_reset_tokens`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `password_reset_tokens`
--
ALTER TABLE `password_reset_tokens`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
