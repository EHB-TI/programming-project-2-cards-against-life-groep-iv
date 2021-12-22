<?php

    if (isset($_POST["id_user"]) && !empty($_POST["id_user"]) &&  //check if variabeles are not empty
    isset($_POST["code"]) && !empty($_POST["code"]) && isset($_POST["public"]) && !empty($_POST["public"])
    && isset($_POST["open"]) && !empty($_POST["open"])){

        createRoom($_POST["id_user"], $_POST["code"], $_POST["public"], $_POST["open"]);
    }

    function createRoom($id_user, $code, $public ,$open){
        $url = 'localhost:3000/rooms';
        // Setup request to send json via POST
        $data = array(
            "id_user"=> $id_user,
            "code"=> $code,
            "pub"=>$public,
            "open"=>$open
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