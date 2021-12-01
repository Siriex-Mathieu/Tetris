<?php

require_once File::build_path(array("config","conf.php"));

class Model{
  private static $pdo = NULL;
  private $hostname;
  private $database_name;
  private $login;
  private $password;

  public static function init(){
    $hostname=Conf::getHostname();
    $database_name = Conf::getDatabases();
    $password = Conf::getPassword();
    $login = Conf::getLogin();

   try{
      self::$pdo = new PDO("mysql:host=$hostname;dbname=$database_name",$login,$password, array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8"));
      self::$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    } catch (PDOException $e) {
      if (Conf::getDebug()) {
        echo $e->getMessage(); // affiche un message d'erreur
      } else {
        echo 'Une erreur est survenue <a href=""> retour a la page d\'accueil </a>';
      }
      die();
    }

  }

  public static function getPDO(){
    if(is_null(self::$pdo)){
      self::init();
    }   
    return self::$pdo;
}
}
