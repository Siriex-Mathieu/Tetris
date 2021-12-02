<?php 
    class LeaderBoard{
        public function sortTab(array &$tab){
            usort($tab,"sorting");
        }
    }

?>