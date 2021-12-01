<?php
    class userStats{
        private $pseudo;
        private $tab_score;
        
        public function getPseudo(){
            return $this->pseudo;
        }

        public function getTabScore(){
            return $this->pseudo;
        }

        public function addToScore($score){
            array_push($tab_score,$score);
        }
    }


?>