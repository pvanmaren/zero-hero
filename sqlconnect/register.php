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
$role = ["ROLE_USER"];

echo json_encode(array("name" => $username, "email" => $email, "function" => $function, "password" => $password));

exit();

// // Check if the username already exists
// $nameCheckQuery = "SELECT username FROM users WHERE username=?";
// $stmt = mysqli_prepare($con, $nameCheckQuery);
// mysqli_stmt_bind_param($stmt, "s", $username);
// mysqli_stmt_execute($stmt);
// $result = mysqli_stmt_get_result($stmt);

// if (!$result) {
//     echo json_encode(array("error" => "Name check query failed"));
//     exit();
// }

// if (mysqli_num_rows($result) > 0) {
//     echo json_encode(array("error" => "Username already exists"));
//     exit();
// }

// // Encrypts password
// $encryptedPassword = password_hash($password, PASSWORD_DEFAULT);

// // Insert the user into the table
// $insertUserQuery = "INSERT INTO users (email, roles, password, function, full_name) VALUES (?, ?, ?, ?, ?)";
// $stmt = mysqli_prepare($con, $insertUserQuery);
// mysqli_stmt_bind_param($stmt, "sss", $email, $role, $encryptedPassword, $function, $username);
// $result = mysqli_stmt_execute($stmt);

// if (!$result) {
//     echo json_encode(array("error" => "Insert user query failed"));
// } else {
//     echo json_encode(array("success" => "User registered successfully"));
// }

// mysqli_close($con);
?>
