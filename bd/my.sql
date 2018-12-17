-- MySQL Script generated by MySQL Workbench
-- Sun Dec 16 20:48:56 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema financeiro
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema financeiro
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `financeiro` DEFAULT CHARACTER SET utf8 ;
USE `financeiro` ;

-- -----------------------------------------------------
-- Table `financeiro`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `financeiro`.`usuario` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Senha` VARCHAR(255) NOT NULL,
  `Data_Nascimento` DATE NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `financeiro`.`conta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `financeiro`.`conta` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(45) NOT NULL,
  `Saldo` DECIMAL(9,2) NOT NULL,
  `Usuario_Id` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Conta_Usuario_idx` (`Usuario_Id` ASC) VISIBLE,
  CONSTRAINT `fk_Conta_Usuario`
    FOREIGN KEY (`Usuario_Id`)
    REFERENCES `financeiro`.`usuario` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `financeiro`.`plano_contas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `financeiro`.`plano_contas` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(45) NOT NULL,
  `Tipo` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `financeiro`.`transacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `financeiro`.`transacao` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Data` DATETIME NOT NULL,
  `Tipo` CHAR(1) NOT NULL,
  `Valor` DECIMAL(9,2) NOT NULL,
  `Descricao` VARCHAR(45) NULL DEFAULT NULL,
  `Conta_Id` INT(11) NOT NULL,
  `Plano_Contas_Id` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Transacao_Conta1_idx` (`Conta_Id` ASC) VISIBLE,
  INDEX `fk_Transacao_Plano_Contas1_idx` (`Plano_Contas_Id` ASC) VISIBLE,
  CONSTRAINT `fk_Transacao_Conta1`
    FOREIGN KEY (`Conta_Id`)
    REFERENCES `financeiro`.`conta` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Transacao_Plano_Contas1`
    FOREIGN KEY (`Plano_Contas_Id`)
    REFERENCES `financeiro`.`plano_contas` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;