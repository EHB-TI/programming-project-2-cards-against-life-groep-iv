<?php

    if (isset($_POST["answer"]) && !empty($_POST["answer"]) &&  //check if variabeles are not empty
    isset($_POST["question"]) && !empty($_POST["question"])){

        createFriends($_POST["answer"], $_POST["question"]);
    }

    function createFriends($answer, $question){
        $url = 'localhost:3000/community';
        // Setup request to send json via POST
        $data = array(
            "answer"=> $answer,
            "question"=>$question
        );

        $data_string = json_encode($data);

        $ch = curl_init($url);

        curl_setopt($ch, CURLOPT_POSTFIELDS, $data_string);

        curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type:application/json'));

        curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

        $result = curl_exec($ch);

        curl_close($ch);

        echo "$result";
    }

?>