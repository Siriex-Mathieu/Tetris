<?php
require_once File::build_path(array("model", 'model.php'));
require_once File::build_path(array("model", "userStats.php"));
class modelUser
{
    private $id_score;
    private $pseudo;
    private $score;

    public function getPseudo()
    {
        return $this->pseudo;
    }
    public function getScore()
    {
        return $this->score;
    }

    function __construct($id_score = NULL, $pseudo = NULL, $score = NULL)
    {
        if (!is_null($id_score) && !is_null($pseudo) && !is_null($score)) {
            $this->id_score = $id_score;
            $this->pseudo = $pseudo;
            $this->score = $score;
        }
    }

    public static function getAllLines()
    {
        $rep = Model::getPDO()->query('SELECT * FROM p_score');
        $rep->setFetchMode(PDO::FETCH_CLASS, 'modelUser');
        $tab_line = $rep->fetchAll();
        return $tab_line;
    }

    public static function getBestLines()
    {
        $rep = Model::getPDO()->query('SELECT * FROM p_bestScore');
        $rep->setFetchMode(PDO::FETCH_CLASS, 'modelUser');
        $tab_line = $rep->fetchAll();
        return $tab_line;
    }

    public static function getAllLinesAux()
    {
        $u1 = new modelUser(1, "Jean", 1021);
        $u2 = new modelUser(4, "Yavé", 1024);
        $u3 = new modelUser(3, "Jhon deuf", 10245);
        $u4 = new modelUser(2, "Poil", 10221);
        $tab_line = array($u1, $u2, $u3, $u4);
        return $tab_line;
    }

    private static function addToTab(array &$tab, modelUser $var)
    {
        if (empty($tab)) array_push($tab, new userStats($var->getPseudo(), $var->getScore()));

        foreach ($tab as $val) {

            if ($var->getPseudo() == $val->getPseudo()) {
                $val->addToScore($var->getScore());
            }
        }
        array_push($tab, new userStats($var->getPseudo(), $var->getScore()));
    }

    public static function GetAllStats()
    {
        $tab = self::getAllLinesAux();
        $user_tab = array();
        return self::arrayUserToUserStats($user_tab, $tab);
    }

    public static function GetBestStats()
    {
        $tab = self::getBestLines();
        $user_tab = array();
        return self::arrayUserToUserStats($user_tab, $tab);
    }
    private static function arrayUserToUserStats(array &$user_tab, array &$tab)
    {
        foreach ($tab as $user) {
            self::addToTab($user_tab, $user);
        }
        return $user_tab;
    }
}
