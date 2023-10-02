<?php
// Set the response content type to JSON
header('Content-Type: application/json');

// Establish a database connection
$con = mysqli_connect('localhost', 'root', '', 'zero_hero');

// Check for database connection errors
if (mysqli_connect_errno()) {
    echo json_encode(array("error" => "Connection failed: " . mysqli_connect_error()));
    exit();
}

$userId = $_POST["userId"];
$currentDateTime = date("d-m-Y H:i"); // Get the current date and time

// Define the SQL query to fetch upcoming reservations based on start_date_time
$nameCheckQuery = "SELECT * FROM reservations WHERE user_id = $userId AND STR_TO_DATE(start_date_time, '%d-%m-%Y %H:%i') > '$currentDateTime' ORDER BY STR_TO_DATE(start_date_time, '%d-%m-%Y %H:%i')";

// Execute the SQL query
$result = mysqli_query($con, $nameCheckQuery);


// Check for SQL query execution errors
if (!$result) {
    echo json_encode(array("error" => "Query failed: " . mysqli_error($con)));
    exit();
}

// Initialize an array to hold the fetched data
$data = array();

// Fetch rows from the result set and add them to the data array
while ($row = mysqli_fetch_assoc($result)) {
    $data[] = $row;
}

// Check if any data was found
if (empty($data)) {
    echo json_encode(array("error" => "No upcoming reservations found"));
} else {
    // Return success and the data as JSON
    echo json_encode(array("success" => "Success", "data" => $data));
}

// Close the database connection
mysqli_close($con);
?>
