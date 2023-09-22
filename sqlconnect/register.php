<?php

header('Content-Type: application/json');

$con = mysqli_connect('localhost', 'root', '', 'zero_hero');

if (mysqli_connect_errno()) {
    echo json_encode(array("error" => "Connection failed"));
    exit();
}

$username = $_POST["name"];
$email = $_POST["email"];
$function = $_POST["function"];
$password = $_POST["password"];
$role = implode(',', ['["ROLE_USER"]']);

echo json_encode(array("name" => $username, "email" => $email, "function" => $function, "password" => $password));


 // Check if the e-mail already exists
 $emailCheckQuery = "SELECT email FROM user WHERE email=?";
 $stmt = mysqli_prepare($con, $emailCheckQuery);
 mysqli_stmt_bind_param($stmt, "s", $email);
 mysqli_stmt_execute($stmt);
 $result = mysqli_stmt_get_result($stmt);

 if (!$result) {
     echo json_encode(array("error" => "Email check query failed"));
     exit();
 }

 if (mysqli_num_rows($result) > 0) {
     echo json_encode(array("error" => "Email already exists"));
     exit();
 }

 // Encrypts password
 $encryptedPassword = password_hash($password, PASSWORD_DEFAULT);

 // Insert the user into the table
 $insertUserQuery = "INSERT INTO user (email, roles, password, function, full_name) VALUES (?, ?, ?, ?, ?)";
 $stmt = mysqli_prepare($con, $insertUserQuery);
 mysqli_stmt_bind_param($stmt, "sssss", $email, $role, $encryptedPassword, $function, $username);
 $result = mysqli_stmt_execute($stmt);

 if (!$result) {
     echo json_encode(array("error" => "Insert user query failed"));
 } else {
     echo json_encode(array("success" => "User registered successfully"));
 }

 mysqli_close($con);
?>
