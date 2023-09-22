<?php

header('Content-Type: application/json');

$con = mysqli_connect('localhost', 'root', '', 'zero_hero');

if (mysqli_connect_errno()) {
    echo json_encode(array("error" => "Connection failed"));
    exit();
}

$pointA = $_POST["pointA"];
$pointB = $_POST["pointB"];
$startDateTime = $_POST["startDateTime"];
$endDateTime = $_POST["endDateTime"];

echo json_encode(array("pointA" => $pointA, "pointB" => $pointB, "startDateTime" => $startDateTime, "endDateTime" => $endDateTime));

// Insert the reservation into the table
$insertReservationQuery = "INSERT INTO reservations (pointA, pointB, startDateTime, endDateTime) VALUES (?, ?, ?, ?)";
$stmt = mysqli_prepare($con, $insertReservationQuery);
mysqli_stmt_bind_param($stmt, "ssss", $pointA, $pointB, $startDateTime, $endDateTime);
$result = mysqli_stmt_execute($stmt);

if (!$result) {
    echo json_encode(array("error" => "Insert reservation query failed"));
} else {
    echo json_encode(array("success" => "reservation placed successfully"));
}

mysqli_close($con);
?>
