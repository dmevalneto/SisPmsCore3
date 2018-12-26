-- MySQL Script generated by MySQL Workbench
-- Tue Dec 18 12:22:19 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema sispmscore
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sispmscore
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sispmscore` DEFAULT CHARACTER SET utf8 ;
USE `sispmscore` ;

-- -----------------------------------------------------
-- Table `sispmscore`.`tiposetor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sispmscore`.`tiposetor` (
  `idtipo_setor` INT NOT NULL,
  `nome` VARCHAR(45) NULL,
  `descricao` VARCHAR(255) NULL,
  `tipo_setorcol` VARCHAR(45) NULL,
  PRIMARY KEY (`idtipo_setor`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sispmscore`.`setor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sispmscore`.`setor` (
  `idsetor` INT NOT NULL,
  `nome` VARCHAR(45) NULL,
  `telefone1` VARCHAR(100) NULL,
  `telefone2` VARCHAR(100) NULL,
  `cep` VARCHAR(100) NULL,
  `bairro` VARCHAR(100) NULL,
  `logradouro` VARCHAR(100) NULL,
  `numero` INT NULL,
  `latitude` VARCHAR(255) NULL,
  `longitude` VARCHAR(255) NULL,
  `gestor` VARCHAR(255) NULL,
  `setorcol` VARCHAR(45) NULL,
  `tipo_setor_idtipo_setor` INT NOT NULL,
  PRIMARY KEY (`idsetor`),
  INDEX `fk_setor_tipo_setor_idx` (`tipo_setor_idtipo_setor` ASC),
  CONSTRAINT `fk_setor_tipo_setor`
    FOREIGN KEY (`tipo_setor_idtipo_setor`)
    REFERENCES `sispmscore`.`tiposetor` (`idtipo_setor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sispmscore`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sispmscore`.`usuario` (
  `idusuario` INT NOT NULL,
  `nome` VARCHAR(100) NULL,
  `email` VARCHAR(100) NULL,
  `senha` VARCHAR(100) NULL,
  `data` DATE NULL,
  `setor_idsetor` INT NOT NULL,
  PRIMARY KEY (`idusuario`),
  INDEX `fk_usuario_setor1_idx` (`setor_idsetor` ASC),
  CONSTRAINT `fk_usuario_setor1`
    FOREIGN KEY (`setor_idsetor`)
    REFERENCES `sispmscore`.`setor` (`idsetor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sispmscore`.`colaborador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sispmscore`.`colaborador` (
  `idcolaborador` INT NOT NULL,
  `nome` VARCHAR(45) NULL,
  `cpf` VARCHAR(255) NULL,
  `data_admissao` VARCHAR(255) NULL,
  `telefone` VARCHAR(45) NULL,
  `setor_idsetor` INT NOT NULL,
  PRIMARY KEY (`idcolaborador`),
  INDEX `fk_colaborador_setor1_idx` (`setor_idsetor` ASC),
  CONSTRAINT `fk_colaborador_setor1`
    FOREIGN KEY (`setor_idsetor`)
    REFERENCES `sispmscore`.`setor` (`idsetor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sispmscore`.`historico`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sispmscore`.`historico` (
  `idhistorico` INT NOT NULL,
  `data` DATE NOT NULL,
  `observacao` VARCHAR(255) NULL,
  `historicocol` VARCHAR(45) NULL,
  `colaborador_idcolaborador` INT NOT NULL,
  `setor_idsetor` INT NOT NULL,
  `usuario_idusuario` INT NOT NULL,
  PRIMARY KEY (`idhistorico`),
  INDEX `fk_historico_colaborador1_idx` (`colaborador_idcolaborador` ASC),
  INDEX `fk_historico_setor1_idx` (`setor_idsetor` ASC),
  INDEX `fk_historico_usuario1_idx` (`usuario_idusuario` ASC),
  CONSTRAINT `fk_historico_colaborador1`
    FOREIGN KEY (`colaborador_idcolaborador`)
    REFERENCES `sispmscore`.`colaborador` (`idcolaborador`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_historico_setor1`
    FOREIGN KEY (`setor_idsetor`)
    REFERENCES `sispmscore`.`setor` (`idsetor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_historico_usuario1`
    FOREIGN KEY (`usuario_idusuario`)
    REFERENCES `sispmscore`.`usuario` (`idusuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `sispmscore`.`anotacoes_setor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sispmscore`.`anotacoes_setor` (
  `idanotacoes` INT NOT NULL,
  `nota` VARCHAR(255) NULL,
  `anotacoescol` VARCHAR(45) NULL,
  `setor_idsetor` INT NOT NULL,
  `usuario_idusuario` INT NOT NULL,
  PRIMARY KEY (`idanotacoes`),
  INDEX `fk_anotacoes_setor1_idx` (`setor_idsetor` ASC),
  INDEX `fk_anotacoes_usuario1_idx` (`usuario_idusuario` ASC),
  CONSTRAINT `fk_anotacoes_setor1`
    FOREIGN KEY (`setor_idsetor`)
    REFERENCES `sispmscore`.`setor` (`idsetor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_anotacoes_usuario1`
    FOREIGN KEY (`usuario_idusuario`)
    REFERENCES `sispmscore`.`usuario` (`idusuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;