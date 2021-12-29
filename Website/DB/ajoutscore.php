<?php

$username = $_POST["username"];
$score = $_POST["score"];

require_once "../lib/file.php";

require_once File::build_path(array("model", "model.php"));

try{
    $sql = "INSERT INTO p_score (pseudo,score) VALUES (':username',':score')";
    $req_prep = Model::getPDO()->prepare($sql);
    $values = array(
        "username" => $username,
        "score" => $score
    );
    $req_prep->execute($values);
}
catch(Throwable $t){
    echo "Erreur :" . $t ;
}
?>