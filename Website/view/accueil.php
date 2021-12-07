<?php
foreach ($tab_v as $v)
    echo ' 
        <div class="d-md-flex flex-fill align-items-center align-items-md-center" style="height: 3em;margin: 7px;background: #e6e6e6;border-width: 1.4px;border-style: none;border-radius: 60px;">
            <div class="d-md-flex justify-content-md-start" style="width: 33%;"><span style="padding: 1em;">'. $v['Rank'] .'</span></div>
            <div style="width: 33%;"><span class="d-md-flex justify-content-md-center">'. htmlspecialchars($v['Pseudo']) .' </span></div>
            <div style="width: 33%;"><span class="d-md-flex justify-content-md-end" style="padding-right: 1em;">  '. $v['Score'] .' </span></div>
        </div>
        ';?>
        <!-- TODO mettre ce lien du dossier à download -->
<button href="" class="btn btn-primary d-md-flex mx-auto" data-bss-hover-animate="pulse" id="button1" type="button"><img style="width: 20px;height: 20px;transform: rotate(270deg) translateX(-2px);" src="assets/img/arrowwhite.gif"><span><strong>Télecharger</strong></span><img style="width: 20px;height: 20px;transform: rotate(90deg) translateX(2px);" src="assets/img/arrowwhite.gif"></button>
    <script src="assets/js/bs-init.js"></script>

        <!-- https://openclassrooms.com/fr/courses/1603881-apprenez-a-creer-votre-site-web-avec-html5-et-css3/1604646-creez-des-liens#/id/r-1609721 -->