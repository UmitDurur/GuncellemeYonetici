<?php 
header('Content-Type: application/json');
//$apiArgArray=explode("/", substr(@$_SERVER['REQUEST_URI'], 1));
/*if($_GET["request"]===""||$_GET["request"]==" "){$html = file_get_contents('http://umit.abitekno.com/404.html'); echo $html;
}else{*/
	include('baglanti.php');
	switch (@$_SERVER['REQUEST_METHOD']) {
		case 'POST':/*
		$idSorgusu=$baglan->query("select ver.id from app_versions as ver inner join applications as uyg on ver.namespace=uyg.namespace where ver.namespace='$namespace' and ver.versiyon='$versiyon' ORDER BY ver.id asc");
		if($idSorgusu->num_rows>0){
			while($satir=$idSorgusu->fetch_assoc())
				$baslamaid=$satir['id'];
		}

		$sonucSorgusu=$baglan->query("select * from app_versions as ver inner join applications as uyg on ver.namespace=uyg.namespace where ver.namespace='$namespace' and ver.id>$baslamaid and guncelleme_durumu=1 order by ver.id asc");
		if($sonucSorgusu->num_rows>0){
			while ($satir=$sonucSorgusu->fetch_assoc()){
				$array[]= array(
					'versiyon' => $satir["versiyon"],
					'paketSayisi' => $satir["paket_sayisi"],
					'zorunlu'=>$satir["zorunlu"],
					'guncellemeNotu' => $satir["guncelleme_notu"],
					);
			}
		}*/
	$decodedText = html_entity_decode($_GET["request"]);
	$degisken=json_decode($decodedText,true);
		$isim=$degisken["UygulamaAdi"];
		$namespace=$degisken["Namespace"];
		$sonucSorgusu=$baglan->query("INSERT INTO `applications`( `isim`, `namespace`) VALUES('$isim','$namespace')");
		echo json_encode($sonucSorgusu);
			break;

			case 'GET':
		$sonucSorgusu=$baglan->query("select * from applications as uyg order by uyg.id asc");
		if($sonucSorgusu->num_rows>0){
			while ($satir=$sonucSorgusu->fetch_assoc()){
				$array[]= array(
					'id' => $satir["id"],
					'Namespace' => $satir["namespace"],
					'UygulamaAdi'=>$satir["isim"],
					);
			}
			echo json_encode($array);
		}
			break;
			case 'PATCH':
			$decodedText = html_entity_decode($_GET["request"]);
	$degisken=json_decode($decodedText,true);
		$isim=$degisken["UygulamaAdi"];
		$namespace=$degisken["Namespace"];
		$id=$degisken["ID"];	
		$sonucSorgusu=$baglan->query("UPDATE `applications` set `isim`='$isim', `namespace`='$namespace' where id=$id");
		echo json_encode($sonucSorgusu);
			break;
		default:
			# code...
			break;
	//}
//echo json_encode($array);
}
?>