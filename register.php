<?php

    $con =  mysqli_connect('localhost', 'ryan', '1235', 'programming_project');
    if(mysqli_connect_errno()){
        http_response_code(500);
        die();
    }
    // Turn off all error reporting so that users don't get what's behind the scenes.
    error_reporting(0); 
    
    $username = $_POST["name"];
    $password = $_POST["password"];

    isset($_POST['name']) ? $_POST['password']: '';

    if(strlen($username) < 4){
        http_response_code(500);
        die();
    }

    if(strlen($password) < 8){
        http_response_code(500);
        die();
    }

    $result = $con->prepare("SELECT username FROM users WHERE username = ?");
    $result->bind_param("s", $username);
    $result->execute();
    $found = $result->fetch();                        
    $result->close();

    if ($found){        
        echo "User already exists!";   
        http_response_code(500);                                       
    } else {
        $options = [
            'cost' => 12,
        ];
        $newPassword = $password;
        $newPassword = password_hash($newPassword, PASSWORD_BCRYPT, $options);
        $register = $con->prepare("INSERT INTO users (username, password) VALUES (?, ?)");
        $register->bind_param("ss", $username, $newPassword);
        $register->execute();
        $register->close(); 

    }

    echo("0");
?>