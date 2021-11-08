<?php 
header('Content-Type: application/json');
//$apiArgArray=explode("/", substr(@$_SERVER['REQUEST_URI'], 1));
/*if($_GET["request"]===""||$_GET["request"]==" "){$html = file_get_contents('http://umit.abitekno.com/404.html'); echo $html;
}else{*/
	include('baglanti.php');
	switch (@$_SERVER['REQUEST_METHOD']) {
		case 'POST':	
	$decodedText = html_entity_decode($_GET["request"]);
	$degisken=json_decode($decodedText,true);
		$versiyon=$degisken["Versiyon"];
		$namespace=$degisken["Namespace"];
		$paketSayisi=$degisken["PaketSayisi"];
		$zorunlu=$degisken["Zorunlu"];
		$guncellemeNotu=$degisken["GuncellemeNotu"];
		$guncellemeDurumu=$degisken["GuncellemeDurumu"];

		$sonucSorgusu=$baglan->query("INSERT INTO `app_versions`( `namespace`, `versiyon`, `paket_sayisi`, `guncelleme_notu`, `zorunlu`, `guncelleme_durumu`) VALUES ('$namespace','$versiyon',$paketSayisi,'$guncellemeNotu',$zorunlu,$guncellemeDurumu)");
		echo json_encode($sonucSorgusu);
			break;

			case 'GET':
				$apiArgArray=explode("/", $_GET["request"]);
	$namespace=$apiArgArray[0];
		$sonucSorgusu=$baglan->query("select * from app_versions where namespace='$namespace' order by id asc");
		if($sonucSorgusu->num_rows>0){
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

			echo json_encode($array);
		}
			break;	
			case 'DELETE':
			$apiArgArray=explode("/", $_GET["request"]);
			$id=$apiArgArray[0];
			$sonucSorgusu=$baglan->query("DELETE from `app_versions` where `id`=$id");
		echo json_encode($sonucSorgusu);
			break;
		default:
			# code...
			break;
	//}
//echo json_encode($array);
}
?>