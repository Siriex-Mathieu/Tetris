<?php
   require_once File::build_path(array("model",'model.php'));
   require_once File::build_path(array("model","userStats.php"));
    class modelUser{
        private $idScore;
        private $pseudo;
        private $score;

        public function getPseudo(){
            return $this->pseudo;
        }
        public function getScore(){
            return $this->score;
        }
    
        public static function getLines(){
            $rep = Model::getPDO()->query('SELECT idScore FROM p_score');
            $rep->setFetchMode(PDO::FETCH_CLASS, 'modelUser');
            $tab_line = $rep->fetchAll();
            return $tab_line;
        }

        private static function inUserTab( array &$tab,$var){
            foreach($tab as $val){
                if($var::getPseudo() == $val::getPseudo()) return true;
            }
            return false;
        }

        private static function addToTab(array &$tab,modelUser $var){
            foreach($tab as $val){
                
                if($var->getPseudo() == $val->getPseudo()){
                    $val->addToScore($var->getScore());
                }
            }
            array_push($tab,new userStats($var->getPseudo(),$var->getScore()));
        }

        public static function GetAllStats(){
            $tab = self::getLines();
            $user_tab = array();
            foreach($tab as $user){
                self::addToTab($user_tab,$user);
            }
            return $user_tab;
        }
    }



?>