<?php
$database = "world";
    $host = "localhost";
    $dbuser = "normalkullanici";
    $dbpass = "163650828";
    $baglan = new mysqli($host,$dbuser,$dbpass,$database);
if($baglan->connect_error){ die("Mysql Baglantisi Yapilamadi:".$baglan->connect_error);
}
    $baglan->query("SET NAMES UTF8");
?>