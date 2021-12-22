<?php   
    $host   = "mysql:host=dt5.ehb.be;dbname=2122AntonLouf";
	$user   = "2122AntonLouf";
	$pass   = "R8Y4a!k";
	try{
		$con = new PDO($host,$user, $pass);
		$con->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}catch(PDOException $e){ echo $e.getMessage(); }
?>