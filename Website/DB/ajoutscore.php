<?php

$username = $_POST["username"];
$score = $_POST["score"];

require_once "../lib/file.php";

require_once File::build_path(array("model", "model.php"));

try{
    $sql = "INSERT INTO p_score (pseudo,score) VALUES (?,?)";
    $req_prep = Model::getPDO()->prepare($sql);
    $req_prep->bindParam(1,$username);
    $req_prep->bindParam(2,$score);
    $req_prep->execute();
}
catch(Throwable $t){
    echo "Erreur :" . $t ;
}
?>