<?php
// database_handler.php
$servername = "https://phpmyadmin.blauregen.dev";
$username = "EcoHome";
$password= "ITPLeonding2425EcoHome";
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
        $stmt->bind_param("score", $score);
        $stmt->bind_param("sname", $sname);


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