<?php

header('Content-Type: application/json');

$con = mysqli_connect('localhost', 'root', '', 'zero_hero');

if (mysqli_connect_errno()) {
    echo json_encode(array("error" => "Connection failed"));
    exit();
}

$username = $_POST["name"];
$password = $_POST["password"];

$nameCheckQuery = "SELECT * FROM user WHERE email=?";
$stmt = mysqli_prepare($con, $nameCheckQuery);
mysqli_stmt_bind_param($stmt, "s", $username);
mysqli_stmt_execute($stmt);
$result = mysqli_stmt_get_result($stmt);

if (!$result) {
    echo json_encode(array("error" => "Name check query failed"));
    exit();
}

if (mysqli_num_rows($result) != 1) {
    echo json_encode(array("error" => "Email not found"));
    exit();
}

$existingInfo = mysqli_fetch_assoc($result);

$loginHash = password_verify($password, $existingInfo["password"]);

if (!$loginHash) {
    echo json_encode(array("error" => "Incorrect password"));
} else {
    echo json_encode(array("success" => "Login successful", "data" => $existingInfo));
}

mysqli_close($con);
?>
