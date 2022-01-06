<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>
        <?php
            echo $pagetitle; 
        ?>
    </title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.min.css">
    <?php
        foreach (glob("assets/*/*/*.css") as $css) {
            echo "<link rel='stylesheet' href='$css'>\n";
        }
        foreach (glob("assets/*/*.css") as $css) {
            echo "<link rel='stylesheet' href='$css'>\n";
        }
        foreach (glob("assets/*.css") as $css) {
            echo "<link rel='stylesheet' href='$css'>\n";
        }
    ?>
   
</head>

<body>
    <nav class="navbar navbar-light navbar-expand-lg navigation-clean-search">
        <div class="container">
            <a class="navbar-brand" href="#">Accueil</a>
            <button data-bs-toggle="collapse" class="navbar-toggler" data-bs-target="#navcol-1">
                <span class="visually-hidden">Toggle navigation</span>
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navcol-1">
                <ul class="navbar-nav">
                    <li class="nav-item"><a class="nav-link" href="#">Tableau des scores</a></li>
                    <li class="nav-item"><a class="nav-link" href="#">Téléchargement</a></li>
                </ul>
                <form class="me-auto search-form" target="_self">
                    <div class="d-flex align-items-center">
                        <label class="form-label d-flex mb-0" for="search-field">
                            <i class="fa fa-search"></i>
                        </label>
                        <input class="form-control search-field" type="search" id="search-field" name="search">
                    </div>
                </form><a class="btn btn-light action-button" role="button" href="#">Action </a>
            </div>
        </div>
    </nav>
    <?php
    $filepath = File::build_path(array("view", $controller, "$view.php"));
    require $filepath;
    ?>
    <footer class="footer-basic">
        <div class="social">
            <a href="#">
                <i class="icon ion-social-instagram"></i>
            </a>
            <a href="#">
                <i class="icon ion-social-snapchat"></i>
            </a>
            <a href="#">
                <i class="icon ion-social-twitter"></i>
            </a>
            <a href="#">
                <i class="icon ion-social-facebook"></i>
            </a>
        </div>
        <ul class="list-inline">
            <li class="list-inline-item"><a href="#">Accueil</a></li>
            <li class="list-inline-item"><a href="#">Financement</a></li>
            <li class="list-inline-item"><a href="#">Qui nous sommes</a></li>
            <li class="list-inline-item"><a href="#">CGU & RGPD</a></li>
        </ul>
        <p class="copyright">Entreprise qui claque © 2021</p>
    </footer>
</body>

</html>