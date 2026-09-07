<html>

<body>
    <?php
    $targetRow = $_GET["rang"];

    // U0 = 2
    $x = $_GET["value"];

    for ($n = 0; $n <= $targetRow; $n++) {
        echo "U$n = $x <br>";

        // Un+1 = Un / 4 + 2
        $x = $x / 4 + 2;
    }
    ?>
</body>

</html>