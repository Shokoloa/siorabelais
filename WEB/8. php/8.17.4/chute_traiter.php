<html>

<body>
    <table border="2">
        <tr>
            <td>t écoulé (s)</td>
            <td>Vitesse acquise (m/s)</td>
            <td>Distance parcourue (mètres)</td>
        </tr>
        <?php
        $g = $_GET["g"];
        $t = $_GET["t"];

        for ($time = 0; $time <= $t; $time++) {
            $y = ($g * pow($time, 2)) / 2;
            $v = $g * $time;

            echo "<tr><td>$time</td><td>$v</td><td>$y</td></tr>";
        }
        ?>
    </table>
</body>

</html>