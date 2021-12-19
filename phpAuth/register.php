<?php

        //Author: De Vogel Ryan

        //Source: https://github.com/herbou/Tuto_Unity_SendDataToServer
        include_once("db.php");

        if (isset($_POST["username"]) && !empty($_POST["username"]) &&  //check if variabeles are not empty
        isset($_POST["password"]) && !empty($_POST["password"])){
        
            Register($_POST["username"], $_POST["password"]);
        }
        else {
            exit(); //exit(): means end server connection (don't execute the rest)
            http_response_code(500);
        }

        function Register($username, $password){
            GLOBAL $con;
            // check if name exists
            $namecheckquery = "SELECT username FROM Users WHERE username=?";//check if user already exists with preparedStatements
            
            $selectQuery=$con->prepare($namecheckquery);
            $selectQuery->execute(array($username));
            $all=$selectQuery->fetchAll();//get the results of query
            if (count($all) == 1){ //We check if the the resulst is succes which means the user exists
                http_response_code(500);
            }
            else {
                $createUser = "INSERT INTO Users (username, password, level) VALUES (?,?,?);";//make new user with preparedStatements
                $insertQuery= $con->prepare($createUser);
                $insertQuery->execute(array($username, sha1($password), 0));//Sha1 is a hashing algoritm
            }

        }
    
?>