<?php	switch (@$_SERVER['REQUEST_METHOD']) {
					case 'PUT':
		$sonucSorgusu="PUT";

			echo json_encode($sonucSorgusu);
			break;
			case 'POST':
		$sonucSorgusu="POST";

			echo json_encode($sonucSorgusu);
			break;
			case 'DELETE':
		$sonucSorgusu="DELETE";

			echo json_encode($sonucSorgusu);
			break;
			case 'PATCH':
		$sonucSorgusu="PATCH";

			echo json_encode($sonucSorgusu);
			break;
		default:
			# code...
			break;
			}?>