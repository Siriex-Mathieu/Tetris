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

        static function sorting($a, $b){
            return -($a->tab_score[0]-$b->tab_score[0]);
        }
    }


?>