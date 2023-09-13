<?php

header('Content-Type: application/json');

$con = mysqli_connect('localhost', 'root', '', 'zero_hero');

if (mysqli_connect_errno()) {
    echo json_encode(array("error" => "Connection failed"));
    exit();
}

$username = $_POST["name"];
$password = $_POST["password"];

// Check if the username already exists
$nameCheckQuery = "SELECT username FROM users WHERE username=?";
$stmt = mysqli_prepare($con, $nameCheckQuery);
mysqli_stmt_bind_param($stmt, "s", $username);
mysqli_stmt_execute($stmt);
$result = mysqli_stmt_get_result($stmt);

if (!$result) {
    echo json_encode(array("error" => "Name check query failed"));
    exit();
}

if (mysqli_num_rows($result) > 0) {
    echo json_encode(array("error" => "Username already exists"));
    exit();
}

// Generate a secure salt and hash the password
$salt = '$5$rounds=5000$' . 'steamedhams' . $username . '$';
$hash = crypt($password, $salt);

// Insert the user into the table
$insertUserQuery = "INSERT INTO users (username, hash, salt) VALUES (?, ?, ?)";
$stmt = mysqli_prepare($con, $insertUserQuery);
mysqli_stmt_bind_param($stmt, "sss", $username, $hash, $salt);
$result = mysqli_stmt_execute($stmt);

if (!$result) {
    echo json_encode(array("error" => "Insert user query failed"));
} else {
    echo json_encode(array("success" => "User registered successfully"));
}

mysqli_close($con);
?>
