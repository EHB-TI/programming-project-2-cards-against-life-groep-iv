<?php   
    $host   = "...";
	$user   = "...";
	$pass   = "...";
	try{
		$con = new PDO($host,$user, $pass);
		$con->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}catch(PDOException $e){ echo $e.getMessage(); }
?>