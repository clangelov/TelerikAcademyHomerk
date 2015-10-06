-- MySQL Script generated by MySQL Workbench
-- 10/05/15 22:04:44
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema UniversityDB
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema UniversityDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `UniversityDB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `UniversityDB` ;

-- -----------------------------------------------------
-- Table `UniversityDB`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Faculties` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` NVARCHAR(50) NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Departments` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` NVARCHAR(45) NOT NULL COMMENT '',
  `Faculties_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Departments_Faculties_idx` (`Faculties_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Departments_Faculties`
    FOREIGN KEY (`Faculties_Id`)
    REFERENCES `UniversityDB`.`Faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Professors` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` NVARCHAR(45) NOT NULL COMMENT '',
  `Departments_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Professors_Departments1_idx` (`Departments_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Professors_Departments1`
    FOREIGN KEY (`Departments_Id`)
    REFERENCES `UniversityDB`.`Departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Students` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` NVARCHAR(45) NOT NULL COMMENT '',
  `Faculties_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Students_Faculties1_idx` (`Faculties_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`Faculties_Id`)
    REFERENCES `UniversityDB`.`Faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Courses` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` NVARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Courses_has_Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Courses_has_Students` (
  `Courses_Id` INT NOT NULL COMMENT '',
  `Students_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Courses_Id`, `Students_Id`)  COMMENT '',
  INDEX `fk_Courses_has_Students_Students1_idx` (`Students_Id` ASC)  COMMENT '',
  INDEX `fk_Courses_has_Students_Courses1_idx` (`Courses_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Courses_has_Students_Courses1`
    FOREIGN KEY (`Courses_Id`)
    REFERENCES `UniversityDB`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_has_Students_Students1`
    FOREIGN KEY (`Students_Id`)
    REFERENCES `UniversityDB`.`Students` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Professors_has_Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Professors_has_Courses` (
  `Professors_Id` INT NOT NULL COMMENT '',
  `Courses_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Professors_Id`, `Courses_Id`)  COMMENT '',
  INDEX `fk_Professors_has_Courses_Courses1_idx` (`Courses_Id` ASC)  COMMENT '',
  INDEX `fk_Professors_has_Courses_Professors1_idx` (`Professors_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Professors_has_Courses_Professors1`
    FOREIGN KEY (`Professors_Id`)
    REFERENCES `UniversityDB`.`Professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_has_Courses_Courses1`
    FOREIGN KEY (`Courses_Id`)
    REFERENCES `UniversityDB`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Titles` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Title` NVARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Professors_has_Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Professors_has_Titles` (
  `Professors_Id` INT NOT NULL COMMENT '',
  `Titles_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Professors_Id`, `Titles_Id`)  COMMENT '',
  INDEX `fk_Professors_has_Titles_Titles1_idx` (`Titles_Id` ASC)  COMMENT '',
  INDEX `fk_Professors_has_Titles_Professors1_idx` (`Professors_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Professors_has_Titles_Professors1`
    FOREIGN KEY (`Professors_Id`)
    REFERENCES `UniversityDB`.`Professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_has_Titles_Titles1`
    FOREIGN KEY (`Titles_Id`)
    REFERENCES `UniversityDB`.`Titles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
