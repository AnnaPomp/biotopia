-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jun 11, 2025 at 07:21 AM
-- Server version: 5.7.24
-- PHP Version: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `logindatabaseunity`
--

-- --------------------------------------------------------

--
-- Table structure for table `classes`
--

CREATE TABLE `classes` (
  `id` int(11) NOT NULL,
  `class_name` varchar(100) NOT NULL,
  `teacher_username` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `classes`
--

INSERT INTO `classes` (`id`, `class_name`, `teacher_username`) VALUES
(1, 'clasanoua', 'profesornou1'),
(2, 'clasamea12', 'profesornou1'),
(3, 'clasamea_test_1', 'profesornou1'),
(4, 'test__1', 'profesornou1'),
(5, 'clasamea', 'profesornou1'),
(6, 'clasaprofesor', 'profesornou1'),
(7, 'clasameadetest', 'profesornou1'),
(8, '11A', 'profff1234'),
(9, 'clasa 11 A', 'proflungu'),
(10, 'clasa11a', 'profesorluigi'),
(11, 'clasameaa', 'profesor_ana'),
(12, 'clasamea_test', 'profesor_ana'),
(13, 'clas', 'profesor_ana'),
(14, 'clasmeu', 'profesor_ana'),
(15, 'clasamea', 'profesor_ana'),
(16, 'tst_an11', 'profesor_ana'),
(17, 'prof_an', 'profesor_ana'),
(18, 'clasa_11_a', 'prof_annna'),
(19, 'clasa 11 A', 'profesorrobert'),
(20, 'clasa 11A', 'profesorecotopia'),
(21, 'clasa 9A', 'profesorelena'),
(22, '9a', 'profesorelena'),
(23, 'clasa 9a', 'profesoralbert'),
(24, 'clasa 9B', 'profesormario'),
(25, 'clasa 11 a', 'profesoranna'),
(26, 'clasa 10 d', 'profesoranna');

-- --------------------------------------------------------

--
-- Table structure for table `class_students`
--

CREATE TABLE `class_students` (
  `id` int(11) NOT NULL,
  `class_id` int(11) NOT NULL,
  `student_username` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `players`
--

CREATE TABLE `players` (
  `id` int(10) NOT NULL,
  `username` varchar(16) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(50) NOT NULL,
  `score` int(10) NOT NULL DEFAULT '0',
  `role` enum('elev','profesor') NOT NULL DEFAULT 'elev',
  `class_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `players`
--

INSERT INTO `players` (`id`, `username`, `hash`, `salt`, `score`, `role`, `class_name`) VALUES
(1, 'boardstobits', '$5$rounds=5000$steamedhamsboard$d/10N9sLsUzmoiqxD4Q39YTm4YE7eYY71rqYJo1c5SC', '$5$rounds=5000$steamedhamsboardstobits$', 0, 'elev', 'clasaprofesor'),
(2, 'boardtobits', '$5$rounds=5000$steamedhamsboard$d/10N9sLsUzmoiqxD4Q39YTm4YE7eYY71rqYJo1c5SC', '$5$rounds=5000$steamedhamsboardtobits$', 0, 'elev', NULL),
(3, 'anapomparau', '$5$rounds=5000$steamedhamsanapo$PwrWN4RTpD6vrrlnp6XZHX2DuXTXy82HePXCEfIdXT/', '$5$rounds=5000$steamedhamsanapomparau$', 11, 'elev', NULL),
(4, 'profesor', '$5$rounds=5000$steamedhamsprofe$6vPbzbicO7.vYUVkXt8WlKaYi7MGVMX6wgtrStnPLf.', '$5$rounds=5000$steamedhamsprofesor$', 13, 'elev', NULL),
(5, 'elev1234', '$5$rounds=5000$steamedhamselev1$HP39Dnztcfha3rWSlMAdEhWsb5/P6YTK8aFY4A7N4s6', '$5$rounds=5000$steamedhamselev1234$', 163, 'elev', 'clasamea'),
(6, 'contadmin', '$5$rounds=5000$steamedhamsconta$ZpVBiqU.1Kl7iZeGTv4NA2ot9ANC6lwQTE2JOS8OLL9', '$5$rounds=5000$steamedhamscontadmin$', 0, 'elev', NULL),
(7, 'Pompyst12345678', '$5$rounds=5000$steamedhamsPompy$FcL4xAdhvdndtx3O.6wT7eHCWs2aqIFWuUGQmy2w8I8', '$5$rounds=5000$steamedhamsPompyst12345678$', -20, 'elev', NULL),
(8, 'anapomparau2006', '$5$rounds=5000$steamedhamsanapo$PwrWN4RTpD6vrrlnp6XZHX2DuXTXy82HePXCEfIdXT/', '$5$rounds=5000$steamedhamsanapomparau2006$', 0, 'elev', NULL),
(9, 'anaeceamaitare', '$5$rounds=5000$steamedhamsanaec$HwaZCyhTtFUztCT/StJOrnMcO1mLwIbN5z/510oUHlD', '$5$rounds=5000$steamedhamsanaeceamaitare$', 0, 'elev', NULL),
(10, 'elev2345', '$5$rounds=5000$steamedhamselev2$J4plRJuGUJ8VfuvYUU.nJFH2TYVDqXKozyI6UDWFqo6', '$5$rounds=5000$steamedhamselev2345$', 0, 'elev', NULL),
(11, 'economie2006', '$5$rounds=5000$steamedhamsecono$q4Gu2wbu4Jhqmj.J0NV2oFKkUhOmLCgdbhDqo5LTXH6', '$5$rounds=5000$steamedhamseconomie2006$', 0, 'elev', NULL),
(12, '', '$5$rounds=5000$steamedhams$KRaxREhYX4K9X8sbjvEHOJNSd9Wp/o6ds0La0x8egc0', '$5$rounds=5000$steamedhams$', 0, 'elev', NULL),
(14, 'informatica', '$5$rounds=5000$steamedhamsinfor$TQa2666KEjgwZ93s/EAy5QDTKiTQrJo5.4AeCsXJm02', '$5$rounds=5000$steamedhamsinformatica$', 0, 'profesor', NULL),
(15, 'ionusprost', '$5$rounds=5000$steamedhamsionus$LdL03.SaYmIzUntREujmz9P.2rjT8ePNOccgGFi7vm9', '$5$rounds=5000$steamedhamsionusprost$', 0, 'profesor', NULL),
(16, 'teiubescmult', '$5$rounds=5000$steamedhamsteiub$Eyw5Lv4834OVM6qNFykOIwJqeWwbcpFzNR3Y0Vvkdc4', '$5$rounds=5000$steamedhamsteiubescmult$', 0, 'profesor', NULL),
(17, 'profesorinfo', '$5$rounds=5000$steamedhamsprofe$CKEQEpOyXnGdptssmjO2CQIsNTYCD6UlR0c928QVI84', '$5$rounds=5000$steamedhamsprofesorinfo$', 0, 'profesor', NULL),
(18, 'profesorinfo1', '$5$rounds=5000$steamedhamsprofe$CKEQEpOyXnGdptssmjO2CQIsNTYCD6UlR0c928QVI84', '$5$rounds=5000$steamedhamsprofesorinfo1$', 0, 'profesor', NULL),
(19, 'profesorinfo2', '$5$rounds=5000$steamedhamsprofe$gOUQicNFedpkh8bzlB1Px4rWkXYF71pJilbmk9gWhg.', '$5$rounds=5000$steamedhamsprofesorinfo2$', 0, 'profesor', NULL),
(20, 'profesorinfobun', '$5$rounds=5000$steamedhamsprofe$YgSOTOUuifoYP0QzE3Q4qBUFKyTFIglOkZVrg8IsNz4', '$5$rounds=5000$steamedhamsprofesorinfobun$', 0, 'profesor', NULL),
(21, 'malasdeviata', '$5$rounds=5000$steamedhamsmalas$9qU1NbA.9CkVmCXm0m6WHK3e5aVh4zUvOYNW0Y3ywe4', '$5$rounds=5000$steamedhamsmalasdeviata$', 0, 'profesor', NULL),
(22, 'helloworld', '$5$rounds=5000$steamedhamshello$TT2gtTQjAth/dUq3kR3msxNBw7Mz.64CIsgD65u97D6', '$5$rounds=5000$steamedhamshelloworld$', 0, 'profesor', NULL),
(23, 'fizicaefaina', '$5$rounds=5000$steamedhamsfizic$Th7LnUfEEmBFomqjEVxg2.HJv680gBpg3a1NwE1wR55', '$5$rounds=5000$steamedhamsfizicaefaina$', 0, 'profesor', NULL),
(24, 'anaaremere', '$5$rounds=5000$steamedhamsanaar$p0Ucyu2taokffq3TTnJRyK25yw8ZbsqCSWUsHJd.UW6', '$5$rounds=5000$steamedhamsanaaremere$', 0, 'profesor', NULL),
(25, 'profesorrau', '$5$rounds=5000$steamedhamsprofe$XOmz7A5lsJsLOt0Gxllv582fnulHb4y.JhzAf0QUADA', '$5$rounds=5000$steamedhamsprofesorrau$', 0, 'profesor', NULL),
(26, 'anapomparau7', '$5$rounds=5000$steamedhamsanapo$7gnmeRCXMYfo.42GzWp/C.On5rePyzbrAxU5EFPQtj4', '$5$rounds=5000$steamedhamsanapomparau7$', 0, 'profesor', NULL),
(27, 'numaipot', '$5$rounds=5000$steamedhamsnumai$vRqyStbXTPyhMsaGTc/tE4aRcXsogCPoc0ITb8D8wg7', '$5$rounds=5000$steamedhamsnumaipot$', 0, 'profesor', NULL),
(28, 'profesoradmin', '$5$rounds=5000$steamedhamsprofe$6vPbzbicO7.vYUVkXt8WlKaYi7MGVMX6wgtrStnPLf.', '$5$rounds=5000$steamedhamsprofesoradmin$', 0, 'profesor', NULL),
(29, 'elevtest', '$5$rounds=5000$steamedhamselevt$0DFkH6/eRXLXrWFHms0BiQwA3Yyvtxt9Dcsci1PJU.8', '$5$rounds=5000$steamedhamselevtest$', 0, 'elev', NULL),
(30, 'contnou2006', '$5$rounds=5000$steamedhamscontn$HhcKz232yEzCLwKiQQlj1bkAJgZpcgv7/Eghj/g1pd1', '$5$rounds=5000$steamedhamscontnou2006$', 61, 'elev', NULL),
(31, 'pastile2006', '$5$rounds=5000$steamedhamspasti$da8FUh9lljvCMBB525rzIN6WP8KE5ZX.7p2033HaUDA', '$5$rounds=5000$steamedhamspastile2006$', 0, 'elev', 'clasaprofesor'),
(32, 'elevnoubun', '$5$rounds=5000$steamedhamselevn$QF.PvzoPFhy0aiER1cjXjv6YIPBY0LiDTkMCpkv.qB.', '$5$rounds=5000$steamedhamselevnoubun$', 367, 'elev', NULL),
(33, 'elev6789', '$5$rounds=5000$steamedhamselev6$AH/aFy3nfn.bedA6Sw3bKJzse9lS8RByhzkwq/uduq/', '$5$rounds=5000$steamedhamselev6789$', 61, 'elev', NULL),
(34, 'nustiucenume', '$5$rounds=5000$steamedhamsnusti$XIV9mDC7qOsUIVKmnntZRpPgmjNoIHng/o.jxc11MbD', '$5$rounds=5000$steamedhamsnustiucenume$', -20, 'elev', NULL),
(35, 'idknumepun', '$5$rounds=5000$steamedhamsidknu$Pi/JOMRJ7SjcxGrOa7u1lxSmze7yBPJNhin6ypya7.B', '$5$rounds=5000$steamedhamsidknumepun$', -20, 'elev', NULL),
(36, 'elevinf2006', '$5$rounds=5000$steamedhamselevi$jNKBBySHEDfpYFitquEjnuENGPo0nMi7TIo1hC26FpB', '$5$rounds=5000$steamedhamselevinf2006$', -20, 'elev', NULL),
(37, 'ultimcontnou', '$5$rounds=5000$steamedhamsultim$0wnfERLoXO41u8YEO9OLeG/QkhT/U4Vv7Kq.eUSc1AD', '$5$rounds=5000$steamedhamsultimcontnou$', 0, 'elev', NULL),
(38, 'profesornouu', '$5$rounds=5000$steamedhamsprofe$6vPbzbicO7.vYUVkXt8WlKaYi7MGVMX6wgtrStnPLf.', '$5$rounds=5000$steamedhamsprofesornouu$', 0, 'profesor', NULL),
(39, 'eleveminescu', '$5$rounds=5000$steamedhamseleve$zFOcBDTWtnQD7nUed7oUSDcffPKGPJ/FDfWWzn8Ors5', '$5$rounds=5000$steamedhamseleveminescu$', 0, 'elev', NULL),
(40, 'elvlaurian', '$5$rounds=5000$steamedhamselvla$6M4k0GgWZ4GOfyM8DDMmnDj61W0612cY5MafGcCZLg2', '$5$rounds=5000$steamedhamselvlaurian$', 0, 'elev', NULL),
(41, 'elevlaurian', '$5$rounds=5000$steamedhamselevl$bMfNvsvmjw04uSTtbxOKHisEW28H22/U9ExI69uWEaC', '$5$rounds=5000$steamedhamselevlaurian$', 61, 'elev', NULL),
(42, 'elevrandom', '$5$rounds=5000$steamedhamselevr$AF25pD.ABlb10FxcZ.3nq6NcX6vx5fW/GFi9DIxphr/', '$5$rounds=5000$steamedhamselevrandom$', 61, 'elev', NULL),
(43, 'random2006', '$5$rounds=5000$steamedhamsrando$0zm0.CmQCNof.BeQkNqKBMw2egy3/XyPP7IkNqEDmR1', '$5$rounds=5000$steamedhamsrandom2006$', 0, 'elev', NULL),
(44, 'profesorinforr', '$5$rounds=5000$steamedhamsprofe$6vPbzbicO7.vYUVkXt8WlKaYi7MGVMX6wgtrStnPLf.', '$5$rounds=5000$steamedhamsprofesorinforr$', 0, 'profesor', NULL),
(45, 'utilizatorrandom', '$5$rounds=5000$steamedhamsutili$xvPrsHKsyEwBaECT1CxhtPmPE9gwGjDezHjUFs3QG4D', '$5$rounds=5000$steamedhamsutilizatorrandom$', 122, 'elev', NULL),
(46, 'colegnou', '$5$rounds=5000$steamedhamscoleg$m5wuWqz7PrpC4C3CpXnEVDbxz/W21.foqai4PY8fMEA', '$5$rounds=5000$steamedhamscolegnou$', 7261, 'elev', 'profesoranna_clasa 10 d'),
(47, 'bogdan popescu', '$5$rounds=5000$steamedhamsbogda$Zc.leHVVQLpmq5/Hy5qlf6SA/PNqPBLdMYuJ5Vlle47', '$5$rounds=5000$steamedhamsbogdan popescu$', 0, 'profesor', NULL),
(48, 'popescu vasile', '$5$rounds=5000$steamedhamspopes$HmM5dXlsx4cIQAamfKRR67HQUvf/hsYRkzFAt..LFD6', '$5$rounds=5000$steamedhamspopescu vasile$', 0, 'elev', NULL),
(49, 'popescuvasile', '$5$rounds=5000$steamedhamspopes$HmM5dXlsx4cIQAamfKRR67HQUvf/hsYRkzFAt..LFD6', '$5$rounds=5000$steamedhamspopescuvasile$', 0, 'elev', NULL),
(50, 'popescudaniel', '$5$rounds=5000$steamedhamspopes$ntnpjuKkaHr1/66UURfb5rkhZbqkndUvhy/bxltdGR3', '$5$rounds=5000$steamedhamspopescudaniel$', 183, 'elev', NULL),
(51, 'popescuantonio', '$5$rounds=5000$steamedhamspopes$If7n2f1Zy1v1T698ixf2skEmBF6Z37Ui5O6KpVM1G59', '$5$rounds=5000$steamedhamspopescuantonio$', 0, 'profesor', NULL),
(52, 'popescudumitru', '$5$rounds=5000$steamedhamspopes$Wd/VfNx9rj6LcYJP7CxVukGDFH5nO8bk7jnBqbLAFO9', '$5$rounds=5000$steamedhamspopescudumitru$', 305, 'elev', NULL),
(53, '123456789', '$5$rounds=5000$steamedhams12345$o/upYKrm/pVzKtLu9n9o8s.5q1EqoYG.SYAoQZ54GC3', '$5$rounds=5000$steamedhams123456789$', 0, 'elev', NULL),
(54, 'popescuprof', '$5$rounds=5000$steamedhamspopes$ntnpjuKkaHr1/66UURfb5rkhZbqkndUvhy/bxltdGR3', '$5$rounds=5000$steamedhamspopescuprof$', 0, 'profesor', NULL),
(55, 'popescuthomas', '$5$rounds=5000$steamedhamspopes$qnnOrulnzO8G3MtESQiqiwZTCym0XVV2rkhc/va5PqC', '$5$rounds=5000$steamedhamspopescuthomas$', 0, 'elev', NULL),
(56, 'popescumihail', '$5$rounds=5000$steamedhamspopes$bVZqROa4tHzr5iSp2OZnLASyYgGRf6zNm1D9NL2UGS9', '$5$rounds=5000$steamedhamspopescumihail$', 0, 'elev', NULL),
(57, 'popescumihaela', '$5$rounds=5000$steamedhamspopes$QRyhWcz0XhyYZr783FT7SP.az4RYtlfQ.jqdlBCne.4', '$5$rounds=5000$steamedhamspopescumihaela$', 0, 'elev', NULL),
(58, 'popescumarinela', '$5$rounds=5000$steamedhamspopes$ntnpjuKkaHr1/66UURfb5rkhZbqkndUvhy/bxltdGR3', '$5$rounds=5000$steamedhamspopescumarinela$', 427, 'elev', NULL),
(59, 'popescu ion', '$5$rounds=5000$steamedhamspopes$iLRB7nY2tJjkBXW4lbRwdyTBwTvBPzuvvPBn8SgCDu9', '$5$rounds=5000$steamedhamspopescu ion$', 488, 'elev', NULL),
(60, 'popescu andreea', '$5$rounds=5000$steamedhamspopes$r/Iszjgf4NxjYWrAaR/IEyRxMOWASgK5z//IftZWA89', '$5$rounds=5000$steamedhamspopescu andreea$', 122, 'elev', NULL),
(61, 'vsile ion', '$5$rounds=5000$steamedhamsvsile$NDd88QkLAA6oMKQhi49RK10LfEpPdsWIU0ig9kXRNp9', '$5$rounds=5000$steamedhamsvsile ion$', 427, 'elev', NULL),
(62, 'vasile pop', '$5$rounds=5000$steamedhamsvasil$2m6vkiy.gnOfip883.gx2VI.glBhYe7g/Zpe80Qo6v0', '$5$rounds=5000$steamedhamsvasile pop$', 0, 'elev', NULL),
(63, 'popescu liliana', '$5$rounds=5000$steamedhamspopes$xuATLZLUV4eYLfPTmcFLnhqNVYNPmnhNXIuahIAh4p9', '$5$rounds=5000$steamedhamspopescu liliana$', 61, 'elev', NULL),
(64, 'vreau acasa', '$5$rounds=5000$steamedhamsvreau$6YjivG1CyyfgtFPzrrlFuzHgcCqdyEXjfyXaU5zsnH3', '$5$rounds=5000$steamedhamsvreau acasa$', 0, 'elev', NULL),
(65, 'liliac andrei', '$5$rounds=5000$steamedhamslilia$aA3Wsm3ylDGySIkjfzmRmxNidPOFR8OMFHhPzrbUFf2', '$5$rounds=5000$steamedhamsliliac andrei$', 122, 'elev', NULL),
(66, 'bec aur1', '$5$rounds=5000$steamedhamsbec a$ZuomokeAjGhH9NFodgrsWMffGein5K/.D15togXe1g7', '$5$rounds=5000$steamedhamsbec aur1$', 0, 'elev', NULL),
(67, 'alexandru', '$5$rounds=5000$steamedhamsalexa$qoDwToZTq28J/s0rgvMHfjv7YiU88kDRfxtZwJCY7Y5', '$5$rounds=5000$steamedhamsalexandru$', 0, 'elev', NULL),
(68, 'ecotopia', '$5$rounds=5000$steamedhamsecoto$e1ggQDGuxZAluGXyxi86odvuzL/onWrNB8aJNakQpl7', '$5$rounds=5000$steamedhamsecotopia$', 0, 'elev', NULL),
(69, 'tester123', '$5$rounds=5000$steamedhamsteste$LcpSO9IoLOA13Nt92FpiTwhc6YFY9gbvGf9fzfE7f56', '$5$rounds=5000$steamedhamstester123$', 671, 'elev', NULL),
(70, 'popescu adrian', '$5$rounds=5000$steamedhamspopes$TEcN7GzL4vOgLjSQdJMGbeVaJwRKfVNZC1qdUkJS3g.', '$5$rounds=5000$steamedhamspopescu adrian$', 0, 'elev', NULL),
(71, 'vasile ion', '$5$rounds=5000$steamedhamsvasil$sGcX/1YPkPorTC8jdkqxtHNpRfPNBUyXkEIYb4qPx/4', '$5$rounds=5000$steamedhamsvasile ion$', 61, 'elev', NULL),
(72, 'vasile ana', '$5$rounds=5000$steamedhamsvasil$EArznmt/tdGntSYr6qQFpj0gicrCNERLYZs.18WjaT/', '$5$rounds=5000$steamedhamsvasile ana$', 0, 'elev', NULL),
(73, 'paul antionio', '$5$rounds=5000$steamedhamspaul $0jfxVL1tZ6M/JA.I1PXLn9cTKryj0UrE/ljGp6LJUQ1', '$5$rounds=5000$steamedhamspaul antionio$', 0, 'elev', NULL),
(74, 'valerica val', '$5$rounds=5000$steamedhamsvaler$4OnCWuWD6xpp4bu5dfQCoHGgC318vDXMO.UQAxAgfn5', '$5$rounds=5000$steamedhamsvalerica val$', 0, 'elev', NULL),
(75, 'valeriu val', '$5$rounds=5000$steamedhamsvaler$tTMB1PPK/qs2fYk2T1ZzWhwEpRMdLgUIgiXY08BenOA', '$5$rounds=5000$steamedhamsvaleriu val$', 0, 'profesor', NULL),
(76, 'dumitru val', '$5$rounds=5000$steamedhamsdumit$IC35tedNMotuqQs993BWYpIX8TPJh4wtPcA.PyWP/t9', '$5$rounds=5000$steamedhamsdumitru val$', 0, 'profesor', NULL),
(77, 'valerica v', '$5$rounds=5000$steamedhamsvaler$ztXLezStKV59Lvx4fK6/yRHj8en78.zS/AhxVrgkigA', '$5$rounds=5000$steamedhamsvalerica v$', 61, 'elev', 'profesor_ana_clas'),
(78, 'valeriu v', '$5$rounds=5000$steamedhamsvaler$3EHAnPPadWaJvuCBt2PcEPwSOiweCMt4ucH/R7PVQS/', '$5$rounds=5000$steamedhamsvaleriu v$', 0, 'elev', NULL),
(79, 'laurentiu v', '$5$rounds=5000$steamedhamslaure$O5FzdOk.HIx3rXnZLULd6Pcu.9zKIZWv8.girn2qZz5', '$5$rounds=5000$steamedhamslaurentiu v$', 0, 'elev', NULL),
(80, 'cosmin c', '$5$rounds=5000$steamedhamscosmi$btv67WCS30CTVBcNk5l3ONfn74V3CeErRKpRVGnjppA', '$5$rounds=5000$steamedhamscosmin c$', 61, 'elev', NULL),
(81, 'contelev567', '$5$rounds=5000$steamedhamsconte$rOxwQwg9e.KHWIxHP31D17YUf5n61eQ.8DaaeLJCcHA', '$5$rounds=5000$steamedhamscontelev567$', 0, 'elev', NULL),
(82, 'valval12', '$5$rounds=5000$steamedhamsvalva$iImB1hLkv.n8dLvISBhE604a1S0fBqDlcP8D/PFqmG9', '$5$rounds=5000$steamedhamsvalval12$', 427, 'elev', NULL),
(83, 'biologie', '$5$rounds=5000$steamedhamsbiolo$HzzdrmvJuSp6lC8ZPjwq.QNWi7LV6TV8dBAxFvP0/AA', '$5$rounds=5000$steamedhamsbiologie$', 0, 'profesor', NULL),
(84, 'numeutil', '$5$rounds=5000$steamedhamsnumeu$wZDRyMznqw2aUGruWGbQ.Goe.wiHPYADUZzXp.qvka9', '$5$rounds=5000$steamedhamsnumeutil$', 427, 'elev', NULL),
(85, 'profbio123', '$5$rounds=5000$steamedhamsprofb$nkNXSAsdE3JO2Ln33LE4C9mBaHIkkk6GoKFDj8vha43', '$5$rounds=5000$steamedhamsprofbio123$', 0, 'profesor', NULL),
(86, 'colegnouvenit', '$5$rounds=5000$steamedhamscoleg$uaqPieG6TbvE78VD4juzdL2HTMA4YM/xFtrfhKkyX0.', '$5$rounds=5000$steamedhamscolegnouvenit$', 0, 'elev', NULL),
(87, 'colegnouuu', '$5$rounds=5000$steamedhamscoleg$uaqPieG6TbvE78VD4juzdL2HTMA4YM/xFtrfhKkyX0.', '$5$rounds=5000$steamedhamscolegnouuu$', 61, 'elev', NULL),
(88, 'profesornou', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesornou$', 0, 'profesor', NULL),
(89, 'colegtest1', '$5$rounds=5000$steamedhamscoleg$JvuQ0QqxZyR0YeZ9nNzK2Lf.Wd93qxhnq8tigGO3.28', '$5$rounds=5000$steamedhamscolegtest1$', 366, 'elev', NULL),
(90, 'profesornounout', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesornounout$', 0, 'profesor', NULL),
(91, 'profesorlevel', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesorlevel$', 0, 'profesor', NULL),
(92, 'hello2006', '$5$rounds=5000$steamedhamshello$Ui9OAFhZvPRAo//1Ie.p5L/cYrFCBVp49Xe.fttaKPB', '$5$rounds=5000$steamedhamshello2006$', 0, 'elev', NULL),
(93, 'annapomparau', '$5$rounds=5000$steamedhamsannap$1Q7KLfEW9U4i5Zg8p3XVwz4YUuTAbzjNaU3rzxFhWS9', '$5$rounds=5000$steamedhamsannapomparau$', 427, 'elev', 'profesor_ana_clas'),
(94, 'profesorbiologie', '$5$rounds=5000$steamedhamsprofe$LcbOnqNDrePsdmeA2nj.2xhvG13NqFnUuz/ngAJPDd2', '$5$rounds=5000$steamedhamsprofesorbiologie$', 0, 'profesor', NULL),
(95, 'elevnounou', '$5$rounds=5000$steamedhamselevn$.1aBkcJiUup66mCX6TNsRqBhIcogZPO2Dcp1XsdJQr.', '$5$rounds=5000$steamedhamselevnounou$', 427, 'elev', NULL),
(96, 'profesorprofesor', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesorprofesor$', 0, 'profesor', NULL),
(97, 'contnoucont', '$5$rounds=5000$steamedhamscontn$FKvJRRvBk7J4yet5y8jz4JY3NHliw8NZnP0RjKml1e5', '$5$rounds=5000$steamedhamscontnoucont$', 427, 'elev', NULL),
(98, 'profesor12345678', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesor12345678$', 0, 'profesor', NULL),
(99, 'Malina00', '$5$rounds=5000$steamedhamsMalin$9kPkV7Zk2Ha4FPKrQ2JMB1RMCihSnvIesWh6QIu23F7', '$5$rounds=5000$steamedhamsMalina00$', 307, 'elev', NULL),
(100, 'contnouttest', '$5$rounds=5000$steamedhamscontn$FKvJRRvBk7J4yet5y8jz4JY3NHliw8NZnP0RjKml1e5', '$5$rounds=5000$steamedhamscontnouttest$', 0, 'elev', NULL),
(101, 'luigivolosincu', '$5$rounds=5000$steamedhamsluigi$X7LxDpN/fcAyvLW0R4Hie0hOje8fd2OWqtWk7etrLuD', '$5$rounds=5000$steamedhamsluigivolosincu$', 427, 'elev', NULL),
(102, 'profesorluigi', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesorluigi$', 0, 'profesor', NULL),
(103, 'profesornou1', '$5$rounds=5000$steamedhamsprofe$6vPbzbicO7.vYUVkXt8WlKaYi7MGVMX6wgtrStnPLf.', '$5$rounds=5000$steamedhamsprofesornou1$', 0, 'profesor', 'clasaprofesor'),
(104, 'profesor_alina', '$5$rounds=5000$steamedhamsprofe$HKu2ZTzbf1NE8Z/8Wc4vJFEicz3/2IUveM5zxROFll4', '$5$rounds=5000$steamedhamsprofesor_alina$', 0, 'profesor', NULL),
(105, 'ana_pomparau', '$5$rounds=5000$steamedhamsana_p$C8aLorwYfBBIeVjwOy4KMolkp1FAqtFlD/ep4JZMq30', '$5$rounds=5000$steamedhamsana_pomparau$', 0, 'elev', 'clasaprofesor'),
(106, 'profff1234', '$5$rounds=5000$steamedhamsproff$vnUXJ1XKvHuCsepvbXsjP5t1JGzY6T5fnIpEQwDdwv2', '$5$rounds=5000$steamedhamsprofff1234$', 0, 'profesor', NULL),
(107, '1123456789', '$5$rounds=5000$steamedhams11234$u/MtF6bEIh6gfbOXSeXVXDe736/mC91F2ZkzCUagf1C', '$5$rounds=5000$steamedhams1123456789$', 0, 'elev', NULL),
(108, 'elevluigi', '$5$rounds=5000$steamedhamselevl$VYJOhF6DgDF3zoprAUDPphX6W1YJnanzG2TMP71NkMA', '$5$rounds=5000$steamedhamselevluigi$', 91, 'elev', NULL),
(109, 'proflungu', '$5$rounds=5000$steamedhamsprofl$AQfnE214EEGWG2gaDrD3lPQmjQDFGYmRVYj.7rMizLD', '$5$rounds=5000$steamedhamsproflungu$', 0, 'profesor', NULL),
(110, 'profesor_ana', '$5$rounds=5000$steamedhamsprofe$0zSzHaK32DvtWvS6JwQwU5Aqjou5kUK.p5ni7XW/YS0', '$5$rounds=5000$steamedhamsprofesor_ana$', 0, 'profesor', 'profesor_ana_prof_an'),
(111, 'pomparau_ana', '$5$rounds=5000$steamedhamspompa$OB4GcwtwRYqTUUT/25ENHVQ2.4vqgI0Fkn2PQnygLcA', '$5$rounds=5000$steamedhamspomparau_ana$', 61, 'elev', NULL),
(112, 'prof_annna', '$5$rounds=5000$steamedhamsprof_$fspqZ5As0i3mOXwNfV0ZNm6cDuAxYVdo3Z9wbdeqbu4', '$5$rounds=5000$steamedhamsprof_annna$', 0, 'profesor', 'prof_annna_clasa_11_a'),
(113, 'bobita12', '$5$rounds=5000$steamedhamsbobit$oNJX4O/1OW4QaiwuwaQ4C1esTURkXDWnNwbK/9d5l53', '$5$rounds=5000$steamedhamsbobita12$', 0, 'elev', NULL),
(114, 'elevrobert', '$5$rounds=5000$steamedhamselevr$O81JHisCoH7Dw7czPSfiW5q55vZH9kQ1X9tJ098wE2.', '$5$rounds=5000$steamedhamselevrobert$', 366, 'elev', 'profesormario_clasa 9B'),
(115, 'profesorrobert', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesorrobert$', 0, 'profesor', 'profesorrobert_clasa 11 A'),
(116, 'elevecotopia', '$5$rounds=5000$steamedhamseleve$iR.hxSFHYjQDp4qd3lBB6ssdmOMaqbDW1bxgcOeIgID', '$5$rounds=5000$steamedhamselevecotopia$', 366, 'elev', 'profesorecotopia_clasa 11A'),
(117, 'profesorecotopia', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesorecotopia$', 0, 'profesor', 'profesorecotopia_clasa 11A'),
(118, 'elevelena', '$5$rounds=5000$steamedhamseleve$iR.hxSFHYjQDp4qd3lBB6ssdmOMaqbDW1bxgcOeIgID', '$5$rounds=5000$steamedhamselevelena$', 1281, 'elev', 'profesormario_clasa 9B'),
(119, 'profesorelena', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesorelena$', 0, 'profesor', 'profesorelena_9a'),
(120, 'rubla0303030', '$5$rounds=5000$steamedhamsrubla$eW7b/jhmw2afOnfuH1uhluTpWS080w/8x8shGwgaHy0', '$5$rounds=5000$steamedhamsrubla0303030$', 0, 'elev', NULL),
(121, 'victorCa', '$5$rounds=5000$steamedhamsvicto$DgEAZmCfKBuot0K6yb1FEUkQhMoZBIRlKlVQl4G/G43', '$5$rounds=5000$steamedhamsvictorCa$', 0, 'elev', NULL),
(122, 'elevrazvan', '$5$rounds=5000$steamedhamselevr$O81JHisCoH7Dw7czPSfiW5q55vZH9kQ1X9tJ098wE2.', '$5$rounds=5000$steamedhamselevrazvan$', 610, 'elev', 'profesoralbert_clasa 9a'),
(123, 'profesoralbert', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesoralbert$', 0, 'profesor', 'profesoralbert_clasa 9a'),
(124, 'elevdenis', '$5$rounds=5000$steamedhamselevd$v.Axmdx/XoaJyaifRLN7iqWyFjlpYygi32YKe6dekP0', '$5$rounds=5000$steamedhamselevdenis$', 366, 'elev', NULL),
(125, 'profesormario', '$5$rounds=5000$steamedhamsprofe$gH3PnEo/N6s9uIrPnzcq85Ym8TIW.UESTC.qybEaVy0', '$5$rounds=5000$steamedhamsprofesormario$', 0, 'profesor', 'profesormario_clasa 9B'),
(126, 'profesoranna', '$5$rounds=5000$steamedhamsprofe$6vPbzbicO7.vYUVkXt8WlKaYi7MGVMX6wgtrStnPLf.', '$5$rounds=5000$steamedhamsprofesoranna$', 0, 'profesor', 'profesoranna_clasa 10 d'),
(127, 'elevnou1', '$5$rounds=5000$steamedhamselevn$QF.PvzoPFhy0aiER1cjXjv6YIPBY0LiDTkMCpkv.qB.', '$5$rounds=5000$steamedhamselevnou1$', -20, 'elev', NULL),
(128, 'elevluca', '$5$rounds=5000$steamedhamselevl$bMfNvsvmjw04uSTtbxOKHisEW28H22/U9ExI69uWEaC', '$5$rounds=5000$steamedhamselevluca$', 163, 'elev', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `id` int(11) NOT NULL,
  `question_text` text NOT NULL,
  `answer_1` text NOT NULL,
  `answer_2` text NOT NULL,
  `answer_3` text NOT NULL,
  `answer_4` text NOT NULL,
  `correct_answer` int(11) NOT NULL,
  `test_id` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`id`, `question_text`, `answer_1`, `answer_2`, `answer_3`, `answer_4`, `correct_answer`, `test_id`) VALUES
(4, 'ana are mere?', 'test1', 't2', 't3', 't4', 2, 3),
(11, 'iti place acest joc', 'da', 'nu', 'imi place foarte mult', 'poate', 3, 2),
(13, 'iti place acest joc?', 'da', 'normal', 'nu', 'poate', 2, 2),
(14, 'ce faci?', 'bine', 'nu ', 'da', 'cu siguranta', 3, 2),
(15, 'cum ti se pare jocul?', 'minunat', 'splendid', 'cel mai bun joc', 'nu', 3, 2),
(16, 'cum vi se pare jocul?', 'meh', 'bun', 'genial', 'nu imi place', 3, 2),
(17, 'cum este jocul?', 'bun', 'superb', 'meh', 'nu mi place', 2, 1),
(18, 'iti plae jocul?', 'da', 'nu', 'desigur', 'meh', 1, 2),
(19, 'iti place jocul?', 'da', 'nu', 'meh', 'normal', 4, 2),
(20, 'ce este ecologia?', 'nu stiu', 'bun ', 'rau ', 'etc', 3, 2),
(21, 'iti place ecologia?', 'r1', 'r2', 'r3', 'r4', 3, 2);

-- --------------------------------------------------------

--
-- Table structure for table `test_results`
--

CREATE TABLE `test_results` (
  `id` int(11) NOT NULL,
  `student_username` varchar(100) DEFAULT NULL,
  `test_id` int(11) DEFAULT NULL,
  `score` int(11) DEFAULT NULL,
  `start_time` datetime DEFAULT NULL,
  `end_time` datetime DEFAULT NULL,
  `duration_seconds` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `test_results`
--

INSERT INTO `test_results` (`id`, `student_username`, `test_id`, `score`, `start_time`, `end_time`, `duration_seconds`) VALUES
(1, 'colegnou', 1, 3, '2025-05-17 17:15:08', '2025-05-17 17:15:13', 4),
(2, NULL, NULL, NULL, NULL, NULL, NULL),
(3, 'colegnou', 1, 10, '2025-05-19 15:42:08', '2025-05-19 15:42:27', 19),
(4, 'colegnou', 1, 10, '2025-05-19 15:44:56', '2025-05-19 15:45:12', 16),
(5, 'elevluigi', 1, 10, '2025-05-19 16:03:17', '2025-05-19 16:03:43', 26),
(6, 'elevluigi', 1, 1, '2025-05-19 16:04:37', '2025-05-19 16:04:45', 8),
(7, 'elevluigi', 1, 2, '2025-05-19 16:04:55', '2025-05-19 16:04:59', 4),
(8, 'pomparau_ana', 1, 3, '2025-05-21 10:30:59', '2025-05-21 10:31:29', 30),
(9, 'colegnou', 1, 0, '2025-05-22 11:52:35', '2025-05-22 11:53:41', 66),
(10, 'elevrobert', 1, 2, '2025-05-22 12:39:28', '2025-05-22 12:39:37', 8),
(11, 'elevrobert', 1, 3, '2025-05-22 12:39:45', '2025-05-22 12:39:50', 5),
(12, 'elevecotopia', 1, 0, '2025-05-22 12:59:10', '2025-05-22 12:59:18', 8),
(13, 'elevecotopia', 1, 2, '2025-05-22 12:59:23', '2025-05-22 12:59:28', 4),
(14, 'elevelena', 1, 1, '2025-05-22 22:10:27', '2025-05-22 22:10:34', 6),
(15, 'elevelena', 1, 2, '2025-05-22 22:10:42', '2025-05-22 22:10:46', 4),
(16, 'colegnou', 1, 1, '2025-05-23 09:28:59', '2025-05-23 09:29:05', 5),
(17, 'colegnou', 1, 0, '2025-05-23 09:29:08', '2025-05-23 09:29:36', 28),
(18, 'colegnou', 1, 1, '2025-05-23 09:29:42', '2025-05-23 09:29:49', 7),
(19, 'colegnou', 1, 1, '2025-05-23 09:29:51', '2025-05-23 09:29:53', 2),
(20, 'colegnou', 1, 0, '2025-05-23 09:29:56', '2025-05-23 09:30:02', 5),
(21, 'colegnou', 1, 3, '2025-05-23 09:30:05', '2025-05-23 09:30:14', 8),
(22, 'colegnou', 1, 5, '2025-05-23 09:30:23', '2025-05-23 09:31:58', 95),
(23, 'elevrazvan', 1, 1, '2025-05-23 11:17:40', '2025-05-23 11:17:46', 6),
(24, 'elevrazvan', 1, 3, '2025-05-23 11:17:51', '2025-05-23 11:17:56', 4),
(25, 'elevdenis', 1, 1, '2025-05-30 14:33:23', '2025-05-30 14:33:31', 8),
(26, 'elevdenis', 1, 2, '2025-05-30 14:33:39', '2025-05-30 14:33:42', 3),
(27, 'elevdenis', 1, 3, '2025-05-30 14:34:10', '2025-05-30 14:34:13', 3),
(28, 'colegnou', 1, 3, '2025-06-03 22:12:10', '2025-06-03 22:12:14', 4),
(29, 'colegnou', 1, 3, '2025-06-03 22:12:17', '2025-06-03 22:12:23', 5),
(30, 'colegnou', 1, 2, '2025-06-03 22:12:41', '2025-06-03 22:12:45', 3),
(31, 'colegnou', 1, 3, '2025-06-03 22:12:47', '2025-06-03 22:12:50', 3),
(32, 'elevluca', 1, 3, '2025-06-06 20:18:40', '2025-06-06 20:18:47', 6),
(33, 'elevluca', 1, 2, '2025-06-06 20:18:59', '2025-06-06 20:19:04', 4),
(34, 'elevluca', 1, 3, '2025-06-06 20:19:25', '2025-06-06 20:19:29', 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `classes`
--
ALTER TABLE `classes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `teacher_username` (`teacher_username`);

--
-- Indexes for table `class_students`
--
ALTER TABLE `class_students`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unique_student_class` (`class_id`,`student_username`),
  ADD KEY `student_username` (`student_username`);

--
-- Indexes for table `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `test_results`
--
ALTER TABLE `test_results`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `classes`
--
ALTER TABLE `classes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `class_students`
--
ALTER TABLE `class_students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `players`
--
ALTER TABLE `players`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=129;

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `test_results`
--
ALTER TABLE `test_results`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `classes`
--
ALTER TABLE `classes`
  ADD CONSTRAINT `classes_ibfk_1` FOREIGN KEY (`teacher_username`) REFERENCES `players` (`username`);

--
-- Constraints for table `class_students`
--
ALTER TABLE `class_students`
  ADD CONSTRAINT `class_students_ibfk_1` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `class_students_ibfk_2` FOREIGN KEY (`student_username`) REFERENCES `players` (`username`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
