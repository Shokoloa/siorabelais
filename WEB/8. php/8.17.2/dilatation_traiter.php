<html>

<body>
    Durée écoulée sur la terre =
    <?php
    $C = 300000;
    $v = $_GET["vitesse"];
    $t = $_GET["duree"];

    $DureeSurTerre = $t / sqrt(1 - (pow($v, 2) / pow($C, 2)));
    echo $DureeSurTerre
    ?>
</body>

</html>