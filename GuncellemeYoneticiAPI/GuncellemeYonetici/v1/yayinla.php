<?php 
header('Content-Type: application/json');
//$apiArgArray=explode("/", substr(@$_SERVER['REQUEST_URI'], 1));
/*if($_GET["request"]===""||$_GET["request"]==" "){$html = file_get_contents('http://umit.abitekno.com/404.html'); echo $html;
}else{*/
	include('baglanti.php');
	switch (@$_SERVER['REQUEST_METHOD']) {
					case 'POST':
				$apiArgArray=explode("/", $_GET["request"]);
	$id=$apiArgArray[0];
	$durum=$apiArgArray[1];
		$sonucSorgusu=$baglan->query("UPDATE `app_versions` SET `guncelleme_durumu`=$durum WHERE `id`=$id");
		/*if($sonucSorgusu->num_rows>0){
			while ($satir=$sonucSorgusu->fetch_assoc()){
				$array[]= array(
					'versiyon' => $satir["versiyon"],
					'paketSayisi' => $satir["paket_sayisi"],
					'zorunlu'=>$satir["zorunlu"],
					'guncellemeNotu' => $satir["guncelleme_notu"],
					'guncellemeDurumu'=>$satir["guncelleme_durumu"],
					'id'=>$satir["id"],
					
					);
		}
			}*/

			echo json_encode($sonucSorgusu);
			break;
		default:
			# code...
			break;
	//}
//echo json_encode($array);
}
?>