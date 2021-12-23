<?php

        //Author: De Vogel Ryan

        //Source: https://github.com/herbou/Tuto_Unity_SendDataToServer
        include_once("db.php");

        if (isset($_POST["username"]) && !empty($_POST["username"]) && //check if variabeles are not empty
	    isset($_POST["password"]) && !empty($_POST["password"])){
            
            Login($_POST["username"], $_POST["password"]);
	    }
        else {
            exit();
            http_response_code(500);
        }

        function Login($username, $password){
            GLOBAL $con;
            $namecheckquery = "SELECT id_user FROM Users WHERE username=? AND password=?";//match the given data with the database
            $selectQuery=$con->prepare($namecheckquery);
            $selectQuery->execute(array($username, sha1($password)));//Sha1 is a hashing algoritm
            $all=$selectQuery->fetchAll(PDO::FETCH_COLUMN, 0);//get the results of query
            if (count($all) == 1){//We check if the the resulst is succes which means the user exists
                echo($all[0]);
                exit();//quit the program login is succesfull
                http_response_code(200);
            }
            else {
                http_response_code(500);
            }


        }
?>