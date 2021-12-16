<?php

    $con =  mysqli_connect('localhost', 'ryan', '1235', 'programming_project');
    if(mysqli_connect_errno()){
        http_response_code(500);
        die();
    }

    $username = $_POST["username"];
    $password = $_POST["password"];

////////////////
    $result = $con->prepare("SELECT username,salt,hash,score FROM users WHERE username = ?");
    $result->bind_param("s", $username);
    $result->execute();
    $found = $result->fetch();                        
    $result->close();


    if ($found){      
        if(password_verify($password, $found['password'])){
            echo("logged in!");
        }else {
            http_response_code(500);
        }             
    } else {
        http_response_code(500);
    }

?>