<?php
class Controller
{
    public static function base()
    {        
        $pagetitle = "Accueil";
        $controller = "../view";
        $view = "accueil";
        include_once File::build_path(array("model", "modelUser.php"));
        $tab_user = modelUser::GetBestStats();
        self::sortUserArray($tab_user);
        $tab_v = array();
        self::userArrayToListableArray($tab_user, $tab_v);

        require File::build_path(array("view", "view.php"));
    }

    public static function list()
    {
        $pagetitle = "Liste des scores";
        $controller = "LeaderBoard";
        $view = "list";
        include_once File::build_path(array("model", "modelUser.php"));
        $tab_user = modelUser::GetAllStats();
        self::sortUserArray($tab_user);
        $tab_v = array();
        self::userArrayToListableArray($tab_user, $tab_v);

        require File::build_path(array("view", "view.php"));
    }
    public static function debug()
    {
        echo "Test <br>";
    }
    public static function error()
    {
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


    private static function sortUserArray(array &$tab_user)
    {
        foreach ($tab_user as $user) {
            $user->sort();
        }
        usort($tab_user, "userStats::sorting");
    }
    private static function userArrayToListableArray(array &$tab_user, array &$tab_v)
    {
        for ($i = 0; $i < count($tab_user); $i++) {
            $tab_v[$i]['Rank'] = $i + 1;
            $tab_v[$i]['Pseudo'] = $tab_user[$i]->getPseudo();
            $tab_v[$i]['Score'] = $tab_user[$i]->getTabScore()[0];
        }
    }
}
?>