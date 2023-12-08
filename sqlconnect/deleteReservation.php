<?php
header('Content-Type: application/json');
$con = mysqli_connect('localhost', 'root', '', 'zero_hero');
if (mysqli_connect_errno()) {
    echo json_encode(array("error" => "Connection failed: " . mysqli_connect_error()));
    exit();
}
$idToDelete = $_POST["id"];
$deleteQuery = "DELETE FROM reservations WHERE id = $idToDelete";
if (mysqli_query($con, $deleteQuery)) {
    // Check if any rows were affected (i.e., if the ID existed and was deleted)
    if (mysqli_affected_rows($con) > 0) {
        echo json_encode(array("success" => "Record with ID $idToDelete deleted successfully"));
    } else {
        echo json_encode(array("error" => "Record with ID $idToDelete not found"));
    }
} else {
    echo json_encode(array("error" => "Delete query failed: " . mysqli_error($con)));
}
mysqli_close($con);
?>
