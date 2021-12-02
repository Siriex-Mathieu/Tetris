<?php
    class ControllerConnect
    {
    public static function base(){
        echo "Il n'y a rien ici";
    }
    
    public static function list(){
            $pagetitle = "Liste des scores";
            $controller = "LeaderBoard";
            $view = "list";
            include_once File::build_path(array("model","modelUser.php"));
            $tab_user = modelUser::GetAllStats();
            foreach($tab_user as $user){
                $user->sort();
            }
            $tab_v = &$tab_user;
            require File::build_path(array("view","view.php"));

    }
    public static function debug(){
        echo "Test <br>";
       
    }
    public static function error(){
        echo "il y a un soucis";
    }

        public static function createTable()
        {
            // require_once File::build_path(array("model", "model.php"));
            
            //     try {
            //         // $sql = "CREATE TABLE `siriexm`.`p_score` ( `id_score` INT(10) NOT NULL AUTO_INCREMENT , `pseudo` VARCHAR(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `score` INT NOT NULL , PRIMARY KEY (`id_score`(10))) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;";
            //         $sql = "SELECT * FROM p_score";
            //         $req_prep = Model::getPDO()->prepare($sql);
            //         $values = array();
            //         $req_prep->execute($values);
            //     } catch (\Throwable $th) {
            //         if (Conf::getDebug()) {
            //             echo $th->getMessage() . "<br>"; // affiche un message d'erreur
            //         }
            //     }
            
        }
    }
?>