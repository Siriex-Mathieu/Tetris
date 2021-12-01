<?php
$action = 'base';
require_once File::build_path(array("controller","ControllerConnect.php"));
// On recupère l'action passée dans l'URL
if(isset($_GET['action'])){
    if (in_array($_GET['action'],get_class_methods("ControllerConnect"))) {
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

ControllerConnect::$action(); 
?> 