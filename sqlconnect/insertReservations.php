<?php

header('Content-Type: application/json');

$con = mysqli_connect('localhost', 'root', '', 'zero_hero');

if (mysqli_connect_errno()) {
    echo json_encode(array("error" => "Connection failed"));
    exit();
}

$userId = $_POST["userId"];
$pointA = $_POST["pointA"];
$pointB = $_POST["pointB"];
$startDateTime = $_POST["startDateTime"];
$endDateTime = $_POST["endDateTime"];

echo json_encode(array("userId"=> $userId, "pointA" => $pointA, "pointB" => $pointB, "startDateTime" => $startDateTime, "endDateTime" => $endDateTime));

// Insert the reservation into the table
$insertReservationQuery = "INSERT INTO reservations (user_id, point_a, point_b, start_date_time, end_date_time) VALUES (?, ?, ?, ?, ?)";
$stmt = mysqli_prepare($con, $insertReservationQuery);
mysqli_stmt_bind_param($stmt, "sssss", $userId, $pointA, $pointB, $startDateTime, $endDateTime);
$result = mysqli_stmt_execute($stmt);

if (!$result) {
    echo json_encode(array("error" => "Insert reservation query failed"));
} else {
    echo json_encode(array("success" => "reservation placed successfully"));
}

mysqli_close($con);
?>
