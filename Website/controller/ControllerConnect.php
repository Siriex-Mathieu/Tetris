<?php
    include_once File::build_path(array("Script", "Script.php"));
class ControllerConnect
{
    public static function base(){
        echo "Il n'y a rien ici";
    }
    public static function signUp(){
        $isBad = false;
        $pagetitle = "Créer un compte";
        $controller = "Connect";
        $view = "SignUp";
        require File::build_path(array("view","view.php"));
    }
    public static function signedUp(){
        if($_GET['password'] == $_GET['password']){
            $isBad = true;
            $pagetitle = "Créer un compte";
            $controller = "Connect";
            $view = "SignUp";
            require File::build_path(array("view","view.php"));

        }
    }
    public static function debug(){
        echo "Test <br>";
        include_once File::build_path(array("Script","PrefabText","PrefabText.php"));
        Script::debug_ModifyAllMail();
        PrefabText::sendMailToAll();
    }
    public static function error(){
        echo "il y a un soucis";
    }
}

?>