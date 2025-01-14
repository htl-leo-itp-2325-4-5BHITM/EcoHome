<?php
// database_handler.php
$servername = "127.0.0.1";
$username = "EcoHome";
$password= "EcoHome";
$dbname = "EcoHome";

// Get POST data 
$sname= $_POST['name'] ?? null;
$score = $_POST['score'] ?? null;

if ($score) {
    try {
        // Create connection
        $conn = new mysqli($servername, $username, $password, $dbname);

        // Check connection
        if ($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }

        // Insert into table
        $stmt = $conn->prepare("INSERT INTO punkte (sname, score) VALUES (?,?)");
        $stmt->bind_param("si", $score);

        if ($stmt->execute()) {
            echo json_encode(["success" => true, "message" => "Data inserted successfully."]);
        } else {
            echo json_encode(["success" => false, "message" => "Failed to insert data."]);
        }

        $stmt->close();
        $conn->close();
    } catch (Exception $e) {
        echo json_encode(["success" => false, "message" => "Error: " . $e->getMessage()]);
    }
} else {
    echo json_encode(["success" => false, "message" => "Invalid data."]);
}
?>