-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 02 okt 2023 om 15:20
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
-- Tabelstructuur voor tabel `doctrine_migration_versions`
--

DROP TABLE IF EXISTS `doctrine_migration_versions`;
CREATE TABLE `doctrine_migration_versions` (
  `version` varchar(191) COLLATE utf8_unicode_ci NOT NULL,
  `executed_at` datetime DEFAULT NULL,
  `execution_time` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Gegevens worden geëxporteerd voor tabel `doctrine_migration_versions`
--

INSERT INTO `doctrine_migration_versions` (`version`, `executed_at`, `execution_time`) VALUES
('DoctrineMigrations\\Version20221101124145', '2023-09-15 13:14:16', 129),
('DoctrineMigrations\\Version20230915103330', '2023-09-15 13:14:16', 77),
('DoctrineMigrations\\Version20230915103828', '2023-09-15 13:14:16', 20),
('DoctrineMigrations\\Version20230915104242', '2023-09-15 13:14:16', 142),
('DoctrineMigrations\\Version20230920083659', '2023-09-20 10:37:12', 91),
('DoctrineMigrations\\Version20230920083831', '2023-09-20 10:38:35', 43),
('DoctrineMigrations\\Version20230920084807', '2023-09-20 10:48:18', 44),
('DoctrineMigrations\\Version20230920084908', '2023-09-20 10:49:11', 44),
('DoctrineMigrations\\Version20230925114437', '2023-09-25 13:44:41', 66),
('DoctrineMigrations\\Version20230925114456', '2023-09-25 13:44:59', 41),
('DoctrineMigrations\\Version20230925114550', '2023-09-25 13:45:53', 67),
('DoctrineMigrations\\Version20231002091040', '2023-10-02 11:10:44', 42);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `messenger_messages`
--

DROP TABLE IF EXISTS `messenger_messages`;
CREATE TABLE `messenger_messages` (
  `id` bigint(20) NOT NULL,
  `body` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `headers` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `queue_name` varchar(190) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime NOT NULL,
  `available_at` datetime NOT NULL,
  `delivered_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `reservations`
--

DROP TABLE IF EXISTS `reservations`;
CREATE TABLE `reservations` (
  `id` int(11) NOT NULL,
  `point_a` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `point_b` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `start_date_time` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `end_date_time` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Gegevens worden geëxporteerd voor tabel `reservations`
--

INSERT INTO `reservations` (`id`, `point_a`, `point_b`, `start_date_time`, `end_date_time`, `user_id`) VALUES
(5, 'Tinwerf 14', 'Tinwerf 14', '3-10-2023 14:00 ', '3-10-2023  15:00', 8),
(6, 'sda', 'asd', '8-10-2023 13:00 ', '8-10-2023  14:00', 8),
(7, 'dsf', 'sdf', '4-10-2023 10:00 ', '4-10-2023  11:00', 8),
(8, 'fdgz', 'ewr ', '5-10-2023 14:00 ', '5-10-2023  15:00', 8),
(9, 'dfgg', 'dfg', '15-10-2023 13:00 ', '15-10-2023  14:00', 8),
(10, 'ilgk', 'hjk', '14-10-2023 10:00 ', '14-10-2023  11:00', 8),
(11, 'yyy', 'yyyyy', '3-10-2023 10:00 ', '3-10-2023  11:00', 8),
(12, 'vcx', 'vcx', '20-10-2023 12:00 ', '20-10-2023  13:00', 8),
(13, 'cxv', 'xcv', '21-10-2023 10:00 ', '21-10-2023  11:00', 8);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `email` varchar(180) COLLATE utf8mb4_unicode_ci NOT NULL,
  `roles` longtext COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '(DC2Type:json)',
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `function` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `full_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Gegevens worden geëxporteerd voor tabel `user`
--

INSERT INTO `user` (`id`, `email`, `roles`, `password`, `function`, `full_name`) VALUES
(1, 'ewffe', '[\"ROLE_ADMIN\"]', '123', 'stage', 'smurf van cat'),
(2, 'test', '[\"ROLE_ADMIN\"]', '$2y$13$OpeR3CRO9IkSX7FXRKw1Xe6x6eh6U3d7pm9U7GRjTVgKeWbTNlh1C', 'stage', 'pepijn van marwn'),
(3, 'gianni@gmail.com', '[\"ROLE_ADMIN\"]', ' $2y$13$lizaA.DSBWZiNH4/d9xQ3OxOzfF0s3ilMaDSa/JYiFb5ngJpPkqv.', '', ''),
(4, 'wouter@gmail.com', '[\"ROLE_ADMIN\"]', '$2y$13$VXvMeqeJWG7A321Eo7vzJ.oBWeiON7gk0jdcoNR7KiuJ9XCbXnfF2', '', ''),
(5, 'rachel@gmail.com', '[\"ROLE_ADMIN\"]', '$2y$13$VXvMeqeJWG7A321Eo7vzJ.oBWeiON7gk0jdcoNR7KiuJ9XCbXnfF2', '', ''),
(6, 'feraz@gmail.com', '[\"ROLE_MEMBER\"]', '$2y$13$VXvMeqeJWG7A321Eo7vzJ.oBWeiON7gk0jdcoNR7KiuJ9XCbXnfF2', '', ''),
(7, 'depropepijn@gmail.com', '[\"ROLE_ADMIN\"]', '$2y$13$16vTc5TcVSy1YX39jIURxueuKF9xK92B0eZqhqCjzJS1yz6kfM7cG', 'stagair', 'pepijn van maren'),
(8, 'a@a.a', '[\"ROLE_USER\"]', '$2y$10$.hmjGgxEVFmaAnHgIt5Iouks4lWBsiAWyq/iiC/p6trHYlXN1beGm', 'Sagiaire', 'Gianni Ramdjiawan');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `doctrine_migration_versions`
--
ALTER TABLE `doctrine_migration_versions`
  ADD PRIMARY KEY (`version`);

--
-- Indexen voor tabel `messenger_messages`
--
ALTER TABLE `messenger_messages`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IDX_75EA56E0FB7336F0` (`queue_name`),
  ADD KEY `IDX_75EA56E0E3BD61CE` (`available_at`),
  ADD KEY `IDX_75EA56E016BA31DB` (`delivered_at`);

--
-- Indexen voor tabel `reservations`
--
ALTER TABLE `reservations`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UNIQ_8D93D649E7927C74` (`email`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `messenger_messages`
--
ALTER TABLE `messenger_messages`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `reservations`
--
ALTER TABLE `reservations`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT voor een tabel `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
