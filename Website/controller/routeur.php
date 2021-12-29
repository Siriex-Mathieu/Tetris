<?php
$action = 'base';
require_once File::build_path(array("controller","Controller.php"));
// On recupère l'action passée dans l'URL
if(isset($_GET['action'])){
    if (in_array($_GET['action'],get_class_methods("Controller"))) {
        $action = $_GET['action'];    
    }   
    else $action = 'error';
    
}
// else{
//     $action = "base";
//     if(isset($_COOKIE["Pref"])){
//         $controller_default = $_COOKIE["Pref"];
//     }
// }

Controller::$action(); 
?> 