<?php
foreach ($tab_v as $v)
    echo ' 
        <div class="d-md-flex flex-fill align-items-center align-items-md-center" style="height: 3em;margin: 7px;background: #e6e6e6;border-width: 1.4px;border-style: none;border-radius: 60px;">
            <div class="d-md-flex justify-content-md-start" style="width: 33%;"><span style="padding: 1em;">'. $v['Rank'] .'</span></div>
            <div style="width: 33%;"><span class="d-md-flex justify-content-md-center">'. htmlspecialchars($v['Pseudo']) .' </span></div>
            <div style="width: 33%;"><span class="d-md-flex justify-content-md-end" style="padding-right: 1em;">  '. $v['Score'] .' </span></div>
        </div>
        ';?>