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

// Define the SQL query to fetch start_date_time from the reservations table
$nameCheckQuery = "SELECT start_date_time FROM reservations";

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
    echo json_encode(array("error" => "No data found"));
} else {
    // Return success and the data as JSON
    echo json_encode(array("success" => "Success", "data" => $data));
}

// Close the database connection
mysqli_close($con);
?>
