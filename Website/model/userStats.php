<?php
    class userStats{
        private $pseudo;
        private $tab_score ;
        
        public function getPseudo(){
            return $this->pseudo;
        }

        public function getTabScore(){
            return $this->tab_score;
        }

        function __construct($pseudo,$score){
            $this->pseudo = $pseudo;
            $this->tab_score= array($score);
        }

        public function addToScore($score){
            array_push($this->tab_score,$score);
        }

        public function sort(){
            sort($this->tab_score);
        }

        public static function sorting($a, $b){
            return $a->getTabScore()[0]-$b->getTabScore()[0];
        }
    }


?>